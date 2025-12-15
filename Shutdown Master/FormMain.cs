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
        string[] domainElements = new string[60 * 60];
        bool isShutdowning = false;
        int timerSeconds = 0;

        public void fillDomainElements()
        {
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
                timer.Enabled = false;
            }
            else
            {
                Process.Start("shutdown", $"/{mode} /t {time}");
                isShutdowning = true;
                progressBar.Maximum = time;
                timerSeconds = time;
                timer.Enabled = true;
            }
        }

        public FormMain()
        {
            InitializeComponent();
            fillDomainElements();
            comboBoxModes.SelectedIndex = Properties.Settings.Default.mode;
            labelVersion.Text = $"v{Assembly.GetExecutingAssembly().GetName().Version.ToString()} build {151225}";
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
            timerSeconds--;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            int time = Array.IndexOf(domainElements ,domainUpDown_Time.SelectedItem) + 1;
            char mode;
            switch (comboBoxModes.SelectedIndex)
            {
                case 0: mode = 's'; break;
                case 1: mode = 'r'; break;
                default: mode = 's'; break;
            }

            shutdown(mode, time);
        }
    }
}
