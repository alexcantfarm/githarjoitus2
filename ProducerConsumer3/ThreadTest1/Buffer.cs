using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadTest1
{
    class Buffer
    {
        private Queue<int> queue = new Queue<int>();

        private static object objToLock = new object();
        
        public void Put(int data)
        {
            bool ok = false;
            Monitor.Enter(objToLock);
            while (queue.Count == 0)
            {
                ok = Monitor.Enter(objToLock, 1000);
                if (!ok) break;
            }
            int data = -1;
            if (ok)
            {

                data = queue.Enqueue(data);
            }
            Monitor.Pulse(objToLock);
            Monitor.Exit(objToLock);
        }

        
        public int Get()
        {
            Monitor.Enter(objToLock);
            
            while (queue.Count == 0)
            {
                // odotellaan, että kuluttaja lähettää Pulsen
                Monitor.Wait(objToLock);
            }

            Console.Write("queue: ");
            foreach (var item in queue)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            int data = queue.Dequeue();

            Monitor.Pulse(objToLock);
            Monitor.Exit(objToLock);

            return data;
        }

    }
}
