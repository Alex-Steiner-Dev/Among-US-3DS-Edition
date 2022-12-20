using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Game_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server("2.40.58.180", 3000);
        }
    }
}