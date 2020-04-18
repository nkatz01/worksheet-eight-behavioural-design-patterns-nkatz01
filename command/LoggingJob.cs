using System;
using System.Threading;

namespace command
{
    public class LoggingJob : IJob
    {
       
        public Logging Logging { set; get; }

        public void Run()
        {
            if (Logging != null) { 
             Console.WriteLine($"Job ID {Thread.CurrentThread.ManagedThreadId} Executing Logging jobs");
            Logging.Log();}
       
        }

       
            
    }
}