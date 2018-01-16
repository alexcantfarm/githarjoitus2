using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadTest1
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker workerObject = new Worker();
            // create the thread
            Thread workerThread1 = new Thread(workerObject.Producer);
            Thread workerThread2 = new Thread(workerObject.Consumer);
            // start the thread
            workerThread1.Start();
            workerThread2.Start();
            Console.WriteLine("main thread: starting worker thread");
            // loop until the thread starts (wait)
            while (!workerThread1.IsAlive)
                ;
            while (!workerThread2.IsAlive)
                ;            
            // wait 10 seconds
            Thread.Sleep(10000);
            // request the worker thread to stop itself
            workerObject.RequestStop();
            //workerThread.Abort();

            // wait until the worker thread stops
            workerThread1.Join();
            workerThread2.Join();
            Console.WriteLine("main thread: worker thread terminated");
        }
    }
}
