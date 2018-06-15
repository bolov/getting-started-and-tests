using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static IList<IPAddress> GetAllIpv4Addresses()
        {
            List<IPAddress> addresses = new List<IPAddress>();

            foreach (var i in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (var ua in i.GetIPProperties().UnicastAddresses)
                {
                    if (ua.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        addresses.Add(ua.Address);
                }
            }

            return addresses;
        }

        static void ServeAClient(TcpListener server)
        {
            server.Start();
            Console.WriteLine(" :: started");

            Console.WriteLine(" :: w8 for client");

            TcpClient client = null;

            try
            {
                client = server.AcceptTcpClient();
                server.Stop();

                Console.WriteLine(" :: got client");

                NetworkStream stream = client.GetStream();
                Console.WriteLine(" :: got stream");

                byte[] buffer = new byte[client.ReceiveBufferSize];

                int bytesRead;
                Console.WriteLine(" :: reading");
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string msg = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("received: '{0}'", msg);

                    Console.WriteLine(" :: reading");
                }
            }
            finally
            {
                client?.Close();
                Console.WriteLine(" :: client done");

                server?.Stop();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(" :: Server :: ");
            Console.ReadKey();

            IList<IPAddress> addresses = GetAllIpv4Addresses();

            foreach (IPAddress adr in addresses)
                Console.WriteLine(String.Format("{0}", adr));

            Console.WriteLine();

            TcpListener server = null;
            try
            {
                string ipString = "127.0.0.1";
                int port = 50100;

                IPAddress ip = IPAddress.Parse(ipString);
                ip = IPAddress.Any;

                server = new TcpListener(ip, port);

                while (true)
                {
                    try
                    {
                        ServeAClient(server);
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine("erro client: " + e);
                    }
                }

            }
            catch (Exception e)
            {
                Console.Error.WriteLine("error: " + e);
            }
        }
    }
}
