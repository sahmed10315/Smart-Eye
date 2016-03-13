using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace SmartEye3
{
    public partial class SelectStereoImages : Form
    {
        private bool leftImageSelected;
        private bool rightImageSelected;

        public SelectStereoImages()
        {
            InitializeComponent();

            leftImageSelected = false;
            rightImageSelected = false;
        }

        private void btn_LeftBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog OFD = new OpenFileDialog();
                String path = ConfigurationManager.AppSettings["ImageFolder"];
                OFD.InitialDirectory = @path;
                DialogResult result = OFD.ShowDialog();

                if (result != DialogResult.Cancel)
                {
                    this.pb_Left.Image = new Bitmap(OFD.FileName);
                    leftImageSelected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (leftImageSelected && rightImageSelected)
            {
                this.btn_Next.Enabled = true;
            }
        }

        private void btn_RightBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog OFD = new OpenFileDialog();
                String path = ConfigurationManager.AppSettings["ImageFolder"];
                OFD.InitialDirectory = @path;
                DialogResult result = OFD.ShowDialog();

                if (result != DialogResult.Cancel)
                {
                    this.pb_Right.Image = new Bitmap(OFD.FileName);
                    rightImageSelected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (leftImageSelected && rightImageSelected)
            {
                this.btn_Next.Enabled = true;
            }
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            Phase1 phase1 = new Phase1(this.pb_Left.Image, this.pb_Right.Image);
            phase1.BackClicked += new EventHandler(this.OnReturn);
            phase1.Show();
            this.Hide();
        }

        public void OnReturn(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}

