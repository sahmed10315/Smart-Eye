using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SmartEye3
{
    public class Edge
    {
        private Point point1;
        private Point point2;
        public Double Length;

        public Edge(Point point1, Point point2)
        {
            this.point1 = point1;
            this.point2 = point2;
            Length = Math.Sqrt(Math.Pow(this.point2.X - this.point1.X, 2) + Math.Pow(this.point2.Y - this.point1.Y, 2));
        }

        public Point Point1
        {
            get
            {
                return point1;
            }
            set
            {
                point1 = value;
                Length = Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
            }
        }

        public Point Point2
        {
            get
            {
                return point2;
            }
            set
            {
                point2 = value;
                Length = Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
            }
        }
    }
}
