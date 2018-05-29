using System;

namespace MathServer
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
            // User chooses which protocol to use.
            Console.WriteLine("1 - UDP \n2 - TCP\n");
            switch(Console.ReadLine())
            {
                case "1":
                    // Starts the UDP client
                    var clientUDP = new UDPClient();
                    break;
                     
                case "2":
                    // Starts the TCP client.
                    var clientTCP = new TCPClient();
                    break;
                    
            }
        }
    }
}
