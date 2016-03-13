using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Configuration;
using System.IO;

namespace SmartEye3
{
    public class DepthPerceiver
    {
        private const Double angleDifference = 7.000;
        private const int depthMultiplier = 100;
        private ImageAngles imageAnglesLeft;
        private ImageAngles imageAnglesRight;
        private double stereoDistance;

        public DepthPerceiver(ImageAngles imageAnglesLeft, ImageAngles imageAnglesRight, double stereoDistance)
        {
            this.imageAnglesLeft = imageAnglesLeft;
            this.imageAnglesRight = imageAnglesRight;
            this.stereoDistance = stereoDistance;
        }

        public List<Edge3D> Find3DEdges(List<List<Edge>> correspondingEdges)
        {
            List<Edge3D> Edges = new List<Edge3D>();

            for (int i = 0; i < correspondingEdges.Count; i++)
            {
                Edge3D edge = PerceiveDepth(correspondingEdges[i][0], correspondingEdges[i][1]);
                Edges.Add(edge);
            }

            return Edges;
        }

        public Edge3D PerceiveDepth(Edge edgeLeft, Edge edgeRight)
        {
            Edge3D edge;
            Double alpha;
            Double beta;
            Double gamma;
            Double depth;

            if (Distance(edgeLeft.Point1, edgeRight.Point1) < Distance(edgeLeft.Point1, edgeRight.Point2))
            {
                alpha = imageAnglesLeft.GetPixelAngle(edgeLeft.Point1);
                beta = imageAnglesRight.GetPixelAngle(edgeRight.Point1);
                gamma = Math.PI - alpha - beta;
                depth = (Double)(stereoDistance * Math.Sin(alpha) * Math.Sin(beta)) / (Double)(Math.Sin(gamma));
                depth = Round(depth);
                depth *= depthMultiplier;
                Point3D point1 = new Point3D(edgeLeft.Point1.X, edgeLeft.Point1.Y, (int)depth);
                
                alpha = imageAnglesLeft.GetPixelAngle(edgeLeft.Point2);
                beta = imageAnglesRight.GetPixelAngle(edgeRight.Point2);
                gamma = Math.PI - alpha - beta;
                depth = (Double)(stereoDistance * Math.Sin(alpha) * Math.Sin(beta)) / (Double)(Math.Sin(gamma));
                depth = Round(depth);
                depth *= depthMultiplier;
                Point3D point2 = new Point3D(edgeLeft.Point2.X, edgeLeft.Point2.Y, (int)depth);
                
                edge = new Edge3D(point1, point2);
            }
            else
            {
                alpha = imageAnglesLeft.GetPixelAngle(edgeLeft.Point1);
                beta = imageAnglesRight.GetPixelAngle(edgeRight.Point2);
                gamma = Math.PI - alpha - beta;
                depth = (Double)(stereoDistance * Math.Sin(alpha) * Math.Sin(beta)) / (Double)(Math.Sin(gamma));
                depth = Round(depth);
                depth *= depthMultiplier;
                Point3D point1 = new Point3D(edgeLeft.Point1.X, edgeLeft.Point1.Y, (int)depth);
                
                alpha = imageAnglesLeft.GetPixelAngle(edgeLeft.Point2);
                beta = imageAnglesRight.GetPixelAngle(edgeRight.Point1);
                gamma = Math.PI - alpha - beta;
                depth = (Double)(stereoDistance * Math.Sin(alpha) * Math.Sin(beta)) / (Double)(Math.Sin(gamma));
                depth = Round(depth);
                depth *= depthMultiplier;
                Point3D point2 = new Point3D(edgeLeft.Point2.X, edgeLeft.Point2.Y, (int)depth);
                
                edge = new Edge3D(point1, point2);
            }

            return edge;
        }

        public List<List<Edge>> FindCorrespondingEdges(List<Edge> leftEdges, List<Edge> rightEdges)
        {
            List<List<Edge>> correspondingEdges = new List<List<Edge>>();

            for (int i = 0; i < leftEdges.Count; i++)
            {
                Double minDistance = 400;
                int nearestEdgeIndex = -1;

                for (int j = 0; j < rightEdges.Count; j++)
                {
                    if (Parallel(leftEdges[i], rightEdges[j]))
                    {
                        Double distance = PointLineDistance(leftEdges[i].Point1, rightEdges[j]);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            nearestEdgeIndex = j;
                        }
                    }
                }

                if (nearestEdgeIndex != -1)
                {
                    List<Edge> edgePair = new List<Edge>();
                    edgePair.Add(leftEdges[i]);
                    edgePair.Add(rightEdges[nearestEdgeIndex]);
                    correspondingEdges.Add(edgePair);
                    rightEdges.RemoveAt(nearestEdgeIndex);
                }
            }

            return correspondingEdges;
        }

        private Double PointLineDistance(Point point, Edge edge)
        {
            Double distance;

            if (edge.Point2.X - edge.Point1.X == 0)
            {
                distance = Math.Abs(edge.Point1.X - point.X);
            }
            else
            {
                //Find A, B, C
                Double A = (Double)(edge.Point2.Y - edge.Point1.Y) / (Double)(edge.Point2.X - edge.Point1.X);
                Double C = edge.Point1.Y - A * edge.Point1.X;
                Double B = -1;

                distance = Math.Abs((Double)(A * point.X + B * point.Y + C) / (Double)(Math.Sqrt(A * A + B * B)));
            }

            return distance;
        }

        private Double ArcTan(Edge edge)
        {
            Double theta;

            if ((edge.Point2.X - edge.Point1.X) == 0)
            {
                theta = 90.000;
            }
            else
            {
                Double fraction = (Double)(edge.Point2.Y - edge.Point1.Y) / (Double)(edge.Point2.X - edge.Point1.X);
                theta = Math.Atan(fraction);
                theta *= 180 / Math.PI;
            }

            return theta;
        }

        private bool Parallel(Edge edge1, Edge edge2)
        {
            Double angle1 = ArcTan(edge1);
            Double angle2 = ArcTan(edge2);
            angle1 = Math.Abs(angle1);
            angle2 = Math.Abs(angle2);

            Double difference = Math.Abs(angle1 - angle2);

            if (difference <= angleDifference)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Double Round(Double numberDouble)
        {
            int numberInt = (int)numberDouble;

            if ((numberDouble - numberInt) < 0.5)
            {
                numberDouble = Math.Floor(numberDouble);
            }
            else
            {
                numberDouble = Math.Ceiling(numberDouble);
            }

            return numberDouble;
        }

        private Double Distance(Point Point1, Point Point2)
        {
            return (Double)Math.Sqrt(Math.Pow(Point2.X - Point1.X, 2) + Math.Pow(Point2.Y - Point1.Y, 2));
        }
    }
}
