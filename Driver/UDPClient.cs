using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.IO;


namespace MathServer
{
    public class UDPClient
    {
        public UDPClient()
        {
            byte[] buffer = new byte[1024];

            var client = new UdpClient();
            client.Connect(IPAddress.Parse("192.168.1.4"), 3002);

            var server = new IPEndPoint(IPAddress.Any, 3002);

            while(true)
            {
                buffer = Encoding.UTF8.GetBytes(Console.ReadLine());
                if (Encoding.UTF8.GetString(buffer) == "end")
                {
                    Console.WriteLine("Closing the connection...");
                    client.Close();
                    break;
                }
                client.Send(buffer, buffer.Length);   
                var data = client.Receive(ref server);
                Console.WriteLine(Encoding.UTF8.GetString(data));
            }

            client.Close();
        }
    }
}
