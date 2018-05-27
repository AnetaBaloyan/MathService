using System;

namespace UdpServer
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting the UDP Server...");
            var server = new UDPServer();
            Console.WriteLine("UDP Server has started!");
        }
    }
}
