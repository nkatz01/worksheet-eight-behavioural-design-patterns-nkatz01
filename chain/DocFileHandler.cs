using System;
namespace worksheet_eight_behavioural_design_patterns
{
    public class DocFileHandler : IHandler
    {
        public DocFileHandler(string textHandler)
        {
            TextHandler = textHandler;
        }

        public IHandler Handler { get; set; }
        public string TextHandler { get; set; }

        public void Process(object file)
        {
            File File = (File)file;
            if (File.Type == "doc")
                Console.WriteLine($"Process and saving {File.Type} file... by { TextHandler}");
            else
            {
                if (Handler != null)
                {
                    Console.WriteLine($"{TextHandler} forwards request to {Handler.TextHandler}");
                    Handler.Process(File);

                }
                else
                    Console.WriteLine("File not supported");
            }


        }
    }
}