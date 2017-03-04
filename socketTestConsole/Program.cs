using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace socketTestConsole
{
    class Server
    {
        static void Main(string[] args)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("192.168.31.171"), 9050); //本机预计使用的IP和端口
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            newsock.Bind(ipep);
            newsock.Listen(10);

            Console.WriteLine("waiting for a client...");

            Socket client = newsock.Accept(); //当有可用的客户端连接尝试时执行，并返回一个新的socket，用于与客户端之间的通信
            IPEndPoint clientip = (IPEndPoint)client.RemoteEndPoint;
            Console.WriteLine("connect with client:" + clientip.Address + " at port " + clientip);

            while (true)
            {
                var data = new byte[1024];
                var recv = client.Receive(data);
                Console.WriteLine("recv:" + recv);
                if (recv == 0)
                {
                    break;
                }
                Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
                client.Send(data, recv, SocketFlags.None);
            }

            Console.WriteLine("Disconnect from " + clientip.Address);
            client.Close();
            newsock.Close();
        }
    }
}
