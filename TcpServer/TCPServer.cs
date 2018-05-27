using System;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using MathServer;


namespace TcpServer
{
    public class TCPServer
    {
        private TcpListener listener = new TcpListener(IPAddress.Parse("192.168.1.4"), 3001);

        public TCPServer()
        {
            listener.Start();

            while (true)
            {
                Console.WriteLine("Waiting for a connection...");
                var client = listener.AcceptTcpClient();
                Console.WriteLine("Connected!");

                var task = new Task(() =>
                {
                    var stream = client.GetStream();

                    var reader = new StreamReader(stream);
                    string msg = "";

                    var writer = new StreamWriter(stream);
                    writer.AutoFlush = true;

                    while (true)
                    {
                        msg = reader.ReadLine();

                        if (!(msg.ToLower().Replace(" ", "") == "end"))
                        {
                            if (msg.Contains("*"))
                            {
                                string[] arr = msg.Split('*');
                                writer.WriteLine(Calculator.Mult(Double.Parse(arr[0]), Double.Parse(arr[1])).ToString());
                            }
                            else if (msg.Contains("+"))
                            {
                                string[] arr = msg.Split('+');
                                writer.WriteLine(Calculator.Add(Double.Parse(arr[0]), Double.Parse(arr[1])).ToString());
                            }
                            else if (msg.Contains("-"))
                            {
                                string[] arr = msg.Split('-');
                                writer.WriteLine(Calculator.Sub(Double.Parse(arr[0]), Double.Parse(arr[1])).ToString());
                            }
                            else if (msg.Contains("/"))
                            {
                                string[] arr = msg.Split('/');
                                writer.WriteLine(Calculator.Div(Double.Parse(arr[0]), Double.Parse(arr[1])).ToString());
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                });

                task.Start();

            }
        }
    }
}
