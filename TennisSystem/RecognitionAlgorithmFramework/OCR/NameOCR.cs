using System;
using System.Drawing;
using Tesseract;

namespace RecognitionAlgorithmFramework.OCR
{
    public class NameOCR
    {
        private TesseractEngine PlayerNameOCR = null;

        public string Name { get; set; }

        public NameOCR()
        { }

        public void PlayerName(Bitmap OCRNmae)
        {
            PlayerNameOCR = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
            if (PlayerNameOCR != null)
            {
                var page = PlayerNameOCR.Process(OCRNmae);
                Name = page.GetText();
            }
        }
    }
}
