using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIEnginePhase
{
   public class Point
    {
        int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        int z;

        public int Z
        {
            get { return z; }
            set { z = value; }
        }
        public String print()
        {
            return String.Format("X: {0} , Y: {1} , Z: {2}", x, y, z);
        }
        public static bool operator ==(Point p1, Point p2)
        {
            if (p1.X == p2.X && p1.Y == p2.Y && p1.Z == p2.Z)
                return true;

            return false;

        }
        public override string ToString()
        {
            return "" + X + " " + Y + " " + Z;
        }
        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }
    }
}
