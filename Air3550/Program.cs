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
            // clean the routes that have a last date today or before
            SqliteDataAccess.CleanRoutes();
            // generate flights based on the master flight list for dates between now and 6 months from now
            SystemAction.GenerateFlights();
            // run the log in page as the main page of the application --> tied to the closing of the application
            Application.Run(LogInPage.GetInstance);
        }
    }
}
