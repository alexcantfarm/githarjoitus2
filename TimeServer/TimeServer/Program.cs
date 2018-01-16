using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace TimeServer
{
    class Program
    {
        static void Main(string[] args) 
        {
            try {
                Int32 port = 13001;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                TcpListener tcpListener = new TcpListener(localAddr, port);
                tcpListener.Start();
                ServerOps services = new ServerOps();

                while (true)
                {
                  
                    //blocks, nothing happens before someone connects
                    TcpClient client = tcpListener.AcceptTcpClient();

                    //open IOstreams
                    NetworkStream ns = client.GetStream();
                    StreamWriter sw = new StreamWriter(ns);
                    StreamReader sr = new StreamReader(ns);

                    //read the command
                    string cmd = sr.ReadLine();
                    sw.AutoFlush = true;
                    string time;
                    if (cmd == "time")
                    {
                        time = services.getTime();
                        Console.WriteLine("SERVER: " + time);
                        sw.WriteLine(time);
                    }
                    else if (cmd == "quit")
                    {
                        break;
                    }
                    else if (cmd == "count")
                    {
                        sw.WriteLine(services.getCount().ToString());
                    }
                    else
                    {
                        Console.WriteLine("only time and quit can be served...");
                    }

                    sw.Close();
                    sr.Close();
                    client.Close();
                }
            }catch(Exception e)
            {
                Console.WriteLine("err: " + e.StackTrace);
            }

            
        }
    }
}
