using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormsTemplate.Utilities;

namespace WinFormsTemplate.UI
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
        }

        private void AboutDialog_Load(object sender, EventArgs e)
        {
            this.Text = "About " + Application.ProductName;

            Icon icoSource = Properties.Resources.AppIcon;
            Icon ico64 = new Icon(icoSource, 64, 64);
            this.pictureBoxIcon.Image = ico64.ToBitmap();

            label1.Text = Application.ProductName + " - " + "Version " + AssemblyInfoHelper.GetMajorDotMinorVersion();
            label2.Text = AssemblyInfoHelper.GetCopyright();

            this.buttonOK.Left = (this.ClientSize.Width - buttonOK.Width) / 2;
        }

        private void label3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.label3.LinkVisited = true;

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
             {
                FileName = "https://www.perbal.net/home/",
                UseShellExecute = true
             });
        }
    }
}
