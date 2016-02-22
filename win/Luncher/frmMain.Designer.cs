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
            this.lbl_L = new System.Windows.Forms.Label();
            this.lbl_Z = new System.Windows.Forms.Label();
            this.lbl_X = new System.Windows.Forms.Label();
            this.lbl_Y = new System.Windows.Forms.Label();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.sc1 = new System.Windows.Forms.SplitContainer();
            this.lblName = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.numLong = new System.Windows.Forms.NumericUpDown();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.numLevel = new System.Windows.Forms.NumericUpDown();
            this.numWeight = new System.Windows.Forms.NumericUpDown();
            this.btnColor = new System.Windows.Forms.Button();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpSelectedCargo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.sc1.Panel1.SuspendLayout();
            this.sc1.Panel2.SuspendLayout();
            this.sc1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSelectedCargo
            // 
            this.grpSelectedCargo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSelectedCargo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.grpSelectedCargo.Controls.Add(this.btnDelete);
            this.grpSelectedCargo.Controls.Add(this.btnUpdate);
            this.grpSelectedCargo.Controls.Add(this.btnAdd);
            this.grpSelectedCargo.Controls.Add(this.btnNew);
            this.grpSelectedCargo.Controls.Add(this.btnColor);
            this.grpSelectedCargo.Controls.Add(this.numWeight);
            this.grpSelectedCargo.Controls.Add(this.numLevel);
            this.grpSelectedCargo.Controls.Add(this.numWidth);
            this.grpSelectedCargo.Controls.Add(this.numHeight);
            this.grpSelectedCargo.Controls.Add(this.numLong);
            this.grpSelectedCargo.Controls.Add(this.txtColor);
            this.grpSelectedCargo.Controls.Add(this.txtName);
            this.grpSelectedCargo.Controls.Add(this.lblColor);
            this.grpSelectedCargo.Controls.Add(this.lblWeight);
            this.grpSelectedCargo.Controls.Add(this.lblZ);
            this.grpSelectedCargo.Controls.Add(this.lblX);
            this.grpSelectedCargo.Controls.Add(this.lblLevel);
            this.grpSelectedCargo.Controls.Add(this.lblY);
            this.grpSelectedCargo.Controls.Add(this.lblName);
            this.grpSelectedCargo.Controls.Add(this.lbl_L);
            this.grpSelectedCargo.Controls.Add(this.lbl_Z);
            this.grpSelectedCargo.Controls.Add(this.lbl_X);
            this.grpSelectedCargo.Controls.Add(this.lbl_Y);
            this.grpSelectedCargo.Controls.Add(this.pBox);
            this.grpSelectedCargo.Location = new System.Drawing.Point(6, 1);
            this.grpSelectedCargo.Name = "grpSelectedCargo";
            this.grpSelectedCargo.Size = new System.Drawing.Size(612, 203);
            this.grpSelectedCargo.TabIndex = 0;
            this.grpSelectedCargo.TabStop = false;
            this.grpSelectedCargo.Text = "Selected Cargo";
            this.grpSelectedCargo.Resize += new System.EventHandler(this.grpSelectedCargo_Resize);
            // 
            // lbl_L
            // 
            this.lbl_L.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_L.AutoSize = true;
            this.lbl_L.Location = new System.Drawing.Point(350, 63);
            this.lbl_L.Name = "lbl_L";
            this.lbl_L.Size = new System.Drawing.Size(36, 13);
            this.lbl_L.TabIndex = 4;
            this.lbl_L.Text = "Level:";
            // 
            // lbl_Z
            // 
            this.lbl_Z.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Z.AutoSize = true;
            this.lbl_Z.Location = new System.Drawing.Point(350, 141);
            this.lbl_Z.Name = "lbl_Z";
            this.lbl_Z.Size = new System.Drawing.Size(15, 13);
            this.lbl_Z.TabIndex = 4;
            this.lbl_Z.Text = "z:";
            // 
            // lbl_X
            // 
            this.lbl_X.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_X.AutoSize = true;
            this.lbl_X.Location = new System.Drawing.Point(273, 171);
            this.lbl_X.Name = "lbl_X";
            this.lbl_X.Size = new System.Drawing.Size(15, 13);
            this.lbl_X.TabIndex = 4;
            this.lbl_X.Text = "x:";
            // 
            // lbl_Y
            // 
            this.lbl_Y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Y.AutoSize = true;
            this.lbl_Y.Location = new System.Drawing.Point(221, 141);
            this.lbl_Y.Name = "lbl_Y";
            this.lbl_Y.Size = new System.Drawing.Size(15, 13);
            this.lbl_Y.TabIndex = 4;
            this.lbl_Y.Text = "y:";
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
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(612, 197);
            this.dataGridView1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnExit);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnLoad);
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
            this.btnCalculate.Location = new System.Drawing.Point(216, 0);
            this.btnCalculate.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(100, 23);
            this.btnCalculate.TabIndex = 1;
            this.btnCalculate.Text = "Calculate Grid";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
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
            this.sc1.Panel1MinSize = 207;
            // 
            // sc1.Panel2
            // 
            this.sc1.Panel2.Controls.Add(this.dataGridView1);
            this.sc1.Size = new System.Drawing.Size(624, 417);
            this.sc1.SplitterDistance = 207;
            this.sc1.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(6, 43);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(31, 13);
            this.lblX.TabIndex = 6;
            this.lblX.Text = "Long";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(6, 66);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(38, 13);
            this.lblY.TabIndex = 5;
            this.lblY.Text = "Height";
            // 
            // lblZ
            // 
            this.lblZ.AutoSize = true;
            this.lblZ.Location = new System.Drawing.Point(6, 89);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(35, 13);
            this.lblZ.TabIndex = 6;
            this.lblZ.Text = "Width";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(6, 112);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(33, 13);
            this.lblLevel.TabIndex = 5;
            this.lblLevel.Text = "Level";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(6, 135);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(41, 13);
            this.lblWeight.TabIndex = 6;
            this.lblWeight.Text = "Weight";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(6, 160);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(31, 13);
            this.lblColor.TabIndex = 6;
            this.lblColor.Text = "Color";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(53, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(80, 20);
            this.txtName.TabIndex = 7;
            // 
            // numLong
            // 
            this.numLong.DecimalPlaces = 1;
            this.numLong.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numLong.Location = new System.Drawing.Point(53, 40);
            this.numLong.Name = "numLong";
            this.numLong.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numLong.Size = new System.Drawing.Size(80, 20);
            this.numLong.TabIndex = 8;
            // 
            // numHeight
            // 
            this.numHeight.DecimalPlaces = 1;
            this.numHeight.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numHeight.Location = new System.Drawing.Point(53, 63);
            this.numHeight.Name = "numHeight";
            this.numHeight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numHeight.Size = new System.Drawing.Size(80, 20);
            this.numHeight.TabIndex = 8;
            // 
            // numWidth
            // 
            this.numWidth.DecimalPlaces = 1;
            this.numWidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numWidth.Location = new System.Drawing.Point(53, 86);
            this.numWidth.Name = "numWidth";
            this.numWidth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numWidth.Size = new System.Drawing.Size(80, 20);
            this.numWidth.TabIndex = 8;
            // 
            // numLevel
            // 
            this.numLevel.Location = new System.Drawing.Point(53, 109);
            this.numLevel.Name = "numLevel";
            this.numLevel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numLevel.Size = new System.Drawing.Size(80, 20);
            this.numLevel.TabIndex = 8;
            // 
            // numWeight
            // 
            this.numWeight.DecimalPlaces = 1;
            this.numWeight.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numWeight.Location = new System.Drawing.Point(53, 132);
            this.numWeight.Name = "numWeight";
            this.numWeight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numWeight.Size = new System.Drawing.Size(80, 20);
            this.numWeight.TabIndex = 8;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(53, 156);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(20, 20);
            this.btnColor.TabIndex = 9;
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(79, 156);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(54, 20);
            this.txtColor.TabIndex = 7;
            this.txtColor.Text = "#";
            this.txtColor.TextChanged += new System.EventHandler(this.txtColor_TextChanged);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(6, 177);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(40, 20);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(53, 177);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(40, 20);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.Location = new System.Drawing.Point(100, 177);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(53, 20);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(160, 177);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 20);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(328, 0);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load File";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(431, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 0, 12, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save File";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.sc1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(540, 480);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpSelectedCargo.ResumeLayout(false);
            this.grpSelectedCargo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.sc1.Panel1.ResumeLayout(false);
            this.sc1.Panel2.ResumeLayout(false);
            this.sc1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numLong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).EndInit();
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
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.NumericUpDown numWeight;
        private System.Windows.Forms.NumericUpDown numLevel;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.NumericUpDown numLong;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
    }
}

