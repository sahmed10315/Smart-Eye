using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace SmartEye3
{
    public partial class Phase2 : Form
    {
        private DepthPerceiver DP;
        private List<List<Edge>> correspondingEdges;
        private List<Edge3D> Edges;
        private ImageAngles imageAnglesLeft;
        private ImageAngles imageAnglesRight;
        private List<Edge> edgesLeft;
        private List<Edge> edgesRight;

        private DataTable AnglesTableLeft;
        private DataTable AnglesTableRight;
        private DataTable CorrespondingEdgesTable;

        public Phase2(List<Edge> left, List<Edge> right)
        {
            InitializeComponent();

            edgesLeft = left;
            edgesRight = right;
            imageAnglesLeft = new ImageAngles(400, 10, Side.Left);
            imageAnglesRight = new ImageAngles(400, 10, Side.Right);
            imageAnglesLeft.SetPixelAngles();
            imageAnglesRight.SetPixelAngles();
            DP = new DepthPerceiver(imageAnglesLeft, imageAnglesRight, 6);
            correspondingEdges = DP.FindCorrespondingEdges(edgesLeft, edgesRight);
            Edges = DP.Find3DEdges(correspondingEdges);
        }

        private void Phase2_Load(object sender, EventArgs e)
        {
            AnglesTableLeft = new DataTable();
            DataColumn[] columnsLeft = new DataColumn[2];
            columnsLeft[0] = new DataColumn("Index");
            columnsLeft[1] = new DataColumn("Angle");
            AnglesTableLeft.Columns.AddRange(columnsLeft);

            AnglesTableRight = new DataTable();
            DataColumn[] columnsRight = new DataColumn[3];
            columnsRight[0] = new DataColumn("Index");
            columnsRight[1] = new DataColumn("Angle");
            AnglesTableRight.Columns.AddRange(columnsRight);

            CorrespondingEdgesTable = new DataTable();
            DataColumn[] columns = new DataColumn[3];
            columns[0] = new DataColumn("No.");
            columns[1] = new DataColumn("Edge1");
            columns[2] = new DataColumn("Edge2");
            CorrespondingEdgesTable.Columns.AddRange(columns);

            this.dGV_Left.DataSource = AnglesTableLeft;
            this.dGV_Right.DataSource = AnglesTableRight;
            this.dataGridView.DataSource = CorrespondingEdgesTable;

            DataRow Row;
            for (int i = 0; i < imageAnglesLeft.GetImageWidth(); i++)
            {
                Row = AnglesTableLeft.NewRow();
                Row["Index"] = i.ToString();
                Row["Angle"] = imageAnglesLeft.GetPixelAngle(i);
                AnglesTableLeft.Rows.Add(Row);
            }

            for (int i = 0; i < imageAnglesRight.GetImageWidth(); i++)
            {
                Row = AnglesTableRight.NewRow();
                Row["Index"] = i.ToString();
                Row["Angle"] = imageAnglesRight.GetPixelAngle(i);
                AnglesTableRight.Rows.Add(Row);
            }

            for (int i = 0; i < correspondingEdges.Count; i++)
            {
                Row = CorrespondingEdgesTable.NewRow();
                Row["No."] = i.ToString();
                Row["Edge1"] = "(" + correspondingEdges[i][0].Point1.X.ToString() + ", " + correspondingEdges[i][0].Point1.Y.ToString() + ")" + ", (" + correspondingEdges[i][0].Point2.X.ToString() + ", " + correspondingEdges[i][0].Point2.Y.ToString() + ")";
                Row["Edge2"] = "(" + correspondingEdges[i][1].Point1.X.ToString() + ", " + correspondingEdges[i][1].Point1.Y.ToString() + ")" + ", (" + correspondingEdges[i][1].Point2.X.ToString() + ", " + correspondingEdges[i][1].Point2.Y.ToString() + ")";
                CorrespondingEdgesTable.Rows.Add(Row);
            }
        }

        private void btn_ViewModel_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(Edges);
            form.Show();

            while (form.Created)
            {
                form.HeartBeat();
                Application.DoEvents();
            }
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            List<AIEnginePhase.MEdge> edges = new List<AIEnginePhase.MEdge>();

            for (int i = 0; i < Edges.Count; i++)
            {
                edges.Add(new AIEnginePhase.MEdge(Edges[i].Point1.X, Edges[i].Point1.Y, Edges[i].Point1.Z, Edges[i].Point2.X, Edges[i].Point2.Y, Edges[i].Point2.Z, String.Concat("e", i)));
            }
                        
            AIEnginePhase.mainForm frm = new AIEnginePhase.mainForm();
            frm.Edges = edges;
            frm.Show();
            this.Close();
        }
    }
}