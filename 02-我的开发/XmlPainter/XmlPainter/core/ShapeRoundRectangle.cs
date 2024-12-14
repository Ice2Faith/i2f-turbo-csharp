using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Xml;
using System.Drawing.Drawing2D;

namespace XmlPainter
{
    public class ShapeRoundRectangle : PainterShape
    {
        public double width;
        public double height;
        public double radius;

        public override void draw(Graphics gra)
        {
            Brush br = new SolidBrush(Color.White);
            GraphicsPath path = new GraphicsPath();
            // 顺时针环绕
            // -
            path.AddLine((int)(posX+radius), (int)(posY), (int)(posX+width-radius), (int)(posY));
            // \
            path.AddArc((int)(posX + width - radius*2), (int)(posY), (int)(radius * 2), (int)(radius * 2), 270, 90);
            // |
            path.AddLine((int)(posX + width), (int)(posY + radius), (int)(posX + width), (int)(posY + height - radius));
            // /
            path.AddArc((int)(posX + width - radius*2), (int)(posY + height - radius*2), (int)(radius * 2), (int)(radius * 2), 0, 90);
            // -
            path.AddLine((int)(posX + width - radius), (int)(posY + height), (int)(posX + radius), (int)(posY + height));
            // \
            path.AddArc((int)(posX), (int)(posY + height - radius*2), (int)(radius * 2), (int)(radius * 2), 90, 90);
            // |
            path.AddLine((int)(posX), (int)(posY + height - radius), (int)(posX), (int)(posY + radius));
            // /
            path.AddArc((int)(posX ), (int)(posY ), (int)(radius*2), (int)(radius*2), 180, 90);


            gra.FillPath(br, path);

            Pen pen = new Pen(Color.Blue);
            gra.DrawPath(pen, path);

            Font font = new Font("黑体", 12, FontStyle.Italic);
            SizeF fsize = gra.MeasureString(text, font);

            double tcx = centerX() - (fsize.Width / 2.0);
            double tcy = centerY() - (fsize.Height / 2.0);
            Brush brush = new SolidBrush(Color.Black);
            gra.DrawString(text, font, brush, (float)tcx, (float)tcy);
        }
        public override string naming()
        {
            return "RoundRectangle";
        }

        public override XmlNode xml(XmlDocument doc)
        {
            XmlNode node = XmlPainterUtil.makeNode(doc, naming());
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.NODE_ATTR_ID, id);
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.SHAPE_ATTR_POS_X, posX + "");
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.SHAPE_ATTR_POS_Y, posY + "");
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.SHAPE_ATTR_WIDTH, width + "");
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.SHAPE_ATTR_HEIGHT, height + "");
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.SHAPE_ATTR_RADIUS, radius + "");
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
