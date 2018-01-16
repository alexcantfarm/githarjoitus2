using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadTest1
{
    class Buffer
    {
        private int data { get; set; }
        private bool Available{ get; set; }
        private static object lockObj = new object();
        public void Put(int data)
        {
            Monitor.Enter(lockObj);
            //if true data was already written for consumer to read
            if(Available == true)
            {
                //wait for pulse from the consumer, Wait(lockObj) 
                // gives access to who's using the same lockObject
                Monitor.Wait(lockObj);
            }
            this.data = data;
            this.Available = true;
            Monitor.Pulse(lockObj);
            Monitor.Exit(lockObj);

        }

        public int Get()
        {
            Monitor.Enter(lockObj);
            //if true data was already written for consumer to read
            if (Available == false)
            {
                //wait for pulse from the consumer, Wait(lockObj) 
                // gives access to who's using the same lockObject
                Monitor.Wait(lockObj);
            }
            int data = this.data;
            this.Available = false;

            Monitor.Pulse(lockObj);
            Monitor.Exit(lockObj);

            return data;

        }

    }
}
