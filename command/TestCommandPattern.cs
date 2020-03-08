using System;

namespace command
{
    public static class TestCommandPattern
    {
        public static void Main(string[] args)
        {
            const int numberOfThreads = 10;
            const int numberOfJobs = 5;

            var pool = new ThreadPool<IJob>(numberOfThreads);

            var emailJob = new EmailJob();
            var smsJob = new SmsJob();
            var fileIOJob = new FileIOJob();
            var logJob = new LoggingJob();

            for (var i = 0; i < numberOfJobs; i++)
            {
                emailJob.Email(new Email());
                smsJob.Sms(new Sms());
                fileIOJob.FileIO(new FileIO());
                logJob.Logging = new Logging();
                pool.AddJob(emailJob);
                pool.AddJob(smsJob);
                pool.AddJob(fileIOJob);
                pool.AddJob(logJob);
            }

            pool.ShutdownPool();
        }
    }
}