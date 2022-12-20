using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Game_Server
{
    internal class Server
    {
        public Server(string ipString, int port)
        {
            IPAddress ip = IPAddress.Parse(ipString);

            TcpListener server = new TcpListener(ip, port);
            server.Start();
            
            Console.WriteLine("Server started on  " + ip.MapToIPv4() + ":" + port);

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("New client connected");

                NetworkStream stream = client.GetStream();

                while (true)
                {
                    byte[] data = new byte[1024];
                    int bytesRead = stream.Read(data, 0, data.Length);
                    string message = Encoding.ASCII.GetString(data, 0, bytesRead);

                    byte[] response = Encoding.ASCII.GetBytes(message);
                    stream.Write(response, 0, response.Length);

                    Console.WriteLine("Received: " + message);
                }
            }
        }
    }
}
