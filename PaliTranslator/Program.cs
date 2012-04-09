using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PaliTranslator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form2());
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Oops, a crash occured: " + ex.Message);
            }
        }

     
    }
}
