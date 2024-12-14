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

namespace 聊天室客户端
{
    public partial class FormClient : Form
    {
        private Socket clientSoc;
        public FormClient()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void FormClient_Load(object sender, EventArgs e)
        {
            this.textBoxInputPort.Text = "12202";
            clientSoc = null;
            
        }

        private void buttonLink_Click(object sender, EventArgs e)
        {
            IPAddress addr = IPAddress.Parse(this.textBoxInputIP.Text.ToString().Trim());
            IPEndPoint endp = new IPEndPoint(addr, Int16.Parse(this.textBoxInputPort.Text.ToString().Trim()));
            clientSoc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSoc.Connect(endp);
                this.toolStripStatusLabelLog.Text = "服务器创建成功";
                new Thread(ReceiveMsg).Start();
            }
            catch (Exception)
            {
                this.toolStripStatusLabelLog.Text = "服务器创建失败";
            }
           
            
        }
        private void ReceiveMsg()
        {
            while(true)
            {
                byte[] buffer = new byte[1024];
                try
                {
                    int len = clientSoc.Receive(buffer);
                    this.listBoxMsgs.Items.Add(Encoding.Default.GetString(buffer));
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string str = this.textBoxInputMsg.Text.Trim();
            if(str.Length>0)
                clientSoc.Send(Encoding.Default.GetBytes(str));
            this.textBoxInputMsg.Text = "";
        }

        private void textBoxInputMsg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                string str = this.textBoxInputMsg.Text.Trim();
                if (str.Length > 0)
                    clientSoc.Send(Encoding.Default.GetBytes(str));
                this.textBoxInputMsg.Text = "";
            }
        }
    }
}
