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

        private DataSet ds;
        private ColorDialog cd;
        private Color pC;
        private string HEXC = string.Empty;

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
            // Calculate Shema and Displays
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

            // initialize the Color Picker
            cd = new ColorDialog();
            cd.FullOpen = true;
            pC = Helper.GetRandomColor(); cd.Color = pC;
            txtColor.Text = ColorTranslator.ToHtml(pC);

            // initialize the data table
            var dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]{
                   new DataColumn("Name", typeof(string)),
                   new DataColumn("Long(X)",typeof(float)),
                   new DataColumn("Height(Y)", typeof(float)),
                   new DataColumn("Width(Z)",typeof(float)),
                   new DataColumn("Level",typeof(int)),
                   new DataColumn("Weight", typeof(float)),
                   new DataColumn("CBM",typeof(float)),
                   new DataColumn("Color", typeof(string))
            });
            ds = new DataSet();
            ds.Tables.Add(dt);
            dataGridView1.DataSource = ds.Tables[0];
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

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // int[] test = { 1,3,2,5,4,7,34,5,76,11,38,28,0,9,2};

            //Random rdn = new Random(2000000);
            //int[] xdata = new int[2000000];
            //Helper.MixDataUp(ref xdata, rdn); //Randomize data to be searched

            //Helper.QuickSort(ref xdata);

            //var snc = from eleman in xdata select new { Deger = eleman.ToString() };
            //dataGridView1.DataSource = snc.ToList();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            var _rslt = cd.ShowDialog();
            if (_rslt != System.Windows.Forms.DialogResult.OK) { return; }

            pC = cd.Color;
            btnColor.BackColor = pC;
            txtColor.Text = ColorTranslator.ToHtml(pC);
        }

        private void txtColor_TextChanged(object sender, EventArgs e)
        {
            HEXC = txtColor.Text; // int rslt;
            if (HEXC == string.Empty || HEXC == "#") { HEXC = "#000000"; }
            //if (HEXC.Length > 0 && HEXC[0] != '#' ||
            //    false == int.TryParse(HEXC.Substring(1, HEXC.Length - 1), out rslt)) { HEXC = ""; }
            try { pC = ColorTranslator.FromHtml(HEXC); }
            catch (Exception ex) { pC = Color.Black; HEXC = string.Empty; }
            
            btnColor.BackColor = pC;
            cd.Color = pC;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ds.Tables[0].Rows.Add(new object[]
            {
                txtName.Text,
                (float)numLong.Value,
                (float)numHeight.Value,
                (float)numWidth.Value,
                (int)numLevel.Value,
                (float)numWeight.Value,
                    (float)(numLong.Value * numHeight.Value * numWidth.Value),
                (string) ColorTranslator.ToHtml(cd.Color)
            });
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) { return; }

            string FileName = saveFileDialog.FileName;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) != DialogResult.OK) { return; }
            
            string FileName = openFileDialog.FileName;
        }

    }
}
