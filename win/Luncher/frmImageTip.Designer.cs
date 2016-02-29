namespace Luncher
{
    partial class frmImageTip
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
            this.pBoxImage = new System.Windows.Forms.PictureBox();
            this.lbl_ImageTipTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pBoxImage
            // 
            this.pBoxImage.BackColor = System.Drawing.Color.Transparent;
            this.pBoxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoxImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBoxImage.Image = global::Luncher.Properties.Resources.go_none;
            this.pBoxImage.Location = new System.Drawing.Point(0, 0);
            this.pBoxImage.Name = "pBoxImage";
            this.pBoxImage.Size = new System.Drawing.Size(150, 150);
            this.pBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxImage.TabIndex = 0;
            this.pBoxImage.TabStop = false;
            // 
            // lbl_ImageTipTitle
            // 
            this.lbl_ImageTipTitle.Location = new System.Drawing.Point(3, 3);
            this.lbl_ImageTipTitle.Name = "lbl_ImageTipTitle";
            this.lbl_ImageTipTitle.Size = new System.Drawing.Size(145, 40);
            this.lbl_ImageTipTitle.TabIndex = 5;
            this.lbl_ImageTipTitle.Text = "Info:\r\nGravity Offset is the start point of gravity vector.";
            this.lbl_ImageTipTitle.UseCompatibleTextRendering = true;
            // 
            // frmImageTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(150, 150);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_ImageTipTitle);
            this.Controls.Add(this.pBoxImage);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImageTip";
            this.Opacity = 0.75D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmImageTip_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pBoxImage;
        private System.Windows.Forms.Label lbl_ImageTipTitle;
    }
}