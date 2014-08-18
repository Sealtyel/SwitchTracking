using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace SwitchTracking
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            SwitchQuery.spSwitchProcess();
            //Class1.Method();
            
        }
    }
}
