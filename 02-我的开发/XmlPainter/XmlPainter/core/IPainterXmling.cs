using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Xml;

namespace XmlPainter
{
    public interface IPainterXmling
    {
        XmlNode xml(XmlDocument doc);
    }
}
