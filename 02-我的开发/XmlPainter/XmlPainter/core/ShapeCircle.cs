using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Xml;

namespace XmlPainter
{
    public class ShapeCircle : PainterShape
    {
        public double radius;
        public override void draw(Graphics gra)
        {
            Brush br = new SolidBrush(Color.White);
            gra.FillEllipse(br, (float)posX, (float)posY, (float)radius, (float)radius);

            Pen pen = new Pen(Color.Blue);
            gra.DrawEllipse(pen, (float)posX, (float)posY, (float)radius, (float)radius);

            Font font = new Font("黑体", 12, FontStyle.Italic);
            SizeF fsize = gra.MeasureString(text, font);

            double tcx = centerX()-(fsize.Width/2.0);
            double tcy = centerY()-(fsize.Height/2.0);
            Brush brush = new SolidBrush(Color.Black);
            gra.DrawString(text, font, brush, (float)tcx, (float)tcy);
        }
        public override string naming()
        {
            return "Circle";
        }

        public override XmlNode xml(XmlDocument doc)
        {
            XmlNode node = XmlPainterUtil.makeNode(doc, naming());
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.NODE_ATTR_ID, id);
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.SHAPE_ATTR_POS_X, posX+"");
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.SHAPE_ATTR_POS_Y, posY+"");
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.SHAPE_ATTR_RADIUS, radius + "");
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.NODE_ATTR_TEXT, text);

            return node;
        }

        public override double centerX()
        {
            return posX + (radius / 2.0);
        }

        public override double centerY()
        {
            return posY + (radius / 2.0);
        }
    }
}
