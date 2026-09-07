using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.IO;

namespace Shutdown_Master_Tool
{
    public partial class FormMain : Form
    {
        string btnText;
        string[] domainElements = new string[60 * 60];
        bool isShutdowning = false;
        bool isBiosMode = false;
        int timerSeconds = 0;
        string timerHeader;

        public void setLanguage()
        {
            if (Properties.Settings.Default.language == "ru")
            {
                menuStrip.Items[0].Text = "Справка";
                menuStrip.Items[1].Text = "Язык";
                помощьToolStripMenuItem.Text = "Помощь";
                опрограммеToolStripMenuItem.Text = "О программе";
                labelDelay.Text = "Задержка (мин/сек):";
                comboBoxModes.Items[0] = "Завершение работы";
                comboBoxModes.Items[1] = "Перезагрузка";
                try { comboBoxModes.Items[2] = "Перезагрузка в BIOS"; }
                catch { }


                toolTip.SetToolTip(comboBoxModes, "Режим завершения работы");
                toolTip.SetToolTip(domainUpDown_Time, "Задержка завершения работы");
                toolTip.SetToolTip(buttonApply, "Запуск отсчета до завершения работы");
                toolTip.SetToolTip(progressBar, "Оставшееся время до завершения работы");
                toolTip.SetToolTip(labelTimer, "Оставшееся время до завершения работы");
            }
            else if (Properties.Settings.Default.language == "en")
            {
                menuStrip.Items[0].Text = "Help";
                menuStrip.Items[1].Text = "Language";
                помощьToolStripMenuItem.Text = "Help";
                опрограммеToolStripMenuItem.Text = "About";
                labelDelay.Text = "Delay (min/sec):";
                comboBoxModes.Items[0] = "Shutdown";
                comboBoxModes.Items[1] = "Reboot";
                try { comboBoxModes.Items[2] = "Reboot to BIOS"; } 
                catch { }

                toolTip.SetToolTip(comboBoxModes, "Shutdown mode");
                toolTip.SetToolTip(domainUpDown_Time, "Shutdown delay");
                toolTip.SetToolTip(buttonApply, "Start countdown to shutdown");
                toolTip.SetToolTip(progressBar, "Remaining time until shutdown");
                toolTip.SetToolTip(labelTimer, "Remaining time until shutdown");
            }
            labelVersion.Text = verFormat();
            fillDomainElements();
        }

        public string verFormat()
        {
            string buildDate = "070926"; // BUILD DATE    Format: [DDMMYY]
            string verString;
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            if(version.Major > 0)
            {
                verString = $"v{version.Major}.{version.Minor}.{version.Build}";
            }
            else
            {
                if(Properties.Settings.Default.language == "ru")
                {
                    verString = $"v{version.ToString()} сборка {buildDate}";
                }
                else
                {
                    verString = $"v{version.ToString()} build {buildDate}";
                }
            }
            Properties.Settings.Default.build = buildDate;
            Properties.Settings.Default.Save();
            return verString;
        }

        public void fillDomainElements() // Fill the domainUpDown_Time with time options
        {
            domainUpDown_Time.Items.Clear();
            int counter = 0;
            for (int i = -1; i < 59; i++)
            {
                for (int j = -1; j < 59; j++)
                {
                    if(Properties.Settings.Default.language == "ru")
                    {
                        domainElements[counter] = $"{i + 1} мин {j + 1} сек";
                    }
                    else
                    {
                        domainElements[counter] = $"{i + 1} min {j + 1} sec";
                    }
                    counter++;
                }
            }

            for (int i = 60 * 60; i > 15; i--)
            {
                domainUpDown_Time.Items.Add(domainElements[i - 1]);
            }

            int currentIndex = Properties.Settings.Default.time;
            if (currentIndex >= 0 && currentIndex < domainUpDown_Time.Items.Count)
            {
                domainUpDown_Time.SelectedIndex = -1;
                domainUpDown_Time.SelectedIndex = currentIndex;
            }
            else
            {
                domainUpDown_Time.SelectedIndex = 0;
            }
        }

        public void systemShutdownOrReboot(char mode, int time)
        {
            if (isShutdowning) // Cancel the shutdown/reboot if already in progress
            {
                if (isBiosMode)
                {
                    timer.Stop();
                    isShutdowning = false;
                    isBiosMode = false;
                    progressBar.Value = 0;
                    progressBar.Enabled = false;
                    labelTimer.Text = "";
                    comboBoxModes.Enabled = true;
                    domainUpDown_Time.Enabled = true;
                    comboBoxModes_SelectedIndexChanged(null, null);
                }
                else
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
                return;
            }

            isBiosMode = (mode == 'b');
            comboBoxModes.Enabled = false;
            domainUpDown_Time.Enabled = false;
            progressBar.Enabled = true;
            progressBar.Maximum = time * 100;
            timerSeconds = time;
            isShutdowning = true;

            if (isBiosMode) // If the mode is BIOS reboot, just start the timer
            {
                timerHeader = Properties.Settings.Default.language == "ru" ? "До перезагрузки в BIOS: " : "Until reboot to BIOS: ";
                timer.Start();
                buttonApply.Text = Properties.Settings.Default.language == "ru" ? "Отмена" : "Cancel";
            }
            else // If the mode is shutdown or reboot, execute the shutdown command
            {
                Process.Start("shutdown", $"/{mode} /t {time}");

                if (Properties.Settings.Default.language == "ru")
                {
                    switch (mode)
                    {
                        case 's': timerHeader = "До завершения работы: "; break;
                        case 'r': timerHeader = "До перезагрузки: "; break;
                        default: timerHeader = "Ошибка: "; break;
                    }
                }
                else
                {
                    switch (mode)
                    {
                        case 's': timerHeader = "Remaining until shutdown: "; break;
                        case 'r': timerHeader = "Remaining until reboot: "; break;
                        default: timerHeader = "Error: "; break;
                    }
                }
                timer.Start();
                buttonApply.Text = Properties.Settings.Default.language == "ru" ? "Отмена" : "Cancel";
            }
        }

        public void checkUefiSupport()
        {
            if (!FirmwareHelper.IsUefiSupported())
            {
                comboBoxModes.Items.RemoveAt(2); // Remove "Reboot" option if UEFI is not supported
            }
        }

        public FormMain()
        {
            InitializeComponent();
            fillDomainElements();
            checkUefiSupport();
            try { comboBoxModes.SelectedIndex = Properties.Settings.Default.mode; }
            catch { comboBoxModes.SelectedIndex = 0; }
            labelVersion.Text = verFormat();
            labelTimer.Text = "";
            progressBar.Enabled = false;
            comboBoxModes_SelectedIndexChanged(null, null);
            timer.Stop();

            if(Properties.Settings.Default.language == "ru")
            {
                языкLanguageToolStripMenuItem.SelectedIndex = 1;
            }
            else
            {
                языкLanguageToolStripMenuItem.SelectedIndex = 0;
            }
            setLanguage();
        }

        private void comboBoxModes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnText = comboBoxModes.SelectedItem.ToString();
            if(Properties.Settings.Default.language == "ru")
            {
                switch (comboBoxModes.SelectedIndex)
                {
                    case 0: buttonApply.Text = "Завершить работу"; break;
                    case 1: buttonApply.Text = "Перезагрузить"; break;
                    case 2: buttonApply.Text = "Перезагрузить в BIOS"; break;
                    default: buttonApply.Text = "Ошибка"; break;
                }
            }
            else
            {
                switch (comboBoxModes.SelectedIndex)
                {
                    case 0: buttonApply.Text = "Shutdown"; break;
                    case 1: buttonApply.Text = "Reboot"; break;
                    case 2: buttonApply.Text = "Reboot to BIOS"; break;
                    default: buttonApply.Text = "Error"; break;
                }
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
                while (progressBar.Value % 100 != 0)
                {
                    progressBar.Value++;
                }
            }
            else
            {
                timer.Stop();
                if (isBiosMode)
                {
                    Process.Start("shutdown", "/r /fw /t 0");
                    isShutdowning = false;
                    isBiosMode = false;
                    progressBar.Value = 0;
                    progressBar.Enabled = false;
                    labelTimer.Text = "";
                    comboBoxModes.Enabled = true;
                    domainUpDown_Time.Enabled = true;
                    comboBoxModes_SelectedIndexChanged(null, null);
                }
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBoxModes.SelectedIndex;

            if (selectedIndex == 2) // Admin check for BIOS reboot
            {
                bool isAdmin = false;
                try
                {
                    WindowsIdentity identity = WindowsIdentity.GetCurrent();
                    WindowsPrincipal principal = new WindowsPrincipal(identity);
                    isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
                }
                catch { }

                if (!isAdmin)
                {
                    string msg = Properties.Settings.Default.language == "ru"
                        ? "Для перезагрузки в BIOS требуется запуск программы от имени администратора."
                        : "Reboot to BIOS requires running the program as administrator.";
                    MessageBox.Show(msg, "Ошибка / Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string confirmMsg = Properties.Settings.Default.language == "ru"
                    ? "Вы действительно хотите перезагрузить компьютер в BIOS/UEFI?\n\nЭта функция доступна только на системах с UEFI."
                    : "Are you sure you want to reboot into BIOS/UEFI?\n\nThis function is only available on UEFI systems.";
                DialogResult result = MessageBox.Show(confirmMsg, "Подтверждение / Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes)
                    return;
            }

            int time = Array.IndexOf(domainElements, domainUpDown_Time.SelectedItem) + 1;
            char mode;
            if (selectedIndex == 2)
                mode = 'b';
            else
                mode = (selectedIndex == 1) ? 'r' : 's';

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
                if (isBiosMode)
                {
                    // If BIOS mode is active, stop the timer and reset the state
                    timer.Stop();
                    isShutdowning = false;
                    isBiosMode = false;
                }
                else
                {
                    Process.Start("shutdown", $"/a");
                }
            }
        }

        private void языкLanguageToolStripMenuItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (языкLanguageToolStripMenuItem.SelectedIndex == 0)
            {
                Properties.Settings.Default.language = "en";
                Properties.Settings.Default.Save();
            }
            else if (языкLanguageToolStripMenuItem.SelectedIndex == 1)
            {
                Properties.Settings.Default.language = "ru";
                Properties.Settings.Default.Save();
            }
            setLanguage();
        }
    }

    public static class FirmwareHelper
    {
        // FirmwareType enumeration to represent the firmware type
        private enum FirmwareType
        {
            Unknown = 0,
            Bios = 1,
            Uefi = 2,
            Max = 3
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetFirmwareType(ref FirmwareType firmwareType);

        public static bool IsUefiSupported()
        {
            try
            {
                FirmwareType firmwareType = FirmwareType.Unknown;
                if (GetFirmwareType(ref firmwareType))
                {
                    return firmwareType == FirmwareType.Uefi;
                }
                return false; // If the function fails, assume UEFI is not supported
            }
            catch
            {
                return false; // In case of any exception, assume UEFI is not supported
            }
        }
    }
}
