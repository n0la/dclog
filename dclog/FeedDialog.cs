using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace dclog
{
  public partial class FeedDialog : Form
  {
    private string[] lines = null;

    public string[] Lines { get { return lines; } }

    public FeedDialog()
    {
      InitializeComponent();
    }

    private void okay_Click(object sender, EventArgs e)
    {
      lines = Regex.Split(combatlog.Text, "\r\n");
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void cancel_Click(object sender, EventArgs e)
    {
    }
  }
}
