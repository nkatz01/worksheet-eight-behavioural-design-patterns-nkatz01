using System;
using System.Collections.Concurrent;
using System.Threading;

namespace command
{
    public class ThreadPool<T> where T : IJob
    {
        
        private static BlockingCollection<T> jobQueue = new BlockingCollection<T>();
        private Thread[] jobThreads;
        private static bool shutdown;

        public ThreadPool(int numberOfThreads)
        {
            jobThreads = new Thread[numberOfThreads];
            for (var i = 0; i < numberOfThreads; i++)
            {
                Worker w = new Worker();
               
                jobThreads[i]= new Thread(new ThreadStart(w.Run));
                jobThreads[i].Name = i.ToString();
              //  jobThreads[i].Start();
              //  jobThreads[i].Join();


            }
        }

        public void AddJob(T emailJob)
        {
            jobQueue.Add(emailJob);
            
        }

        public void startPool()
        {
            foreach (var thr in jobThreads)
            {
                thr.Start();
                

                        
            }
        }
  
       public void ShutdownPool()
        {
            const int sleepTime = 1000;

             Thread.Sleep(sleepTime);

            while (jobQueue.Count > 0)
            {

                try
                {
                    var r = jobQueue.Take();
                }
                catch (ThreadInterruptedException ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
            }

            shutdown = true;
            foreach (var workerThread in jobThreads)
            {
              workerThread.Interrupt();
            }
        }
        


        public class Worker : ThreadLocal<IJob>
        {

            static readonly object _object = new object();
            public void Run()
        {
            while (!shutdown    )
            {
                   
                try
                {    
                    var r = jobQueue.Take();
                           

                           Console.Write($"Job ID: {Thread.CurrentThread.Name} ");

                        r.Run();
                         
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