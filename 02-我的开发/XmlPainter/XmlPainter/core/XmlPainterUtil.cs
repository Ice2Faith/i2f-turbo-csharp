using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;

namespace XmlPainter
{
   
    public class XmlPainterUtil
    {
        public const string ROOT_NODE_NAME="Painter";

        public const string EDGES_NODE_NAME = "Edges";
        public const string SHAPES_NODE_NAME = "Shapes";

        public const string NODE_ATTR_ID = "id";
        public const string NODE_ATTR_TEXT = "text";

        public const string SHAPE_ATTR_POS_X = "posX";
        public const string SHAPE_ATTR_POS_Y = "posY";

        public const string SHAPE_ATTR_WIDTH = "width";
        public const string SHAPE_ATTR_HEIGHT = "height";

        public const string EDGE_ATTR_FORM_ID = "formId";
        public const string EDGE_ATTR_TO_ID = "toId";

        public const string SHAPE_ATTR_RADIUS = "radius";

        public const string SHAPE_ATTR_DIRECT = "direct";

        public const string DIRECT_UP = "up";
        public const string DIRECT_DOWN = "down";
        public const string DIRECT_LEFT = "left";
        public const string DIRECT_RIGHT = "right";


        public static PainterMetaData loadPainter(string path)
        {
            PainterMetaData data = null;

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNode root = null;
            XmlNodeList list = doc.ChildNodes;
            foreach (XmlNode node in list)
            {
                if (node.Name == ROOT_NODE_NAME)
                {
                    root = node;
                    break;
                }
            }

            if (root == null)
            {
                return data;
            }

            List<PainterShape> shapeList = new List<PainterShape>();
            List<PainterEdge> edgeList = new List<PainterEdge>();
            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.Name == EDGES_NODE_NAME)
                {
                    foreach (XmlNode edgeNode in node.ChildNodes)
                    {
                        PainterEdge edge = resolveEdgeNode(edgeNode);
                        if (edge != null)
                        {
                            edgeList.Add(edge);
                        }
                    }
                }
                if (node.Name == SHAPES_NODE_NAME)
                {
                    foreach (XmlNode shapeNode in node.ChildNodes)
                    {
                        PainterShape shape=resolveShapeNode(shapeNode);
                        if (shape != null)
                        {
                            shapeList.Add(shape);
                        }
                    }
                }
            }

            data = new PainterMetaData();
            data.shapes = shapeList;
            data.edges = edgeList;

            return data;

        }

        public static string nodeAttr(XmlNode node, string name, string defVal)
        {
            XmlAttribute attr = node.Attributes[name];
            if (attr == null)
            {
                return defVal;
            }
            return attr.Value;

        }
        public static DateTime DateTime1970 = new DateTime(1970, 1, 1).ToLocalTime();
        public static long getTimeStamp(DateTime dateTime)
        {
            return (long)(dateTime.ToLocalTime() - DateTime1970).TotalSeconds;
        }
        public static string genId(string prefix)
        {
            return prefix + getTimeStamp(DateTime.Now)+""+DateTime.Now.Millisecond+"" + new Random().Next(1024);
        }
        public static PainterShape resolveShapeNode(XmlNode node)
        {
            PainterShape shape = null;
            string name = node.Name;
            string id = nodeAttr(node, NODE_ATTR_ID, genId("s"));
            string text = nodeAttr(node, NODE_ATTR_TEXT, "");
            double posX = Convert.ToDouble(nodeAttr(node, SHAPE_ATTR_POS_X, "0"));
            double poxY = Convert.ToDouble(nodeAttr(node, SHAPE_ATTR_POS_Y, "0"));
            if (name == new ShapeRectangle().naming())
            {
                double width = Convert.ToDouble(nodeAttr(node, SHAPE_ATTR_WIDTH, "10"));
                double height = Convert.ToDouble(nodeAttr(node, SHAPE_ATTR_HEIGHT, "5"));
                ShapeRectangle p = new ShapeRectangle();
                p.width = width;
                p.height = height;
                shape = p;
            }
            else if (name == new ShapeEllipse().naming())
            {
                double width = Convert.ToDouble(nodeAttr(node, SHAPE_ATTR_WIDTH, "10"));
                double height = Convert.ToDouble(nodeAttr(node, SHAPE_ATTR_HEIGHT, "5"));
                ShapeEllipse p = new ShapeEllipse();
                p.width = width;
                p.height = height;
                shape = p;
            }
            else if (name == new ShapeCircle().naming())
            {
                double radius = Convert.ToDouble(nodeAttr(node, SHAPE_ATTR_RADIUS, "5"));
                ShapeCircle p = new ShapeCircle();
                p.radius = radius;
                shape = p;
            }
            else if (name == new ShapeDiamond().naming())
            {
                double width = Convert.ToDouble(nodeAttr(node, SHAPE_ATTR_WIDTH, "10"));
                double height = Convert.ToDouble(nodeAttr(node, SHAPE_ATTR_HEIGHT, "5"));
                ShapeDiamond p = new ShapeDiamond();
                p.width = width;
                p.height = height;
                shape = p;
            }
            else if (name == new ShapeRoundRectangle().naming())
            {
                double width = Convert.ToDouble(nodeAttr(node, SHAPE_ATTR_WIDTH, "10"));
                double height = Convert.ToDouble(nodeAttr(node, SHAPE_ATTR_HEIGHT, "5"));
                double radius = Convert.ToDouble(nodeAttr(node, SHAPE_ATTR_RADIUS, "5"));
                ShapeRoundRectangle p = new ShapeRoundRectangle();
                p.width = width;
                p.height = height;
                p.radius = radius;
                shape = p;
            }
            else if (name == new ShapeTriangle().naming())
            {
                double width = Convert.ToDouble(nodeAttr(node, SHAPE_ATTR_WIDTH, "10"));
                double height = Convert.ToDouble(nodeAttr(node, SHAPE_ATTR_HEIGHT, "5"));
                string direct = nodeAttr(node, SHAPE_ATTR_DIRECT, DIRECT_RIGHT);
                ShapeTriangle p = new ShapeTriangle();
                p.width = width;
                p.height = height;
                p.direct = direct;
                shape = p;
            }
            if (shape != null)
            {
                shape.id = id;
                shape.text = text;
                shape.posX = posX;
                shape.posY = poxY;
            }

            return shape;
        }

        public static PainterEdge resolveEdgeNode(XmlNode node)
        {
            PainterEdge edge = null;
            string name = node.Name;
            string id = nodeAttr(node, NODE_ATTR_ID, genId("e"));
            string text = nodeAttr(node, NODE_ATTR_TEXT, "");
            string formId=nodeAttr(node, EDGE_ATTR_FORM_ID, null);
            string toId = nodeAttr(node, EDGE_ATTR_TO_ID, null);
            if (formId == null || toId == null)
            {
                return edge;
            }
            if (name == new EdgeLine().naming())
            {
                EdgeLine p = new EdgeLine();
                edge = p;
            }
            if (name == new EdgeArrow().naming())
            {
                EdgeArrow p = new EdgeArrow();
                edge = p;
            }
            if (name == new EdgeFillArrow().naming())
            {
                EdgeFillArrow p = new EdgeFillArrow();
                edge = p;
            }
            if (edge != null)
            {
                edge.id = id;
                edge.text = text;
                edge.formId = formId;
                edge.toId = toId;
            }

            return edge;
        }

        public static void savePainter(PainterMetaData meta, string path)
        {
            XmlDocument doc = new XmlDocument();

            XmlDeclaration declaration= doc.CreateXmlDeclaration("1.0", "utf-8", "yes");

            XmlNode root = makeNode(doc, ROOT_NODE_NAME);


            XmlNode shapesNode = makeNode(doc, SHAPES_NODE_NAME);
            foreach (PainterShape shape in meta.shapes)
            {
                XmlNode node = shape.xml(doc);
                shapesNode.AppendChild(node);
            }


            XmlNode edgesNode = makeNode(doc,EDGES_NODE_NAME);
            foreach (PainterEdge edge in meta.edges)
            {
                XmlNode node = edge.xml(doc);
                edgesNode.AppendChild(node);
            }

            root.AppendChild(edgesNode);
            root.AppendChild(shapesNode);

            doc.AppendChild(declaration);
            doc.AppendChild(root);

            doc.Save(path);
        }

        public static XmlNode makeNode(XmlDocument doc, string name)
        {
            XmlNode node = doc.CreateElement(name);
            return node;
        }
        public static XmlAttribute addAttr(XmlDocument doc, XmlNode node, string name, string value)
        {
            XmlAttribute attr = doc.CreateAttribute(name);
            attr.Value = value;
            node.Attributes.Append(attr);
            return attr;
        }
    }
}
