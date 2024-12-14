using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StyleSuit
{
    public partial class FormStyle : Form
    {
        private bool mIsMaxWnd=false;
        private string mTitleWnd = "FormStyle";
        private string mNameWnd = "New Window";
        private Point mCursorPoint;
        private int beforeHeight;
        private bool allowMove;
        public FormStyle()
        {
            InitializeComponent();
            TitleWnd = "FormStyle";
            NameWnd = "New Window";
            beforeHeight = this.Height;
            allowMove = true;
        }

        public bool MaxWnd
        {
            get { return mIsMaxWnd;}
            set
            {
                mIsMaxWnd = value;
                if (mIsMaxWnd)
                    this.WindowState = FormWindowState.Maximized;
                else
                    this.WindowState = FormWindowState.Normal;
            }
        }
        public override string Text
        {
            get { return mTitleWnd; }
            set
            {
                mTitleWnd = value;
                this.buttonTitleWnd.Text = mTitleWnd;
            }
        }
        public string TitleWnd
        {
            get { return mTitleWnd; }
            set
            {
                mTitleWnd = value;
                this.buttonTitleWnd.Text = mTitleWnd;
            }
        }

        public string NameWnd
        {
            get { return mNameWnd; }
            set
            {
                mNameWnd = value;
                this.buttonNameWnd.Text = mNameWnd;
            }
        }

        public virtual void buttonMinWnd_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public virtual void buttonMaxWnd_Click(object sender, EventArgs e)
        {
            MaxWnd = !MaxWnd;
        }

        public virtual void buttonCloseWnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void panelHead_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MaxWnd = !MaxWnd;
        }


        public virtual void panelHead_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && allowMove)
            {
                this.Location = new Point(this.Location.X + e.X - mCursorPoint.X, this.Location.Y + e.Y - mCursorPoint.Y);
            }
               
        }

        public virtual void FormStyle_Resize(object sender, EventArgs e)
        {
            if (this.Size.Width < 10)
                this.Size = new Size(10,this.Size.Height);
            if (this.Size.Height < 10)
                this.Size = new Size(this.Size.Width,10 );
            this.buttonNameWnd.Location = new Point(this.Size.Width/2-this.buttonNameWnd.Size.Width/2,this.buttonNameWnd.Location.Y);
        }



        public virtual void panelBorder_MouseDown(object sender, MouseEventArgs e)
        {
            mCursorPoint = e.Location;
        }


        public virtual void panelBorderResize_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Size = new Size(this.Size.Width + e.X - mCursorPoint.X, this.Size.Height + e.Y - mCursorPoint.Y);
                mCursorPoint = e.Location;
            }
        }

        private void buttonShrink_Click(object sender, EventArgs e)
        {
            if (this.Height == this.panelHeadBorder.Height + this.panelButtomBorder.Height)
            {
                this.Height = beforeHeight;
            }else
            {
                beforeHeight = this.Height;
                this.Height = this.panelHeadBorder.Height + this.panelButtomBorder.Height;
            }
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            allowMove = !allowMove;
        }

       
    }
}
