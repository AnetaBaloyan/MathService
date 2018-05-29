using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.IO;

namespace MathServer
{
    /// <summary>
    /// UDP Client.
    /// </summary>
    public class UDPClient
    {
        /// <summary>
        /// Starts the UDP client.
        /// </summary>
        public UDPClient()
        {
            // The buffer.
            byte[] buffer = new byte[1024];

            // The client.
            var client = new UdpClient();

            // Connects to the server.
            client.Connect(IPAddress.Parse("127.0.0.1"), 3002);

            // The server end point.
            var server = new IPEndPoint(IPAddress.Any, 3002);

            Console.WriteLine("- The protocol is number_operator_number.");
            Console.WriteLine("- Type \"end\" to finish the session.");

            // Starts listening to the user.
            while(true)
            {
                buffer = Encoding.UTF8.GetBytes(Console.ReadLine());

                // Checks if the user wants to end the session.
                if (Encoding.UTF8.GetString(buffer).ToLower().Replace(" ", "") == "end")
                {
                    // Tells the server that client is ending the session.
                    client.Send(buffer, buffer.Length);

                    // Closes the client.
                    Console.WriteLine("Closing the connection...");
                    client.Close();
                    break;
                }
                else
                {
                    // Sends the message to the server.
                    client.Send(buffer, buffer.Length);
                    var data = client.Receive(ref server);
                    Console.WriteLine(Encoding.UTF8.GetString(data));   
                }
            }

            // Closes the client.
            client.Close();
        }
    }
}
