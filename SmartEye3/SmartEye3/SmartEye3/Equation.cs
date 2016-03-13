using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AIEnginePhase
{
    class Equation
    {
        int x, y, z;
        int c4;
        public Equation()
        { }
        public Equation(int a, int b, int c, int xa, int ya, int za)
        {
            x = xa;
            c4 = a * xa;

            y = ya;
            c4 += b * ya;

            z = za;
            c4 += c * za;
        }
        public override string ToString()
        {
            string e;
            e = x.ToString() + "x+" + y.ToString() + "y+" + z.ToString() + "z-" + c4.ToString() + "= 0";
            return e;
        }
        public bool checkpoint(Point P4)
        {
            int temp = x * P4.X;
            int temp1 = y * P4.Y;
            int temp2 = z * P4.Z;
            if (temp + temp1 + temp2 - c4 == 0)
                return true;
            else if (((temp + temp1 + temp2 / c4) > 0.75) || ((temp + temp1 + temp2) / c4 < 1.25))
                return true;
            return false;
        }


        public bool checkpoint(List<Point> legs, ref int prob,   TextBox p )
        {
            bool flag = true;
            int temp = x * legs[0].X;
            int temp1 = y * legs[0].Y;
            int temp2 = z * legs[0].Z;
            int[] sign = new int[4];//temp + temp1 + temp2 - c4;
            //if (sign < 0)
            //  sign = 0;
            //else sign = 1;

            //Console.WriteLine("Adding probablity 5% because we have found a point which is on same side"); prob += 5;
            for (int i = 0; i < legs.Count; i++)
            {
                temp = x * legs[i].X;
                temp1 = y * legs[i].Y;
                temp2 = z * legs[i].Z;
                sign[i] = temp + temp1 + temp2 - c4;

            }




            //if (sign == 0 && temp + temp1 + temp2 - c4 >= sign)
            //{
            //    flag = false;
            //    continue;
            //}
            //else if (sign == 1 && temp + temp1 + temp2 - c4 < sign)
            //{
            //    flag = false;
            //    continue;
            //}
            for (int i = 0; i < 4; i++)
            {
                if (sign[i] < 0)
                    sign[i] = -1;
                else if (sign[i] > 0)
                    sign[i] = 1;
                else
                    sign[i] = 0;
            }

            p.Text += Environment.NewLine;
 
            if ((sign[0] == 1 && sign[1] == 1 && sign[2] == 1 && sign[3] == 1) || (sign[0] == -1 && sign[1] == -1 && sign[2] == -1 && sign[3] == -1))
            {

                p.Text += Environment.NewLine;
                p.Text+=("Adding probablity 20% because we have found four point which is on same side");
                prob += 20;
                flag = true;
            }
            else if ((sign[0] == 1 && sign[1] == -1 && sign[2] == -1 && sign[3] == -1) || (sign[0] == -1 && sign[1] == 1 && sign[2] == -1 && sign[3] == -1) || (sign[0] == -1 && sign[1] == -1 && sign[2] == 1 && sign[3] == -1) || (sign[0] == -1 && sign[1] == -1 && sign[2] == -1 && sign[3] == 1) || (sign[0] == 1 && sign[1] == -1 && sign[2] == -1 && sign[3] == -1) || (sign[0] == -1 && sign[1] == 1 && sign[2] ==  1 && sign[3] ==  1) || (sign[0] ==  1 && sign[1] ==  1 && sign[2] == -1 && sign[3] ==  1) || (sign[0] == 1 && sign[1] == 1 && sign[2] == 1 && sign[3] == -1))
            {

                p.Text += Environment.NewLine;
                p.Text+=("Adding probablity 15% because we have found three point which is on same side");
                prob += 15;
                flag = true;
            }
            else if ((sign[0] == 1 && sign[1] == 1 && sign[2] == -1 && sign[3] == -1) || (sign[0] == -1 && sign[1] == 1 && sign[2] == 1 && sign[3] == -1) || (sign[0] == -1 && sign[1] == -1 && sign[2] == 1 && sign[3] == 1) || (sign[0] == 1 && sign[1] == -1 && sign[2] == -1 && sign[3] == 1))
            {
                p.Text += Environment.NewLine;
                p.Text+=("Adding probablity 10% because we have found two point which is on same side");
                prob += 10;
                flag = true;
            }
             
            else
            {
                flag = false;

            }
            p.Text += Environment.NewLine;
            return flag;
        }
    }
}
