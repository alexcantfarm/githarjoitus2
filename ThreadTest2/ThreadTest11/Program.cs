using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest11
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker workerObject1 = new Worker();
            Worker workerObject2 = new Worker();
            Thread workerThread1 =
                new Thread(workerObject1.DoWork1);
            Thread workerThread2 =
                new Thread(workerObject2.DoWork2);

            workerThread1.Start();
            workerThread2.Start();

            // odotetaan, että säie käynnistyy
            while (!workerThread1.IsAlive && !workerThread2.IsAlive)
                ;

            Thread.Sleep(10000);

            workerObject1.RequestStop();
            workerObject2.RequestStop();

            workerThread1.Join();
            workerThread2.Join();

            Console.WriteLine("worker thread terminated");

        }
    }
}
