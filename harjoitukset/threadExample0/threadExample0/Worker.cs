using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace threadExample0
{
    class Worker
    {
        //volatile can be used to stop thread
        private volatile bool _shouldStop;
        private string id;
        Random rnd;
        int sleep;
        //Method to be executed on separate thread
        public Worker(string id)
        {
            this.id = id;
            rnd = new Random();
            sleep = 0;
        }
        public void DoWork()
        {
            while(!_shouldStop)
            {
                Console.WriteLine("Worker thread " + id + ": Working...");
                Thread.Sleep(rnd.Next(0,5000));
            }
            Console.WriteLine("Worker thread " + id + ": graceful exit");
        }

        public void RequestStop()
        {
            _shouldStop = true;
        }
    }
}
