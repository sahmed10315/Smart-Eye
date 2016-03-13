namespace SmartEye3
{
    partial class Phase2
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tp_ImageAngles = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dGV_Left = new System.Windows.Forms.DataGridView();
            this.dGV_Right = new System.Windows.Forms.DataGridView();
            this.tp_CorrespondingEdges = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tp_3DModel = new System.Windows.Forms.TabPage();
            this.btn_View3DModel = new System.Windows.Forms.Button();
            this.panel_Bottom = new System.Windows.Forms.Panel();
            this.btn_Next = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tp_ImageAngles.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Right)).BeginInit();
            this.tp_CorrespondingEdges.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tp_3DModel.SuspendLayout();
            this.panel_Bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel_Bottom, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.91338F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.086614F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(853, 537);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tp_ImageAngles);
            this.tabControl.Controls.Add(this.tp_CorrespondingEdges);
            this.tabControl.Controls.Add(this.tp_3DModel);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(5, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(843, 487);
            this.tabControl.TabIndex = 1;
            // 
            // tp_ImageAngles
            // 
            this.tp_ImageAngles.BackColor = System.Drawing.SystemColors.Control;
            this.tp_ImageAngles.Controls.Add(this.tableLayoutPanel3);
            this.tp_ImageAngles.Location = new System.Drawing.Point(4, 22);
            this.tp_ImageAngles.Name = "tp_ImageAngles";
            this.tp_ImageAngles.Size = new System.Drawing.Size(835, 461);
            this.tp_ImageAngles.TabIndex = 2;
            this.tp_ImageAngles.Text = "Image Angles";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.dGV_Left, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.dGV_Right, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(835, 461);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // dGV_Left
            // 
            this.dGV_Left.AllowUserToAddRows = false;
            this.dGV_Left.AllowUserToDeleteRows = false;
            this.dGV_Left.AllowUserToResizeRows = false;
            this.dGV_Left.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV_Left.Location = new System.Drawing.Point(5, 5);
            this.dGV_Left.MultiSelect = false;
            this.dGV_Left.Name = "dGV_Left";
            this.dGV_Left.ReadOnly = true;
            this.dGV_Left.Size = new System.Drawing.Size(408, 451);
            this.dGV_Left.TabIndex = 0;
            // 
            // dGV_Right
            // 
            this.dGV_Right.AllowUserToAddRows = false;
            this.dGV_Right.AllowUserToDeleteRows = false;
            this.dGV_Right.AllowUserToResizeRows = false;
            this.dGV_Right.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV_Right.Location = new System.Drawing.Point(421, 5);
            this.dGV_Right.MultiSelect = false;
            this.dGV_Right.Name = "dGV_Right";
            this.dGV_Right.ReadOnly = true;
            this.dGV_Right.Size = new System.Drawing.Size(409, 451);
            this.dGV_Right.TabIndex = 1;
            // 
            // tp_CorrespondingEdges
            // 
            this.tp_CorrespondingEdges.BackColor = System.Drawing.SystemColors.Control;
            this.tp_CorrespondingEdges.Controls.Add(this.tableLayoutPanel2);
            this.tp_CorrespondingEdges.Location = new System.Drawing.Point(4, 22);
            this.tp_CorrespondingEdges.Name = "tp_CorrespondingEdges";
            this.tp_CorrespondingEdges.Padding = new System.Windows.Forms.Padding(3);
            this.tp_CorrespondingEdges.Size = new System.Drawing.Size(835, 461);
            this.tp_CorrespondingEdges.TabIndex = 0;
            this.tp_CorrespondingEdges.Text = "Corresponding Edges";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.dataGridView, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.38793F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(829, 455);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(5, 5);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(819, 445);
            this.dataGridView.TabIndex = 2;
            // 
            // tp_3DModel
            // 
            this.tp_3DModel.BackColor = System.Drawing.SystemColors.Control;
            this.tp_3DModel.Controls.Add(this.btn_View3DModel);
            this.tp_3DModel.Location = new System.Drawing.Point(4, 22);
            this.tp_3DModel.Name = "tp_3DModel";
            this.tp_3DModel.Padding = new System.Windows.Forms.Padding(3);
            this.tp_3DModel.Size = new System.Drawing.Size(835, 461);
            this.tp_3DModel.TabIndex = 1;
            this.tp_3DModel.Text = "3D Model";
            // 
            // btn_View3DModel
            // 
            this.btn_View3DModel.Location = new System.Drawing.Point(367, 205);
            this.btn_View3DModel.Name = "btn_View3DModel";
            this.btn_View3DModel.Size = new System.Drawing.Size(100, 50);
            this.btn_View3DModel.TabIndex = 0;
            this.btn_View3DModel.Text = "View 3D Model";
            this.btn_View3DModel.UseVisualStyleBackColor = true;
            this.btn_View3DModel.Click += new System.EventHandler(this.btn_ViewModel_Click);
            // 
            // panel_Bottom
            // 
            this.panel_Bottom.Controls.Add(this.btn_Next);
            this.panel_Bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Bottom.Location = new System.Drawing.Point(5, 500);
            this.panel_Bottom.Name = "panel_Bottom";
            this.panel_Bottom.Size = new System.Drawing.Size(843, 32);
            this.panel_Bottom.TabIndex = 2;
            // 
            // btn_Next
            // 
            this.btn_Next.Location = new System.Drawing.Point(763, 5);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(75, 23);
            this.btn_Next.TabIndex = 0;
            this.btn_Next.Text = "Next >>";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // Phase2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 537);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "Phase2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phase 2";
            this.Load += new System.EventHandler(this.Phase2_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tp_ImageAngles.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Right)).EndInit();
            this.tp_CorrespondingEdges.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tp_3DModel.ResumeLayout(false);
            this.panel_Bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tp_ImageAngles;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView dGV_Left;
        private System.Windows.Forms.DataGridView dGV_Right;
        private System.Windows.Forms.TabPage tp_CorrespondingEdges;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabPage tp_3DModel;
        private System.Windows.Forms.Panel panel_Bottom;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btn_View3DModel;

    }
}