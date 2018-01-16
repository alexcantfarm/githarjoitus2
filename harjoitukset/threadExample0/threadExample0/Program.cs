using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace threadExample0
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker workerObject0 = new Worker("one");
            Worker workerObject1 = new Worker("two");

            Thread workerThread0 = new Thread(workerObject0.DoWork);
            Thread workerThread1 = new Thread(workerObject1.DoWork);

            //starts the thread
            workerThread0.Start();
            workerThread1.Start();


            //loop untill workerThread activates
            while (!workerThread1.IsAlive || !workerThread1.IsAlive) ;

            //put the main thread to sleep for 10 sec to
            //allow the workerthread top do some work
            Thread.Sleep(10000);

            //request workerthread to stop by calling its param obj stop condition
            workerObject0.RequestStop();
            workerObject1.RequestStop();


            //use the join method to block current thread
            //until the object's thread terminates
            workerThread0.Join();
            workerThread1.Join();

            Console.WriteLine("main thread: worker thread has terminated");
        }
    }
}
