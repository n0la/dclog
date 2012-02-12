using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace dclog
{
    public partial class WaitBox : Form
    {
        public WaitBox()
        {
            InitializeComponent();
        }

        public string InfoText
        {
            get { return text.Text; }
            set { text.Text = value; }
        }

        private void WaitBox_Load(object sender, EventArgs e)
        {

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
