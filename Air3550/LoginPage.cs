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
        public LogInPage()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            // This method checks the provided information against the database
            // and throws an error if the information is not in the database or
            // loggs the user in and transistions to the customer home page
            string errorMessage = null;
            if (String.IsNullOrEmpty(UserIDText.Text))
                errorMessage += "USERID is Blank\n";
            if (String.IsNullOrEmpty(PasswordText.Text))
                errorMessage += "PASSWORD is Blank\n";
            if (errorMessage != null)
                MessageBox.Show(errorMessage, "ERROR: Invalid Log In", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                int userID = int.Parse(UserIDText.Text); // turn value from the UserID combo box into an int
                string currPass = PasswordText.Text; // get the provided password
                int passCheck = SqliteDataAccess.GetPassword(userID, currPass); // compare the provided userID and password with the database
                if (passCheck == 0)
                    MessageBox.Show("This password does not match the provided UserID", "ERROR: Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (passCheck == -1)
                    MessageBox.Show("The provided UserID is not in the system. Click below to create a new account.", "ERROR: Invalid UserID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    CustomerHomePage home = new CustomerHomePage(); // create the next form
                    home.Show(); // show the next form
                    this.Close(); // close log in form
                    this.IsAccessible = true; // make the form accessible to reference it in program.cs to change the main form
                }
            }
        }

        private void CreateCustomerAccountButton_Click(object sender, EventArgs e)
        {
            // This method transitions the displayed page from the log in page to the create customer account page
            // after the button is clicked
            CreateCustomerPage createCustomer = new CreateCustomerPage(); // create the next form
            createCustomer.Show(); // show the next form
        }

        private void UserIDText_MouseClick(object sender, MouseEventArgs e)
        {
            // This method was required to get the combo box cursor to start on the left side automatically
            UserIDText.SelectionStart = 0;
        }

        private void UserIDText_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // This method was required to get the combo box cursor to start on the left side automatically
            UserIDText.SelectionStart = 0;
        }

        private void PasswordText_TextChanged(object sender, EventArgs e)
        {
            // This method was required to show the password as asterisks when the user types
            PasswordText.PasswordChar = '*';
        }
    }
}
