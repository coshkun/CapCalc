using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
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
        private DataTable dt;
        private ColorDialog cd;
        private Color pC;
        private string HEXC = string.Empty;
        private string _ID;
        private string[] NameArray = new string[1000];
        private int NameIndex = 0;
        private string _rValue = ""; // Lookup variable to make recursive name search
        private static List<ContainerInfo> Konteyners = new List<ContainerInfo>();
        private bool isLoaded = false; // this is a regular correction to fix legacy Form Load Eventhandler problem,
                                       // it always casting twice by windows, and cause the Form_Load() event code execution twice :('

        private string summary = ""; // Lookup variable for InfoTips


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
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]{
                   new DataColumn("ID", typeof(string)),
                   new DataColumn("Name", typeof(string)),
                   new DataColumn("Long",typeof(double)),
                   new DataColumn("Height", typeof(double)),
                   new DataColumn("Width",typeof(double)),
                   new DataColumn("Level",typeof(int)),
                   new DataColumn("Weight", typeof(double)),
                   new DataColumn("CBM",typeof(double)),
                   new DataColumn("Color", typeof(string))
            });
            ds = new DataSet();
            ds.Tables.Add(dt);

            // Refresh Grid
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns["ID"].Visible = false;

            // Initialize Inteli Naming Array,
            for (int i = 0; i < 1000; i++)
            {
                NameArray[i] = "Cargo " + string.Format("{0:000}", i);
            }

            // Initialize Konteyner to hold the Max Capacity.
            Konteyners.Add(new ContainerInfo("13.6 Semitrailer", 13.60d, 2.40d, 2.80d, 22.0d));
            cmbConSelector.DataSource = Konteyners.ToArray();
            cmbConSelector.DisplayMember = "Name";
            // var usage = ((ContainerInfo)cmbConSelector.SelectedValue).CBM;

            // Create ToolTip Handler
            InfoTips.ToolTipIcon = ToolTipIcon.Info;
            InfoTips.ToolTipTitle = "Info:";
            InfoTips.SetToolTip(cmbConSelector, summary);

            // Note this flag must be the last event line! it is a Legacy System Fix for Indexy Controls
            isLoaded = true;
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
            catch { pC = Color.Black; HEXC = string.Empty; }
            
            btnColor.BackColor = pC;
            cd.Color = pC;
        }

        private void cmbConSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            numLong.Maximum = (decimal)((ContainerInfo)cmbConSelector.SelectedValue).Long *100;
            numHeight.Maximum = (decimal)((ContainerInfo)cmbConSelector.SelectedValue).Height *100;
            numWidth.Maximum = (decimal)((ContainerInfo)cmbConSelector.SelectedValue).Width *100;
            numWeight.Maximum = (decimal)((ContainerInfo)cmbConSelector.SelectedValue).Weight *1000;

            summary = "Long: " + ((ContainerInfo)cmbConSelector.SelectedValue).Long.ToString() + "m \n"
                            + "Height: " + ((ContainerInfo)cmbConSelector.SelectedValue).Height.ToString() + "m \n"
                            + "Width: " + ((ContainerInfo)cmbConSelector.SelectedValue).Width.ToString() + "m \n"
                            + "Capacity: " + ((ContainerInfo)cmbConSelector.SelectedValue).CBM.ToString() + "m \n"
                            + "Payload: " + ((ContainerInfo)cmbConSelector.SelectedValue).Weight.ToString() + " tons";
            //if(this.isLoaded)
                InfoTips.SetToolTip(cmbConSelector, summary);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ID = Helper.GenerateId();
            var chk = from myRow in ds.Tables[0].AsEnumerable()
                      where (string)myRow.Field<string>("ID") == _ID
                      select new []{ (string)myRow.Field<string>("ID") };// Get ID;

            if (chk.Any()) // if, is there any chance to hit by 13.5 Bilion Lightyears away? :)
                _ID = Helper.GenerateId();

            if (txtName.Text == string.Empty) { txtName.Text = NameArray[NameIndex]; NameIndex++; }
            // Check the name on very first time if it is exist before.
            var chkN = from myRow in ds.Tables[0].AsEnumerable()
                       where (string)myRow.Field<string>("Name") == txtName.Text
                       select new[] { (string)myRow.Field<string>("Name") };// Get Name;

            _rValue = ""; // Reset the lookup variable
            if (chkN.Any()) { txtName.Text = CheckName(txtName.Text); }

            ds.Tables[0].Rows.Add(new object[]
            {
                _ID,
                txtName.Text,
                (double)numLong.Value,
                (double)numHeight.Value,
                (double)numWidth.Value,
                (int)numLevel.Value,
                (double)numWeight.Value,
                    (double)(numLong.Value * numHeight.Value * numWidth.Value),
                (string) ColorTranslator.ToHtml(cd.Color)
            });
            dataGridView1.DataSource = ds.Tables[0]; // Refresh Grid
        }
        
        private string CheckName(string NameWhoChecked)
        {
            var chkN = from myRow in ds.Tables[0].AsEnumerable()
                       where (string)myRow.Field<string>("Name") == NameWhoChecked
                select new[] { (string)myRow.Field<string>("Name") };// Get Name;

            if (chkN.Any()) 
            {   
                NameWhoChecked = NameArray[NameIndex]; NameIndex++;
                CheckName(NameWhoChecked);
            }
            if (_rValue == "")
            {
                MessageBox.Show("There is a matching cargo with same name. Your new entry added by " 
                                 + NameWhoChecked);
                _rValue = NameWhoChecked;
                return _rValue;
            }
            return _rValue;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            string _capturID = row.Cells["ID"].Value.ToString();

            DataRow r= dt.AsEnumerable().Where(x => // Get the selected row from table
                    x.Field<string>("ID") == _capturID).FirstOrDefault();

            if (txtName.Text == string.Empty) { txtName.Text = NameArray[NameIndex]; NameIndex++; }
            r.SetField<string>("Name", (string)txtName.Text);
            r.SetField<double>("Long", (double)numLong.Value);
            r.SetField<double>("Height", (double)numHeight.Value);
            r.SetField<double>("Width", (double)numWidth.Value);
            r.SetField<int>("Level", (int)numLevel.Value);
            r.SetField<double>("Weight", (double)numWeight.Value);
            r.SetField<double>("CBM",
                      (double)(numLong.Value * numHeight.Value * numWeight.Value));
            if (txtColor.Text == string.Empty) { txtColor.Text = ColorTranslator.ToHtml(cd.Color); }
            r.SetField<string>("Color", txtColor.Text);

            dataGridView1.DataSource = ds.Tables[0]; // Refresh the grid
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow satır in dataGridView1.SelectedRows)
            {
                if (satır != null)
                {
                    // Fix: Null Exception now handled :P
                    string _selectedID = ((satır.Cells["ID"].Value)!=null) ? satır.Cells["ID"].Value.ToString() : "";

                    if (_selectedID != "")
                    {
                        DataRow r = dt.AsEnumerable().Where(x => // Get the relevant selected row from table
                         x.Field<string>("ID") == _selectedID).FirstOrDefault();

                        ds.Tables[0].Rows.Remove(r);
                    }
                }
            }

            dataGridView1.DataSource = ds.Tables[0]; // Refresh the grid
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                ResetForm(ctrl); 
            }
            // Get New Random Color
            pC = Helper.GetRandomColor(); cd.Color = pC;
            txtColor.Text = ColorTranslator.ToHtml(pC);
        }

        private void ResetForm(Control control)
        {
            if (control.GetType() == typeof(TextBox))
            {
                var ty = control.GetType().GetProperty("Text");
                ty.SetValue(control, "", null);
            }
            //if (control.GetType() == typeof(ComboBox))
            //{
            //    var ty = control.GetType().GetProperty("Text");
            //    ty.SetValue(control, "", null);
            //}
            if (control.GetType() == typeof(CheckBox))
            {
                var ty = control.GetType().GetProperty("Checked");
                ty.SetValue(control, false, null);
            }
            if (control.GetType() == typeof(NumericUpDown))
            {
                var ty2 = control.GetType().GetProperty("Value");
                ty2.SetValue(control, (decimal)0, null);
            }
            // Set Static Contols here:
            if (control.Name == "lbl_X") { lbl_X.Text = "x:"; }
            if (control.Name == "lbl_Y") { lbl_X.Text = "y:"; }
            if (control.Name == "lbl_Z") { lbl_X.Text = "z:"; }
            if (control.Name == "lbl_L") { lbl_X.Text = "Level:"; }

            foreach (Control ctrl in control.Controls)
            {
                if (ctrl != null)
                    ResetForm(ctrl);
                else
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK) { return; }

            string FileName = saveFileDialog.FileName;
            if (ds.Tables[0].Rows.Count > 0)
                ds.Tables[0].WriteXml(FileName, XmlWriteMode.IgnoreSchema);
            else { MessageBox.Show("No Data Writen, Your Cargo Table is Empty!"); }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) != DialogResult.OK) { return; }
            
            string FileName = openFileDialog.FileName;
            ds.Tables[0].Clear();
            ds.Tables[0].ReadXml(FileName);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string _capturID = "";
            DataRow r; // = new DataTable() { }.NewRow();
            DataGridViewRow row = dataGridView1.CurrentRow;

            if ((row.Cells["ID"].Value) != null)
            { _capturID = row.Cells["ID"].Value.ToString(); }

            if (dt.AsEnumerable().Where(x => x.Field<string>("ID") == _capturID).Any())
            {
                r = dt.AsEnumerable().Where(x => // Get the selected row from table
                        x.Field<string>("ID") == _capturID).FirstOrDefault();
            }
            else { r = dt.NewRow(); }

            var _tmp1 = r.Field<string>("Name"); txtName.Text = (_tmp1 == null)? string.Empty : _tmp1;
            var _tmp2 = r.Field<object>("Long"); numLong.Value = (_tmp2 == null) ? 0.0m : decimal.Parse(_tmp2.ToString());
            var _tmp3 = r.Field<object>("Height"); numHeight.Value = (_tmp3 == null) ? 0.0m : decimal.Parse(_tmp3.ToString());
            var _tmp4 = r.Field<object>("Width"); numWidth.Value = (_tmp4 == null) ? 0.0m : decimal.Parse(_tmp4.ToString());
            var _tmp5 = r.Field<object>("Level"); numLevel.Value = (_tmp5 == null) ? 0 : int.Parse(_tmp5.ToString());
            var _tmp6 = r.Field<object>("Weight"); numWeight.Value = (_tmp6 == null) ? 0.0m : decimal.Parse(_tmp6.ToString());
            // CBM Ignored from table.
            var _tmp7 = r.Field<string>("Color"); txtColor.Text = (_tmp7 == null) ? string.Empty : (string)_tmp7;

            dataGridView1.DataSource = ds.Tables[0];
        }

        #region NumericFilters
        private void numLong_ValueChanged(object sender, EventArgs e)
        {
            lbl_X.Text = "x: " + numLong.Value.ToString();
        }

        private void numHeight_ValueChanged(object sender, EventArgs e)
        {
            lbl_Y.Text = "y: " + numHeight.Value.ToString();
        }

        private void numWidth_ValueChanged(object sender, EventArgs e)
        {
            lbl_Z.Text = "z: " + numWidth.Value.ToString();
        }

        private void numLevel_ValueChanged(object sender, EventArgs e)
        {
            lbl_L.Text = "Level: " + numLevel.Value.ToString();
        }

        private void numWeight_ValueChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
