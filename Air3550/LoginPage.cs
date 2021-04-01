using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Air3550
{
    public partial class LogInPage : Form
    {
        // This form file is to document the actions done on the Log In Page specifically
        public bool IsLoggedIn { get; set; } // added to change main form running
        public bool StartAccountCreation { get; set; } // added to change main form running

        public LogInPage()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            // 
            //Console.WriteLine(SqliteDataAccess.GetRandUserID());
            //string pass = "apple";
            //Console.WriteLine(SystemAction.EncryptPassword(pass));
        }

        private void CreateCustomerAccountButton_Click(object sender, EventArgs e)
        {
            // This method transitions the displayed page from the log in page to the create customer account page
            // after the button is clicked
            CreateCustomerPage createCustomer = new CreateCustomerPage(); // create the next form
            createCustomer.Show(); // show the next form
            this.Close(); // close this form
            StartAccountCreation = true; // change to create customer account page
        }
    }
}
