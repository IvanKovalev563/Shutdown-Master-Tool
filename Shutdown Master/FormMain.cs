using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shutdown_Master
{
    public partial class FormMain : Form
    {
        void cmd()
        {

        }

        string[] appModes = { "Завершение работы", "Перезагрузка" };
        public FormMain()
        {
            InitializeComponent();
            comboBoxModes.DataSource = appModes;
        }
    }
}
