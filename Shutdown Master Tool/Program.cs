using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shutdown_Master_Tool
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        private static Mutex _mutex = new Mutex(true, "{ShutdownMasterTool-IK-B054E6F8-483D-4398-BE6D-036A73D7034E}");

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (_mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.Run(new FormMain());
                _mutex.ReleaseMutex();
            }
        }
    }
}
