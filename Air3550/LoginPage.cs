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
            else if (UserIDText.Text.Length < 6)
                errorMessage += "USERID is too short\n";
            if (String.IsNullOrEmpty(PasswordText.Text))
                errorMessage += "PASSWORD is Blank\n";
            else if (PasswordText.Text.Length < 6)
                errorMessage += "PASSWORD is too short\n";
            if (errorMessage != null)
                MessageBox.Show(errorMessage, "ERROR: Invalid Log In", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                int userID = int.Parse(UserIDText.Text); // turn value from the UserID combo box into an int
                string currPass = PasswordText.Text; // get the provided password
                if (userID == 111111 && currPass.Equals("accounting"))
                {
                    // log in as accounting manager
                    UserIDText.Text = null;
                    PasswordText.Text = null;
                    UserIDText.Select(); // used to put cursor back in userID box
                    AccountingManagerHomePage accountingHome = new AccountingManagerHomePage();
                    accountingHome.Show(); // show the next form
                    this.Hide(); // close log in form
                }
                else if (userID == 222222 && currPass.Equals("flight"))
                {
                    // log in as flight manager
                    UserIDText.Text = null;
                    PasswordText.Text = null;
                    UserIDText.Select(); // used to put cursor back in userID box
                    FlightManagerHomePage flightHome = new FlightManagerHomePage();
                    flightHome.Show(); // show the next form
                    this.Hide(); // close log in form
                }
                else if (userID == 333333 && currPass.Equals("loadengineer"))
                {
                    // log in as load engineer
                    UserIDText.Text = null;
                    PasswordText.Text = null;
                    UserIDText.Select(); // used to put cursor back in userID box
                    LoadEngineerHomePage loadEngineerHome = new LoadEngineerHomePage();
                    loadEngineerHome.Show(); // show the next form
                    this.Hide(); // close log in form
                }
                else if (userID == 444444 && currPass.Equals("marketing"))
                {
                    // log in as marketing manager
                    UserIDText.Text = null;
                    PasswordText.Text = null;
                    UserIDText.Select(); // used to put cursor back in userID box
                    MarketingManagerHomePage marketingHome = new MarketingManagerHomePage();
                    marketingHome.Show(); // show the next form
                    this.Hide(); // close log in form
                }
                else
                {
                    int passCheck = SqliteDataAccess.CheckPassword(userID, currPass); // compare the provided userID and password with the database
                    if (passCheck == 0)
                        MessageBox.Show("This password does not match the provided UserID", "ERROR: Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (passCheck == -1)
                        MessageBox.Show("The provided UserID is not in the system. Click below to create a new account.", "ERROR: Invalid UserID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        // resets textboxes to allow for multiple log ins and prevents anyone else from seeing the previous log in information
                        UserIDText.Text = null;
                        PasswordText.Text = null;
                        UserIDText.Select(); // used to put cursor back in userID box
                        List<string> userData = SqliteDataAccess.GetUserData(userID);
                        CustomerModel customer = new CustomerModel(userID, userData[1], userData[2], userData[3], userData[4], userData[5], userData[6], userData[7], userData[8], userData[9], int.Parse(userData[10]), userData[11]);
                        CustomerHomePage home = new CustomerHomePage(ref customer); // create the next form
                        home.Show(); // show the next form
                        this.Hide(); // close log in form
                    }
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
    }
}
