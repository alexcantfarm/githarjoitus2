using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsumerProducer
{
    class Reader
    {
        private Data data;
        private bool stopper;
        public Reader(Data data)
        {
            this.data = data;
        }

        public void readData()
        {
            while (!stopper)
            {
                Console.WriteLine("reader reading...");
                this.data.readData();
                Thread.Sleep(1000);
            }
        }

         public void reqStop()
        {
            stopper = true;
        }
    }
}
