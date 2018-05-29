using System;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using MathServer;

namespace TcpServer
{
    /// <summary>
    /// TCP Server.
    /// </summary>
    public class TCPServer
    {
        /// <summary>
        /// The listener.
        /// </summary>
        private TcpListener listener = new TcpListener(IPAddress.Any, 3001);

        /// <summary>
        /// Starts the server.
        /// </summary>
        public TCPServer()
        {
            // Starts the listener.
            listener.Start();

            while (true)
            {
                // Waits for a client to connect.
                Console.WriteLine("Waiting for a connection...");
                var client = listener.AcceptTcpClient();
                Console.WriteLine("Connected!");

                // Creates a new task to handle the requsts of the client.
                var task = new Task(() =>
                {
                    // The stream.
                    var stream = client.GetStream();

                    // The stream reader.
                    var reader = new StreamReader(stream);

                    // Container for the user message.
                    string msg = "";

                    // The stream writer.
                    var writer = new StreamWriter(stream);
                    writer.AutoFlush = true;

                    // Starts listening to the client.
                    while (true)
                    {
                        // Gets the user message.
                        msg = reader.ReadLine();

                        // Checks if the user wants to end the session.
                        if (!(msg.ToLower().Replace(" ", "") == "end"))
                        {
                            // Uses the Calculator service to handle the request 
                            // and returns the answer to the client.
                            writer.WriteLine(Calculator.Handle(msg.Replace(" ", "")));
                        }
                        else
                        {
                            // Stops waiting for messages form the client if the client has ended the session.
                            break;
                        }
                    }
                });

                // Starts the task.
                task.Start();
            }
        }
    }
}
