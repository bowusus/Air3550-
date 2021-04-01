using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Air3550
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
            LogInPage login = new LogInPage();
            CreateCustomerPage createCustomer = new CreateCustomerPage();
            CustomerHomePage home = new CustomerHomePage();
            Application.Run(login); // start with the login page as the main page
            if (login.StartAccountCreation) // create customer page is the main page
                Application.Run(createCustomer);
            if (login.IsLoggedIn || createCustomer.IsLoggedIn) // now the home page is the main page which closes when this page is closed
                Application.Run(home);
        }
    }
}
