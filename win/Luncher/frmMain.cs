using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

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
        private frmImageTip frmOffsetHelper;


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

            // initialize the shematic in accordance of platform
            string rslt = GetOSFriendlyName();
            if (rslt.Contains("Windows 10")) { pBox.Image = Properties.Resources.cargo_picker_w10; }

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
            Konteyners.Add(new ContainerInfo("13.6 Semitrailer", 1360, 280, 240, 22000));
            cmbConSelector.DataSource = Konteyners.ToArray();
            cmbConSelector.DisplayMember = "Name";
            // var usage = ((ContainerInfo)cmbConSelector.SelectedValue).CBM;

            // Create ToolTip Handler
            InfoTips.ToolTipIcon = ToolTipIcon.Info;
            InfoTips.ToolTipTitle = "Info:";
            InfoTips.SetToolTip(cmbConSelector, summary);

            // Fill the Offset Selector
            cmbOffset.Items.Add(@"Top Left"); cmbOffset.Items.Add(@"Top Center"); cmbOffset.Items.Add(@"Top Right");
            cmbOffset.Items.Add(@"Middle Left"); cmbOffset.Items.Add(@"Middle Center"); cmbOffset.Items.Add(@"Middle Right");
            cmbOffset.Items.Add(@"Bottom Left"); cmbOffset.Items.Add(@"Bottom Center"); cmbOffset.Items.Add(@"Bottom Right");
            // initialize an instance of Selector Helper
            frmOffsetHelper = new frmImageTip(cmbOffset);
            frmOffsetHelper.Image = new Bitmap(Properties.Resources.go_none);
            cmbOffset.SelectedItem = @"Middle Left";

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
            /* ***********************************
             * CAPCALC ALGORITHYM achieved by Rectgangels 
             * to hold the cargo size and positions in its container
             * 
             * Not:
             * the space property of CargoInfo class uses System.Drawing.Rectangel item
             * to hold the position and floor area of cargo. Pls, take attention while you
             * assigning new values as;
             * 
             * Cargo.Space = new Rectangle(x,y, m,n);
             * x => Left of Cargo in Container space
             * y => Top of Cargo in Container space
             * m => is the Long  (x dimention of cargo floor area while you look from top)
             * n => is the Width (y dimention of cargo floor area while you look from top)
             * 
             * *********************************** */
            var secim = (ContainerInfo)cmbConSelector.SelectedItem;
            ContainerMatrix Ambar = new ContainerMatrix(secim);

            CargoInfo[] Kargolar;
            // Create the cargo list and sort them.
            if (ds.Tables[0].Rows.Count > 0)
            {
                Kargolar = new CargoInfo[ds.Tables[0].Rows.Count]; // size the cargo list
                // Read the cargoes from data table
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var crg = new CargoInfo();
                    crg.Name = ds.Tables[0].Rows[i].Field<string>("Name");
                    crg.Long = ds.Tables[0].Rows[i].Field<double>("Long");
                    crg.Width = ds.Tables[0].Rows[i].Field<double>("Width");
                    crg.Height = ds.Tables[0].Rows[i].Field<double>("Height");
                    crg.Weight = ds.Tables[0].Rows[i].Field<double>("Weight");
                    crg.Level  = ds.Tables[0].Rows[i].Field<int>("Level");

                    Kargolar[i] = crg;
                }

                // Now Sort a copy of them based on CBM
                object[] sort = new object[Kargolar.Length];
                for (int i = 0; i < sort.Length; i++)
                {
                    sort[i] = Kargolar[i];
                }

                Helper.QuickSort(ref sort, "CBM");
                
                // Now check the Gravity Offset to start writing in container
                // (do that later, lets say "Top Left" for now)

                for (int i = sort.Length -1 ; i >= 0; i--)  // Big to Small
                {
                    CargoInfo crg = (CargoInfo)sort[i];
                    if (Ambar.StartIndexes.Count > 0)
                    {
                        Ambar.AddCargo(crg, Ambar.CurrentIndex);
                    }
                }

                // Try to take a snapshot for debug purpose
                DebuggerDisplay(Ambar); //shows loaded areas on selected cargo container matrix
            }
        }

        private void DebuggerDisplay(ContainerMatrix CargoHold)
        {
            // Try to take a snapshot for debug purpose
            Image image = (Image)(new Bitmap(CargoHold.Space.Height, CargoHold.Space.Width));

            using (Graphics g = Graphics.FromImage(image))
            {
                // Modify the image using g here... 
                // Create a brush with an alpha value and use the g.FillRectangle function
                Color customColor = Color.FromArgb(75, Color.Green);
                Color indexColor = Color.FromArgb(100, Color.Red);
                SolidBrush shadowBrush = new SolidBrush(customColor);
                SolidBrush indexBrush = new SolidBrush(indexColor);
                g.Clear(Color.DarkGray);
                for (int i = 0; i < CargoHold.Space.Width - 1; i++)
                {
                    for (int j = 0; j < CargoHold.Space.Height - 1; j++)
                    {
                        var rec = new Rectangle(i, j, 1, 1);

                        if (CargoHold.Data[i, j].IsLoaded)
                        {
                            g.DrawRectangle(Pens.White, i * 10, j * 10, 10, 10);
                            g.FillRectangles(shadowBrush, new RectangleF[] { rec });
                        }
                        if (CargoHold.Data[i, j].StartIndex)
                        {
                            var rec2 = new RectangleF((float)i, (float)j, 4f, 4f);
                            g.FillRectangles(indexBrush, new RectangleF[] { rec2 });
                        }
                        // if (i == 0 && j == 500) { System.Diagnostics.Debugger.Break(); }
                    }
                }
            }
            // Now display it
            var Disp = new Form();
            var pb = new PictureBox() { }; // Image = image, Dock = DockStyle.Fill, Parent = Disp
            pb.Image = image; pb.Dock = DockStyle.Fill; pb.Parent = Disp;
            pb.Size = new Size(CargoHold.Space.Height, CargoHold.Space.Width);
            Disp.Size = new Size(CargoHold.Space.Height, CargoHold.Space.Width);
            Disp.BackColor = ColorTranslator.FromHtml("#ff333333");
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            Disp.Controls.Add(pb);
            Disp.Show();
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
            numLong.Maximum = (decimal)((ContainerInfo)cmbConSelector.SelectedValue).Long;
            numHeight.Maximum = (decimal)((ContainerInfo)cmbConSelector.SelectedValue).Height;
            numWidth.Maximum = (decimal)((ContainerInfo)cmbConSelector.SelectedValue).Width;
            numWeight.Maximum = (decimal)((ContainerInfo)cmbConSelector.SelectedValue).Weight;

            summary = "Long: " + (((ContainerInfo)cmbConSelector.SelectedValue).Long / 100).ToString() + "m \n"
                            + "Height: " + (((ContainerInfo)cmbConSelector.SelectedValue).Height / 100).ToString() + "m \n"
                            + "Width: " + (((ContainerInfo)cmbConSelector.SelectedValue).Width / 100).ToString() + "m \n"
                            + "Capacity: " + (((ContainerInfo)cmbConSelector.SelectedValue).CBM / 1000000).ToString() + "m3 \n"
                            + "Payload: " + (((ContainerInfo)cmbConSelector.SelectedValue).Weight / 1000).ToString() + " tons";
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
                MessageBox.Show("There is a matching cargo with same name. Your new entry will be added by " 
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

        public static string GetOSFriendlyName()
        {
            string result = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (ManagementObject os in searcher.Get())
            {
                result = os["Caption"].ToString();
                break;
            }
            return result;
        }

        private void cmbOffset_MouseEnter(object sender, EventArgs e)
        {
            frmOffsetHelper.Location = new Point(cmbOffset.PointToScreen(Point.Empty).X - (frmOffsetHelper.Width - cmbOffset.Width),
                                                             cmbOffset.PointToScreen(Point.Empty).Y + 25);
            frmOffsetHelper.Show();
        }

        private void cmbOffset_MouseLeave(object sender, EventArgs e)
        {
            frmOffsetHelper.Hide();
        }

        private void cmbOffset_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((string)cmbOffset.SelectedItem)
            {
                case "":
                    frmOffsetHelper.Image = Properties.Resources.go_none;
                    break;
                case "Top Left":
                    frmOffsetHelper.Image = Properties.Resources.go_top_left;
                    break;
                case "Top Center":
                    frmOffsetHelper.Image = Properties.Resources.go_top_center;
                    break;
                case "Top Right":
                    frmOffsetHelper.Image = Properties.Resources.go_top_right;
                    break;
                case "Middle Left":
                    frmOffsetHelper.Image = Properties.Resources.go_middle_left;
                    break;
                case "Middle Center":
                    frmOffsetHelper.Image = Properties.Resources.go_middle_center;
                    break;
                case "Middle Right":
                    frmOffsetHelper.Image = Properties.Resources.go_middle_right;
                    break;
                case "Bottom Left":
                    frmOffsetHelper.Image = Properties.Resources.go_bottom_left;
                    break;
                case "Bottom Center":
                    frmOffsetHelper.Image = Properties.Resources.go_bottom_center;
                    break;
                case "Bottom Right":
                    frmOffsetHelper.Image = Properties.Resources.go_bottom_right;
                    break;
                default:
                    frmOffsetHelper.Image = Properties.Resources.go_none;
                    break;
            }
        }
    }
}
