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

        public void MakeCCW()
        {
            if (!this.IsCCW)
            {
                // make [0 2 1]
                PointF tmp = v[1];
                v[1] = v[2];
                v[2] = tmp;
            }
        }

        public static bool MakesCCW(PointF A, PointF B, PointF C)
        {
            //PointF AB = PointF.Empty;
            //PointF AC = PointF.Empty;
            //AB.X = B.X - A.X;
            //AB.Y = B.Y - A.Y;
            //AC.X = C.X - A.X;
            //AC.Y = C.Y - A.Y;
            //return AB.X * AC.Y - AB.Y * AC.X > 0;

            //
            //   | xa ya 1 | 
            //   | xb yb 1 | > 0  => CCW
            //   | xc yc 1 |
            //
            return B.X * C.Y - C.X * B.Y - A.X * C.Y + C.X * A.Y + A.X * B.Y - B.X * A.Y > 0;
        }

        public bool IsCCW
        {
            get
            {
                //PointF AB = PointF.Empty;
                //PointF AC = PointF.Empty;
                //AB.X = v[1].X - v[0].X;
                //AB.Y = v[1].Y - v[0].Y;
                //AC.X = v[2].X - v[0].X;
                //AC.Y = v[2].Y - v[0].Y;

                //return AB.X * AC.Y - AB.Y * AC.X > 0;

                //
                //   | xa ya 1 | 
                //   | xb yb 1 | > 0  => CCW
                //   | xc yc 1 |
                //
                return v[1].X * v[2].Y - v[2].X * v[1].Y - v[0].X * v[2].Y + v[2].X * v[0].Y + v[0].X * v[1].Y - v[1].X * v[0].Y > 0;
            }
        }
    }
}
