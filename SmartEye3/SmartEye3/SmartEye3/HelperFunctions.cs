using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AIEnginePhase
{ 
        static class HelperFunctions
        {


            public static bool findRectangles(List<MEdge> edges, ref Rectangle rect,   TextBox p)
            {


                Point initialPoint = edges[0].P1;
                Point secPoint = (edges[0].P2);
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 1; j < edges.Count; j++)
                    {
                        if (secPoint.X == edges[j].P1.X && secPoint.Y == edges[j].P1.Y && secPoint.Z == edges[j].P1.Z)
                            secPoint = edges[j].P2;
                        else if (secPoint.X == edges[j].P2.X && secPoint.Y == edges[j].P2.Y && secPoint.Z == edges[j].P2.Z)
                            secPoint = edges[j].P1;

                    }
                    if (secPoint.X == initialPoint.X && secPoint.Y == initialPoint.Y && secPoint.Z == initialPoint.Z)
                    {
                        rect.P1 = edges[0].P1;
                        rect.P2 = edges[0].P2;
                        for (int index = 1; index < 4; index++)
                        {

                            if (edges[index].P1 != rect.P1 && edges[index].P1 != rect.P2)
                            {
                                rect.P3 = edges[index].P1;
                                break;
                            }
                            else if (edges[index].P2 != rect.P1 && edges[index].P2 != rect.P2)
                            {
                                rect.P3 = edges[index].P2;
                                break;
                            }
                        }
                        for (int index = 1; index < 4; index++)
                        {

                            if (edges[index].P1 != rect.P1 && edges[index].P1 != rect.P2 && edges[index].P1 != rect.P3)
                            {
                                rect.P4 = edges[index].P1;
                                break;
                            }
                            else if (edges[index].P2 != rect.P1 && edges[index].P2 != rect.P2 && edges[index].P2 != rect.P3)
                            {
                                rect.P4 = edges[index].P2;
                                break;
                            }
                        }

                        p.Text += Environment.NewLine;

                        p.Text += ("These are the edges which form a four sided closed path");

                        p.Text += Environment.NewLine;
                        for (int k = 0; k < 4; k++)
                        {

                            p.Text += Environment.NewLine;
                            p.Text += edges[k].print();
                        }
                        p.Text += Environment.NewLine;
                        return true;
                    }
                }
                return false;
            }

            public static MEdge getEdge(string p, List<MEdge> edges)
            {
                for (int i = 0; i < edges.Count; i++)
                    if (edges[i].Name == p)
                        return (edges[i]);
                return new MEdge(0, 0, 0, 0, 0, 0, "Not found");
            }
        }
    }
 