using System;
using System.Collections.Concurrent;
using System.Threading;

namespace command
{
    public class ThreadPool<T> where T : IJob
    {
        private static BlockingCollection<T> jobQueue = new BlockingCollection<T>();
        private Thread[] jobThreads;
        private static bool shutdown = false;

        public ThreadPool(int numberOfThreads)
        {
            jobThreads = new Thread[numberOfThreads];
            for (var i = 0; i < numberOfThreads; i++)
            {
                Worker w = new Worker();

                jobThreads[i] = new Thread(w.Run);
              //  jobThreads[i].Name = i.ToString();
                jobThreads[i].Start();
            }

         
        }

        public void AddJob(T emailJob)
        {
            jobQueue.Add(emailJob);
        }

          public void ShutdownPool()
        {
            const int sleepTime = 1000;

            while (jobQueue.Count > 0)
            {
                try
                {
                   
                    Thread.Sleep(sleepTime);

                }
                catch (ThreadInterruptedException ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }

            shutdown = true;
            foreach (var workerThread in jobThreads)
            {
               Console.WriteLine( workerThread.ThreadState);
                workerThread.Join();
                workerThread.Interrupt();
            }
        }
        

        public class Worker: ThreadLocal<IJob>
        {

            public void Run( )
            {
                while (!shutdown)
                {
                    try
                    {
                        var r = jobQueue.Take();
                     
                        r.Run();
                        Thread.Sleep(500);

                    }
                    catch (ThreadInterruptedException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                

            }
        }
    }
}