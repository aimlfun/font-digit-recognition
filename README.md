# font-digit-recognition
From blog posting: https://aimlfun.com/i-recognise-that-letter/

This application requires .net6 and Visual Studio 2022 (Community works).

1. Download https://visualstudio.microsoft.com/vs/community/
2. Download the source-code as a ZIP. 
3. Save it where you like - I tend to use c:\repos\ai\{folder-name}, feel free to choose a better folder.
4. Open the solution, and enjoy!

Any problems? Post a comment on my blog, and I will happily try to assist.

For a pre-trained network, copy /Model/digits.ai to c:\temp.

Please note: it was trained on a specific list of 231 fonts. You may have fonts I do not.

If you don't do that, it will take more than an hour to train. If unsuccessful, it may be a font that you have isn't containing regular digits so don't forget to exclude it in the code.
