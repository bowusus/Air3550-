using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace Air3550
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /* Just for testing LE home page uncomment it later */
            // SystemAction.CleanAvailableFlights();
            SqliteDataAccess.CleanRoutes();
            SystemAction.GenerateFlights();
  //          SystemAction.SetTakenFlights();
            Application.Run(LogInPage.GetInstance);
        }
    }
}
