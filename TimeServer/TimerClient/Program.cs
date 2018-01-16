using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;


namespace TimerClient
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            while (true)
            {
                try
                {

                    int port = 13001;
                    IPAddress server = IPAddress.Parse("127.0.0.1");
                    TcpClient client = new TcpClient(server.ToString(), port);

                    NetworkStream ns = client.GetStream();

                    StreamWriter sw = new StreamWriter(ns);
                    StreamReader sr = new StreamReader(ns);

                    sw.AutoFlush = true;
                    sw.WriteLine("time");
                    string resp = sr.ReadLine();
                    Console.WriteLine("CLIENT: " + resp);

                    sw.WriteLine("count");
                    resp = sr.ReadLine();
                    Console.WriteLine("CLIENT: " + resp);
                    sw.WriteLine("...");
                    resp = sr.ReadLine();
                    Console.WriteLine("CLIENT: " + resp);
                    if (count > 100) { break; }else
                    {
                        sw.WriteLine("quit");
                    }

                    sw.Close();
                    sw.Close();
                    client.Close();
                }
                catch (Exception e)
                {

                    Console.WriteLine("err: " + e.Message);
                }
            }

        }
    }
}
