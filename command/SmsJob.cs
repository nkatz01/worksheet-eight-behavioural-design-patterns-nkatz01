using System;

namespace command
{
    public class SmsJob : IJob
    {
        private Sms sms { set; get; }
        public void Run()
        {
            if (sms != null)
            {
                Console.WriteLine("Executing sms jobs");
                sms.SendSms();
            }
        }

        public void Sms(Sms sms)
        {
            this.sms = sms;  
        }
    }
}