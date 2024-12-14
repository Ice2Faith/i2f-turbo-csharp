using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Xml;

namespace XmlPainter
{
    public class ShapeEllipse : PainterShape
    {
        public double width;
        public double height;

        public override void draw(Graphics gra)
        {
            Brush br=new SolidBrush(Color.White);
            gra.FillEllipse(br, (float)posX, (float)posY, (float)width, (float)height);

            Pen pen = new Pen(Color.Blue);
            gra.DrawEllipse(pen, (float)posX, (float)posY, (float)width, (float)height);

            Font font = new Font("黑体", 12, FontStyle.Italic);
            SizeF fsize = gra.MeasureString(text, font);

            double tcx = centerX() - (fsize.Width / 2.0);
            double tcy = centerY() - (fsize.Height / 2.0);
            Brush brush = new SolidBrush(Color.Black);
            gra.DrawString(text, font, brush, (float)tcx, (float)tcy);
        }
        public override string naming()
        {
            return "Ellipse";
        }
        public override XmlNode xml(XmlDocument doc)
        {
            XmlNode node = XmlPainterUtil.makeNode(doc, naming());
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.NODE_ATTR_ID, id);
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.SHAPE_ATTR_POS_X, posX + "");
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.SHAPE_ATTR_POS_Y, posY + "");
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.SHAPE_ATTR_WIDTH, width + "");
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.SHAPE_ATTR_HEIGHT, height + "");
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.NODE_ATTR_TEXT, text);

            return node;
        }
        public override double centerX()
        {
            return posX + (width / 2.0);
        }

        public override double centerY()
        {
            return posY + (height / 2.0);
        }
    }
}
