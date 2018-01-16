using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsumerProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            Data data = new Data();
            Writer writer = new Writer(data);
            Reader reader = new Reader(data);

            Thread writerThread = new Thread(writer.writeData);
            Thread readerThread = new Thread(reader.readData);
            
            writerThread.Start();
            readerThread.Start();
            
            //while (!writerThread.IsAlive || readerThread.IsAlive) ;
            Thread.Sleep(10000);

            writer.reqStop();
            reader.reqStop();

            writerThread.Join();
            readerThread.Join();

            Console.WriteLine("main thread stop");



        }
    }
}
