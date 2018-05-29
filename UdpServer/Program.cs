using System;

namespace UdpServer
{
    /// <summary>
    /// Main class.
    /// </summary>
    class MainClass
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            // Starts the UDP server.
            Console.WriteLine("Starting the UDP Server...");
            var server = new UDPServer();
            Console.WriteLine("UDP Server has started!");
        }
    }
}
