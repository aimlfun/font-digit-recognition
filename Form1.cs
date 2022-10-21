using Digits.AI;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Text;

namespace Digits
{
    /// <summary>
    /// Not exactly a new concept, but that doesn't make it invalid.
    /// We train the AI based on low resolution fonts, some of which
    /// are quite unreadable to humans at that size.
    /// 
    /// This simple back propagated NN manages it with 100% accuracy on 
    /// all digits for the 300 fonts. 
    /// 
    /// One could argue, but Dave you've got clear images. Well no. They 
    /// are anti-aliased, and some are wierd shapes. You could argue I
    /// didn't train on 80% and test on the remaining 20%. The response to
    /// that is, well why would I do that? I wanted the AI to do it with
    /// 100% accuracy, and that's what it does. There is no overtraining.
    /// 
    /// You might ask why didn't I use the NIST images. Simply because I had
    /// no desire to. Once I saw the 14x14 digit images, I was happy it proves
    /// the point I wished to make - it recognises them accurately despite the
    /// less conformant fonts.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// This is where we save / load our AI model from.
        /// </summary>
        const string c_aiModelFilePath = @"c:\temp\Digits.ai";

        /// <summary>
        /// Tracks the digit and its associated image.
        /// </summary>
        readonly Dictionary<int, List<DigitToOCR>> digitsToOCR = new();

        /// <summary>
        /// The brains of the operation - our neural network.
        /// </summary>
        readonly NeuralNetwork networkGuessTheDigit;

        int testDigit = 0;

        Point lastHandDrawn = new(-1, -1);

        /// <summary>
        /// Constructor.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // 14x14 works with below for 300 fonts: 30,30,30
            int[] layers = new int[5] { 14 * 14, 30, 30, 30, 1 };

            // How did I arrive at 5 layers (input, 3x hidden, output) and their sizes?
            // The input and output were no brainers. I wanted all 14x14px (the image of the digit) as the input.
            // I chose to encode the output as 1/10*digit.
            // That left the hidden layers to be decided, and that was a little trial and error. It can achieve with far
            // less neurons, but depending on the random initialised biases & weights, it may not train despite the
            // large number of iterations. In the end I went for increasing the layers, and this gave a reliable
            // result.

            // Although we can use different activation functions, the best success has been with TanH.
            ActivationFunctions[] activationFunctions = new ActivationFunctions[6] { ActivationFunctions.TanH,
                                                                                     ActivationFunctions.TanH,
                                                                                     ActivationFunctions.TanH,
                                                                                     ActivationFunctions.TanH,
                                                                                     ActivationFunctions.TanH,
                                                                                     ActivationFunctions.TanH };

            networkGuessTheDigit = new(0, layers, activationFunctions, false);

            EnableDisableDigitButtons(false); // can't change whilst training
            comboBoxFont.Enabled = false; // can't choose the font whilst training
        }

 
        #region EVENT HANDLERS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Show();
            Log("Retrieving fonts...");

            RenderEachDigitForAllTheFonts();

            richTextBox1.Clear();

            // if we have a pre-trained AI, load it.
            if (File.Exists(c_aiModelFilePath))
            {
                networkGuessTheDigit.Load(c_aiModelFilePath);

                Log("Please pick a font, and digit ->");
                Log("AI model loaded from file.");
                EnableDisableDigitButtons(true);
                comboBoxFont.Enabled = true;
                return;
            }

            Train();
            Confirm100pctTrained();

            EnableDisableDigitButtons(true);
            comboBoxFont.Enabled = true;
        }

        /// <summary>
        /// User selected a different font, ask the AI to identify the digut.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFont is null) throw new Exception("comboBoxFont is null");

            int index = (comboBoxFont.SelectedIndex);

            if (index < 0) return;

#pragma warning disable CS8602 // Dereference of a possibly null reference. 
            string font = comboBoxFont.Items[index].ToString().TrimEnd('*');
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            try
            {
                double[] pixels = DigitToOCR.BitmapGetImage(testDigit, font, out Bitmap image);
                image.Dispose();
                image = DrawPixelsEnlarged(pixels, 15);

                pictureBoxAISees.Image?.Dispose();
                pictureBoxAISees.Image = image;

                labelResult.Text = ((int)Math.Round(10 * networkGuessTheDigit.FeedForward(pixels)[0])).ToString();
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Draw the image with each pixel scaled (think 1 pixeldrawn as filled square of "scale px x scale px")
        /// </summary>
        /// <param name="pixels">Monochrome data used by the AI for visual recognition.</param>
        /// <param name="scale">How big each pixel is drawn.</param>
        /// <returns></returns>
        private static Bitmap DrawPixelsEnlarged(double[] pixels, int scale)
        {
            Bitmap bitmap = new(14 * scale, 14 * scale);

            using Graphics graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            // walk down all 14x14 pixels, drawing it enlarged
            for (int y = 0; y < 14; y++)
            {
                for (int x = 0; x < 14; x++)
                {
                    int pixel = (int)Math.Round((1 - pixels[x + y * 14]) * 255); // black on white

                    using SolidBrush brush = new(Color.FromArgb(pixel, pixel, pixel));
                    graphics.FillRectangle(brush, new Rectangle(x * scale, y * scale, scale, scale));
                }
            }

            graphics.Flush();

            return bitmap; // a 14px x 14px scaled image to 14 x scale px x 14 x scale px
        }

        /// <summary>
        /// User clicks [0]...[9], and we ask the AI to guess the digit clicked in the current font.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDigit_Click(object sender, EventArgs e)
        {
            testDigit = int.Parse(((Button)sender).Text);

            ComboBoxFont_SelectedIndexChanged(sender, e);
        }

        /// <summary>
        /// Renders the NN to an image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveNNVisualisation_Click(object sender, EventArgs e)
        {
            Bitmap image = NeuralNetworkVisualiser.Render(networkGuessTheDigit, 900, 300);
            int index = (comboBoxFont.SelectedIndex);
            string font = comboBoxFont.Items[index].ToString().TrimEnd('*');
            string filename = $@"c:\temp\{font}-{testDigit}-Neural-Network.png";
            image.Save(filename);
            MessageBox.Show($"Saved to {filename}");
        }

        private void PictureBoxHandDrawn_MouseDown(object sender, MouseEventArgs e)
        {
            lastHandDrawn = new Point(-1, -1);

            Bitmap b = new(pictureBoxHandDrawn.Width, pictureBoxHandDrawn.Height);
            using Graphics g = Graphics.FromImage(b);
            g.Clear(Color.White);

            pictureBoxHandDrawn.Image = b;
            DrawOnHandDrawnImage(e.X, e.Y);

            pictureBoxHandDrawn.MouseMove += PictureBoxHandDrawn_MouseMove;
        }

        private void PictureBoxHandDrawn_MouseMove(object? sender, MouseEventArgs e)
        {
            DrawOnHandDrawnImage(e.X, e.Y);
        }

        private void PictureBoxHandDrawn_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBoxHandDrawn.MouseMove -= PictureBoxHandDrawn_MouseMove;
            PredictHandDrawnDigit();
            lastHandDrawn = new Point(-1, -1);
        }

        private void PictureBoxHandDrawn_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Cross;
        }

        private void PictureBoxHandDrawn_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        #endregion

        /// <summary>
        /// Updates a basic log (top-down).
        /// </summary>
        /// <param name="text"></param>
        private void Log(string text)
        {
            richTextBox1.Text = text + "\n" + richTextBox1.Text;
            Application.DoEvents();
        }

        private void EnableDisableDigitButtons(bool state)
        {
            foreach (Control c in Controls) if (c is Button button) button.Enabled = state;
        }

        /// <summary>
        /// Re-tests all digits x fonts for accurate result.
        /// </summary>
        private void Confirm100pctTrained()
        {
            StringBuilder sb = new(10);
            int nomatch = 0;

            for (int i = 0; i < 10; i++)
            {
                foreach (DigitToOCR digitToOCR in digitsToOCR[i])
                {
                    int output = (int)Math.Round(10 * networkGuessTheDigit.FeedForward(digitToOCR.pixelsToLearn)[0]);

                    if (output != i) ++nomatch;

                    sb.AppendLine($"{i},{output},{(output == i ? "-" : "NO MATCH")}");
                }
            }

            File.WriteAllText(@"c:\temp\results.csv", sb.ToString());

            if (nomatch > 0)
            {
                Log(sb.ToString());
                Log($"Failed match count: {nomatch}");
            }
        }

        /// <summary>
        /// Trains the AI using back propagation.
        /// </summary>
        private void Train()
        {
            Log($"# Fonts: {comboBoxFont.Items.Count} | # Digits: {10 * comboBoxFont.Items.Count}");

            for (int round = 0; round < 30000; round++)
            {
                // train
                for (int digit = 0; digit < 10; digit++)
                {
                    double[] expectedDigitEncoded0to1 = new double[] { (float)digit / 10 };

                    foreach (DigitToOCR digitToOCR in digitsToOCR[digit])
                    {
                        networkGuessTheDigit.BackPropagate(digitToOCR.pixelsToLearn, expectedDigitEncoded0to1);
                    }
                }

                // it takes around 16,000 rounds of training, so we only start checking the AI is accurate
                // after that point (otherwise it slows the training down).
                bool trained = (round > 16000);

                if (trained)
                {
                    // all are correct
                    for (int digit = 0; digit < 10; digit++)
                    {
                        foreach (DigitToOCR digitToOCR in digitsToOCR[digit])
                        {
                            if (trained)
                            {
                                int output = (int)Math.Round(10 * networkGuessTheDigit.FeedForward(digitToOCR.pixelsToLearn)[0]);

                                if (output == digit) continue;

                                trained = false;
                                break;
                            }
                        }

                        if (!trained) break; // no need to check others
                    }
                }

                if (round % 20 == 0) Log($"Epoch: {round}");

                // if it's trained we can save doing it all 20000 times
                if (trained)
                {
                    networkGuessTheDigit.Save(c_aiModelFilePath);

                    Log($"Training complete. All characters are recognised");
                    break; // no more training required, all 1024 permutations return the correct result.
                }
            }
        }

        /// <summary>
        /// Render all 10 digits (0..9) for each font.
        /// </summary>
        private void RenderEachDigitForAllTheFonts()
        {
            int numberOfFonts = 300;
            int cnt = 0;

            InstalledFontCollection col = new();

            foreach (FontFamily fa in col.Families)
            {
                // avoid, or find out why you should have avoided them!
                if (fa.Name.Contains("Symbol") ||
                    fa.Name.Contains("Blackadder ITC") ||
                    fa.Name.Contains("MDL2 Assets") ||
                    fa.Name.Contains("Palace Script MT") ||
                    fa.Name.Contains("Icons") ||
                    fa.Name.Contains("MT Extra") ||
                    fa.Name.Contains("MS Outlook") ||
                    fa.Name.Contains("Marlett") ||
                    fa.Name.Contains("Parchment") ||
                    fa.Name.Contains("MS Reference Specialty") ||
                    fa.Name.Contains("dings") ||
                    fa.Name.Contains("Rage Italic") ||
                    fa.Name.Contains("Playbill") ||
                    fa.Name.Contains("Snap ITC") ||
                    fa.Name.Contains("Kunstler Script")) continue; // symbols are totally different to digit.

                ++cnt;

                comboBoxFont.Items.Add(fa.Name + (cnt <= numberOfFonts ? "*" : ""));

                for (int i = 0; i < 10; i++)
                {
                    if (!digitsToOCR.ContainsKey(i)) digitsToOCR.Add(i, new());

                    if (cnt <= numberOfFonts) digitsToOCR[i].Add(new DigitToOCR(i, fa.Name));
                }
            }

            comboBoxFont.SelectedIndex = 0;
        }

        /// <summary>
        /// User has hand drawn a digit, ask the AI to guess what it is 
        /// </summary>
        private void PredictHandDrawnDigit()
        {
            try
            {
                double[] pixels = DigitToOCR.BitmapGetImage(pictureBoxHandDrawn.Image, out Bitmap image);
                
                image.Dispose();
                
                for (int i = 0; i < pixels.Length; i++)
                {
                    pixels[i] = 1 - pixels[i]; // invert
                    if (pixels[i] < 0.004) pixels[i] = 0;
                }
                
                image = DrawPixelsEnlarged(pixels, 15);

                pictureBoxAISees.Image?.Dispose();
                pictureBoxAISees.Image = image;

                labelResult.Text = ((int)Math.Round(10 * networkGuessTheDigit.FeedForward(pixels)[0])).ToString();
            }
            catch (Exception)
            {

            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void DrawOnHandDrawnImage(int x, int y)
        {
            Point newPoint = new(x, y);

            if (lastHandDrawn.X != -1)
            {
                Bitmap b = (Bitmap)pictureBoxHandDrawn.Image;
                
                using Graphics graphics = Graphics.FromImage(b);
                using Pen pen = new(Color.Black, 8);

                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.FillEllipse(Brushes.Black, new Rectangle(newPoint.X - 4, newPoint.Y - 4, 8, 8));
                graphics.DrawLine(pen, lastHandDrawn, newPoint);
                graphics.Flush();

                pictureBoxHandDrawn.Image = b;

            }

            lastHandDrawn = newPoint;
        }

    }
}