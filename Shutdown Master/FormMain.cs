using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shutdown_Master
{
    public partial class FormMain : Form
    {
        public string[] domainElements = new string[60*60];
        string[] appModes = { "Завершение работы", "Перезагрузка" };

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
            
            for (int i = 60*60; i > 0; i--)
            {
                domainUpDown_Time.Items.Add(domainElements[i-1]);
            }
            domainUpDown_Time.SelectedIndex = 60*60-1;
        }

        public static void сmd(string line)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd",
                Arguments = "/c " + line,
                WindowStyle = ProcessWindowStyle.Hidden
            });
        }

        public FormMain()
        {
            InitializeComponent();
            fillDomainElements();
            comboBoxModes.DataSource = appModes;

        }
    }
}
