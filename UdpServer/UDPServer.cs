using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.IO;
using MathServer;

namespace UdpServer
{
    /// <summary>
    /// UDP Server.
    /// </summary>
    public class UDPServer
    {
        /// <summary>
        /// Starts the UDP server.
        /// </summary>
        public UDPServer()
        {
            // The endpoint of the server.
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3002);
            UdpClient newsock = new UdpClient(endpoint);

            while (true)
            {
                // The buffer.
                byte[] buffer = new byte[1024];

                Console.WriteLine("Server has strated!");

                // Starts listening to requests.
                while (true)
                {
                    // The endpoint of the client.
                    IPEndPoint client = new IPEndPoint(IPAddress.Any, 3002);

                    Console.WriteLine("Waiting for a request...");

                    // Recieves the message and sets the client endpoint.
                    buffer = newsock.Receive(ref client);

                    // Decodes the message into a string.
                    string innerMsg = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

                    // If the message is not a request to end.
                    if (!(innerMsg.ToLower().Replace(" ", "") == "end"))
                    {
                        // Handles the request by the help of the Calculator service.
                        string backMsg = Calculator.Handle(innerMsg.Replace(" ", ""));

                        // Encodes into the buffer.
                        buffer = Encoding.UTF8.GetBytes(backMsg);

                        // Sends the result back to the client.
                        newsock.Send(buffer, buffer.Length, client);

                        Console.WriteLine("Solved!");
                    }

                    // Continues to other requests.
                }
            }
        }
    }
}
