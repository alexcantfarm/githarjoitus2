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
    }
    */

    class Worker
    {
        private volatile bool shouldStop = false;
        //private Measurements m = new Measurements();

        // a dummy object
        //private static object obj = new object();

        // thread method
        private Buffer buffer = new Buffer();
        private int data;
        public void Producer() // producer will update measurements
        {
            int counter = 0;
            Random gen = new Random();
            while (!shouldStop)
            {
                //Monitor.Enter(obj);

                buffer.Put(counter++);

                Thread.Sleep(gen.Next()% 1000);
                // Monitor.Exit(obj);
            }
            Console.WriteLine("worker thread A: terminating gracefully");
        }

        // thread method
        public void Consumer() // consumer will write measurements to the console
        {
            int counter = 0;
            Random gen = new Random();
            Thread.Sleep(150);
            while (!shouldStop)
            {
                //Monitor.Enter(obj);
                this.data = buffer.Get();
                Thread.Sleep(gen.Next() % 1000);
                Console.WriteLine(this.data);
                //Monitor.Exit(obj);
            }
            Console.WriteLine("worker thread B: terminating gracefully");
        }

        public void RequestStop()
        {
            shouldStop = true;
        }
    }
}
