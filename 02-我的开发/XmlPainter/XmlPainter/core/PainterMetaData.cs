using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace XmlPainter
{
    public class SizeD
    {
        public double width;
        public double height;
        public SizeD()
        {

        }
        public SizeD(double width,double height)
        {
            this.width = width;
            this.height = height;
        }
    }
    public class EdgeEndpoint
    {
        public PainterShape begin;
        public PainterShape end;
        public EdgeEndpoint()
        {

        }
        public EdgeEndpoint(PainterShape begin, PainterShape end)
        {
            this.begin = begin;
            this.end = end;
        }
    }
    public class PainterMetaData : IPainterDrawing
    {
        public List<PainterShape> shapes;
        public List<PainterEdge> edges;
        public EdgeEndpoint findEndpoint(PainterEdge edge)
        {
            PainterShape begin = null;
            PainterShape end = null;
            foreach (PainterShape item in shapes)
            {
                if (item.id == edge.formId)
                {
                    begin = item;
                }
                if (item.id == edge.toId)
                {
                    end = item;
                }
                if (begin != null && end != null)
                {
                    break;
                }
            }
            if (begin == null || end == null)
            {
                return null;
            }
            return new EdgeEndpoint(begin, end);
        }

        public void draw(Graphics gra)
        {
            foreach (PainterEdge edge in edges)
            {
                EdgeEndpoint ed = findEndpoint(edge);
                edge.draw(gra, ed.begin, ed.end);
            }
            foreach (PainterShape shape in shapes)
            {
                shape.draw(gra);
            }
        }

        public SizeD normalize()
        {
            double minX = 999999999;
            double minY = 999999999;
            double maxX = 0;
            double maxY = 0;
            foreach (PainterShape shape in shapes)
            {
                if (shape.posX < minX)
                {
                    minX = shape.posX;
                }
                if (shape.posY < minY)
                {
                    minY = shape.posY;
                }
                if (shape.posX > maxX)
                {
                    maxX = shape.posX;
                }
                if (shape.posY > maxY)
                {
                    maxY = shape.posY;
                }
            }

            foreach (PainterShape shape in shapes)
            {
                shape.posX -= minX;
                shape.posY -= minY;
                shape.posX += 200;
                shape.posY += 200;
            }

            return new SizeD(maxX - minX+400, maxY - minY+400);
        }
    }
}
