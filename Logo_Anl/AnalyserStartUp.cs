using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logo_Anl
{
    static class AnalyserStartUp
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Registration());
        }

        static public string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+@"C:\Users\Thom\Documents\sixth form\Computer science\Thom Johnson NEA\Logo_Anl\Logo_Anl\UserBase.mdf"+";Integrated Security=True"; //connection string for SQLConnection
    }
}
