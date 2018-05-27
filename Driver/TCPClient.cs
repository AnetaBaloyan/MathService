using System;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading.Tasks;
namespace MathServer
{
    public class TCPClient
    {
        private TcpClient client = new TcpClient();

        public TCPClient()
        {
            Console.WriteLine("Connecting to the server... ");

            IPEndPoint serevr = new IPEndPoint(IPAddress.Parse("192.168.1.4"), 3001);

            client.Connect(IPAddress.Parse("192.168.1.4"), 3001);

            Console.WriteLine("Connected!");

            var reader = new StreamReader(client.GetStream());

            while(true)
            {
                var writer = new StreamWriter(client.GetStream());
                var msg = Console.ReadLine();
                if (msg == "end")
                {
                    writer.WriteLine(msg);
                    writer.Flush();
                    Console.WriteLine("Closing the connection...");
                    client.Close();
                    break;
                }
                else
                {
                    writer.WriteLine(msg);
                    writer.Flush();
                    Console.WriteLine(reader.ReadLine());
                }
            }
        }
    }
}
