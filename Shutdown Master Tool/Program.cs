using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shutdown_Master_Tool
{
    internal static class Program
    {
        static string guid_ = Assembly.GetExecutingAssembly().GetCustomAttribute<GuidAttribute>().Value;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (Mutex _mutex = new Mutex(true, "{ShutdownMasterTool-IK-" + guid_ + "}"))
            {
                if (_mutex.WaitOne(TimeSpan.Zero, true)) Application.Run(new FormMain());
            }
        }
    }
}
