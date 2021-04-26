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
        private static LogInPage instance; // singleton instance
        public LogInPage()
        {
            InitializeComponent();
        }
        public static LogInPage GetInstance
        {
            // This method follows the singleton pattern to allow for one form to be used rather than multiple being created
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new LogInPage();
                }
                return instance;
            }
        }
        private void LogInButton_Click(object sender, EventArgs e)
        {
            // This method checks the provided information against the database
            // and throws an error if the information is not in the database or
            // logs the user in and transistions to the customer home page
            UserIDError.Visible = false;
            PasswordError.Visible = false;
            if (String.IsNullOrEmpty(UserIDText.Text) || UserIDText.Text.Length < 6)
                UserIDError.Visible = true;
            if (String.IsNullOrEmpty(PasswordText.Text) || PasswordText.Text.Length < 6)
                PasswordError.Visible = true;
            else
            {
                int userID = int.Parse(UserIDText.Text); // turn value from the UserID combo box into an int
                string currPass = PasswordText.Text; // get the provided password
                if (SqliteDataAccess.CheckIfEmployee(userID, currPass).Equals("AccountingManager"))
                {
                    // log in as accounting manager
                    UserIDText.Text = null;
                    PasswordText.Text = null;
                    UserIDText.Select(); // used to put cursor back in userID box
                    AccountingManagerHomePage accountingHome = new AccountingManagerHomePage();
                    accountingHome.Show(); // show the next form
                    this.Hide(); // close log in form
                }
                else if (SqliteDataAccess.CheckIfEmployee(userID, currPass).Equals("FlightManager"))
                {
                    // log in as flight manager
                    UserIDText.Text = null;
                    PasswordText.Text = null;
                    UserIDText.Select(); // used to put cursor back in userID box
                    FlightManagerHomePage.GetInstance().Show(); // show the customer home page to prevent the need to remember your userID
                    this.Hide(); // close the instance of the log in page
                }
                else if (SqliteDataAccess.CheckIfEmployee(userID, currPass).Equals("LoadEngineer"))
                {
                    // log in as load engineer
                    UserIDText.Text = null;
                    PasswordText.Text = null;
                    UserIDText.Select(); // used to put cursor back in userID box
                    LoadEngineerHomePage.GetInstance.Show();
                    this.Hide(); // close log in form
                }
                else if (SqliteDataAccess.CheckIfEmployee(userID, currPass).Equals("MarketingManager"))
                {
                    // log in as marketing manager
                    UserIDText.Text = null;
                    PasswordText.Text = null;
                    UserIDText.Select(); // used to put cursor back in userID box
                    MarketingManagerHomePage.GetInstance.Show(); // show the next form
                    this.Hide(); // close log in form
                }
                else
                {
                    // the user is a customer
                    int passCheck = SqliteDataAccess.CheckPassword(userID, currPass); // compare the provided userID and password with the database
                    if (passCheck == 0)
                        PasswordError.Visible = true;
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
                        SystemAction.SetTakenFlights(customer.userID);
                        CustomerHomePage.GetInstance(ref customer).Show(); // show the customer home page to prevent the need to remember your userID
                        this.Hide(); // close the instance of the log in page
                    }
                }
            }
        }
        private void CreateCustomerAccountButton_Click(object sender, EventArgs e)
        {
            // This method transitions the displayed page from the log in page to the create customer account page
            // after the button is clicked
            this.Hide(); // close the instance of the log in page
            CreateCustomerPage.GetInstance.Show(); // show the customer home page to prevent the need to remember your userID
        }
        private void UserIDText_MouseClick(object sender, MouseEventArgs e)
        {
            // This method was required to get the combo box cursor to start on the left side automatically
            int index = UserIDText.Text.IndexOf(" ");
            if (UserIDText.Text.Equals("      "))
                UserIDText.SelectionStart = 0;
            else
            {
                if (index != -1)
                    UserIDText.SelectionStart = index;
                else
                    UserIDText.SelectionStart = UserIDText.Text.Length;
            }
        }
        private void UserIDText_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // This method was required to get the combo box cursor to start on the left side automatically
            int index = UserIDText.Text.IndexOf(" ");
            if (UserIDText.Text.Equals("      "))
                UserIDText.SelectionStart = 0;
            else
            {
                if (index != -1)
                    UserIDText.SelectionStart = index;
                else
                    UserIDText.SelectionStart = UserIDText.Text.Length;
            }
        }
    }
}
