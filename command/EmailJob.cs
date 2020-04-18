using System;
using System.Threading;

namespace command
{
    public class EmailJob : IJob
    {
        private Email email { get; set; }
        public void Run()
        {
            if (email != null)
            {
                Console.WriteLine($"Job ID {Thread.CurrentThread.ManagedThreadId} Executing email jobs");
                email.SendEmail();
            }
           
        }

        public void Email(Email email) => this.email = email;
    }
}