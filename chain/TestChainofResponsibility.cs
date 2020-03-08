using System;
using System.Collections.Generic;

namespace worksheet_eight_behavioural_design_patterns
{
    public static class TestChainOfResponsibility
    {
        public static void Main(string[] args)
        {
            IHandler textHandler = new TextFileHandler("Text Handler");
            IHandler docHandler = new DocFileHandler("Doc Handler");
            IHandler excelHandler = new ExcelFileHandler("Excel Handler");
            IHandler audioHandler = new AudioFileHandler("Audio Handler");
            IHandler videoHandler = new VideoFileHandler("Video Handler");
            IHandler imageHandler = new ImageFileHandler("Image Handler");

            textHandler.Handler = docHandler;
            docHandler.Handler = excelHandler;
            excelHandler.Handler = audioHandler;
            audioHandler.Handler = videoHandler;
            videoHandler.Handler = imageHandler;

            var file = new File("Abc.mp3", "audio", "C:");
            textHandler.Process(file);

            Console.WriteLine("--------------------");

            file = new File("Abc.jpg", "video", "C:");
            textHandler.Process(file);

            Console.WriteLine("--------------------");

            file = new File("Abc.doc", "doc", "C:");
            textHandler.Process(file);

            Console.WriteLine("--------------------");

            file = new File("Abc.bat", "bat", "C:");
            textHandler.Process(file);
        }
    }
}