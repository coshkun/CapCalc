using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Luncher
{
    public partial class frmMain : Form
    {
        Point x, y, z, L, offset, middle, picBox;
        int dX, dY, dZ, dL, dPic;
        int eX, eY, eZ, eL, ePic;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            x = new Point(lbl_X.Location.X, lbl_X.Location.Y);
            y = new Point(lbl_Y.Location.X, lbl_Y.Location.Y);
            z = new Point(lbl_Z.Location.X, lbl_Z.Location.Y);
            L = new Point(lbl_L.Location.X, lbl_L.Location.Y);
            picBox = new Point(pBox.Location.X, pBox.Location.Y);
            offset = new Point(grpSelectedCargo.Width / 2,
                                grpSelectedCargo.Height / 2);
            dX = offset.X - x.X; dY = offset.X - y.X; dZ = offset.X - z.X; dL = offset.X - L.X;
            eX = offset.Y - x.Y; eY = offset.Y - y.Y; eZ = offset.Y - z.Y; eL = offset.Y - L.Y;
            dPic = offset.X - picBox.X; ePic = offset.Y - picBox.Y;
        }

        private void CalculateShemaPosition()
        {
            middle = new Point(grpSelectedCargo.Width / 2,
                                grpSelectedCargo.Height / 2);
            lbl_X.Location = new Point(middle.X - Math.Abs(dX), middle.Y + Math.Abs(eX));
            lbl_Y.Location = new Point(middle.X - Math.Abs(dY), middle.Y + Math.Abs(eY));
            lbl_Z.Location = new Point(middle.X + Math.Abs(dZ), middle.Y + Math.Abs(eZ));
            lbl_L.Location = new Point(middle.X + Math.Abs(dL), middle.Y - Math.Abs(eL));
            pBox.Location = new Point(middle.X - Math.Abs(dPic), middle.Y - Math.Abs(ePic));
        }

        private void grpSelectedCargo_Resize(object sender, EventArgs e)
        {
            CalculateShemaPosition();
        }
    }
}
