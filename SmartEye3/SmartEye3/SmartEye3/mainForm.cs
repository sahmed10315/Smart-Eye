using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AIEnginePhase
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            radioButton1.Checked = true; 

        }
         
        List<TextBox> boxes = new List<TextBox>();

        List<MEdge> edges = new List<MEdge>();

        internal List<MEdge> Edges
        {
            get { return edges; }
            set { edges = value; }
        }
        private void button1_Click(object sender, EventArgs e8)
        {
            //if (flag == false)
            //    MessageBox.Show("Load edges first.", "Error");
            //else
            {
                ShowEdges she = new ShowEdges();
                she.textBox1.Text += "These are the set of edges in which we try to find a table. ";

                she.textBox1.Text += Environment.NewLine;
                she.textBox1.Text += Environment.NewLine;
                for (int j = 0; j < edges.Count; j++)
                {
                    she.textBox1.Text += edges[j].print();

                    she.textBox1.Text += Environment.NewLine;
                }
                if (she.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Edges loaded successfully.", "success");
                }
                flag = true;
                // Call the function to find a table
                if (radioButton1.Checked)
                    AIEngine.findTables(edges, boxes, ref prb);
                else
                    AIEngine.findChairs(edges, boxes, ref prb);
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        bool flag = false;
        //private void button2_Click(object sender, EventArgs ea)
        //{
        //    int i = 0; 

        //    MEdge e = new MEdge(2, 20, 5, 2, 10, 5, String.Concat("e", ++i));

        //    edges.Add(e);
        //    e = new MEdge(2, 10, 5, 10, 10, 5, String.Concat("e", ++i));
        //    edges.Add(e);

        //    e = new MEdge(2, 10, 5, 2, 10, 4, String.Concat("e", ++i));
        //    edges.Add(e);
        //    e = new MEdge(2, 10, 4, 2, 0, 4, String.Concat("e", ++i));

        //    edges.Add(e);
        //    e = new MEdge(2, 10, 4, 10, 10, 4, String.Concat("e", ++i));

        //    edges.Add(e);
        //    e = new MEdge(10, 10, 4, 10, 0, 4, String.Concat("e", ++i));

        //    edges.Add(e);

        //    e = new MEdge(10, 10, 5, 10, 0, 5, String.Concat("e", ++i));

        //    edges.Add(e);

        //    e = new MEdge(10, 10, 4, 10, 10, 5, String.Concat("e", ++i));

        //    edges.Add(e);

        //        //Edge e = new Edge(2, 10, 5, 2, 0, 5, String.Concat("e", ++i));

        //        //edges.Add(e);

        //        //e = new Edge(2, 20, 5, 2, 10, 5, String.Concat("e", ++i));
        //        //edges.Add(e);

        //        //e = new Edge(8, 10, 5, 8, 20, 5, String.Concat("e", ++i));

        //        //edges.Add(e);
        //        //e = new Edge(2, 20, 5, 8, 20, 5, String.Concat("e", ++i));

        //        //edges.Add(e);
        //        //e = new Edge(2, 10, 5, 3, 10, 4, String.Concat("e", ++i));

        //        //edges.Add(e);
        //        //e = new Edge(3, 10, 4, 10, 10, 4, String.Concat("e", ++i));

        //        //edges.Add(e);

        //        //e = new Edge(2, 10, 5, 8, 10, 5, String.Concat("e", ++i));
        //        //edges.Add(e);
        //        //e = new Edge(10, 10, 4, 8, 10, 5, String.Concat("e", ++i));

        //        //edges.Add(e);


        //        //e = new Edge(3, 10, 4, 3, 0, 4, String.Concat("e", ++i));

        //        //edges.Add(e);
        //        //e = new Edge(8, 10, 5, 8, 0, 5, String.Concat("e", ++i));

        //        //edges.Add(e);

        //        //e = new Edge(10, 10, 4, 10, 0, 4, String.Concat("e", ++i));
        //        //edges.Add(e);

        //        //e = new Edge(120, 110, 4, 140, 40, 4, String.Concat("e", ++i));
        //        //edges.Add(e);
        //    ShowEdges she = new ShowEdges();
        //    // she.shoEdges(edges);
        //    she.textBox1.Text += "These are the set of edges in which we try to find a table. ";

        //    she.textBox1.Text += Environment.NewLine;
        //    she.textBox1.Text += Environment.NewLine;
        //    for (int j = 0; j < edges.Count; j++)
        //    {
        //        she.textBox1.Text += edges[j].print();

        //        she.textBox1.Text += Environment.NewLine;
        //    }
        //    if (she.ShowDialog() == DialogResult.OK)
        //    {
        //        MessageBox.Show("Edges loaded successfully.", "success");
        //    }
        //    flag = true;
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterToParent();
            boxes.Add(results);
            boxes.Add(results2);
            boxes.Add(results3);
            boxes.Add(result4);
            boxes.Add(results5);
        }
    }
}
