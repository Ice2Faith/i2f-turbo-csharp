using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.IO;

namespace 聊天室服务器
{
    public partial class FormServer : Form
    {
        private Socket serverSoc;
        private List<Socket> clientSocList;
        public FormServer()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void FormServer_Load(object sender, EventArgs e)
        {
            IPHostEntry he = Dns.GetHostEntry(Dns.GetHostName());
            foreach(IPAddress iad in he.AddressList)
            {
                this.comboBoxIP.Items.Add(iad.ToString());
            }
            this.comboBoxIP.SelectedIndex = 0;
            this.textBoxInputPort.Text = "12202";
            serverSoc = null;
            clientSocList=new List<Socket>();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            serverSoc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress addr = IPAddress.Parse(this.comboBoxIP.SelectedItem.ToString().Trim());
            IPEndPoint endp = new IPEndPoint(addr, Int16.Parse(this.textBoxInputPort.Text.Trim()));
            try
            {
                serverSoc.Bind(endp);
                serverSoc.Listen(1024);
                this.buttonRun.Enabled = false;
                this.toolStripStatusLabelLog.Text = "服务器创建成功";
                new Thread(AcceptClient).Start();
                
            }
            catch (Exception)
            {
                this.toolStripStatusLabelLog.Text = "服务器创建失败";
            }
           
        }
        private void AcceptClient()
        {
            while(true)
            {
                Socket client = serverSoc.Accept();
                clientSocList.Add(client);
                new Thread(ReceiveMsg).Start();
            }
        }
        private void ReceiveMsg()
        {
            Socket clientSoc=clientSocList[clientSocList.Count-1];
            IPEndPoint cep = clientSoc.RemoteEndPoint as IPEndPoint;
            this.toolStripStatusLabelLog.Text = "客户端" + cep.Address.ToString()+":"+cep.Port + "已连接";
            foreach (Socket clt in clientSocList)
            {
                clt.Send(Encoding.Default.GetBytes("系统提示：" + cep.Port + "加入群聊"));
            }
            while(true)
            {
                byte[] buffer = new byte[1024];
                try
                {
                    int len = clientSoc.Receive(buffer);
                }catch(Exception)
                {
                    clientSocList.Remove(clientSoc);
                    foreach (Socket clt in clientSocList)
                    {
                        clt.Send(Encoding.Default.GetBytes("系统提示：" + cep.Port + "离开群聊"));
                    }
                    return;
                }
                string str=Encoding.Default.GetString(buffer);
                foreach(Socket clt in clientSocList)
                {
                    clt.Send(Encoding.Default.GetBytes(cep.Port + "说:" + str));
                }
                clientSoc.Send(buffer);
                this.listBoxMsgs.Items.Add(cep.Port+"说:"+str);
            }
        }

        private void buttonBroad_Click(object sender, EventArgs e)
        {
            string str=this.textBoxInputBroad.Text.Trim();
            if(str.Length>0)
            foreach (Socket clt in clientSocList)
            {
                clt.Send(Encoding.Default.GetBytes("系统广播：" +str ));
                this.textBoxInputBroad.Text = "";
            }
           
        }

        private void textBoxInputBroad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string str = this.textBoxInputBroad.Text.Trim();
                if (str.Length > 0)
                    foreach (Socket clt in clientSocList)
                    {
                        clt.Send(Encoding.Default.GetBytes("系统广播：" + str));
                        this.textBoxInputBroad.Text = "";
                    }
            }
        }
    }
}
