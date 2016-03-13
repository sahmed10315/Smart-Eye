using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartEye3
{
    public class Edge3D
    {
        private Point3D point1;
        private Point3D point2;
        public Double Length;

        public Edge3D(Point3D point1, Point3D point2)
        {
            this.point1 = point1;
            this.point2 = point2;
            Length = Math.Sqrt(Math.Pow(this.point2.X - this.point1.X, 2) + Math.Pow(this.point2.Y - this.point1.Y, 2) + Math.Pow(this.point2.Z - this.point1.Z, 2));
        }

        public Point3D Point1
        {
            get
            {
                return point1;
            }
            set
            {
                point1 = value;
                Length = Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2) + Math.Pow(point2.Z - point1.Z, 2));
            }
        }

        public Point3D Point2
        {
            get
            {
                return point2;
            }
            set
            {
                point2 = value;
                Length = Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2) + Math.Pow(point2.Z - point1.Z, 2));
            }
        }
    }
}
