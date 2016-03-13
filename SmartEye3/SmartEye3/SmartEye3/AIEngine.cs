using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace AIEnginePhase
{
    static class AIEngine
    {
        public static void findChairs(List<MEdge> edges, List<TextBox> p, ref TextBox prb)
        {
            List<Rectangle> edgees = new List<Rectangle>();
 
            List<Rectangle> planes = findTables(edges, "chair",  p, ref prb, out edgees);
             Rectangle plane1 = planes[0];
            Rectangle plane2 = planes[1];
            p[3].Text += Environment.NewLine;
            
            p[3].Text+=(" \n\nThe two planes P1: ");
            p[3].Text+= String.Format(plane1.P1 + ", " + plane1.P2 + ", " + plane1.P3 + ", " + plane1.P4);
            p[3].Text += Environment.NewLine;
            
            p[3].Text+= String.Format(" and P2: " + plane2.P1 + ", " + plane2.P2 + ", " + plane2.P3 + ", " + plane2.P4);

            p[3].Text += Environment.NewLine;
            Point[] check = new Point[4];
            check[0] = plane1.P1;
            check[1] = plane1.P2;
            check[2] = plane1.P3;
            check[3] = plane1.P4;
            List<Point> intersection = new List<Point>();

            for (int i = 0; i < 4; i++)
            {
                if (check[i] == plane2.P1)
                {
                    intersection.Add(check[i]);
 
                }
                else if (check[i] == plane2.P2)
                {
                    intersection.Add(check[i]);
                }
                else if (check[i] == plane2.P3)
                {
                    intersection.Add(check[i]);
                }
                else if (check[i] == plane2.P4)
                {
                    intersection.Add(check[i]);
                }
            }

            if (intersection.Count != 2)
            {
                p[3].Text+=("The two planes do not intersect thus its not a chair.");
         //       Environment.Exit(0);
            } 
            for (int i = 0; i < intersection.Count; i++)
                p[3].Text += String.Format(" intersect at {0} ", intersection[i]);
            

            for (int i = 0; i < 2; i++)
            {
                MEdge ed = getEdge(intersection, edgees, i, 0);
                p[4].Text += Environment.NewLine;

                p[4].Text += Environment.NewLine;
                MVector3 vect1 = new MVector3(Convert.ToDouble(ed.P1.X - ed.P2.X ), Convert.ToDouble(ed.P1.Y - ed.P2.Y), Convert.ToDouble(ed.P1.Z - ed.P2.Z));
                p[4].Text += ("Angle between   ");

                p[4].Text += ed.print();
                MEdge e = getEdge(intersection, edgees, i , 1);
                p[4].Text += ("   and   ");

                p[4].Text += e.print();
                MVector3 vect2 = new MVector3(Convert.ToDouble(e.P1.X - e.P2.X), Convert.ToDouble(e.P1.Y - e.P2.Y), Convert.ToDouble(e.P1.Z - e.P2.Z));

                if (!(MVector3.IsPerpendicular(vect1, vect2)))
                    continue;
                p[4].Text += (" is Perpendicular.");

                p[4].Text += Environment.NewLine;
                p[4].Text += Environment.NewLine;

                p[4].Text += ("Adding probablity 5% because we have an angle perpendicular"); //prb += 5;
            }
             
             
                p[4].Text += Environment.NewLine;
                p[4].Text += Environment.NewLine;
                p[4].Text += ("**************************************************************************");
                p[4].Text += String.Format("                 The above set of edges form a chair with 100% probablity");

                p[4].Text += ("**************************************************************************");
             
        }

        private static MEdge getEdge(List<Point> intersection, List<Rectangle> edgees, int i, int j)
        {
            if (i == 0)
            {
                if ((intersection[i] == edgees[j].E1.P1 && edgees[j].E1.P2 != intersection[1])
                || (intersection[i] == edgees[j].E1.P2 && edgees[j].E1.P1 != intersection[1]))
                    return edgees[j].E1;
                else if ((intersection[i] == edgees[j].E2.P1 && edgees[j].E2.P2 != intersection[1])
                || (intersection[i] == edgees[j].E2.P2 && edgees[j].E2.P1 != intersection[1]))
                    return edgees[j].E2;
                else if ((intersection[i] == edgees[j].E3.P1 && edgees[j].E3.P2 != intersection[1])
                || (intersection[i] == edgees[j].E3.P2 && edgees[j].E3.P1 != intersection[1]))
                    return edgees[j].E3;
                else if ((intersection[i] == edgees[j].E4.P1 && edgees[j].E4.P2 != intersection[1])
                || (intersection[i] == edgees[j].E4.P2 && edgees[j].E4.P1 != intersection[1]))
                    return edgees[j].E4;
            }
            else if (i == 1)
            {
                if ((intersection[i] == edgees[j].E1.P1 && edgees[j].E1.P2 != intersection[0])
                || (intersection[i] == edgees[j].E1.P2 && edgees[j].E1.P1 != intersection[0]))
                    return edgees[j].E1;
                else if ((intersection[i] == edgees[j].E2.P1 && edgees[j].E2.P2 != intersection[0])
                || (intersection[i] == edgees[j].E2.P2 && edgees[j].E2.P1 != intersection[0]))
                    return edgees[j].E2;
                else if ((intersection[i] == edgees[j].E3.P1 && edgees[j].E3.P2 != intersection[0])
                || (intersection[i] == edgees[j].E3.P2 && edgees[j].E3.P1 != intersection[0]))
                    return edgees[j].E3;
                else if ((intersection[i] == edgees[j].E4.P1 && edgees[j].E4.P2 != intersection[0])
                || (intersection[i] == edgees[j].E4.P2 && edgees[j].E4.P1 != intersection[0]))
                    return edgees[j].E4;
            }
            return new MEdge();

        }
        public static void findTables(List<MEdge> edges, List<TextBox> boxes, ref TextBox prb)
        {
            List<Rectangle> edgees = new List<Rectangle>();
            findTables(edges, "table", boxes , ref prb,out edgees);
        }

        private static List<Rectangle> findTables(List<MEdge> edges, string name, List<TextBox> boxes, ref TextBox prb, out List<Rectangle> edgees)
        {
            List<MEdge> remainingEdges = new List<MEdge>(edges);
            List<Rectangle> listOfRectangles = new List<Rectangle>();


            String[] elements = new String[edges.Count];
            for (int i = 0; i < edges.Count; i++)
                elements[i] = edges[i].Name;

            int[] indices;
            CombinationGenerator x = new CombinationGenerator(elements.Length, 4);
            int count = 0;
            List<MEdge> fourEdges = new List<MEdge>();
            int c = 0;
            ArrayList fourEdgesArr = new ArrayList();
            List<Rectangle> listofRects = new List<Rectangle>();

            while (x.hasMore())
            { 
                string combination = "";
                fourEdges = new List<MEdge>();
                indices = x.getNext();
                for (int i = 0; i < indices.Length; i++)
                {
                    fourEdges.Add(HelperFunctions.getEdge(elements[indices[i]], edges));
                    combination += (elements[indices[i]]);
                }
                Rectangle rect = new Rectangle();
                //Console.WriteLine("Finding rectangle in {0}.", combination.ToString());
                if (HelperFunctions.findRectangles(fourEdges, ref rect, boxes[0]) == true)
                {
                    c++;
                    listOfRectangles.Add(rect);
                    Rectangle r = new Rectangle(fourEdges);
                    listofRects.Add(r); 

                    remainingEdges.Remove(fourEdges[0]);

                    remainingEdges.Remove(fourEdges[1]);

                    remainingEdges.Remove(fourEdges[2]);

                    remainingEdges.Remove(fourEdges[3]);
                    fourEdgesArr.Add(fourEdges);
                    if (name == "table" && c == 1)
                        break;
                    else if (name == "chair" && c == 2)
                        break;
                }
                count++;
            }
            edgees = new List<Rectangle>(listofRects);

            if (listOfRectangles.Count == 0)
            {
                boxes[0].Text+= String.Format("Its not a {0} because there are no rectangles.", name);
                //Environment.Exit(0);
            }
            boxes[0].Text += Environment.NewLine; boxes[0].Text += Environment.NewLine;
            boxes[0].Text+= String.Format("Checked {0} combinations for rectangles.", ((BigInteger)x.getTotal()).IntValue());
            boxes[0].Text += Environment.NewLine;
            boxes[0].Text += Environment.NewLine;
            boxes[0].Text+= "Following are the points of above edges which has a four sided closed path.";
            boxes[0].Text += Environment.NewLine;
            for (int i = 0; i < listOfRectangles.Count; i++)
            {
                boxes[0].Text += Environment.NewLine;
                boxes[0].Text+=listOfRectangles[i].P1.print();
                boxes[0].Text += Environment.NewLine;
                boxes[0].Text+=listOfRectangles[i].P2.print();
                boxes[0].Text += Environment.NewLine;
                boxes[0].Text+=listOfRectangles[i].P3.print();
                boxes[0].Text += Environment.NewLine;
                boxes[0].Text+=listOfRectangles[i].P4.print();
                boxes[0].Text += Environment.NewLine;
            }
            if (listOfRectangles.Count != 2 && name == "chair")
            {
                boxes[0].Text += Environment.NewLine;
                boxes[0].Text+=String.Format("Its not a {0} because there are not two rectangles.", name);
                prb.Text = "0"; 
                //Application.Exit();
              //  Environment.Exit(0);
            }
            else if (listOfRectangles.Count != 1 && name == "table")
            {
                boxes[0].Text += Environment.NewLine;
                boxes[0].Text+= String.Format("Its a {0} with 0% because there are more than one rectangles.", name);
                prb.Text = "0";
               // Environment.Exit(0);
            }
            boxes[0].Text += Environment.NewLine;
             
            boxes[0].Text+="Sending the above set of points to find if they lie in the same plane.";
            
            Equation[] eqn = new Equation[2];
            for (int i = 0; i < listOfRectangles.Count; i++)
            {
                eqn[i] = new Equation();
                if (haveSamePlane(listOfRectangles[i], out eqn[i]) == false)
                {
                    boxes[0].Text += Environment.NewLine;
                   boxes[0].Text+=String.Format("Its a {0} with {1}% probablity because the points do not lie in the same plane.", name, 0);
                    Environment.Exit(0);
                }
                boxes[0].Text += Environment.NewLine;
                boxes[0].Text += Environment.NewLine;
                boxes[0].Text+=String.Format("\nThe equation of the plane is {0}", eqn[i].ToString());
                boxes[0].Text += Environment.NewLine;
                boxes[0].Text += Environment.NewLine;
                boxes[0].Text+= String.Format("\nThe four points " + listOfRectangles[i].P1.ToString() + ", " + listOfRectangles[i].P2.ToString() + ", " + listOfRectangles[i].P3.ToString() + ", " + listOfRectangles[i].P4.ToString() + " above lie in the same plane thus is a rectangle.");
            }
            boxes[0].Text += Environment.NewLine;
            int probablity = 40;
            boxes[0].Text += Environment.NewLine; boxes[0].Text += Environment.NewLine;
            if (name == "table")
                boxes[0].Text += ("Adding probablity 40% because we have found a rectangle");
            else
                boxes[0].Text += ("Adding probablity 40% because we have found two rectangles");

            boxes[0].Text += Environment.NewLine;
           
            boxes[1].Text += Environment.NewLine;
            List<MEdge> legsEdge;
            boxes[1].Text += "The remaining edges are ";

            boxes[1].Text += Environment.NewLine;
            boxes[1].Text += Environment.NewLine;
            List<Point> legs;
            if (name == "table")
                legs = findLegs(remainingEdges, listOfRectangles[0], out legsEdge, boxes[1]);
            else
                legs = findLegs(remainingEdges, listOfRectangles[1], out legsEdge, boxes[1]);

            boxes[1].Text += Environment.NewLine;
            boxes[1].Text += Environment.NewLine;
            boxes[1].Text += ("Finding legs in the remaining edges.\n");

            boxes[1].Text += Environment.NewLine;
            
            if (legs.Count != 4)
            {
                if (legs.Count == 1)
                {
                    boxes[1].Text += Environment.NewLine;
                    boxes[1].Text+=("Adding probablity 5% because we have found one legs");
                    probablity += 5;
                }
                else if (legs.Count == 2)
                {
                    boxes[1].Text += Environment.NewLine;
                    boxes[1].Text+=("Adding probablity 10% because we have found two legs");
                    probablity += 10;
                }
                else if (legs.Count == 3)
                {
                    boxes[1].Text += Environment.NewLine;
                    boxes[1].Text+=("Adding probablity 15% because we have found three legs");
                    probablity += 15;
                }
                else
                    probablity += 10;
                boxes[1].Text += Environment.NewLine;
                
                boxes[1].Text+=String.Format("Its a {0} with {1}% probablity because the number of legs are not four", name, probablity);
             //   MessageBox.Show(String.Format("Its a {0} with {1}% probablity because the number of legs are not four", name, probablity));
              //  Environment.Exit(0);
            }
            else
            {
                boxes[1].Text += Environment.NewLine;
                boxes[1].Text+=("Adding probablity 20% because we have found four legs");
                probablity += 20;
            }
            boxes[1].Text += Environment.NewLine;
            boxes[1].Text+=("Following are the set of legs which intersect the rectangle");
            boxes[1].Text += Environment.NewLine;
            for (int i = 0; i < legs.Count; i++)
            {
                boxes[1].Text += legs[i].print();
                boxes[1].Text += Environment.NewLine;
            }
            boxes[1].Text += Environment.NewLine; 
            boxes[1].Text+=String.Format("Finding if all the legs lie in the same plane using equation {0}.", eqn[0].ToString());
            
            if (name == "table" && onSameSide(legs, eqn[0], ref probablity,  boxes[1]) != true)
            {
                boxes[1].Text += Environment.NewLine;
                boxes[1].Text+=String.Format("Its a {0} with {1} % probablity because the legs do not fall in the same plane", name, probablity);
                 //MessageBox.Show(String.Format("Its a {0} with {1} % probablity because the legs do not fall in the same plane", name, probablity));
                  //Environment.Exit(0);
            }
            if (name == "chair" && onSameSide(legs, eqn[0], ref probablity, boxes[1]) != true && onSameSide(legs, eqn[1], ref probablity, boxes[1]) != true)
            {
                boxes[1].Text += Environment.NewLine;
                boxes[1].Text += String.Format("Its a {0} with {1} % probablity because the legs do not fall in the same plane", name, probablity);
                //MessageBox.Show(String.Format("Its a {0} with {1} % probablity because the legs do not fall in the same plane", name, probablity));
                //Environment.Exit(0);
            }
            boxes[1].Text += Environment.NewLine;
            boxes[1].Text+=("\nThe legs lie in the same plane.");
            boxes[1].Text += Environment.NewLine;
            boxes[2].Text+=("Finding angles between the leg and table.");
            boxes[2].Text += Environment.NewLine;
            if (name == "table")
            {
                if (findAngles((List<MEdge>)fourEdgesArr[0], legsEdge, ref probablity, boxes[2]) == false)
                {
                    //if (name == "chair" && findAngles((List<Edge>)fourEdgesArr[1], legsEdge, ref probablity, boxes[2]) == false)
                        boxes[2].Text += String.Format("Its a {0} with {1} % probablity because angle of the legs is not perpendicular to the table.", name, probablity);
                    //  Environment.Exit(0);
                }
            }
            if (name == "chair")
            {
                if (findAngles((List<MEdge>)fourEdgesArr[0], legsEdge, ref probablity, boxes[2]) == false && findAngles((List<MEdge>)fourEdgesArr[1], legsEdge, ref probablity, boxes[2]) == false)
                {
                   // if (name == "chair" && findAngles((List<Edge>)fourEdgesArr[1], legsEdge, ref probablity, boxes[2]) == false)
                        boxes[2].Text += String.Format("Its a {0} with {1} % probablity because angle of the legs is not perpendicular to the table.", name, probablity);
                    //  Environment.Exit(0);
                }
            }
            boxes[2].Text += Environment.NewLine;
            boxes[2].Text+=("The above set of legs form a 90 degree angle with the rectangle points respectively.");

            if (name == "table" )
            {
                boxes[2].Text += Environment.NewLine;
                boxes[2].Text += Environment.NewLine;
                boxes[2].Text+=("**************************************************************************");
                boxes[2].Text+=String.Format("                 The above set of edges form a {0} with {1}% probablity", name, probablity);

                boxes[2].Text+=("**************************************************************************");
            }
            prb.Text = probablity.ToString(); 
             return listOfRectangles;
        }

        private static bool findAngles(List<MEdge> fourEdges, List<MEdge> legs, ref int prob,   TextBox p)
        {
            for (int i = 0; i < legs.Count; i++)
            {

                p.Text += Environment.NewLine;
                MVector3 vect1 = new MVector3(Convert.ToDouble(legs[i].P2.X - legs[i].P1.X), Convert.ToDouble(legs[i].P2.Y - legs[i].P1.Y), Convert.ToDouble(legs[i].P2.Z - legs[i].P1.Z));
                p.Text+=("Angle between   ");

                p.Text += legs[i].print();
                MEdge e = getEdge(legs[i], fourEdges);
                p.Text+=("   and   ");

                p.Text += e.print();
                MVector3 vect2 = new MVector3(Convert.ToDouble(e.P1.X - e.P2.X), Convert.ToDouble(e.P1.Y - e.P2.Y), Convert.ToDouble(e.P1.Z - e.P2.Z));
                double angle = MVector3.Angle(vect1, vect2);
                angle = (180 / Math.PI) * angle;
                //if (!(MVector3.IsPerpendicular(vect1, vect2)))
                  //  return false;
                
                p.Text+=("  is   ");
                p.Text += angle;
                p.Text += Environment.NewLine;
                p.Text += Environment.NewLine;
                if (angle < 70 || angle > 110)
                    return false;
               p.Text += ("Adding probablity 5% because we have an angle perpendicular"); prob += 5;
               p.Text += Environment.NewLine;
               p.Text += Environment.NewLine;
            }
            return true;
        }

        private static MEdge getEdge(MEdge edge, List<MEdge> fourEdges)
        {
            if (fourEdges[0].P1 == edge.P1
                || fourEdges[0].P1 == edge.P2)
                return fourEdges[0];
            else if (fourEdges[0].P2 == edge.P1
                || fourEdges[0].P2 == edge.P2)
                return fourEdges[0];
            else if (fourEdges[1].P2 == edge.P1
                || fourEdges[1].P2 == edge.P2)
                return fourEdges[1];
            else if (fourEdges[3].P2 == edge.P1
                || fourEdges[3].P2 == edge.P2)
                return fourEdges[3];
            else if (fourEdges[3].P1 == edge.P1
                || fourEdges[3].P1 == edge.P2)
                return fourEdges[3];
            return new MEdge();

        }

        private static bool onSameSide(List<Point> legs, Equation eqn1, ref int prob,   TextBox p)
        {
            return eqn1.checkpoint(legs, ref prob,   p);
        }

        private static List<Point> findLegs(List<MEdge> remainingEdges, Rectangle rectangle, out List<MEdge> legsEdge, TextBox p)
        {
            for (int i = 0; i < remainingEdges.Count; i++)
            {
                p.Text += remainingEdges[i].print();

                p.Text += Environment.NewLine;
            }
            List<Point> legs = new List<Point>();
            legsEdge = new List<MEdge>();

            for (int i = 0; i < remainingEdges.Count; i++)
            {
                if (remainingEdges[i].P1 == rectangle.P1 || remainingEdges[i].P1 == rectangle.P2 ||
                    remainingEdges[i].P1 == rectangle.P3 || remainingEdges[i].P1 == rectangle.P4)
                {
                    legsEdge.Add(remainingEdges[i]);
                    legs.Add(remainingEdges[i].P2);
                }
                else if (remainingEdges[i].P2 == rectangle.P1 || remainingEdges[i].P2 == rectangle.P2 ||
                    remainingEdges[i].P2 == rectangle.P3 || remainingEdges[i].P2 == rectangle.P4)
                {
                    legsEdge.Add(remainingEdges[i]);
                    legs.Add(remainingEdges[i].P1);
                }
            }
            return legs;
        }

        private static bool haveSamePlane(Rectangle r1, out Equation eqn1)
        {

            MVector3 vect1 = new MVector3(Convert.ToDouble(r1.P2.X - r1.P1.X), Convert.ToDouble(r1.P2.Y - r1.P1.Y), Convert.ToDouble(r1.P2.Z - r1.P1.Z));
            MVector3 vect2 = new MVector3(Convert.ToDouble(r1.P3.X - r1.P1.X), Convert.ToDouble(r1.P3.Y - r1.P1.Y), Convert.ToDouble(r1.P3.Z - r1.P1.Z));
            MVector3 vect3 = vect1.CrossProduct(vect2);

            eqn1 = new Equation(r1.P1.X, r1.P1.Y, r1.P1.Z, (int)vect3[0], (int)vect3[1], (int)vect3[2]);

            return eqn1.checkpoint(r1.P4);

        }


    
    }
}
