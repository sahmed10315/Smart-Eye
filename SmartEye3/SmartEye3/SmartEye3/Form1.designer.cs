namespace SmartEye3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_DetectEdges = new System.Windows.Forms.Button();
            this.btn_MergeEdges = new System.Windows.Forms.Button();
            this.btn_ConnectEdges = new System.Windows.Forms.Button();
            this.btn_OptimizeEdges = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(46, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 300);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btn_DetectEdges
            // 
            this.btn_DetectEdges.Location = new System.Drawing.Point(37, 331);
            this.btn_DetectEdges.Name = "btn_DetectEdges";
            this.btn_DetectEdges.Size = new System.Drawing.Size(100, 23);
            this.btn_DetectEdges.TabIndex = 1;
            this.btn_DetectEdges.Text = "Detect Edges";
            this.btn_DetectEdges.UseVisualStyleBackColor = true;
            this.btn_DetectEdges.Click += new System.EventHandler(this.btn_FindEdges_Click);
            // 
            // btn_MergeEdges
            // 
            this.btn_MergeEdges.Location = new System.Drawing.Point(143, 331);
            this.btn_MergeEdges.Name = "btn_MergeEdges";
            this.btn_MergeEdges.Size = new System.Drawing.Size(100, 23);
            this.btn_MergeEdges.TabIndex = 2;
            this.btn_MergeEdges.Text = "Merge Edges";
            this.btn_MergeEdges.UseVisualStyleBackColor = true;
            this.btn_MergeEdges.Click += new System.EventHandler(this.btn_RefineEdges_Click);
            // 
            // btn_ConnectEdges
            // 
            this.btn_ConnectEdges.Location = new System.Drawing.Point(249, 331);
            this.btn_ConnectEdges.Name = "btn_ConnectEdges";
            this.btn_ConnectEdges.Size = new System.Drawing.Size(100, 23);
            this.btn_ConnectEdges.TabIndex = 3;
            this.btn_ConnectEdges.Text = "Connect Edges";
            this.btn_ConnectEdges.UseVisualStyleBackColor = true;
            this.btn_ConnectEdges.Click += new System.EventHandler(this.btn_ConnectEdges_Click);
            // 
            // btn_OptimizeEdges
            // 
            this.btn_OptimizeEdges.Location = new System.Drawing.Point(355, 331);
            this.btn_OptimizeEdges.Name = "btn_OptimizeEdges";
            this.btn_OptimizeEdges.Size = new System.Drawing.Size(100, 23);
            this.btn_OptimizeEdges.TabIndex = 4;
            this.btn_OptimizeEdges.Text = "Optimize Edges";
            this.btn_OptimizeEdges.UseVisualStyleBackColor = true;
            this.btn_OptimizeEdges.Click += new System.EventHandler(this.btn_OptimizeEdges_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 366);
            this.Controls.Add(this.btn_OptimizeEdges);
            this.Controls.Add(this.btn_ConnectEdges);
            this.Controls.Add(this.btn_MergeEdges);
            this.Controls.Add(this.btn_DetectEdges);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_DetectEdges;
        private System.Windows.Forms.Button btn_MergeEdges;
        private System.Windows.Forms.Button btn_ConnectEdges;
        private System.Windows.Forms.Button btn_OptimizeEdges;
    }
}

