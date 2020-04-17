using System;

namespace command
{
    public class LoggingJob : IJob
    {
       
        public Logging Logging { set; get; }

        public void Run()
        {
            if (Logging != null) { 
             Console.WriteLine("Executing Logging jobs");
            Logging.Log();}
       
        }

       
            
    }
}