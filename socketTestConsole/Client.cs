/*
 * ps:面向无连接的UDP的socket写法以及Server.cs  Client.cs都是出自这篇博文。
 * 可参考。
 * http://www.cnblogs.com/stg609/archive/2008/11/15/1333889.html
 * 
 
 */

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace socketTestConsole
{
    class Client
    {
        private static void Main1(string[] args)
        {
            byte[] data = new byte[1024];
            Socket newclient = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("please input the server ip:");
            string ipadd = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Please input the server port:");
            int port = int.Parse(Console.ReadLine());

            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(ipadd),port );


            //因为客户端只是用来向特定的服务器发送信息，所以不需要绑定本机的ip和端口，不需要监听
            try
            {
                newclient.Connect(ie);
            }
            catch (SocketException e)
            {
                Console.WriteLine("ubable to connect to server");
                Console.WriteLine(e.ToString());
                throw;
            }


            int recv = newclient.Receive(data);
            string stringdata = Encoding.ASCII.GetString(data, 0, recv);
            Console.WriteLine(stringdata);
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exit")
                {
                    break;
                }
                newclient.Send(Encoding.ASCII.GetBytes(input));
                data = new byte[1024];
                recv = newclient.Receive(data);
                stringdata = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine(stringdata);
            }


            Console.WriteLine("disconnect form server");
            newclient.Shutdown(SocketShutdown.Both);
            newclient.Close();

        }
    }
}
