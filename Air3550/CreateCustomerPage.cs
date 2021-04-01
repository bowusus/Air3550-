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
    public partial class CreateCustomerPage : Form
    {
        // This form file is to document the actions done on the Log In Page specifically
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
            string errorMessage = null; // used to check if invalid information was provided

            // check if any of the text or combo boxes are empty 
            // and check if the password is of the correct length
            // add any of the invalid information errors to the errorMessage string
            if (String.IsNullOrEmpty(FirstNameText.Text))
                errorMessage += "FIRST NAME is Blank\n";
            if (String.IsNullOrEmpty(LastNameText.Text))
                errorMessage += "LAST NAME is Blank\n";
            if (PasswordText.Text.Length < 6)
                errorMessage += "The PASSWORD needs to be 6 or more characters long\n";
            if (String.IsNullOrEmpty(PasswordText.Text))
                errorMessage += "PASSWORD is Blank\n";
            if (String.IsNullOrEmpty(StreetText.Text))
                errorMessage += "STREET is Blank\n";
            if (String.IsNullOrEmpty(CityText.Text))
                errorMessage += "CITY is Blank\n";
            if (StateComboBox.SelectedItem == null)
                errorMessage += "STATE is Blank\n";
            if (String.IsNullOrEmpty(ZipText.Text))
                errorMessage += "ZIP CODE is Blank\n";
            if (String.IsNullOrEmpty(PhoneText.Text))
                errorMessage += "PHONE NUMBER is Blank\n";
            if (String.IsNullOrEmpty(CreditCardNumText.Text))
                errorMessage += "CREDIT CARD NUMBER is Blank\n";
            if (String.IsNullOrEmpty(EmailText.Text))
                errorMessage += "EMAIL is Blank\n";
            if (AgeComboBox.SelectedItem == null)
                errorMessage += "AGE is Blank";
            
            // if the errorMessage created is not empty, then something went wrong
            // so a message box will be shown to the user with an explanation of all errors
            // if it is empty, then everything was inputted correctly
            if (errorMessage != null)
                MessageBox.Show(errorMessage, "ERROR: Invalid Account Information Provided", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                state = StateComboBox.SelectedItem.ToString(); // get the value from the state combo box and turn it into a string
                age = int.Parse(AgeComboBox.SelectedItem.ToString()); // get the value from the age combo box and turn it into an int

                // validate the information provided against specifc formats and return any errors as a string
                string formatErrorMessage = SystemAction.ValidateAccountFormat(city, zip, phone, creditCardNum, email);
                // if the returned string is not empty, then an invalid format was provided, 
                // so a message box will be shown to the user with an explanation of all errors
                // else check the email in the database and see if a new account can be created
                if (formatErrorMessage != null)
                    MessageBox.Show(formatErrorMessage, "ERROR: Invalid Format of Account Information Provided", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
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
                        SqliteDataAccess.CreateAccount(customer.userID, customer.password, customer.firstName, customer.lastName, customer.street, customer.city, customer.state, customer.zipCode, customer.phoneNumber, customer.creditCardNumber, customer.age, customer.email);
                        // provide a pop up with the user's userID
                        DialogResult result = MessageBox.Show("Your account has been successfully created. Your USERID is "+ userID, "SUCCESS: New Account Created", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (result == DialogResult.OK)
                            this.Close(); // close the create customer page
                    }
                    else
                        MessageBox.Show("There is already an account linked with this email.", "ERROR: Account Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
