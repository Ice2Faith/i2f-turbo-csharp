using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections;

using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace WinIFEO
{
    public partial class IFEOFrom : Form
    {
        public IFEOFrom()
        {
            InitializeComponent();
        }
        private void reloadIFEO2Show()
        {
            this.listViewIFEO.Items.Clear();
            List<IFEOManage.IFEOItem> list = IFEOManage.getAll();

            foreach (IFEOManage.IFEOItem item in list)
            {
                ListViewItem lv = new ListViewItem();
                lv.Text = item.keyName;
                lv.SubItems.Add(item.debugger);
                lv.Tag = item;
                this.listViewIFEO.Items.Add(lv);
            }
        }
        private void listViewIFEO_VisibleChanged(object sender, EventArgs e)
        {
            if (!e.GetType().IsVisible)
            {
                return;
            }
            reloadIFEO2Show();
        }
        private void reloadRightMenu2Show()
        {
            this.listViewRightMenu.Items.Clear();
            List<RightMenuManage.RightMenuItem> list = RightMenuManage.getAll();

            foreach (RightMenuManage.RightMenuItem item in list)
            {
                ListViewItem lv = new ListViewItem();
                lv.Text = item.keyName;
                lv.SubItems.Add(item.command);
                lv.Tag = item;
                this.listViewRightMenu.Items.Add(lv);
            }
        }
        private void listViewRightMenu_VisibleChanged(object sender, EventArgs e)
        {
            if (!e.GetType().IsVisible)
            {
                return;
            }
            reloadRightMenu2Show();
        }
        private void reloadBootItem2Show()
        {
            this.listViewBootItem.Items.Clear();
            List<BootItemManage.BootItemItem> list = BootItemManage.getAll();

            foreach (BootItemManage.BootItemItem item in list)
            {
                ListViewItem lv = new ListViewItem();
                lv.Text = item.valName;
                lv.SubItems.Add(item.application);
                lv.Tag = item;
                this.listViewBootItem.Items.Add(lv);
            }
        }
        private void listViewBootItem_VisibleChanged(object sender, EventArgs e)
        {
            if (!e.GetType().IsVisible)
            {
                return;
            }
            reloadBootItem2Show();
        }

        private void buttonChoiceIFEO_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Filter = "可执行|*.exe";
           DialogResult result= this.openFileDialog.ShowDialog(this);
           this.textBoxIFEOVal.Text=this.openFileDialog.FileName;
        }

        private void buttonDoIFEO_Click(object sender, EventArgs e)
        {
            string name = this.textBoxIFEOName.Text;
            string val = this.textBoxIFEOVal.Text;
            bool success=IFEOManage.add(name, val);
            if (success)
            {
                reloadIFEO2Show();
                MessageBox.Show(this, "映像劫持成功", "映像劫持提示框");
            }
            else
            {
                MessageBox.Show(this, "映像劫持失败", "映像劫持提示框");
            }
        }

        private void buttonEmptyIFEO_Click(object sender, EventArgs e)
        {
            string name = this.textBoxIFEOName.Text;
            bool success = IFEOManage.empty(name);
            if (success)
            {
                reloadIFEO2Show();
                MessageBox.Show(this, "清除映像劫持成功", "映像劫持提示框");
            }
            else
            {
                MessageBox.Show(this, "清除映像劫持失败", "映像劫持提示框");
            }
        }

        private void buttonDelIFEO_Click(object sender, EventArgs e)
        {
            string name = this.textBoxIFEOName.Text;
            bool success = IFEOManage.del(name);
            if (success)
            {
                reloadIFEO2Show();
                MessageBox.Show(this, "删除映像劫持成功", "映像劫持提示框");
            }
            else
            {
                MessageBox.Show(this, "删除映像劫持失败", "映像劫持提示框");
            }
        }

        private void listViewIFEO_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListViewItem lvt = e.Item;
            if (lvt == null)
            {
                return;
            }
            IFEOManage.IFEOItem item=lvt.Tag as IFEOManage.IFEOItem;
            this.textBoxIFEOName.Text = item.keyName;
            this.textBoxIFEOVal.Text = item.debugger;
        }

        private void splitContainerIFEOMain_SizeChanged(object sender, EventArgs e)
        {

            try
            {
                this.splitContainerIFEOMain.SplitterDistance = (int)(this.textBoxIFEOName.Height * 2.5);
                this.listViewIFEO.Columns[0].Width = (int)(this.listViewIFEO.Width * 0.33);
                this.listViewIFEO.Columns[1].Width = (int)(this.listViewIFEO.Width * 0.66);
            }
            catch (Exception)
            {
                
            }
        }

        private void listViewRightMenu_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListViewItem lvt = e.Item;
            if (lvt == null)
            {
                return;
            }
            RightMenuManage.RightMenuItem item = lvt.Tag as RightMenuManage.RightMenuItem;
            this.textBoxRightMenuName.Text = item.keyName;
            this.textBoxRightMenuVal.Text = item.command;
            this.textBoxRightMenuArgs.Text = "";
        }

        private void splitContainerRightMenuMain_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                this.splitContainerRightMenuMain.SplitterDistance = (int)(this.textBoxRightMenuName.Height * 2.5);
                this.listViewRightMenu.Columns[0].Width = (int)(this.listViewRightMenu.Width * 0.33);
                this.listViewRightMenu.Columns[1].Width = (int)(this.listViewRightMenu.Width * 0.66);
            }
            catch (Exception)
            {

            }
        }

        private void buttonChoiceRightMenu_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Filter = "可执行|*.exe";
            DialogResult result = this.openFileDialog.ShowDialog(this);
            this.textBoxRightMenuVal.Text = this.openFileDialog.FileName;
        }

        private void buttonSaveRightMenu_Click(object sender, EventArgs e)
        {
            string name = this.textBoxRightMenuName.Text;
            string val = this.textBoxRightMenuVal.Text;
            string args = this.textBoxRightMenuArgs.Text;
            bool success = RightMenuManage.add(name, val,args);
            if (success)
            {
                reloadRightMenu2Show();
                MessageBox.Show(this, "右键菜单成功", "右键菜单提示框");
            }
            else
            {
                MessageBox.Show(this, "右键菜单失败", "右键菜单提示框");
            }
        }

        private void buttonDelRightMenu_Click(object sender, EventArgs e)
        {
            string name = this.textBoxRightMenuName.Text;
            bool success = RightMenuManage.del(name);
            if (success)
            {
                reloadRightMenu2Show();
                MessageBox.Show(this, "右键菜单删除成功", "右键菜单提示框");
            }
            else
            {
                MessageBox.Show(this, "右键菜单删除失败", "右键菜单提示框");
            }
        }

        private void buttonEmptyRightMenu_Click(object sender, EventArgs e)
        {
            string name = this.textBoxRightMenuName.Text;
            bool success = RightMenuManage.empty(name);
            if (success)
            {
                reloadRightMenu2Show();
                MessageBox.Show(this, "右键菜单清空成功", "右键菜单提示框");
            }
            else
            {
                MessageBox.Show(this, "右键菜单清空失败", "右键菜单提示框");
            }
        }

        private void splitContainerBootItemMain_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                this.splitContainerBootItemMain.SplitterDistance = (int)(this.textBoxBootItemName.Height * 2.5);
                this.listViewBootItem.Columns[0].Width = (int)(this.listViewBootItem.Width * 0.33);
                this.listViewBootItem.Columns[1].Width = (int)(this.listViewBootItem.Width * 0.66);
            }
            catch (Exception)
            {

            }
        }

        private BootItemManage.BootItemItem curSelBootItem = null;
        private void listViewBootItem_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListViewItem lvt = e.Item;
            if (lvt == null)
            {
                curSelBootItem = null;
                return;
            }
            BootItemManage.BootItemItem item = lvt.Tag as BootItemManage.BootItemItem;
            curSelBootItem = item;
            this.textBoxBootItemName.Text = item.valName;
            this.textBoxBootItemVal.Text = item.application;
            this.textBoxBootItemArgs.Text = "";
        }

        private void buttonChoiceBootItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog.Filter = "可执行|*.exe";
            DialogResult result = this.openFileDialog.ShowDialog(this);
            this.textBoxBootItemVal.Text = this.openFileDialog.FileName;
        }

        private void buttonSaveBootItem_Click(object sender, EventArgs e)
        {
            string name = textBoxBootItemName.Text;
            string val = textBoxBootItemVal.Text;
            string args = textBoxBootItemArgs.Text;
            bool success = BootItemManage.add(name,val,args);
            if (success)
            {
                reloadBootItem2Show();
                MessageBox.Show(this, "启动项添加成功", "启动项提示框");
            }
            else
            {
                MessageBox.Show(this, "启动项添加失败", "启动项提示框");
            }
        }

        private void buttonEmptyBootItem_Click(object sender, EventArgs e)
        {
            bool success = BootItemManage.empty(curSelBootItem);
            if (success)
            {
                reloadBootItem2Show();
                MessageBox.Show(this, "启动项清空成功", "启动项提示框");
            }
            else
            {
                MessageBox.Show(this, "启动项清空失败", "启动项提示框");
            }
        }

        private void buttonDelBootItem_Click(object sender, EventArgs e)
        {
            bool success = BootItemManage.del(curSelBootItem);
            if (success)
            {
                reloadBootItem2Show();
                MessageBox.Show(this, "启动项删除成功", "启动项提示框");
            }
            else
            {
                MessageBox.Show(this, "启动项删除失败", "启动项提示框");
            }
        }

        private void buttonUpdBootItem_Click(object sender, EventArgs e)
        {
            string val = textBoxBootItemVal.Text;
            string args = textBoxBootItemArgs.Text;
            bool success = BootItemManage.update(curSelBootItem, val, args);
            if (success)
            {
                reloadBootItem2Show();
                MessageBox.Show(this, "启动项更新成功", "启动项提示框");
            }
            else
            {
                MessageBox.Show(this, "启动项更新失败", "启动项提示框");
            }
        }
    }
}
