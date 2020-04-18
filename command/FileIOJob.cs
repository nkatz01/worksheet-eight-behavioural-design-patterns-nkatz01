using System;
using System.Threading;

namespace command
{
    public class FileIOJob : IJob
    {
        private FileIO fileIO { get; set; }
        public void Run()
        {
            if (fileIO != null)
            {
                Console.WriteLine($"Job ID {Thread.CurrentThread.ManagedThreadId} Executing fileIO jobs");
                fileIO.Execute();

            }

        }    

        public void FileIO(FileIO fileIo)
        {
            this.fileIO = fileIO;
        }
    }
}