using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SmartEye3
{
    public partial class Phase1 : Form
    {
        private EdgeDetector ED_Left;
        private EdgeDetector ED_Right;
        private List<Edge> edgesLeft;
        private List<Edge> edgesRight;
        private DataTable EdgesTableLeft;
        private DataTable EdgesTableRight;

        public event EventHandler BackClicked;

        public Phase1(Image left, Image right)
        {
            InitializeComponent();

            this.pb_Left.Image = left;
            this.pb_Right.Image = right;
        }

        private void Phase1_Load(object sender, EventArgs e)
        {
            this.btn_Action.Click += new EventHandler(this.DetectEdges);

            EdgesTableLeft = new DataTable();
            DataColumn[] columnsLeft = new DataColumn[3];
            columnsLeft[0] = new DataColumn("No.");
            columnsLeft[1] = new DataColumn("Point1");
            columnsLeft[2] = new DataColumn("Point2");
            EdgesTableLeft.Columns.AddRange(columnsLeft);

            EdgesTableRight = new DataTable();
            DataColumn[] columnsRight = new DataColumn[3];
            columnsRight[0] = new DataColumn("No.");
            columnsRight[1] = new DataColumn("Point1");
            columnsRight[2] = new DataColumn("Point2");
            EdgesTableRight.Columns.AddRange(columnsRight);

            this.dGV_Left.DataSource = EdgesTableLeft;
            this.dGV_Right.DataSource = EdgesTableRight;
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            BackClicked(this, new EventArgs());
            this.Close();
        }

        private void DetectEdges(object sender, EventArgs e)
        {
            this.listView.Items[0].Font = new Font(this.listView.Items[0].Font, FontStyle.Bold);
            this.listView.Refresh();

            //----------------------------------------------------------------------------------//

            ED_Left = new EdgeDetector(new Bitmap(this.pb_Left.Image));
            edgesLeft = ED_Left.DetectEdges();
            DataRow Row;

            for (int i = 0; i < edgesLeft.Count; i++)
            {
                Row = EdgesTableLeft.NewRow();
                Row["No."] = i.ToString();
                Row["Point1"] = edgesLeft[i].Point1.X.ToString() + ", " + edgesLeft[i].Point1.Y.ToString();
                Row["Point2"] = edgesLeft[i].Point2.X.ToString() + ", " + edgesLeft[i].Point2.Y.ToString();
                EdgesTableLeft.Rows.Add(Row);
            }

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

            //----------------------------------------------------------------------------------------------//

            ED_Right = new EdgeDetector(new Bitmap(this.pb_Right.Image));
            edgesRight = ED_Right.DetectEdges();

            for (int i = 0; i < edgesRight.Count; i++)
            {
                Row = EdgesTableRight.NewRow();
                Row["No."] = i.ToString();
                Row["Point1"] = edgesRight[i].Point1.X.ToString() + ", " + edgesRight[i].Point1.Y.ToString();
                Row["Point2"] = edgesRight[i].Point2.X.ToString() + ", " + edgesRight[i].Point2.Y.ToString();
                EdgesTableRight.Rows.Add(Row);
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

            //----------------------------------------------------------------------------------//

            this.btn_Action.Click -= this.DetectEdges;
            this.btn_Action.Click += new EventHandler(this.MergeEdges);
            this.btn_Action.Text = "Next >";
        }

        private void MergeEdges(object sender, EventArgs e)
        {
            this.listView.Items[0].Font = new Font(this.listView.Items[0].Font, FontStyle.Regular);
            this.listView.Items[1].Font = new Font(this.listView.Items[0].Font, FontStyle.Bold);
            this.listView.Refresh();

            EdgesTableLeft.Clear();
            EdgesTableRight.Clear();
            this.dGV_Left.Refresh();
            this.dGV_Right.Refresh();

            //----------------------------------------------------------------------------------//

            edgesLeft = ED_Left.MergeEdgeSegments(edgesLeft);
            DataRow Row;

            for (int i = 0; i < edgesLeft.Count; i++)
            {
                Row = EdgesTableLeft.NewRow();
                Row["No."] = i.ToString();
                Row["Point1"] = edgesLeft[i].Point1.X.ToString() + ", " + edgesLeft[i].Point1.Y.ToString();
                Row["Point2"] = edgesLeft[i].Point2.X.ToString() + ", " + edgesLeft[i].Point2.Y.ToString();
                EdgesTableLeft.Rows.Add(Row);
            }

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

            //---------------------------------------------------------------------------------------------//

            edgesRight = ED_Right.MergeEdgeSegments(edgesRight);

            for (int i = 0; i < edgesRight.Count; i++)
            {
                Row = EdgesTableRight.NewRow();
                Row["No."] = i.ToString();
                Row["Point1"] = edgesRight[i].Point1.X.ToString() + ", " + edgesRight[i].Point1.Y.ToString();
                Row["Point2"] = edgesRight[i].Point2.X.ToString() + ", " + edgesRight[i].Point2.Y.ToString();
                EdgesTableRight.Rows.Add(Row);
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

            //----------------------------------------------------------------------------------//

            this.btn_Action.Click -= this.MergeEdges;
            this.btn_Action.Click += new EventHandler(this.ConnectEdges);
            this.btn_Action.Text = "Next >";
        }

        private void ConnectEdges(object sender, EventArgs e)
        {
            this.listView.Items[1].Font = new Font(this.listView.Items[0].Font, FontStyle.Regular);
            this.listView.Items[2].Font = new Font(this.listView.Items[0].Font, FontStyle.Bold);
            this.listView.Refresh();

            EdgesTableLeft.Clear();
            EdgesTableRight.Clear();
            this.dGV_Left.Refresh();
            this.dGV_Right.Refresh();

            //----------------------------------------------------------------------------------//

            edgesLeft = ED_Left.ConnectEdges(edgesLeft);
            DataRow Row;

            for (int i = 0; i < edgesLeft.Count; i++)
            {
                Row = EdgesTableLeft.NewRow();
                Row["No."] = i.ToString();
                Row["Point1"] = edgesLeft[i].Point1.X.ToString() + ", " + edgesLeft[i].Point1.Y.ToString();
                Row["Point2"] = edgesLeft[i].Point2.X.ToString() + ", " + edgesLeft[i].Point2.Y.ToString();
                EdgesTableLeft.Rows.Add(Row);
            }

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

            //---------------------------------------------------------------------------------------------//

            edgesRight = ED_Right.ConnectEdges(edgesRight);

            for (int i = 0; i < edgesRight.Count; i++)
            {
                Row = EdgesTableRight.NewRow();
                Row["No."] = i.ToString();
                Row["Point1"] = edgesRight[i].Point1.X.ToString() + ", " + edgesRight[i].Point1.Y.ToString();
                Row["Point2"] = edgesRight[i].Point2.X.ToString() + ", " + edgesRight[i].Point2.Y.ToString();
                EdgesTableRight.Rows.Add(Row);
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

            //----------------------------------------------------------------------------------//

            this.btn_Action.Click -= this.ConnectEdges;
            this.btn_Action.Click += new EventHandler(this.OptimizeEdges);
            this.btn_Action.Text = "Next >";
        }

        private void OptimizeEdges(object sender, EventArgs e)
        {
            this.listView.Items[2].Font = new Font(this.listView.Items[2].Font, FontStyle.Regular);
            this.listView.Items[3].Font = new Font(this.listView.Items[3].Font, FontStyle.Bold);
            this.listView.Refresh();

            EdgesTableLeft.Clear();
            EdgesTableRight.Clear();
            this.dGV_Left.Refresh();
            this.dGV_Right.Refresh();

            //----------------------------------------------------------------------------------//

            edgesLeft = ED_Left.OptimizeEdges(edgesLeft);
            DataRow Row;

            for (int i = 0; i < edgesLeft.Count; i++)
            {
                Row = EdgesTableLeft.NewRow();
                Row["No."] = i.ToString();
                Row["Point1"] = edgesLeft[i].Point1.X.ToString() + ", " + edgesLeft[i].Point1.Y.ToString();
                Row["Point2"] = edgesLeft[i].Point2.X.ToString() + ", " + edgesLeft[i].Point2.Y.ToString();
                EdgesTableLeft.Rows.Add(Row);
            }

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

            //---------------------------------------------------------------------------------------------//

            edgesRight = ED_Right.OptimizeEdges(edgesRight);

            for (int i = 0; i < edgesRight.Count; i++)
            {
                Row = EdgesTableRight.NewRow();
                Row["No."] = i.ToString();
                Row["Point1"] = edgesRight[i].Point1.X.ToString() + ", " + edgesRight[i].Point1.Y.ToString();
                Row["Point2"] = edgesRight[i].Point2.X.ToString() + ", " + edgesRight[i].Point2.Y.ToString();
                EdgesTableRight.Rows.Add(Row);
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

            //----------------------------------------------------------------------------------//

            this.btn_Action.Click -= this.OptimizeEdges;
            this.btn_Action.Click += new EventHandler(this.NextScreen);
            this.btn_Action.Text = "Next >>";
        }

        private void NextScreen(object sender, EventArgs e)
        {
            Phase2 phase2 = new Phase2(edgesLeft, edgesRight);
            phase2.Show();
            this.Close();
        }
    }
}
