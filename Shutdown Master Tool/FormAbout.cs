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
            
            if(Properties.Settings.Default.language == "ru")
            {
                labelNameAndVer.Text = $"Shutdown Master Tool\nv{ver.Major}.{ver.Minor}.{ver.Build}.{ver.Revision} (сборка {Properties.Settings.Default.build})";
                labelCopyright.Text = "© Ivan Kovalev, 2025. Все права защищены.";
            }
            else
            {
                labelNameAndVer.Text = $"Shutdown Master Tool\nv{ver.Major}.{ver.Minor}.{ver.Build}.{ver.Revision} (build {Properties.Settings.Default.build})";
                labelCopyright.Text = "© Ivan Kovalev, 2025-2026. All rights reserved.";
            }

            this.Width = 714;
            this.Height = 350;
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
