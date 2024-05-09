using System;
using System.IO;
using PdfiumViewer;
using Tesseract;

class Program
{
    static void Main(string[] args)
    {
        string pdfFilePath = "C:/Users/Nijat/Desktop/Test/04182024.pdf";
        string outputFolder = "C:/Users/Nijat/Desktop/out";

        
        ExtractImagesFromPDF(pdfFilePath, outputFolder);

        
        PerformOCR(outputFolder);
    }

    static void ExtractImagesFromPDF(string pdfFilePath, string outputFolder)
    {
        using (PdfDocument pdfDocument = PdfDocument.Load(pdfFilePath))
        {
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            for (int pageNumber = 0; pageNumber < pdfDocument.PageCount; pageNumber++)
            {
                using (var image = pdfDocument.Render(pageNumber, 300, 300, true))
                {
                    string imagePath = Path.Combine(outputFolder, $"Page_{pageNumber + 1}.png");
                    image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
                    Console.WriteLine($"Image saved: {imagePath}");
                }
            }
        }
    }

    static void PerformOCR(string inputFolder)
    {
        string ocrOutputFolder = "C:/Users/Nijat/Desktop/out";
        if (!Directory.Exists(ocrOutputFolder))
        {
            Directory.CreateDirectory(ocrOutputFolder);
        }

        using (var engine = new TesseractEngine("./tessdata", "eng", EngineMode.Default))
        {
            foreach (string imagePath in Directory.GetFiles(inputFolder))
            {
                using (var img = Pix.LoadFromFile(imagePath))
                {
                    using (var page = engine.Process(img))
                    {
                        string text = page.GetText();
                        string imageName = Path.GetFileName(imagePath);
                        string outputFilePath = Path.Combine(ocrOutputFolder, $"{Path.GetFileNameWithoutExtension(imageName)}.txt");
                        File.WriteAllText(outputFilePath, text);
                        Console.WriteLine($"OCR output saved: {outputFilePath}");
                    }
                }
            }
        }
    }
}

