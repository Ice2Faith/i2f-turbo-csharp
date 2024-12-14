using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloCSharp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void checkBox_MAN_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_MAN.Checked == false)
            {
                this.checkBox_WOMAN.Checked = true;
            }
            else
            {
                this.checkBox_WOMAN.Checked = false;
            }
            
        }

        private void checkBox_WOMAN_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_WOMAN.Checked==false)
            {
                this.checkBox_MAN.Checked = true;
            }else
            {
                this.checkBox_MAN.Checked = false;
            }
            
        }

        private void button_LOGIN_Click(object sender, EventArgs e)
        {
            string name = this.textBox_NAME.Text;
            string pwd = this.textBox_PWD.Text;
            string tel = this.textBox_TEL.Text;
            bool isman=true;
            if(this.checkBox_WOMAN.Checked==true)
            {
                isman = false;
            }
            string date = this.monthCalendar_DATE.SelectionStart.ToString();
            if(name.Equals("") || pwd.Equals("") || tel.Equals(""))//比较对象应该使用equals方法，否则会调用默认object类的equals方法导致出错
            {
                MessageBox.Show("姓名、密码、电话不能为空！！", "登录错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string outstr = "注册信息：\n姓名：" + name + "\n密码：" + pwd + "\n电话：" + tel + "\n性别：" + (isman == true ? "男" : "女") + "\n日期：" + date;
                MessageBox.Show(outstr, "登录成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.checkBox_MAN.Checked = true;
        }
    }
}
