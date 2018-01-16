using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadTest1
{
    /*
    class Measurements
    {
        public double TimeStamp { get; set; }
        public double MeasA { get; set; }
        public double MeasB { get; set; }
    }*/

    class Worker
    {
        private volatile bool shouldStop = false;
        private Buffer buffer = new Buffer();

        // thread method
        public void Producer() // producer will update measurements
        {
            int counter = 0;
            Random gen = new Random();
            while (!shouldStop)
            {
                buffer.Put(counter);
                counter++;
                if (counter % 2 == 0)
                    Thread.Sleep(1);
                else
                    Thread.Sleep(gen.Next() % 2000);
            }
            Console.WriteLine("worker thread A: terminating gracefully");
        }

        // thread method
        public void Consumer() // consumer will write measurements to the console
        {
            Random gen = new Random();
            Thread.Sleep(150);
            while (!shouldStop)
            {
                int data = buffer.Get();
                if(data == -1)
                {
                    Console.WriteLine("timeout");
                }else
                {
                    Console.WriteLine(data);
                }
                Console.WriteLine(data);
                Thread.Sleep(gen.Next() % 1000);
            }
            Console.WriteLine("worker thread B: terminating gracefully");
        }

        public void RequestStop()
        {
            shouldStop = true;
        }
    }
}
