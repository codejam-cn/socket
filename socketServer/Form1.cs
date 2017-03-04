using System;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using socketServer.Properties;

namespace socketServer
{
    public partial class FrmServer : Form
    {
        private ReceiveMessageDelegate _receiveMessageDelegate;
        private string _serverIp;
        private int _serverPort;
        private Socket _socket;
        private Thread _thread;

        public FrmServer()
        {
            InitializeComponent();
        }


        private void frmServer_Load(object sender, EventArgs e)
        {
            var addresses = GetLocalAddress();
            cmbIp.Items.Clear();
            if (addresses.Length > 0)
            {
                foreach (string t in addresses)
                {
                    cmbIp.Items.Add(t);
                }
                cmbIp.Text = (string) cmbIp.Items[2];
            }
            ServerPortText.Text = Resources.FrmServer_frmServer_Load__8899;
        }

        public string[] GetLocalAddress()
        {
            // 获取主机名
            var strHostName = Dns.GetHostName();
            // 根据主机名进行查找
            var iphostentry = Dns.GetHostEntry(strHostName);
            var retval = new string[iphostentry.AddressList.Length];
            var i = 0;
            foreach (var ipaddress in iphostentry.AddressList)
            {
                retval[i] = ipaddress.ToString();
                i++;
            }
            return retval;
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            _serverIp = cmbIp.Text;
            _serverPort = int.Parse(ServerPortText.Text);
            Start();
            StartBtn.Enabled = false;
            StopBtn.Enabled = true;
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            Stop();
            StartBtn.Enabled = true;
            StopBtn.Enabled = false;
        }


        private void Start()
        {
            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var localEndPoint = new IPEndPoint(IPAddress.Parse(_serverIp), _serverPort);
                _socket.Bind(localEndPoint);
                _socket.Listen(10);
                _thread = new Thread(ReceiveAccept);
                _thread.Start();
                AddRunningInfo(">> " + DateTime.Now.ToString(CultureInfo.CurrentCulture) + " Server started.");
            }
            catch (SocketException se)
            {
                throw new Exception(se.Message);
            }
        }

        private void Stop()
        {
            try
            {
                _thread.Abort(); // 线程终止
                _socket.Close(); // Socket Close
                AddRunningInfo(">> " + DateTime.Now.ToString(CultureInfo.InvariantCulture) + " Server stoped.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        private void ReceiveAccept()
        {
            while (true)
            {
                var client = new Client();
                try
                {
                    client.ClientSocket = _socket.Accept();
                    AddRunningInfo(">> " + DateTime.Now.ToString(CultureInfo.InvariantCulture) + " Client[" +
                                   client.ClientSocket.RemoteEndPoint + "] connected.");
                    _receiveMessageDelegate = ReceiveMessages;
                    _receiveMessageDelegate.BeginInvoke(client, ReceiveMessagesCallback, "");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        private void ReceiveMessages(Client client)
        {
            while (true)
            {
                var receiveBuffer = new byte[1024];
                client.ClientSocket.Receive(receiveBuffer);
                var strReceiveData = Encoding.Unicode.GetString(receiveBuffer);
                if (!string.IsNullOrEmpty(strReceiveData))
                {
                    AddRunningInfo(">> Receive data from [" + client.ClientSocket.RemoteEndPoint + "]:" + strReceiveData);
                    var strSendData = "OK. The content is:" + strReceiveData;
                    var sendBuffer = Encoding.Unicode.GetBytes(strSendData);
                    client.ClientSocket.Send(sendBuffer);
                }
            }
        }

        private void ReceiveMessagesCallback(IAsyncResult ar)
        {
            _receiveMessageDelegate.EndInvoke(ar);
        }

        /// <summary>
        ///     将运行信息加入显示列表
        /// </summary>
        private void AddRunningInfo(string message)
        {
            richTextBox1.Text = richTextBox1.Text + @"\r" + message;
        }

        private delegate void ReceiveMessageDelegate(Client client);

        /// <summary>
        ///     客户端会话信息类
        /// </summary>
        public class Client
        {
            public Socket ClientSocket { get; set; }
        }
    }
}