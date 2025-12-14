using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shutdown_Master
{
    public partial class FormMain : Form
    {
        public bool isShutdowning = false;

        public void fillDomainElements()
        {
            string[] domainElements = new string[60 * 60];
            domainUpDown_Time.Items.Clear();
            int counter = 0;
            for (int i = -1; i < 59; i++)
            {
                for (int j = -1; j < 59; j++)
                {
                    domainElements[counter] = (i + 1) + " минут " + (j + 1) + " секунд";
                    counter++;
                }
            }

            for (int i = 60 * 60; i > 15; i--)
            {
                domainUpDown_Time.Items.Add(domainElements[i - 1]);
            }
            domainUpDown_Time.SelectedIndex = Properties.Settings.Default.time;
        }

        public void shutdown(char mode, int time)
        {
            if (isShutdowning)
            {
                Process.Start("shutdown", $"/a");
                isShutdowning = false;
            }
            else
            {
                Process.Start("shutdown", $"{mode} /t {time}");
                isShutdowning = true;
                progressBar.Maximum = time;
            }
        }

        public FormMain()
        {
            InitializeComponent();
            fillDomainElements();
            comboBoxModes.SelectedIndex = Properties.Settings.Default.mode;
            labelVersion.Text = $"v{Assembly.GetExecutingAssembly().GetName().Version.ToString()} build {141225}";
            labelTimer.Text = "";
            labelTimer.Enabled = false;
            progressBar.Enabled = false;
        }

        private void comboBoxModes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.mode = comboBoxModes.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void domainUpDown_Time_SelectedItemChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.time = domainUpDown_Time.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
