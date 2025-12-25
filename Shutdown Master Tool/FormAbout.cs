using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shutdown_Master_Tool
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
            Version ver = Assembly.GetExecutingAssembly().GetName().Version;
            labelNameAndVer.Text = $"Shutdown Master Tool\nv{ver.Major}.{ver.Minor}.{ver.Build}.{ver.Revision} (build {Properties.Settings.Default.build})";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/IvanKovalev563");
        }
    }
}
