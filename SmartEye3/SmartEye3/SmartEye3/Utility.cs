using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace SmartEye3
{
    static class Utility
    {
        public static void FileEdges(List<Edge> Edges, String FileName)
        {
            String path = ConfigurationManager.AppSettings["ApplicationFolder"] + FileName;
            StreamWriter sw = File.CreateText(@path);

            for (int i = 0; i < Edges.Count; i++)
            {
                sw.WriteLine(i.ToString() + ": " + "(" + Edges[i].Point1.X.ToString() + ", " + Edges[i].Point1.Y.ToString() + ")" + ", (" + Edges[i].Point2.X.ToString() + ", " + Edges[i].Point2.Y.ToString() + ")" + " : " + Edges[i].Length);
            }
            sw.Close();
        }

        public static void File3DEdges(List<Edge3D> Edges, String FileName)
        {
            String path = ConfigurationManager.AppSettings["ApplicationFolder"] + FileName;
            StreamWriter sw = File.CreateText(@path);

            for (int i = 0; i < Edges.Count; i++)
            {
                sw.WriteLine(i.ToString() + ": " + "(" + Edges[i].Point1.X.ToString() + ", " + Edges[i].Point1.Y.ToString() + ", " + Edges[i].Point1.Z.ToString() + ")" + ", (" + Edges[i].Point2.X.ToString() + ", " + Edges[i].Point2.Y.ToString() + ", " + Edges[i].Point2.Z.ToString() + ")" + " : " + Edges[i].Length);
            }
            sw.Close();
        }

        public static void FileCorrespondingEdges(List<List<Edge>> CorrespondingEdges, String FileName)
        {
            String path = ConfigurationManager.AppSettings["ApplicationFolder"] + FileName;
            StreamWriter sw = File.CreateText(@path);

            for (int i = 0; i < CorrespondingEdges.Count; i++)
            {
                sw.WriteLine(i.ToString() + ": " + "(" + CorrespondingEdges[i][0].Point1.X.ToString() + ", " + CorrespondingEdges[i][0].Point1.Y.ToString() + ")" + ", (" + CorrespondingEdges[i][0].Point2.X.ToString() + ", " + CorrespondingEdges[i][0].Point2.Y.ToString() + ")" + " :: " + "(" + CorrespondingEdges[i][1].Point1.X.ToString() + ", " + CorrespondingEdges[i][1].Point1.Y.ToString() + ")" + ", (" + CorrespondingEdges[i][1].Point2.X.ToString() + ", " + CorrespondingEdges[i][1].Point2.Y.ToString() + ")");
            }
            sw.Close();
        }

        internal static void File3DEdges(List<AIEnginePhase.MEdge> edges, string p)
        {
            String path = ConfigurationManager.AppSettings["ApplicationFolder"] + p;
            StreamWriter sw = File.CreateText(@path);

            for (int i = 0; i < edges.Count; i++)
            {
                sw.WriteLine(edges[i].print());
                //sw.WriteLine(i.ToString() + ": " + "(" + edges[i].P1.X.ToString() + ", " + edges[i].P1.Y.ToString() + ", " + edges[i].P1.Z.ToString() + ")" + ", (" + edges[i].P2.X.ToString() + ", " + edges[i].P2.Y.ToString() + ", " + edges[i].P2.Z.ToString() + ")" + " : " + edges[i].Name);
            }
            sw.Close();

        }
    }
}
