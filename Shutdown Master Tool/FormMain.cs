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

namespace Shutdown_Master_Tool
{
    public partial class FormMain : Form
    {
        string btnText;
        string[] domainElements = new string[60 * 60];
        bool isShutdowning = false;
        int timerSeconds = 0;
        string timerHeader;

        public string verFormat()
        {
            string buildDate = "160126"; // ДАТА БИЛДА   Формат: [ДДММГГ]
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
            Properties.Settings.Default.build = buildDate;
            Properties.Settings.Default.Save();
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
                progressBar.Value = 0;
                progressBar.Enabled = false;
                labelTimer.Text = "";
                comboBoxModes_SelectedIndexChanged(null, null);
                comboBoxModes.Enabled = true;
                domainUpDown_Time.Enabled = true;
                timer.Stop();
            }
            else
            {
                Process.Start("shutdown", $"/{mode} /t {time}");
                buttonApply.Text = "Отмена";
                isShutdowning = true;
                progressBar.Maximum = time*100;
                timerSeconds = time;
                progressBar.Enabled = true;
                comboBoxModes.Enabled = false;
                domainUpDown_Time.Enabled = false;
                switch (comboBoxModes.SelectedIndex)
                {
                    case 0: timerHeader = "До завершения работы: "; break;
                    case 1: timerHeader = "До перезагрузки: "; break;
                    default: timerHeader = "Error: "; break;
                }
                timer.Start();
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
            timer.Stop();

            toolTip.SetToolTip(comboBoxModes, "Режим завершения работы");
            toolTip.SetToolTip(domainUpDown_Time, "Задержка завершения работы");
            toolTip.SetToolTip(buttonApply, "Запуск отсчета до завершения работы");
            toolTip.SetToolTip(progressBar, "Оставшееся время до завершения работы");
            toolTip.SetToolTip(labelTimer, "Оставшееся время до завершения работы");
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
            timerSeconds--;
            if (timerSeconds > -1)
            {
                int minutes = timerSeconds / 60;
                int seconds = timerSeconds % 60;
                labelTimer.Text = $"{timerHeader}{minutes:00}:{seconds:00}";
                progressBar.Value++;
                while(progressBar.Value % 100 != 0)
                {
                    progressBar.Value++;
                }
            }
            else
            {
                timer.Stop();
            }
        }
        
        private void buttonApply_Click(object sender, EventArgs e)
        {
            int time = Array.IndexOf(domainElements ,domainUpDown_Time.SelectedItem) + 1;
            char mode = 's';
            switch (comboBoxModes.SelectedIndex)
            {
                case 0: mode = 's'; break;
                case 1: mode = 'r'; break;
                default: mode = 's'; break;
            }
            systemShutdownOrReboot(mode, time);
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHelp formHelp = new FormHelp();
            formHelp.ShowDialog();
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isShutdowning)
            {
                Process.Start("shutdown", $"/a");
            }
        }
    }
}
