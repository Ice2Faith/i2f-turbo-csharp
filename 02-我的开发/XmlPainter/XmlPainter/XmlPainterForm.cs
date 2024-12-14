using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XmlPainter
{
    public partial class XmlPainterForm : Form
    {
        public enum OperType
        {
            Cursor, Line, Arrow, FillArrow, Text, S_Circle, S_Rectangle, S_Ellipse, E_Diamond, E_Triangle, E_RoundRectangle
        }
        private PainterMetaData data;
        private OperType operType = OperType.Cursor;
        private List<string> selectIds = new List<string>();
        private Point downPoint;

        public XmlPainterForm()
        {
            InitializeComponent();
            data = new PainterMetaData();
            data.edges = new List<PainterEdge>();
            data.shapes = new List<PainterShape>();
            this.WindowState = FormWindowState.Maximized;
            this.pictureBoxMain.Image = new Bitmap(this.pictureBoxMain.Width, this.pictureBoxMain.Height);

        }

        private void XmlPainterForm_Load(object sender, EventArgs e)
        {
            
            
        }

       
        private void refreshDraw()
        {
            SizeD size = data.normalize();
            Image img = new Bitmap(Math.Max((int)(size.width),this.pictureBoxMain.Width), Math.Max((int)(size.height),this.pictureBoxMain.Height));
            Graphics gra = Graphics.FromImage(img);
            gra.DrawRectangle(new Pen(Color.Silver), 0, 0, img.Width - 1, img.Height - 1);
            data.draw(gra);
            foreach (string id in selectIds)
            {
                Brush brush=new SolidBrush(Color.Red);
                Pen pen=new Pen(Color.Red);
                foreach (PainterShape item in data.shapes)
                {
                    if (item.id == id)
                    {
                        gra.FillEllipse(brush, (int)item.centerX(), (int)item.centerY(), 5, 5);
                    }
                }
                foreach (PainterEdge item in data.edges)
                {
                    if (item.id == id)
                    {
                        EdgeEndpoint ed = this.data.findEndpoint(item);
                        double cx = (ed.begin.centerX() + ed.end.centerX()) / 2.0;
                        double cy = (ed.begin.centerY() + ed.end.centerY()) / 2.0;
                        gra.FillEllipse(brush, (int)cx, (int)cy, 5, 5);
                    }
                }
            }
            this.pictureBoxMain.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBoxMain.Image = img;
        }

        private void OpenInFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filter = "xml文件|*.xml|所有文件|*.*";
            this.openFileDialogMain.FileName = "";
            this.openFileDialogMain.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            this.openFileDialogMain.Filter = filter;
            DialogResult rs = this.openFileDialogMain.ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                string filename = this.openFileDialogMain.FileName;
                if (filename != null && filename.Length > 0)
                {
                    data=XmlPainterUtil.loadPainter(filename);
                    refreshDraw();
                }
            }
        }

        private void SaveInFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filter = "xml文件|*.xml|所有文件|*.*";
            string fname = "painter.xml";
            
            this.saveFileDialogMain.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            this.saveFileDialogMain.Filter = filter;
            this.saveFileDialogMain.FileName = fname;

            DialogResult rs = this.saveFileDialogMain.ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                string filename = this.saveFileDialogMain.FileName;
                if (filename != null && filename.Length > 0)
                {
                    XmlPainterUtil.savePainter(data, filename);
                }
            }
        }

        private void SavePictureInFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filter = "xml文件|*.xml|所有文件|*.*";
            string fname = "painter.png";

            this.saveFileDialogMain.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            this.saveFileDialogMain.Filter = filter;
            this.saveFileDialogMain.FileName = fname;

            DialogResult rs = this.saveFileDialogMain.ShowDialog(this);
            if (rs == DialogResult.OK)
            {
                string filename = this.saveFileDialogMain.FileName;
                if (filename != null && filename.Length > 0)
                {
                    this.pictureBoxMain.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }

 

        private void pictureBoxMain_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBoxMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point cp = cvtLogicalPoint(e.Location);
            if (operType == OperType.Text)
            {
                foreach (PainterShape item in data.shapes)
                {
                    double dis = distance(cp.X, cp.Y, item.centerX(), item.centerY());
                    if (dis < 20)
                    {
                        string text = InputForm.input(this, "请输入文字：", "输入框", item.text);
                        item.text = text.Trim();
                    }
                }
                foreach (PainterEdge item in data.edges)
                {
                    EdgeEndpoint ed = data.findEndpoint(item);
                    double cx = (ed.begin.centerX() + ed.end.centerX()) / 2.0;
                    double cy = (ed.begin.centerY() + ed.end.centerY()) / 2.0;
                    double dis = distance(cp.X, cp.Y, cx, cy);
                    if (dis < 20)
                    {
                        string text = InputForm.input(this, "请输入文字：", "输入框", item.text);
                        item.text = text.Trim();
                    }
                }
                
            }
        }

        private Point cvtLogicalPoint(Point p)
        {
            double dx= p.X * 1.0 / this.pictureBoxMain.Width * this.pictureBoxMain.Image.Width;
            double dy = p.Y * 1.0 / this.pictureBoxMain.Height * this.pictureBoxMain.Image.Height;
            return new Point((int)dx, (int)dy);
        }
        private double distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2.0) + Math.Pow(y2 - y1, 2.0));
        }
        private bool isCtrlDown = false;
        private bool isShiftDown = false;
        private bool isAltDown = false;
        private Point lastPoint;
        private void pictureBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
            downPoint = e.Location;
            Point cp = cvtLogicalPoint(downPoint);
            if (!isCtrlDown)
            {
                selectIds.Clear();
            }

            List<string> tempIds = new List<string>();
            
            foreach (PainterShape item in data.shapes)
            {
                double dis = distance(cp.X, cp.Y, item.centerX(), item.centerY());
                if (dis < 20)
                {
                    tempIds.Add(item.id);
                }
            }
            if (tempIds.Count == 0)
            {
                selectIds.Clear();
            }
            else
            {
                selectIds.AddRange(tempIds);
            }
        }
        
        private void pictureBoxMain_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (operType == OperType.Cursor && e.Button==MouseButtons.Right)
            {
                Point cd = cvtLogicalPoint(lastPoint);
                Point cp = cvtLogicalPoint(e.Location);
                lastPoint = e.Location;
                double dx = cp.X - cd.X;
                double dy = cp.Y - cd.Y;
                foreach (PainterShape item in data.shapes)
                {
                    foreach (string id in selectIds)
                    {
                        if (id == item.id)
                        {
                            item.posX += dx;
                            item.posY += dy;
                        }
                    }
                }
            }
            refreshDraw();
        }

        private void pictureBoxMain_MouseUp(object sender, MouseEventArgs e)
        {
            
            if (operType == OperType.Line || operType==OperType.Arrow || operType==OperType.FillArrow)
            {
                Point cd = cvtLogicalPoint(downPoint);
                Point cp = cvtLogicalPoint(e.Location);
                string fromId = null;
                string toId = null;
                foreach (PainterShape item in data.shapes)
                {
                    double dis = distance(cd.X, cd.Y, item.centerX(), item.centerY());
                    if (dis < 20)
                    {
                        fromId = item.id;
                    }
                    dis = distance(cp.X, cp.Y, item.centerX(), item.centerY());
                    if (dis < 20)
                    {
                        toId = item.id;
                    }
                }
                if (fromId != null && toId != null)
                {
                    if (operType == OperType.Line)
                    {
                        EdgeLine line = new EdgeLine();
                        line.id = XmlPainterUtil.genId("e");
                        line.formId = fromId;
                        line.toId = toId;
                        this.data.edges.Add(line);
                    }
                    if (operType == OperType.Arrow)
                    {
                        EdgeArrow line = new EdgeArrow();
                        line.id = XmlPainterUtil.genId("e");
                        line.formId = fromId;
                        line.toId = toId;
                        this.data.edges.Add(line);
                    }
                    if (operType == OperType.FillArrow)
                    {
                        EdgeFillArrow line = new EdgeFillArrow();
                        line.id = XmlPainterUtil.genId("e");
                        line.formId = fromId;
                        line.toId = toId;
                        this.data.edges.Add(line);
                    }
                    refreshDraw();
                }
            }

            if (operType == OperType.S_Circle)
            {
                Point cd = cvtLogicalPoint(downPoint);
                Point cp = cvtLogicalPoint(e.Location);
                double radius = distance(cd.X, cd.Y, cp.X, cp.Y);
                ShapeCircle item = new ShapeCircle();
                item.id = XmlPainterUtil.genId("s");
                item.posX = cd.X;
                item.posY = cd.Y;
                item.radius = radius;
                this.data.shapes.Add(item);
                refreshDraw();
            }
            if (operType == OperType.S_Rectangle)
            {
                Point cd = cvtLogicalPoint(downPoint);
                Point cp = cvtLogicalPoint(e.Location);
                ShapeRectangle item = new ShapeRectangle();
                item.id = XmlPainterUtil.genId("s");
                item.posX = Math.Min(cd.X,cp.X);
                item.posY = Math.Min(cd.Y,cp.Y);
                item.width = Math.Abs(cd.X-cp.X);
                item.height = Math.Abs(cd.Y - cp.Y);
                this.data.shapes.Add(item);
                refreshDraw();
            }
            if (operType == OperType.S_Ellipse)
            {
                Point cd = cvtLogicalPoint(downPoint);
                Point cp = cvtLogicalPoint(e.Location);
                ShapeEllipse item = new ShapeEllipse();
                item.id = XmlPainterUtil.genId("s");
                item.posX = Math.Min(cd.X, cp.X);
                item.posY = Math.Min(cd.Y, cp.Y);
                item.width = Math.Abs(cd.X - cp.X);
                item.height = Math.Abs(cd.Y - cp.Y);
                this.data.shapes.Add(item);
                refreshDraw();
            }
            if (operType == OperType.E_Diamond)
            {
                Point cd = cvtLogicalPoint(downPoint);
                Point cp = cvtLogicalPoint(e.Location);
                ShapeDiamond item = new ShapeDiamond();
                item.id = XmlPainterUtil.genId("s");
                item.posX = Math.Min(cd.X, cp.X);
                item.posY = Math.Min(cd.Y, cp.Y);
                item.width = Math.Abs(cd.X - cp.X);
                item.height = Math.Abs(cd.Y - cp.Y);
                this.data.shapes.Add(item);
                refreshDraw();
            }
            if (operType == OperType.E_Triangle)
            {
                Point cd = cvtLogicalPoint(downPoint);
                Point cp = cvtLogicalPoint(e.Location);
                ShapeTriangle item = new ShapeTriangle();
                item.id = XmlPainterUtil.genId("s");
                item.posX = Math.Min(cd.X, cp.X);
                item.posY = Math.Min(cd.Y, cp.Y);
                item.width = Math.Abs(cd.X - cp.X);
                item.height = Math.Abs(cd.Y - cp.Y);
                int diffX = cp.X - cd.X;
                int diffY = cp.Y - cd.Y;
                if (Math.Abs(diffX) > Math.Abs(diffY))
                {
                    if (diffX > 0)
                    {
                        item.direct = XmlPainterUtil.DIRECT_RIGHT;
                    }
                    else
                    {
                        item.direct = XmlPainterUtil.DIRECT_LEFT;
                    }
                }
                else
                {
                    if (diffY > 0)
                    {
                        item.direct = XmlPainterUtil.DIRECT_DOWN;
                    }
                    else
                    {
                        item.direct = XmlPainterUtil.DIRECT_UP;
                    }
                }
                this.data.shapes.Add(item);
                refreshDraw();
            }
            if (operType == OperType.E_RoundRectangle)
            {
                Point cd = cvtLogicalPoint(downPoint);
                Point cp = cvtLogicalPoint(e.Location);
                ShapeRoundRectangle item = new ShapeRoundRectangle();
                item.id = XmlPainterUtil.genId("s");
                item.posX = Math.Min(cd.X, cp.X);
                item.posY = Math.Min(cd.Y, cp.Y);
                item.width = Math.Abs(cd.X - cp.X);
                item.height = Math.Abs(cd.Y - cp.Y);
                double radius = Math.Max(5, Math.Min(item.width, item.height) / 8.0);
                item.radius = radius;
                this.data.shapes.Add(item);
                refreshDraw();
            }
        }

        private void XmlPainterForm_KeyDown(object sender, KeyEventArgs e)
        {
            isCtrlDown = e.Control;
            isAltDown = e.Alt;
            isShiftDown = e.Shift;
        }

        private void XmlPainterForm_KeyUp(object sender, KeyEventArgs e)
        {
            isCtrlDown = e.Control;
            isAltDown = e.Alt;
            isShiftDown = e.Shift;
            if (e.KeyCode == Keys.Delete)
            {
                List<PainterShape> deleteShapes = new List<PainterShape>();
                List<PainterEdge> deleteEdges = new List<PainterEdge>();
                foreach (PainterShape item in data.shapes)
                {
                    foreach (string id in selectIds)
                    {
                        if (item.id == id)
                        {
                            deleteShapes.Add(item);
                        }
                    }
                }
                foreach (PainterEdge item in data.edges)
                {
                    foreach (string id in selectIds)
                    {
                        if (item.formId == id || item.toId == id)
                        {
                            deleteEdges.Add(item);
                        }
                    }
                }
                foreach (PainterShape item in deleteShapes)
                {
                    data.shapes.Remove(item);
                }
                foreach (PainterEdge item in deleteEdges)
                {
                    data.edges.Remove(item);
                }
            }
            refreshDraw();
        }

        private void CursorInOperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operType = OperType.Cursor;
        }

        private void LineInOperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operType = OperType.Line;
        }

        private void ArrowLineInOperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operType = OperType.Arrow;
        }
        private void FillArrowLineInOperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operType = OperType.FillArrow;
        }
        private void TextInOperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operType = OperType.Text;
        }


        private void CircleInShapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operType = OperType.S_Circle;
        }

        private void RectangleInShapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operType = OperType.S_Rectangle;
        }

        private void EllipseInShapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operType = OperType.S_Ellipse;
        }

        private void EraseInOperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.data.shapes.Clear();
            this.data.edges.Clear();
            refreshDraw();
        }

        private void DiamondInShapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operType = OperType.E_Diamond;
        }

        private void TriangleInShapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operType = OperType.E_Triangle;
        }

        private void RoundRectangleInShapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operType = OperType.E_RoundRectangle;
        }

        private void AboutInHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "XML画图工具\r\n支持构造简单图形绘制并存储为XML文件\r\n也支持从XML文件中读取进行显示", "XML画图工具");
        }

        private void HelpInHelpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "XML画图工具\r\n1.添加图形\r\n2.连接图形\r\n3.编辑图形或线上的文字\r\n4.保存为XML或者图片\r\n5.图形的选中点在图形几何中心\r\n\t选中之后的图形会带有小红点\r\n6.图形的移动请使用右键拖动\r\n7.图形的删除请使用Delete\r\n8.旨在构建程序友好型绘图\r\n9.可以使用其他途径直接生成XML文件进行显示图形", "XML画图工具");
        }

    }
}
