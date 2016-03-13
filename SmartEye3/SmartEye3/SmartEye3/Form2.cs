using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Threading;

namespace SmartEye3
{
    public partial class Form2 : Form
    {
        private EdgeDetector ED;
        private List<Edge> edgesLeft;
        private List<Edge> edgesRight;

        public Form2()
        {
            InitializeComponent();
        }

        private void btn_PhaseI_Click(object sender, EventArgs e)
        {
            ED = new EdgeDetector(new Bitmap(this.pb_Left.Image));
            edgesLeft = ED.DetectEdges();
            edgesLeft = ED.MergeEdgeSegments(edgesLeft);
            edgesLeft = ED.ConnectEdges(edgesLeft);
            edgesLeft = ED.OptimizeEdges(edgesLeft);

            ED = new EdgeDetector(new Bitmap(this.pb_Right.Image));
            edgesRight = ED.DetectEdges();
            edgesRight = ED.MergeEdgeSegments(edgesRight);
            edgesRight = ED.ConnectEdges(edgesRight);
            edgesRight = ED.OptimizeEdges(edgesRight);

            //--------------------------------------------------------------------------------------------------//

            Utility.FileEdges(edgesLeft, "EdgesLeft.txt");
            Utility.FileEdges(edgesRight, "EdgesRight.txt");

            //--------------------------------------------------------------------------------------------------//

            this.pb_Left.Image = null;
            this.pb_Left.Refresh();
            Graphics g = this.pb_Left.CreateGraphics();
            for (int i = 0; i < edgesLeft.Count; i++)
            {
                if (i % 2 == 0)
                {
                    g.DrawLine(new Pen(Color.Yellow), edgesLeft[i].Point1, edgesLeft[i].Point2);
                }
                else
                {
                    g.DrawLine(new Pen(Color.Red), edgesLeft[i].Point1, edgesLeft[i].Point2);
                }

                Thread.Sleep(20);
            }

            this.pb_Right.Image = null;
            this.pb_Right.Refresh();
            g = this.pb_Right.CreateGraphics();
            for (int i = 0; i < edgesRight.Count; i++)
            {
                if (i % 2 == 0)
                {
                    g.DrawLine(new Pen(Color.Yellow), edgesRight[i].Point1, edgesRight[i].Point2);
                }
                else
                {
                    g.DrawLine(new Pen(Color.Red), edgesRight[i].Point1, edgesRight[i].Point2);
                }

                Thread.Sleep(20);
            }

            //--------------------------------------------------------------------------------------------------//

            this.btn_PhaseI.Enabled = false;
            this.btn_Next.Enabled = true;
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            /*Form3 form = new Form3(edgesLeft, edgesRight);
            form.Show();
            this.Hide();

            while (form.Created)
            {
                form.HeartBeat();
                Application.DoEvents();
            }
            this.Close();*/
        }
    }
}
