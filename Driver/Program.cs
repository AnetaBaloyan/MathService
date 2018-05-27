using System;

namespace MathServer
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("1 - UDP \n2 - TCP\n");
            switch(Console.ReadLine())
            {
                case "1":
                    var clientUDP = new UDPClient();
                    break;
                     
                case "2":
                    var clientTCP = new TCPClient();
                    break;
                    
            }
        }
    }
}
