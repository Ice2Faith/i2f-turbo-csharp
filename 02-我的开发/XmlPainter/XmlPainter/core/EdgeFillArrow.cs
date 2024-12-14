using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Drawing.Drawing2D;

namespace XmlPainter
{
    public class EdgeFillArrow:PainterEdge
    {
        public override void draw(Graphics gra, PainterShape form, PainterShape to)
        {
            Pen pen=new Pen(Color.Blue);
            gra.DrawLine(pen, (float)form.centerX(), (float)form.centerY(), (float)to.centerX(), (float)to.centerY());

            AdjustableArrowCap lineCap = new AdjustableArrowCap(9, 9, true);   //设置一个线头	
            lineCap.Filled = true;
            Pen apen = new Pen(Brushes.Blue, 1);
            apen.CustomEndCap = lineCap;

            double ax = (form.centerX() *0.3+ to.centerX()*0.7);
            double ay = (form.centerY() *0.3+ to.centerY()*0.7);
            gra.DrawLine(apen, (float)form.centerX(), (float)form.centerY(), (float)ax, (float)ay);


            Font font = new Font("黑体", 12, FontStyle.Italic);
            SizeF fsize = gra.MeasureString(text, font);

            double tcx=(form.centerX()+to.centerX()-fsize.Width)/2.0;
            double tcy=(form.centerY()+to.centerY()-fsize.Height)/2.0;
            
            Brush brush=new SolidBrush(Color.Black);
            gra.DrawString(text, font, brush, (float)tcx, (float)tcy);

            
        }
        public override string naming()
        {
            return "FillArrow";
        }

        public override XmlNode xml(XmlDocument doc)
        {
            XmlNode node=XmlPainterUtil.makeNode(doc,naming());
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.NODE_ATTR_ID, id);
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.EDGE_ATTR_FORM_ID, formId);
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.EDGE_ATTR_TO_ID, toId);
            XmlPainterUtil.addAttr(doc, node, XmlPainterUtil.NODE_ATTR_TEXT, text);

            return node;
        }
        
    }
}
