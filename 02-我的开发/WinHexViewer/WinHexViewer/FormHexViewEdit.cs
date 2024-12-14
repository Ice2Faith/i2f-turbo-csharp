using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinHexViewer
{
    public partial class FormHexViewEdit : Form
    {
        public FormHexViewEdit()
        {
            InitializeComponent();
            this.hexViewer1.DisplayLineCount = 32;
            this.hexViewer1.LineByteCount = 16;
            this.hexViewer1.FileName = "";
        }
        public FormHexViewEdit(string openFile)
        {
            InitializeComponent();
            this.hexViewer1.DisplayLineCount = 32;
            this.hexViewer1.LineByteCount = 16;
            this.hexViewer1.FileName = openFile;
        }

    }
}
