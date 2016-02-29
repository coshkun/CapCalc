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
    public partial class frmImageTip : Form
    {
        // Image _image = null;
        private Control _sender;

        public Image Image
        {
            get { return pBoxImage.Image; }
            set { pBoxImage.Image = value; }
        }

        public frmImageTip(Control sender)
        {
            InitializeComponent();
             _sender = sender;
        }

        private void frmImageTip_Load(object sender, EventArgs e)
        {
            //pBoxImage.Image = _image;
            // Get the Screen Position of that animal on the first shown
            this.Location = new Point(_sender.PointToScreen(Point.Empty).X - (this.Width - _sender.Width),
                                                 _sender.PointToScreen(Point.Empty).Y + 25);
            this.Refresh();
        }
    }
}
