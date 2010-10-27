using System.Drawing;

namespace KG5_Triang
{
    public class Triangle
    {
        //public PointF v1, v2, v3;
        public PointF[] v;
        //public Triangle t1, t2, t3;
        public Triangle[] t;

        public PointF center; // ?
        public int hashX;
        public int HashY;

        public Triangle(
            PointF vertex1, PointF vertex2, PointF vertex3,
            Triangle neighbour1, Triangle neighbour2, Triangle neighbour3
            )
            : this(vertex1, vertex2, vertex3)
        {
            t = new Triangle[3];
            t[0] = neighbour1;
            t[1] = neighbour2;
            t[2] = neighbour3;
        }

        public Triangle(PointF vertex1, PointF vertex2, PointF vertex3)
        {
            v = new PointF[3];
            v[0] = vertex1;
            v[1] = vertex2;
            v[2] = vertex3;

            center.X = (vertex1.X + vertex2.X + vertex3.X) / 3f;
            center.Y = (vertex1.Y + vertex2.Y + vertex3.Y) / 3f;
        }
    }
}
