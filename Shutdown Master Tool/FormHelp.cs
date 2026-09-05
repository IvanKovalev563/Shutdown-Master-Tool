using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shutdown_Master_Tool
{
    public partial class FormHelp : Form
    {
        public FormHelp()
        {
            InitializeComponent();
            if(Properties.Settings.Default.language == "ru")
            {
                picturebBoxScreenshot.Image = Properties.Resources.screenshot_ru;
                labelHelp1.Text = "1) Выберите режим завершения работы";
                labelHelp2.Text = "2) Установите таймер перед выключением.\r\n";
                labelHelp3.Text = "3) Нажмите кнопку запуска выключения. \r\nПри нужде отменить выключение - нажмите на неё повторно.";
            }
            else
            {
                picturebBoxScreenshot.Image = Properties.Resources.screenshot_en;
                labelHelp1.Text = "1) Select shutdown mode";
                labelHelp2.Text = "2) Set the timer before shutdown.\r\n";
                labelHelp3.Text = "3) Press the shutdown start button. \r\nIf you need to cancel the shutdown - press it again.";
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
