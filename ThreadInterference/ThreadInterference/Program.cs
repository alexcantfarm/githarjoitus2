using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadInterference
{
    // explanation: http://www.fincher.org/tips/Languages/csharpThreads.shtml

    public class Worker
    {
        public static long counter = 0;
        public static object obj = new object();

        public void DoWork2()
        {
            long repetitions = 10000000;
            for (int i = 0; i < repetitions; i++)
            {
                Monitor.Enter(obj);
                counter++;
                Monitor.Exit(obj);
                //Interlocked.Increment(ref counter);
                Monitor.Enter(obj);
                counter--;
                Monitor.Exit(obj);
                //Interlocked.Decrement(ref counter);
            }
            // The output should be zero, because there are as many increments as decrements
            Console.WriteLine(Thread.CurrentThread.Name + ": " + counter);

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Worker myJob = new Worker();
            Thread thread = new Thread(new ThreadStart(myJob.DoWork2));
            thread.Name = "first";
            thread.Start();

            Worker myJob2 = new Worker();
            Thread thread2 = new Thread(new ThreadStart(myJob2.DoWork2));
            thread2.Name = "second";
            thread2.Start();

            thread.Join();
            thread2.Join();
        }
    }
}
