using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Air3550
{
    public partial class CreateCustomerPage : Form
    {
        // This form file is to document the actions done on the Create Customer Page specifically
        public CreateCustomerPage()
        {
            InitializeComponent();
        }
        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            // This method includes validating the data provided on the Create Account Form
            // and either throwing an error if something is invalid or creating the account 
            // then taking the customer back to the Log In Page
            // get the values from the text boxes on the form
            string firstName = FirstNameText.Text;
            string lastName = LastNameText.Text;
            string password = PasswordText.Text;
            string street = StreetText.Text;
            string city = CityText.Text;
            string state;
            string zip = ZipText.Text;
            string phone = PhoneText.Text;
            string creditCardNum = CreditCardNumText.Text;
            string email = EmailText.Text;
            int age;

            string errorMessage1 = null; // used to check if invalid information was provided
            string errorMessage2 = SystemAction.ValidateAccountFormat(password, firstName, lastName, street, city, zip, phone, creditCardNum, email);
            string totalErrorMessage = null;

            // check if the combo boxes are empty 
            // and check if the password is blank or less than 6 characters
            // add any of the invalid information errors to the errorMessage string
            if (String.IsNullOrEmpty(password))
                errorMessage1 += "PASSWORD is Blank\n";
            if (password.Length < 6)
                errorMessage1 += "The PASSWORD needs to be 6 or more characters long\n";
            if (StateComboBox.SelectedItem == null)
                errorMessage1 += "STATE is Blank\n";
            if (AgeComboBox.SelectedItem == null)
                errorMessage1 += "AGE is Blank";

            totalErrorMessage += errorMessage1 + errorMessage2;

            // if the errorMessage created is not empty, then something went wrong
            // so a message box will be shown to the user with an explanation of all errors
            // if it is empty, then everything was inputted correctly
            if (!String.IsNullOrEmpty(totalErrorMessage))
                MessageBox.Show(totalErrorMessage, "ERROR: Invalid Account Information Provided", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                state = StateComboBox.SelectedItem.ToString(); // get the value from the state combo box and turn it into a string
                age = int.Parse(AgeComboBox.SelectedItem.ToString()); // get the value from the age combo box and turn it into an int

                int existingCustomer = SqliteDataAccess.CheckIfNewCustomer(email); // check if this email exists in the database
                // if the email exists, create a new account
                // else an error will display to the customer
                if (existingCustomer == 0)
                {
                    // get random id
                    int userID = SqliteDataAccess.GetRandUserID();
                    // encrypt the password
                    string pass = SystemAction.EncryptPassword(password);
                    // create a customer object
                    CustomerModel customer = new CustomerModel(userID, pass, firstName, lastName, street, city, state, zip, phone, creditCardNum, age, email);
                    // add the customer to the database aka create account
                    SqliteDataAccess.CreateAccount(userID, pass, firstName, lastName, street, city, state, zip, phone, creditCardNum, age, email);
                    // provide a pop up with the user's userID
                    DialogResult result = MessageBox.Show("Your account has been successfully created. Your USERID is " + userID, "SUCCESS: New Account Created", MessageBoxButtons.OK, MessageBoxIcon.None);
                    if (result == DialogResult.OK)
                    {
                        CustomerHomePage customerHome = new CustomerHomePage(ref customer); // create customer home page with current customer
                        int i = 0;
                        // close the log in form and the create customer form
                        while (i < Application.OpenForms.Count) // look at what forms are open
                        {
                            if (Application.OpenForms[i].Name != "CustomerHomePage") // close everything that isn't the customer home page
                            {
                                if (Application.OpenForms[i].Name == "LogInPage")
                                    //Application.OpenForms[i].IsAccessible = true; // if the current form is the log in form, make it accessible to change the main form to the home page
                                    Application.OpenForms[i].Hide(); // hide the log in page, so it can be referenced later
                                else
                                    Application.OpenForms[i].Close(); // close everything else
                            }
                            i += 1;
                        }
                        customerHome.Show(); // show the customer home page to prevent the need to remember your userID
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("There is already an account linked with this email.\nPress OK to return to the Log In Page to use your previously created account.\nPress CANCEL to modify the email your provided when creating a new account.\n", "ERROR: Account Already Exists", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.OK) // return 
                        this.Close(); // close current page
                }
            }
        }
        private void PhoneText_MouseClick(object sender, MouseEventArgs e)
        {
            // This method was required to get the combo box cursor to start on the left side automatically
            PhoneText.SelectionStart = 0;
        }
        private void PhoneText_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // This method was required to get the combo box cursor to start on the left side automatically
            PhoneText.SelectionStart = 0;
        }
        private void CreditCardNumText_MouseClick(object sender, MouseEventArgs e)
        {
            // This method was required to get the combo box cursor to start on the left side automatically
            CreditCardNumText.SelectionStart = 0;
        }
        private void CreditCardNumText_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // This method was required to get the combo box cursor to start on the left side automatically
            CreditCardNumText.SelectionStart = 0;
        }
    }
}
