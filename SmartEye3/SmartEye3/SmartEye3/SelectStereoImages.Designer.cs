namespace SmartEye3
{
    partial class SelectStereoImages
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Next = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_RightBrowse = new System.Windows.Forms.Button();
            this.pb_Right = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_LeftBrowse = new System.Windows.Forms.Button();
            this.pb_Left = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Right)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Left)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btn_Next, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.92929F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.070707F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(842, 391);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_Next
            // 
            this.btn_Next.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Next.Enabled = false;
            this.btn_Next.Location = new System.Drawing.Point(762, 364);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(75, 22);
            this.btn_Next.TabIndex = 0;
            this.btn_Next.Text = "Next";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(832, 351);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.btn_RightBrowse, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.pb_Right, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(420, 5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.14493F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.855072F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(407, 341);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // btn_RightBrowse
            // 
            this.btn_RightBrowse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_RightBrowse.Location = new System.Drawing.Point(166, 312);
            this.btn_RightBrowse.Name = "btn_RightBrowse";
            this.btn_RightBrowse.Size = new System.Drawing.Size(75, 23);
            this.btn_RightBrowse.TabIndex = 0;
            this.btn_RightBrowse.Text = "Browse";
            this.btn_RightBrowse.UseVisualStyleBackColor = true;
            this.btn_RightBrowse.Click += new System.EventHandler(this.btn_RightBrowse_Click);
            // 
            // pb_Right
            // 
            this.pb_Right.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pb_Right.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pb_Right.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_Right.Location = new System.Drawing.Point(3, 3);
            this.pb_Right.Name = "pb_Right";
            this.pb_Right.Size = new System.Drawing.Size(400, 300);
            this.pb_Right.TabIndex = 1;
            this.pb_Right.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btn_LeftBrowse, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.pb_Left, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.14493F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.855072F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(407, 341);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btn_LeftBrowse
            // 
            this.btn_LeftBrowse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_LeftBrowse.Location = new System.Drawing.Point(166, 312);
            this.btn_LeftBrowse.Name = "btn_LeftBrowse";
            this.btn_LeftBrowse.Size = new System.Drawing.Size(75, 23);
            this.btn_LeftBrowse.TabIndex = 0;
            this.btn_LeftBrowse.Text = "Browse";
            this.btn_LeftBrowse.UseVisualStyleBackColor = true;
            this.btn_LeftBrowse.Click += new System.EventHandler(this.btn_LeftBrowse_Click);
            // 
            // pb_Left
            // 
            this.pb_Left.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pb_Left.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pb_Left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_Left.Location = new System.Drawing.Point(3, 3);
            this.pb_Left.Name = "pb_Left";
            this.pb_Left.Size = new System.Drawing.Size(400, 300);
            this.pb_Left.TabIndex = 1;
            this.pb_Left.TabStop = false;
            // 
            // SelectStereoImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 391);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "SelectStereoImages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Stereo Images";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Right)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Left)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btn_LeftBrowse;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btn_RightBrowse;
        private System.Windows.Forms.PictureBox pb_Right;
        private System.Windows.Forms.PictureBox pb_Left;
    }
}