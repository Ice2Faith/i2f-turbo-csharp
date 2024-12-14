using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * 代码实现：
 * 只要没有点击到任意按钮不能关闭窗口
 * 其中No按钮不允许点击，会移动到鼠标之外区域
 */
namespace ClickMe
{
    public partial class Form1 : Form
    {
        //定义随机数
        private Random rand;
        //定义移动次数控制
        private int times;
        //定义yes按钮位置
        private Point rpoint;
        public Form1()
        {
            InitializeComponent();
            //去除关闭按钮
            this.ControlBox = false;
            //初始化随机数
            rand = new Random();
            //初始化等待次数
            times = 0;
            //记录原始yes按钮位置
            rpoint = this.button_yes.Location;
            //将yes按钮移出窗口
            this.button_yes.Location = new Point(this.Size.Width,this.Size.Height);
        }

        private void button_clickme_MouseMove(object sender, MouseEventArgs e)
        {
            //随机设置No按钮的位置，只要鼠标进入No按钮
            Point point = new Point();
            point.X= rand.Next() %( this.Size.Width-this.button_no.Size.Width);
            point.Y=rand.Next() % (this.Size.Height-this.button_no.Size.Height);
            this.button_no.Location = point;
            //记录何时显示yes按钮
            if(times<10)
                times++;
            if(times>=10)
            {
                this.button_yes.Location = rpoint;
            }

        }
        //点击到任意按钮之后给出提示，并显示关闭按钮
        private void button_yes_Click(object sender, EventArgs e)
        {
            this.label_tips.Text = "Trash";
            this.ControlBox = true;
        }

        private void button_no_Click(object sender, EventArgs e)
        {
            this.label_tips.Text = "Crying";
            this.ControlBox = true;
        }
    }
}
