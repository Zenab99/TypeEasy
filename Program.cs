using System;
using System.Windows.Forms;


namespace type_easy
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
            using (var form01_mainForm = new Form01_mainForm())
            {
                Application.Run(form01_mainForm);
            }
        }
    }
}
