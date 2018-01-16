using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest11
{
    class Worker
    {
        private volatile bool shouldStop;

        public void DoWork()
        {

            while (!shouldStop)
            {
                Console.WriteLine("working");
                Thread.Sleep(1000);
            }
            Console.WriteLine("thread stopped");
        }

        public void RequestStop()
        {
            shouldStop = true;
        }

    }
}
