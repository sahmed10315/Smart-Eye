using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIEnginePhase
{
    class Rectangle
    {

        
            Point p1;
            MEdge e1;

            internal MEdge E1
            {
                get { return e1; }
                set { e1 = value; }
            }
            MEdge e2;

            internal MEdge E2
            {
                get { return e2; }
                set { e2 = value; }
            }
            MEdge e3;

            internal MEdge E3
            {
                get { return e3; }
                set { e3 = value; }
            }
            MEdge e4;

            internal MEdge E4
            {
                get { return e4; }
                set { e4 = value; }
            }
            public Rectangle()
            { }
            public Rectangle(List<MEdge> fourEdges)
            {
                e1 = fourEdges[0];
                e2 = fourEdges[1];
                e3 = fourEdges[2];
                e4 = fourEdges[3];
            }
            internal Point P1
            {
                get { return p1; }
                set { p1 = value; }
            }
            Point p2;

            internal Point P2
            {
                get { return p2; }
                set { p2 = value; }
            }
            Point p3;

            internal Point P3
            {
                get { return p3; }
                set { p3 = value; }
            }
            Point p4;

            internal Point P4
            {
                get { return p4; }
                set { p4 = value; }
            }

        
    }
}
