using System;

namespace TcpServer
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting TCP Server...");
            var server = new TCPServer();
        }
    }
}
