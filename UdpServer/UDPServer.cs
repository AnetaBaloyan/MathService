using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.IO;
using MathServer;


namespace UdpServer
{
    public class UDPServer
    {
        public UDPServer()
        {
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("192.168.1.4"), 3002);
            UdpClient newsock = new UdpClient(endpoint);

            while (true)
            {
                byte[] data = new byte[1024];

                Console.WriteLine("Waiting for a connection...");

                IPEndPoint client = new IPEndPoint(IPAddress.Any, 3002);

                bool connected = false;

                while (true)
                {
                    if(connected)
                    {
                        var task = new Task(() =>
                        {
                            while(true)
                            {
                                data = newsock.Receive(ref client);

                                string innerMsg = Encoding.UTF8.GetString(data, 0, data.Length);

                                if (!(innerMsg.ToLower().Replace(" ", "") == "end"))
                                {
                                    if (innerMsg.Contains("*"))
                                    {
                                        string[] arr = innerMsg.Split('*');
                                        string backMsg = Calculator.Mult(Double.Parse(arr[0]), Double.Parse(arr[1])).ToString();
                                        data = Encoding.UTF8.GetBytes(backMsg);
                                        newsock.Send(data, data.Length, client);
                                    }
                                    else if (innerMsg.Contains("+"))
                                    {
                                        string[] arr = innerMsg.Split('+');
                                        string backMsg = Calculator.Add(Double.Parse(arr[0]), Double.Parse(arr[1])).ToString();
                                        data = Encoding.UTF8.GetBytes(backMsg);
                                        newsock.Send(data, data.Length, client);
                                    }
                                    else if (innerMsg.Contains("-"))
                                    {
                                        string[] arr = innerMsg.Split('-');
                                        string backMsg = Calculator.Sub(Double.Parse(arr[0]), Double.Parse(arr[1])).ToString();
                                        data = Encoding.UTF8.GetBytes(backMsg);
                                        newsock.Send(data, data.Length, client);
                                    }
                                    else if (innerMsg.Contains("/"))
                                    {
                                        string[] arr = innerMsg.Split('/');
                                        string backMsg = Calculator.Div(Double.Parse(arr[0]), Double.Parse(arr[1])).ToString();
                                        data = Encoding.UTF8.GetBytes(backMsg);
                                        newsock.Send(data, data.Length, client);
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
                    else
                    {
                        data = newsock.Receive(ref client);

                        string msg = Encoding.UTF8.GetString(data, 0, data.Length);

                        if (!(msg.ToLower().Replace(" ", "") == "end"))
                        {
                            if (msg.Contains("*"))
                            {
                                string[] arr = msg.Split('*');
                                string backMsg = Calculator.Mult(Double.Parse(arr[0]), Double.Parse(arr[1])).ToString();
                                data = Encoding.UTF8.GetBytes(backMsg);
                                newsock.Send(data, data.Length, client);
                            }
                            else if (msg.Contains("+"))
                            {
                                string[] arr = msg.Split('+');
                                string backMsg = Calculator.Add(Double.Parse(arr[0]), Double.Parse(arr[1])).ToString();
                                data = Encoding.UTF8.GetBytes(backMsg);
                                newsock.Send(data, data.Length, client);
                            }
                            else if (msg.Contains("-"))
                            {
                                string[] arr = msg.Split('-');
                                string backMsg = Calculator.Sub(Double.Parse(arr[0]), Double.Parse(arr[1])).ToString();
                                data = Encoding.UTF8.GetBytes(backMsg);
                                newsock.Send(data, data.Length, client);
                            }
                            else if (msg.Contains("/"))
                            {
                                string[] arr = msg.Split('/');
                                string backMsg = Calculator.Div(Double.Parse(arr[0]), Double.Parse(arr[1])).ToString();
                                data = Encoding.UTF8.GetBytes(backMsg);
                                newsock.Send(data, data.Length, client);
                            }
                        }
                        else
                        {
                            break;
                        }   
                    }
                }
            }
        }
    }
}
