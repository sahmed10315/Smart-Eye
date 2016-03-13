namespace SmartEye3
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.pb_Left = new System.Windows.Forms.PictureBox();
            this.pb_Right = new System.Windows.Forms.PictureBox();
            this.btn_PhaseI = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Right)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_Left
            // 
            this.pb_Left.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pb_Left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_Left.Image = ((System.Drawing.Image)(resources.GetObject("pb_Left.Image")));
            this.pb_Left.Location = new System.Drawing.Point(43, 12);
            this.pb_Left.Name = "pb_Left";
            this.pb_Left.Size = new System.Drawing.Size(400, 300);
            this.pb_Left.TabIndex = 0;
            this.pb_Left.TabStop = false;
            // 
            // pb_Right
            // 
            this.pb_Right.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pb_Right.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_Right.Image = ((System.Drawing.Image)(resources.GetObject("pb_Right.Image")));
            this.pb_Right.Location = new System.Drawing.Point(449, 12);
            this.pb_Right.Name = "pb_Right";
            this.pb_Right.Size = new System.Drawing.Size(400, 300);
            this.pb_Right.TabIndex = 0;
            this.pb_Right.TabStop = false;
            // 
            // btn_PhaseI
            // 
            this.btn_PhaseI.Location = new System.Drawing.Point(368, 331);
            this.btn_PhaseI.Name = "btn_PhaseI";
            this.btn_PhaseI.Size = new System.Drawing.Size(75, 23);
            this.btn_PhaseI.TabIndex = 1;
            this.btn_PhaseI.Text = "Phase I";
            this.btn_PhaseI.UseVisualStyleBackColor = true;
            this.btn_PhaseI.Click += new System.EventHandler(this.btn_PhaseI_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.Enabled = false;
            this.btn_Next.Location = new System.Drawing.Point(449, 331);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(75, 23);
            this.btn_Next.TabIndex = 1;
            this.btn_Next.Text = "Next";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 366);
            this.Controls.Add(this.btn_Next);
            this.Controls.Add(this.btn_PhaseI);
            this.Controls.Add(this.pb_Right);
            this.Controls.Add(this.pb_Left);
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pb_Left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Right)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Left;
        private System.Windows.Forms.PictureBox pb_Right;
        private System.Windows.Forms.Button btn_PhaseI;
        private System.Windows.Forms.Button btn_Next;
    }
}