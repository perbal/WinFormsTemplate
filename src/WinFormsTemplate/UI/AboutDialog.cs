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
        static Icon icon;

        public AboutDialog()
        {
            InitializeComponent();
        }

        private void AboutDialog_Load(object sender, EventArgs e)
        {
            this.Text = "About " + Application.ProductName;

            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
            icon = new Icon((System.Drawing.Icon)(resources.GetObject("$this.Icon")), 64, 64);


            label1.Text = Application.ProductName + " - " + "Version " + AssemblyInfoHelper.GetMajorDotMinorVersion();
            label2.Text = AssemblyInfoHelper.GetCopyright();

            this.buttonOK.Location = new Point((this.Width - buttonOK.Width) / 2, buttonOK.Location.Y);
        }

        private void AboutDialog_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = icon.ToBitmap();
            this.pictureBoxIcon.Image = (Image)bmp;
        }

        private void label3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.label3.LinkVisited = true;
            System.Diagnostics.Process.Start("https://www.perbal.net/home/");
        }
    }
}
