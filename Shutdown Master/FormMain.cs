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
        public string[] domainElements = new string[60*60];

        void fillDomainElements()
        {
            int counter = 0;
            for (int i = -1; i < 59; i++)
            {
                for (int j = -1; j < 59; j++)
                {
                    domainElements[counter] = (i+1) + " минут " + (j+1) + " секунд";
                    counter++;
                }
            }
            
            for (int i = 60*60; i > 15; i--)
            {
                domainUpDown_Time.Items.Add(domainElements[i-1]);
            }
            domainUpDown_Time.SelectedIndex = Properties.Settings.Default.time;
        }

        public static void cmdShutdownCommands(char mode, int time)
        {
            Process.Start("shutdown", $"{mode} /t {time} /f");
        }

        public FormMain()
        {
            InitializeComponent();
            fillDomainElements();
            comboBoxModes.SelectedIndex = Properties.Settings.Default.mode;
            string ver = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            labelVersion.Text = "v" + ver.Substring(0, ver.Length - 1) + "131225";
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
    }
}
