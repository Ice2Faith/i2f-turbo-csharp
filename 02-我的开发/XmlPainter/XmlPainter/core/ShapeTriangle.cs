﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Xml;
using System.Drawing.Drawing2D;

namespace XmlPainter
{
    public class ShapeTriangle : PainterShape
    {
        public double width;
        public double height;
        public string direct;// top down left right

        public override void draw(Graphics gra)
        {
            Brush br=new SolidBrush(Color.White);
            GraphicsPath path=new GraphicsPath();
            if (XmlPainterUtil.DIRECT_DOWN == direct)
            {
                // -
                path.AddLine((int)(posX), (int)(posY), (int)(posX + width), (int)(posY));
                // /
                path.AddLine((int)(posX + width), (int)(posY), (int)(posX + width / 2), (int)(posY + height));
                // \
                path.AddLine((int)(posX + width / 2), (int)(posY + height), (int)(posX), (int)(posY));
            }
            else if (XmlPainterUtil.DIRECT_UP==direct)
            {
                // \
                path.AddLine((int)(posX+width/2), (int)(posY), (int)(posX + width), (int)(posY+height));
                // -
                path.AddLine((int)(posX + width), (int)(posY + height), (int)(posX), (int)(posY + height));
                // /
                path.AddLine((int)(posX), (int)(posY + height), (int)(posX+width/2), (int)(posY));
            }
            else if (XmlPainterUtil.DIRECT_LEFT == direct)
            {
                // |
                path.AddLine((int)(posX+width), (int)(posY), (int)(posX + width), (int)(posY + height));
                // \
                path.AddLine((int)(posX + width), (int)(posY+height), (int)(posX ), (int)(posY + height/2));
                // /
                path.AddLine((int)(posX ), (int)(posY + height/2), (int)(posX+width), (int)(posY));
            }
            else if (XmlPainterUtil.DIRECT_RIGHT == direct)
            {
                // \
                path.AddLine((int)(posX), (int)(posY), (int)(posX + width), (int)(posY+height/2));
                // /
                path.AddLine((int)(posX + width), (int)(posY+height/2), (int)(posX), (int)(posY + height));
                // |
                path.AddLine((int)(posX), (int)(posY + height), (int)(posX), (int)(posY));
            }
            
            

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
            return "Triangle";
        }

        public override XmlNode xml(XmlDocument doc)
        {
            XmlNode node = XmlPainterUtil.makeNode(doc, naming());
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.NODE_ATTR_ID, id);
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.SHAPE_ATTR_POS_X, posX + "");
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.SHAPE_ATTR_POS_Y, posY + "");
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.SHAPE_ATTR_WIDTH, width + "");
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.SHAPE_ATTR_HEIGHT, height + "");
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.SHAPE_ATTR_DIRECT, direct + "");
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
