using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SmartEye3
{
    public class EdgeDetector
    {
        private const int edgePixelCount = 10;
        private const Double pointLineDistance = 2.000;
        private const Double edgePercentage = 70.000;
        private const Double edgeEdgeDistance = 2.000;
        private const Double slopeDifference = 1.000;
        private const Double segmentCollinearityAngle = 155.000;
        private const Double edgeCollinearityAngle = 170.000;
        private const Double edgeConnectDistance = 10.000;

        private Bitmap Image;
        private List<Point> EdgePixels;
        private bool[,] VisitedPixels;

        public EdgeDetector(Bitmap image)
        {
            Image = image;
            VisitedPixels = new bool[Image.Width, Image.Height];
            EdgePixels = new List<Point>();
        }

        public Point SeekStartPoint()
        {
            int i = 0;
            int j = 0;

            while (i < Image.Height && Image.GetPixel(j, i).ToArgb() != Color.Black.ToArgb())
            {
                while (j < Image.Width && Image.GetPixel(j, i).ToArgb() != Color.Black.ToArgb())
                {
                    j++;
                }

                if (j >= Image.Width)
                {
                    i++;
                    j = 0;
                }
            }

            return new Point(j, i);
        }

        public List<Edge> DetectEdges()
        {
            Point startPoint = SeekStartPoint();
            int j = startPoint.X;
            int i = startPoint.Y;
            return FindEdges(j, i);
        }

        private List<Edge> FindEdges(int j, int i)
        {
            List<Edge> Edges = new List<Edge>();

            //Mark the pixel as visited
            VisitedPixels[j, i] = true;

            //Add it to the EdgePixels list
            EdgePixels.Add(new Point(j, i));

            //Check the length of the EdgePixels list
            if (EdgePixels.Count >= edgePixelCount)
            {
                int onlinePixels = 0;
                Point point1 = EdgePixels.First();
                Point point2 = EdgePixels.Last();

                if (point2.X - point1.X == 0)
                {
                    for (int k = 1; k < EdgePixels.Count - 1; k++)
                    {
                        Double D = Math.Abs(point1.X - EdgePixels[k].X);

                        if (D <= pointLineDistance)
                        {
                            onlinePixels++;
                        }
                    }
                }
                else
                {
                    //Find A, B, C
                    Double A = (Double)(point2.Y - point1.Y) / (Double)(point2.X - point1.X);
                    Double C = point1.Y - A * point1.X;
                    Double B = -1;

                    for (int k = 1; k < EdgePixels.Count - 1; k++)
                    {
                        Double D = Math.Abs((Double)(A * EdgePixels[k].X + B * EdgePixels[k].Y + C) / (Double)(Math.Sqrt(A * A + B * B)));

                        if (D <= pointLineDistance)
                        {
                            onlinePixels++;
                        }
                    }
                }

                Double percentage = ((Double)onlinePixels / (Double)edgePixelCount) * 100;

                if (percentage >= edgePercentage)
                {
                    Edge edge = new Edge(point1, point2);
                    Edges.Add(edge);
                    EdgePixels.Clear();
                    EdgePixels.Add(point2);
                }
                else
                {
                    int maxNPCount = 0;
                    int cornerPixelIndex = 1;

                    for (int k = 1; k < EdgePixels.Count - 1; k++)
                    {
                        int NPCount = 0;

                        for (int x = EdgePixels[k].X - 1; x < EdgePixels[k].X + 2; x++)
                        {
                            for (int y = EdgePixels[k].Y - 1; y < EdgePixels[k].Y + 2; y++)
                            {
                                if (Image.GetPixel(x, y).ToArgb() == Color.Black.ToArgb())
                                {
                                    NPCount++;
                                }
                            }
                        }

                        if (NPCount > maxNPCount)
                        {
                            maxNPCount = NPCount;
                            cornerPixelIndex = k;
                        }
                    }

                    Edge edge1 = new Edge(point1, EdgePixels[cornerPixelIndex]);
                    Edges.Add(edge1);
                    Edge edge2 = new Edge(EdgePixels[cornerPixelIndex], point2);
                    Edges.Add(edge2);
                    EdgePixels.Clear();
                    EdgePixels.Add(point2);
                }
            }

            //Call the neighbouring pixels recursively
            bool isLeafPixel = true;
            for (int y = i - 1; y < i + 2; y++)
            {
                for (int x = j - 1; x < j + 2; x++)
                {
                    if (!VisitedPixels[x, y] && Image.GetPixel(x, y).ToArgb() == Color.Black.ToArgb())
                    {
                        isLeafPixel = false;
                        List<Edge> moreEdges = FindEdges(x, y);
                        Edges.AddRange(moreEdges);
                    }
                }
            }

            if (isLeafPixel)
            {
                if (EdgePixels.Count >= 2)
                {
                    Point point1 = EdgePixels.First();
                    Point point2 = EdgePixels.Last();
                    Edges.Add(new Edge(point1, point2));
                }

                EdgePixels.Clear();
            }

            return Edges;
        }

        public List<Edge> MergeEdgeSegments(List<Edge> edgeSegments)
        {
            List<Edge> Edges = new List<Edge>();
            Edges.Add(edgeSegments.First());

            for (int i = 1; i < edgeSegments.Count; i++)
            {
                if (Collinear(Edges.Last(), edgeSegments[i]))
                {
                    Edge mergedEdge = new Edge(Edges.Last().Point1, edgeSegments[i].Point2);
                    Edges.Remove(Edges.Last());
                    Edges.Add(mergedEdge);
                }
                else
                {
                    Edges.Add(edgeSegments[i]);
                }
            }

            return Edges;
        }
        
        private bool Collinear(Edge edge1, Edge edge2)
        {
            Double distance = Distance(edge1.Point2, edge2.Point1);
            Double alpha = Angle(edge1, edge2);

            if (alpha >= segmentCollinearityAngle && distance <= edgeEdgeDistance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Edge> ConnectEdges(List<Edge> Edges)
        {
            for (int i = 0; i < Edges.Count; i++)
            {
                for (int j = 0; j < Edges.Count; j++)
                {
                    if (i != j)
                    {
                        if (Distance(Edges[i].Point1, Edges[j].Point1) > 0 && Distance(Edges[i].Point1, Edges[j].Point1) <= edgeConnectDistance)
                        {
                            Edges[j].Point1 = Edges[i].Point1;
                        }
                        else if (Distance(Edges[i].Point1, Edges[j].Point2) > 0 && Distance(Edges[i].Point1, Edges[j].Point2) <= edgeConnectDistance)
                        {
                            Edges[j].Point2 = Edges[i].Point1;
                        }
                        else if (Distance(Edges[i].Point2, Edges[j].Point1) > 0 && Distance(Edges[i].Point2, Edges[j].Point1) <= edgeConnectDistance)
                        {
                            Edges[j].Point1 = Edges[i].Point2;
                        }
                        else if (Distance(Edges[i].Point2, Edges[j].Point2) > 0 && Distance(Edges[i].Point2, Edges[j].Point2) <= edgeConnectDistance)
                        {
                            Edges[j].Point2 = Edges[i].Point2;
                        }
                    }
                }
            }

            return Edges;
        }

        public List<Edge> OptimizeEdges(List<Edge> edges)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                for (int j = 0; j < edges.Count; j++)
                {
                    if (i != j)
                    {
                        if (edges[i].Point1 == edges[j].Point1)
                        {
                            if (Angle(edges[i], edges[j]) >= edgeCollinearityAngle)
                            {
                                edges[i].Point1 = edges[j].Point2;
                                edges.RemoveAt(j);
                                j--;
                            }
                        }
                        else if (edges[i].Point1 == edges[j].Point2)
                        {
                            if (Angle(edges[i], edges[j]) >= edgeCollinearityAngle)
                            {
                                edges[i].Point1 = edges[j].Point1;
                                edges.RemoveAt(j);
                                j--;
                            }
                        }
                        else if (edges[i].Point2 == edges[j].Point1)
                        {
                            if (Angle(edges[i], edges[j]) >= edgeCollinearityAngle)
                            {
                                edges[i].Point2 = edges[j].Point2;
                                edges.RemoveAt(j);
                                j--;
                            }
                        }
                        else if (edges[i].Point2 == edges[j].Point2)
                        {
                            if (Angle(edges[i], edges[j]) >= edgeCollinearityAngle)
                            {
                                edges[i].Point2 = edges[j].Point1;
                                edges.RemoveAt(j);
                                j--;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].Length == 0)
                {
                    edges.RemoveAt(i);
                }
            }

            return edges;
        }

        private Double Angle(Edge edge1, Edge edge2)
        {
            Point AB = new Point();
            AB.X = edge1.Point2.X - edge1.Point1.X;
            AB.Y = edge1.Point2.Y - edge1.Point1.Y;

            Point CD = new Point();
            CD.X = edge2.Point2.X - edge2.Point1.X;
            CD.Y = edge2.Point2.Y - edge2.Point1.Y;

            int dotProduct = (AB.X * CD.X) + (AB.Y * CD.Y);

            Double magAB = Math.Sqrt(Math.Pow(AB.X, 2) + Math.Pow(AB.Y, 2));
            Double magCD = Math.Sqrt(Math.Pow(CD.X, 2) + Math.Pow(CD.Y, 2));

            Double fraction = (Double)(dotProduct) / (magAB * magCD);
            fraction = Math.Round(fraction, 3);
            Double theta = (Math.Acos(fraction)) * (180 / Math.PI);
            Double alpha = theta;

            if (fraction >= 0)
            {
                alpha = 180 - theta;
            }

            return alpha;
        }

        private Double Distance(Point Point1, Point Point2)
        {
            return (Double)Math.Sqrt(Math.Pow(Point2.X - Point1.X, 2) + Math.Pow(Point2.Y - Point1.Y, 2));
        }
    }
}
