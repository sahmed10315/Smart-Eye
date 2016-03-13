using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIEnginePhase
{ 
        
    class MEdge
    {
        string name;
        public double Length;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        Point p1;
        Point p2;
        public Point P1
        {
            get { return p1; }
            set { p1 = value; }
        }
        public Point P2
        {
            get { return p2; }
            set { p2 = value; }
        }
        public MEdge()
        { }
        public MEdge(Point p1, Point p2, string name)
        {
            this.name = name;
            this.p1 = p1;
            this.p2 = p2;
        }
        public MEdge(int x, int y,int z,  int x1, int y1,int z1, string name)
        {
            p1 = new Point();
            p2 = new Point();
            p1.X = x;
            p1.Y = y;
            p1.Z = z;
            p2.X = x1;
            p2.Y = y1;
            p2.Z = z1;
            this.name = name;
        }

        public String print()
        {
             return String.Format("Edge: {0} {1} {2}, {3} {4} {5}\n\n", p1.X, p1.Y,p1.Z,  p2.X, p2.Y, p2.Z);
        }

    }
}

     
 