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
using System.Web;
using System.Windows.Forms;

namespace Shutdown_Master
{
    public partial class FormMain : Form
    {
        string btnText;
        string[] domainElements = new string[60 * 60];
        bool isShutdowning = false;
        int timerSeconds = 0;

        public string verFormat()
        {
            string buildDate = "151225-2";
            string verString;
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            if(version.Major > 0)
            {
                verString = $"v{version.Major}.{version.Minor}.{version.Build}";
            }
            else
            {
                verString = $"v{version.ToString()} build {buildDate}";
            }
            return verString;
        }

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

        public void systemShutdownOrReboot(char mode, int time)
        {
            if (isShutdowning)
            {
                Process.Start("shutdown", $"/a");
                isShutdowning = false;
                timer.Enabled = false;
                progressBar.Value = 0;
                progressBar.Enabled = false;
                labelTimer.Text = "";
                comboBoxModes_SelectedIndexChanged(null, null);
            }
            else
            {
                Process.Start("shutdown", $"/{mode} /t {time}");
                isShutdowning = true;
                progressBar.Maximum = time;
                timerSeconds = time;
                timer.Enabled = true;
                progressBar.Enabled = true;
            }
        }

        public FormMain()
        {
            InitializeComponent();
            fillDomainElements();
            comboBoxModes.SelectedIndex = Properties.Settings.Default.mode;
            labelVersion.Text = verFormat();
            labelTimer.Text = "";
            progressBar.Enabled = false;
            comboBoxModes_SelectedIndexChanged(null, null);
        }

        private void comboBoxModes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnText = comboBoxModes.SelectedItem.ToString();
            switch (comboBoxModes.SelectedIndex)
            {
                case 0: buttonApply.Text = "Завершить работу"; break;
                case 1: buttonApply.Text = "Перезагрузить"; break;
                default: buttonApply.Text = "Error"; break;
            }
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
            string timerHeader;
            switch (comboBoxModes.SelectedIndex)
            {
                case 0: timerHeader = "До завершения работы: "; break;
                case 1: timerHeader = "До перезагрузки: "; break;
                default: timerHeader = "Error: "; break;
            }
            labelTimer.Text = timerHeader + domainElements[timerSeconds];
            progressBar.Value++;
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
            systemShutdownOrReboot(mode, time);
        }
    }
}
