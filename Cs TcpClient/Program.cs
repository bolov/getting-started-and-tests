using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        private static TcpClient client = null;

        static private string ipString; // = "192.168.1.107";
        static private int port = 50100;

        static void Main(string[] args)
        {
            NetworkStream stream = null;

            //Console.Write("ip: ");
            //string ipString = Console.ReadLine();
            ipString = "127.0.0.1";
            Console.WriteLine("  :: Clinet");
            Console.ReadKey();

            try
            {
                client = new TcpClient();
                client.Connect(ipString, port);
                Console.WriteLine(" :: connected");
                stream = client.GetStream();
                Console.WriteLine(" :: got stream");

                while (true)
                {
                    Console.Write(">");
                    string line = Console.ReadLine();
                    if (line.ToUpper() == "EXIT")
                        break;

                    int byteCound = Encoding.ASCII.GetByteCount(line);

                    byte[] sendData = Encoding.ASCII.GetBytes(line);

                    stream.Write(sendData, 0, sendData.Length);
                    Console.WriteLine(" :: sent");
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(String.Format("error connect: {0}", e));

                return;
            }

            Console.WriteLine("done");

            stream?.Close();
            client?.Close();
        }
    }
}
