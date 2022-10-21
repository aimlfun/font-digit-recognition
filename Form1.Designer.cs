namespace Digits
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.comboBoxFont = new System.Windows.Forms.ComboBox();
            this.pictureBoxAISees = new System.Windows.Forms.PictureBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.buttonSaveNNVisualisation = new System.Windows.Forms.Button();
            this.pictureBoxHandDrawn = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAISees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHandDrawn)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBox1.Location = new System.Drawing.Point(10, 528);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(617, 71);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // comboBoxFont
            // 
            this.comboBoxFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFont.FormattingEnabled = true;
            this.comboBoxFont.Location = new System.Drawing.Point(250, 29);
            this.comboBoxFont.Name = "comboBoxFont";
            this.comboBoxFont.Size = new System.Drawing.Size(370, 23);
            this.comboBoxFont.TabIndex = 0;
            this.comboBoxFont.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFont_SelectedIndexChanged);
            // 
            // pictureBoxAISees
            // 
            this.pictureBoxAISees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxAISees.Location = new System.Drawing.Point(13, 288);
            this.pictureBoxAISees.Name = "pictureBoxAISees";
            this.pictureBoxAISees.Size = new System.Drawing.Size(210, 210);
            this.pictureBoxAISees.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAISees.TabIndex = 2;
            this.pictureBoxAISees.TabStop = false;
            // 
            // labelResult
            // 
            this.labelResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelResult.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelResult.Location = new System.Drawing.Point(315, 322);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(143, 135);
            this.labelResult.TabIndex = 3;
            this.labelResult.Text = "?";
            this.labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Choose a font: (* indicates trained on)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Choose a digit:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(13, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "AI sees: (14px * 14px image)";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(250, 82);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 54);
            this.button1.TabIndex = 1;
            this.button1.Text = "0";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(303, 82);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 54);
            this.button2.TabIndex = 2;
            this.button2.Text = "1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(356, 82);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(47, 54);
            this.button3.TabIndex = 3;
            this.button3.Text = "2";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(409, 82);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 54);
            this.button4.TabIndex = 4;
            this.button4.Text = "3";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button5.Location = new System.Drawing.Point(462, 82);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 54);
            this.button5.TabIndex = 5;
            this.button5.Text = "4";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            // button6
            // 
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button6.Location = new System.Drawing.Point(462, 142);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(47, 54);
            this.button6.TabIndex = 10;
            this.button6.Text = "9";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            // button7
            // 
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button7.Location = new System.Drawing.Point(409, 142);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(47, 54);
            this.button7.TabIndex = 9;
            this.button7.Text = "8";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            // button8
            // 
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button8.Location = new System.Drawing.Point(356, 142);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(47, 54);
            this.button8.TabIndex = 8;
            this.button8.Text = "7";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            // button9
            // 
            this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button9.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button9.Location = new System.Drawing.Point(303, 142);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(47, 54);
            this.button9.TabIndex = 7;
            this.button9.Text = "6";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            // button10
            // 
            this.button10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button10.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button10.Location = new System.Drawing.Point(250, 142);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(47, 54);
            this.button10.TabIndex = 6;
            this.button10.Text = "5";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.ButtonDigit_Click);
            // 
            // buttonSaveNNVisualisation
            // 
            this.buttonSaveNNVisualisation.Location = new System.Drawing.Point(345, 475);
            this.buttonSaveNNVisualisation.Name = "buttonSaveNNVisualisation";
            this.buttonSaveNNVisualisation.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveNNVisualisation.TabIndex = 12;
            this.buttonSaveNNVisualisation.Text = "RenderNN";
            this.buttonSaveNNVisualisation.UseVisualStyleBackColor = true;
            this.buttonSaveNNVisualisation.Click += new System.EventHandler(this.ButtonSaveNNVisualisation_Click);
            // 
            // pictureBoxHandDrawn
            // 
            this.pictureBoxHandDrawn.BackColor = System.Drawing.Color.White;
            this.pictureBoxHandDrawn.Location = new System.Drawing.Point(12, 29);
            this.pictureBoxHandDrawn.Name = "pictureBoxHandDrawn";
            this.pictureBoxHandDrawn.Size = new System.Drawing.Size(167, 167);
            this.pictureBoxHandDrawn.TabIndex = 13;
            this.pictureBoxHandDrawn.TabStop = false;
            this.pictureBoxHandDrawn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxHandDrawn_MouseDown);
            this.pictureBoxHandDrawn.MouseEnter += new System.EventHandler(this.PictureBoxHandDrawn_MouseEnter);
            this.pictureBoxHandDrawn.MouseLeave += new System.EventHandler(this.PictureBoxHandDrawn_MouseLeave);
            this.pictureBoxHandDrawn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBoxHandDrawn_MouseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Draw a digit:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(193, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 30);
            this.label6.TabIndex = 15;
            this.label6.Text = "OR";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(12, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 30);
            this.label8.TabIndex = 17;
            this.label8.Text = "AI Prediction";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 609);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBoxHandDrawn);
            this.Controls.Add(this.buttonSaveNNVisualisation);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.pictureBoxAISees);
            this.Controls.Add(this.comboBoxFont);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Digits - AI to learn all digits in every font";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAISees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHandDrawn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox richTextBox1;
        private ComboBox comboBoxFont;
        private PictureBox pictureBoxAISees;
        private Label labelResult;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button buttonSaveNNVisualisation;
        private PictureBox pictureBoxHandDrawn;
        private Label label5;
        private Label label6;
        private Label label8;
    }
}