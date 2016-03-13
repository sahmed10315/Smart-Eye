using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Threading;

namespace SmartEye3
{
    public partial class Form1 : Form
    {
        private EdgeDetector ED;
        private DepthPerceiver DP;
        List<Edge> Edges;

        public Form1()
        {
            InitializeComponent();
            ED = new EdgeDetector(new Bitmap(this.pictureBox1.Image));
            DP = new DepthPerceiver(new ImageAngles(401, 10, Side.Left), new ImageAngles(401, 10, Side.Right), 6);
        }

        private void btn_FindEdges_Click(object sender, EventArgs e)
        {
            Edges = ED.DetectEdges();

            this.pictureBox1.Image = null;
            this.pictureBox1.Refresh();
            this.btn_DetectEdges.Enabled = false;
            this.btn_MergeEdges.Enabled = true;

            Graphics g = this.pictureBox1.CreateGraphics();
            for (int i = 0; i < Edges.Count; i++)
            {
                if (i % 2 == 0)
                {
                    g.DrawLine(new Pen(Color.Green), Edges[i].Point1, Edges[i].Point2);
                }
                else
                {
                    g.DrawLine(new Pen(Color.Red), Edges[i].Point1, Edges[i].Point2);
                }

                Thread.Sleep(20);
            }

            Utility.FileEdges(Edges, "Edges.txt");
        }

        private void btn_RefineEdges_Click(object sender, EventArgs e)
        {
            List<Edge> RefinedEdges = ED.MergeEdgeSegments(Edges);
            Edges = RefinedEdges;

            this.btn_MergeEdges.Enabled = false;
            this.btn_ConnectEdges.Enabled = true;

            this.Refresh();
            Graphics g = this.pictureBox1.CreateGraphics();
            for (int i = 0; i < RefinedEdges.Count; i++)
            {
                if (i % 2 == 0)
                {
                    g.DrawLine(new Pen(Color.Green), RefinedEdges[i].Point1, RefinedEdges[i].Point2);
                }
                else
                {
                    g.DrawLine(new Pen(Color.Red), RefinedEdges[i].Point1, RefinedEdges[i].Point2);
                }

                Thread.Sleep(20);
            }

            Utility.FileEdges(RefinedEdges, "RefinedEdges.txt");
        }

        private void btn_ConnectEdges_Click(object sender, EventArgs e)
        {
            List<Edge> ConnectedEdges = ED.ConnectEdges(Edges);
            Edges = ConnectedEdges;

            this.btn_ConnectEdges.Enabled = false;
            this.btn_OptimizeEdges.Enabled = true;

            this.Refresh();
            Graphics g = this.pictureBox1.CreateGraphics();
            for (int i = 0; i < ConnectedEdges.Count; i++)
            {
                if (i % 2 == 0)
                {
                    g.DrawLine(new Pen(Color.Green), ConnectedEdges[i].Point1, ConnectedEdges[i].Point2);
                }
                else
                {
                    g.DrawLine(new Pen(Color.Red), ConnectedEdges[i].Point1, ConnectedEdges[i].Point2);
                }

                Thread.Sleep(20);
            }

            Utility.FileEdges(ConnectedEdges, "ConnectedEdges.txt");
        }

        private void btn_OptimizeEdges_Click(object sender, EventArgs e)
        {
            List<Edge> OptimizedEdges = ED.OptimizeEdges(Edges);

            this.btn_OptimizeEdges.Enabled = false;

            this.Refresh();
            Graphics g = this.pictureBox1.CreateGraphics();
            for (int i = 0; i < OptimizedEdges.Count; i++)
            {
                if (i % 2 == 0)
                {
                    g.DrawLine(new Pen(Color.Green), OptimizedEdges[i].Point1, OptimizedEdges[i].Point2);
                }
                else
                {
                    g.DrawLine(new Pen(Color.Red), OptimizedEdges[i].Point1, OptimizedEdges[i].Point2);
                }

                Thread.Sleep(20);
            }

            Utility.FileEdges(OptimizedEdges, "OptimizedEdges.txt");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
