using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormsTemplate.Core;

namespace WinFormsTemplate.UI
{
    public partial class MainForm : Form
    {
        private readonly string sPrefsX = "X";
        private readonly string sPrefsY = "Y";
        private readonly string sPrefsWidth = "Width";
        private readonly string sPrefsHeight = "Height";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ApplicationLoadPrefs();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ApplicationSavePrefs();
        }

        private void ApplicationLoadPrefs()
        {
            int iX;
            int iY;
            int iMargin = 40;
            Rectangle rectWorkingArea = Screen.PrimaryScreen.WorkingArea;

            iX = ApplicationPreference.GetInt(sPrefsX, this.Location.X);
            if (iX < 0) iX = 0;
            else if (iX > rectWorkingArea.Width) iX = rectWorkingArea.Width - iMargin;

            iY = ApplicationPreference.GetInt(sPrefsY, this.Location.Y);
            if (iY < 0) iY = 0;
            else if (iY > rectWorkingArea.Height) iY = rectWorkingArea.Height - iMargin;

            this.Location = new Point(iX, iY);

            iX = ApplicationPreference.GetInt(sPrefsWidth, this.Size.Width);
            iY = ApplicationPreference.GetInt(sPrefsHeight, this.Size.Height);

            this.Size = new Size(iX, iY);
        }

        private void ApplicationSavePrefs()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                ApplicationPreference.SetInt(sPrefsX, this.Location.X);
                ApplicationPreference.SetInt(sPrefsY, this.Location.Y);
                ApplicationPreference.SetInt(sPrefsWidth, this.Size.Width);
                ApplicationPreference.SetInt(sPrefsHeight, this.Size.Height);
            }
        }
    }
}
