namespace Luncher
{
    partial class frmMain
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
            this.grpSelectedCargo = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.sc1 = new System.Windows.Forms.SplitContainer();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lbl_Y = new System.Windows.Forms.Label();
            this.lbl_L = new System.Windows.Forms.Label();
            this.lbl_Z = new System.Windows.Forms.Label();
            this.lbl_X = new System.Windows.Forms.Label();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.grpSelectedCargo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.sc1.Panel1.SuspendLayout();
            this.sc1.Panel2.SuspendLayout();
            this.sc1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSelectedCargo
            // 
            this.grpSelectedCargo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSelectedCargo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.grpSelectedCargo.Controls.Add(this.lbl_L);
            this.grpSelectedCargo.Controls.Add(this.lbl_Z);
            this.grpSelectedCargo.Controls.Add(this.lbl_X);
            this.grpSelectedCargo.Controls.Add(this.lbl_Y);
            this.grpSelectedCargo.Controls.Add(this.pBox);
            this.grpSelectedCargo.Location = new System.Drawing.Point(6, 1);
            this.grpSelectedCargo.Name = "grpSelectedCargo";
            this.grpSelectedCargo.Size = new System.Drawing.Size(612, 204);
            this.grpSelectedCargo.TabIndex = 0;
            this.grpSelectedCargo.TabStop = false;
            this.grpSelectedCargo.Text = "Selected Cargo";
            this.grpSelectedCargo.Resize += new System.EventHandler(this.grpSelectedCargo_Resize);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(612, 196);
            this.dataGridView1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnExit);
            this.flowLayoutPanel1.Controls.Add(this.btnCalculate);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 417);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(624, 25);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // sc1
            // 
            this.sc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc1.Location = new System.Drawing.Point(0, 0);
            this.sc1.Name = "sc1";
            this.sc1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sc1.Panel1
            // 
            this.sc1.Panel1.Controls.Add(this.grpSelectedCargo);
            // 
            // sc1.Panel2
            // 
            this.sc1.Panel2.Controls.Add(this.dataGridView1);
            this.sc1.Size = new System.Drawing.Size(624, 417);
            this.sc1.SplitterDistance = 208;
            this.sc1.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(543, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(440, 0);
            this.btnCalculate.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(100, 23);
            this.btnCalculate.TabIndex = 1;
            this.btnCalculate.Text = "Calculate Grid";
            this.btnCalculate.UseVisualStyleBackColor = true;
            // 
            // lbl_Y
            // 
            this.lbl_Y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Y.AutoSize = true;
            this.lbl_Y.Location = new System.Drawing.Point(221, 142);
            this.lbl_Y.Name = "lbl_Y";
            this.lbl_Y.Size = new System.Drawing.Size(15, 13);
            this.lbl_Y.TabIndex = 4;
            this.lbl_Y.Text = "y:";
            // 
            // lbl_L
            // 
            this.lbl_L.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_L.AutoSize = true;
            this.lbl_L.Location = new System.Drawing.Point(350, 64);
            this.lbl_L.Name = "lbl_L";
            this.lbl_L.Size = new System.Drawing.Size(36, 13);
            this.lbl_L.TabIndex = 4;
            this.lbl_L.Text = "Level:";
            // 
            // lbl_Z
            // 
            this.lbl_Z.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Z.AutoSize = true;
            this.lbl_Z.Location = new System.Drawing.Point(350, 142);
            this.lbl_Z.Name = "lbl_Z";
            this.lbl_Z.Size = new System.Drawing.Size(15, 13);
            this.lbl_Z.TabIndex = 4;
            this.lbl_Z.Text = "z:";
            // 
            // lbl_X
            // 
            this.lbl_X.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_X.AutoSize = true;
            this.lbl_X.Location = new System.Drawing.Point(273, 172);
            this.lbl_X.Name = "lbl_X";
            this.lbl_X.Size = new System.Drawing.Size(15, 13);
            this.lbl_X.TabIndex = 4;
            this.lbl_X.Text = "x:";
            // 
            // pBox
            // 
            this.pBox.Image = global::Luncher.Properties.Resources.cargo_picker;
            this.pBox.Location = new System.Drawing.Point(216, 16);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(180, 180);
            this.pBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox.TabIndex = 4;
            this.pBox.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.sc1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpSelectedCargo.ResumeLayout(false);
            this.grpSelectedCargo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.sc1.Panel1.ResumeLayout(false);
            this.sc1.Panel2.ResumeLayout(false);
            this.sc1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSelectedCargo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.SplitContainer sc1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lbl_L;
        private System.Windows.Forms.Label lbl_Z;
        private System.Windows.Forms.Label lbl_X;
        private System.Windows.Forms.Label lbl_Y;
        private System.Windows.Forms.PictureBox pBox;
    }
}

