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

        public void DoWork1()
        {

            while (!shouldStop)
            {
                Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                Thread.Sleep(1000);
            }
            Console.WriteLine("thread stopped");
        }
        public void DoWork2()
        {

            while (!shouldStop)
            {
                Console.WriteLine("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");
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
