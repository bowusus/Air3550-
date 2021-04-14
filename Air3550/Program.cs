using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //LogInPage login = new LogInPage();

            /* Just for testing LE home page uncomment it later */
            Application.Run(LoadEngineerHomePage.GetInstance);

            //LogInPage login2 = new LogInPage();
            //CustomerHomePage home = new CustomerHomePage();
            //Application.Run(login); // start with the login page as the main page
            /*if (login1.IsDisposed && login1.IsAccessible == true) // check if the log in form is disposed and accessible to change the main form to the customer home page
                Application.Run(home);
            if (home.IsDisposed)
                Application.Run(login2);*/
            //Application.Run(new AccountingManagerHomePage());
            //Application.Exit(); // exit
        }
    }
}
