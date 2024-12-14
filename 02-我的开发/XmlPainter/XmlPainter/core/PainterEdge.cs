using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Xml;

namespace XmlPainter
{
    public abstract class PainterEdge : PainterElem, IPainterNaming, IPainterXmling
    {
        public string formId;
        public string toId;
        public abstract void draw(Graphics gra,PainterShape form,PainterShape to);
        public abstract string naming();

        public abstract XmlNode xml(XmlDocument doc);

    }
}
