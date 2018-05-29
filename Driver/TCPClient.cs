using System;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace MathServer
{
    /// <summary>
    /// TCP Client.
    /// </summary>
    public class TCPClient
    {
        /// <summary>
        /// The client.
        /// </summary>
        private TcpClient client = new TcpClient();

        /// <summary>
        /// Strats the TCP client.
        /// </summary>
        public TCPClient()
        {
            Console.WriteLine("Connecting to the server... ");

            // The endpoint of the server.
            IPEndPoint server = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3001);

            // Connects to the server.
            client.Connect(server);

            Console.WriteLine("Connected!");

            Console.WriteLine("- The protocol is number_operator_number.");
            Console.WriteLine("- Type \"end\" to finish the session.");

            // The stream reader.
            var reader = new StreamReader(client.GetStream());

            // Starts listening to the user.
            while(true)
            {
                // The stream writer.
                var writer = new StreamWriter(client.GetStream());

                // User's input.
                var msg = Console.ReadLine();

                // Checks is the user wants to finish the session.
                if (msg.ToLower().Replace(" ", "") == "end")
                {
                    // Sends the message to the server.
                    writer.WriteLine(msg);
                    writer.Flush();

                    // Closes the client.
                    Console.WriteLine("Closing the connection...");
                    client.Close();
                    break;
                }
                else
                {
                    // Sends the message to the server.
                    writer.WriteLine(msg);
                    writer.Flush();

                    // Outputs the answer of the server.
                    Console.WriteLine(reader.ReadLine());
                }
            }

            // Closes the client.
            client.Close();
        }
    }
}
