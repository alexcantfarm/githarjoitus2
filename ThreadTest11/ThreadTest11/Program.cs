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
            Worker workerObject = new Worker();
            Thread workerThread =
                new Thread(workerObject.DoWork);

            workerThread.Start();

            // odotetaan, että säie käynnistyy
            while (!workerThread.IsAlive)
                ;

            Thread.Sleep(10000);

            workerObject.RequestStop();

            workerThread.Join();           

            Console.WriteLine("worker thread terminated");

        }
    }
}
