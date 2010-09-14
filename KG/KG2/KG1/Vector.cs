using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace KG1
{
    public class Vector
    {
        double _x, _y, _z;

        public double Z
        {
            get { return _z; }
            set { _z = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public Vector(double x, double y, double z)
        {
            _x = x; _y = y; _z = z;
        }

        public Vector(PointF pt)
        {
            _x = pt.X; _y = pt.Y; _z = 0;
        }

        public static Vector operator * (Vector v, double scalar)
        {
            return new Vector(v._x * scalar, v._y * scalar, v._z * scalar);
        }
        public static Vector operator *(double scalar, Vector v)
        {
            return v * scalar;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(
                v1._x + v2._x, 
                v1._y + v2._y, 
                v1._z + v2._z);
        }

        public PointF ToPoint()
        {
            return new PointF((float)_x, (float)_y);
        }
    }
}
