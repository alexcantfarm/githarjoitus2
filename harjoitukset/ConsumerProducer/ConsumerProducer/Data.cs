using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsumerProducer
{
    class Data
    {
        private List<int> theData;
        private int index;
        private static object obj = new object();
        public Data() { theData = new List<int>(); }
        public void addData(int i)
        {
            Monitor.Enter(obj);

            theData.Add(i);
            Monitor.Exit(obj);

        }

        public void readData()
        {
            Monitor.Enter(obj);
            if (theData.Count > 0)
            {
                foreach (int i in theData)
                {

                    Console.Write(i + ", ");
                 
                    Thread.Sleep(1);
                }
                Console.WriteLine();
     
            }
            else
            {
                Console.WriteLine("empty");
            }
            Monitor.Exit(obj);
        }


    }
}
