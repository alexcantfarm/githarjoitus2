using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BufferedProducerConsumer
{
    class CubbyHole
    {
        private Queue<int> data = new Queue<int>();

 
        public int Buffer
        {
            set
            {
  
                Monitor.Enter(this);
                Console.WriteLine("pushing: " + value + "queue.count = " + data.Count);
                data.Enqueue(value);
               
                Monitor.Pulse(this);
                Monitor.Exit(this);
            }

            get
            {
                int n = -1;
                Monitor.Enter(this);
                while(data.Count == 0)
                {
                    Monitor.Wait(this);
                }
              
                n = data.Dequeue();
                Console.WriteLine("pulled: " + n);

                Monitor.Exit(this);
                return n;
            }
        }
    }
}
