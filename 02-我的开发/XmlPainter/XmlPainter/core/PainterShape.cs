using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Xml;

namespace XmlPainter
{
    public abstract class PainterShape : PainterElem, IPainterDrawing, IPainterNaming, IPainterXmling
    {
        public double posX;
        public double posY;
        public abstract void draw(Graphics gra);
        public abstract string naming();

        public abstract XmlNode xml(XmlDocument doc);

        public abstract double centerX();

        public abstract double centerY();

    }
}
