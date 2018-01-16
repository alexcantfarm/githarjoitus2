using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsumerProducer
{
    class Writer
    {
        private Data data;
        private Random rnd;
        private bool stopper;
        public Writer(Data data)
        {
            this.data = data;
            rnd = new Random();
        }

        public void writeData()
        {
            while (!stopper)
            {
                Console.WriteLine("writer writing...");
                data.addData(this.rnd.Next(1, 1000000));
                Thread.Sleep(100);
            }
        }

        public void reqStop()
        {
            stopper = true;
        }

      
    }
}
