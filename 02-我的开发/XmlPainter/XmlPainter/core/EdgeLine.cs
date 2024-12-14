using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;

namespace XmlPainter
{
    public class EdgeLine:PainterEdge
    {
        public override void draw(Graphics gra, PainterShape form, PainterShape to)
        {
            Pen pen=new Pen(Color.Blue);
            gra.DrawLine(pen, (float)form.centerX(), (float)form.centerY(), (float)to.centerX(), (float)to.centerY());

            Font font = new Font("黑体", 12, FontStyle.Italic);
            SizeF fsize = gra.MeasureString(text, font);

            double tcx=(form.centerX()+to.centerX()-fsize.Width)/2.0;
            double tcy=(form.centerY()+to.centerY()-fsize.Height)/2.0;
            
            Brush brush=new SolidBrush(Color.Black);
            gra.DrawString(text, font, brush, (float)tcx, (float)tcy);

            
        }
        public override string naming()
        {
            return "Line";
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
