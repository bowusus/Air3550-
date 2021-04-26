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
    public partial class AccountInformationPage : Form
    {
        // This form file is to document the actions done on the Account Information Page specifically
        public static AccountInformationPage instance; // singleton instance
        public static CustomerModel currCustomer; // make a local object that can be read in the current context
        public AccountInformationPage()
        {
            InitializeComponent();
        }
        public AccountInformationPage(ref CustomerModel customer)
        {
            // This constructor allows for the object to be accessed in this form
            InitializeComponent();
            // get the current customer and pass that information to the textboxes
            currCustomer = customer;
            EditAccountLabel.Text += currCustomer.userID;
            FirstNameText.Text = customer.firstName;
            LastNameText.Text = customer.lastName;
            StreetText.Text = customer.street;
            CityText.Text = customer.city;
            StateComboBox.Text = customer.state;
            ZipText.Text = customer.zipCode;
            PhoneText.Text = customer.phoneNumber;
            EmailText.Text = customer.email;
            AgeComboBox.Text = customer.age.ToString();
        }
        public static AccountInformationPage GetInstance(ref CustomerModel customer)
        {
            // This method follows the singleton pattern to allow for one form to be used rather than multiple being created
            if (instance == null || instance.IsDisposed)
            {
                instance = new AccountInformationPage(ref customer);
            }
            return instance;
        }
        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            // This method updates the database with any changes the customer makes to their account information 
            // The password and credit card number is allowed to be left blank
            // Everything else needs to be not blank and in the correct format
            // The fields get autopopulated with the information associated with the current customer
            // It produces a pop up at the end to notify the customer that their information was updated

            // get the values from the current textboxes
            string first = FirstNameText.Text;
            string last = LastNameText.Text;
            string password = PasswordText.Text;
            string passwordMatch = ConfirmPasswordText.Text;
            string pass = null;
            string street = StreetText.Text;
            string city = CityText.Text;
            string state;
            string zip = ZipText.Text;
            string phone = PhoneText.Text;
            string creditCard = CreditCardNumText.Text;
            Regex creditCardReg = new Regex(@"^?\d{4}-?\d{4}-?\d{4}-?\d{4}$");
            Match creditCardMatch = creditCardReg.Match(creditCard);
            string email = EmailText.Text;
            int age;

            // hide error labels initally
            FirstNameError.Visible = false;
            LastNameError.Visible = false;
            PasswordLengthError.Visible = false;
            ConfirmPasswordMatchError.Visible = false;
            PhoneError.Visible = false;
            CreditError.Visible = false;
            StreetError.Visible = false;
            CityError.Visible = false;
            StateError.Visible = false;
            ZipError.Visible = false;
            EmailError.Visible = false;
            AgeError.Visible = false;

            // make label array to access each label when there is an error
            Label[] errorArray = new Label[12] { FirstNameError, LastNameError, StreetError, CityError, ZipError, PhoneError, CreditError, EmailError, PasswordLengthError, ConfirmPasswordMatchError, StateError, AgeError };
            // get any errors from format
            int[] errors = SystemAction.ValidateAccountFormat(first, last, street, city, zip, phone, email);

            // check if the combo boxes are empty 
            // and check if the password is less than 6 characters if not blank and if the two passwords match
            // and check if the credit card is in the correct format
            // add any of the invalid information errors to the errors[]
            if (!creditCard.Equals("    -    -    -") && !creditCardMatch.Success)
                errors[6] = 1;
            if (!String.IsNullOrEmpty(password) && password.Length < 6)
                errors[8] = 1;
            if (!password.Equals(passwordMatch))
                errors[9] = 1;
            if (StateComboBox.SelectedItem == null)
                errors[10] = 1;
            if (AgeComboBox.SelectedItem == null)
                errors[11] = 1;

            // go through the errors[] and make those error labels visible and remove the error from the errors[]
            // if there are no errors, create the array
            if (errors.Contains(1))
            {
                for (int i = 0; i < 12; i++) // if any of the information is incorrectly inputted, then make that error visible and set it to 0
                {
                    if (errors[i] == 1)
                        errorArray[i].Visible = true;
                    errors[i] = 0;
                }
            }
            else
            {
                int existingCustomer = SqliteDataAccess.CheckIfNewCustomer(email); // check if this email exists in the database
                // if the email exists, create a new account
                // else an error will display to the customer
                if (existingCustomer == 0 || email == currCustomer.email)
                {
                    state = StateComboBox.SelectedItem.ToString(); // get the value from the state combo box and turn it into a string
                    age = int.Parse(AgeComboBox.Text.ToString()); // get the age
                    if (!String.IsNullOrEmpty(password)) // encrypt the new password
                        pass = SystemAction.EncryptPassword(password);
                    SqliteDataAccess.UpdateUser(currCustomer.userID, pass, first, last, street, city, state, zip, phone, creditCard, age, email); // update the database
                    currCustomer = new CustomerModel(currCustomer.userID, pass, first, last, street, city, state, zip, phone, creditCard, age, email);
                    MessageBox.Show("Your Information has been successfully updated and saved", "Account Information Updated and Saved", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                    MessageBox.Show("This email already exists. Try another email.", "Error: Account Information Changes", MessageBoxButtons.OK, MessageBoxIcon.None);

            }
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            // This methods allows the user to return to the customer home page
            // The current form will close
            // The customer home page will open
            DialogResult result = MessageBox.Show("Are you sure that you want to return home?\nAny changes not saved will not be updated.", "Account Information", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (result == DialogResult.Yes)
            {
                CustomerHomePage.GetInstance(ref currCustomer).Show();
                this.Dispose();
            }
        }
        private void LogOutButton_Click(object sender, EventArgs e)
        {
            // This method allows the user to return to the log in page
            // All open forms will close
            // The log in page will open
            // A message asks if the customer has saved everything they desire
            DialogResult result = MessageBox.Show("Are you sure that you want to log out?\nAny changes not saved will not be updated.", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (result == DialogResult.Yes)
            {
                LogInPage.GetInstance.Show();
                this.Dispose();
            }
        }
        private void AccountInformationPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            // This method allows the exit button to be used to end the application
            // If the exit button is clicked, a message will make sure the customer wants to leave
            // then the application ends or the customer cancels
            DialogResult result = MessageBox.Show("Are you sure you would like to exit?\nAny changes not saved will not be updated.", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (result == DialogResult.Yes)
                LogInPage.GetInstance.Close();
            else
                e.Cancel = true;
        }
        private void PhoneText_MouseClick(object sender, MouseEventArgs e)
        {
            // This method was required to get the combo box cursor to start on the left side automatically
            int index = PhoneText.Text.IndexOf(" ");
            if (PhoneText.Text.Equals("(   )   -"))
                PhoneText.SelectionStart = 0;
            else
            {
                if (index != -1)
                    PhoneText.SelectionStart = index;
                else
                    PhoneText.SelectionStart = PhoneText.Text.Length;
            }
        }
        private void PhoneText_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // This method was required to get the combo box cursor to start on the left side automatically
            int index = PhoneText.Text.IndexOf(" ");
            if (PhoneText.Text.Equals("(   )   -"))
                PhoneText.SelectionStart = 0;
            else
            {
                if (index != -1)
                    PhoneText.SelectionStart = index;
                else
                    PhoneText.SelectionStart = PhoneText.Text.Length;
            }
        }
        private void CreditCardNumText_MouseClick(object sender, MouseEventArgs e)
        {
            // This method was required to get the combo box cursor to start on the left side automatically
            int index = CreditCardNumText.Text.IndexOf(" ");
            if (CreditCardNumText.Text.Equals("    -    -    -"))
                CreditCardNumText.SelectionStart = 0;
            else
            {
                if (index != -1)
                    CreditCardNumText.SelectionStart = index;
                else
                    CreditCardNumText.SelectionStart = CreditCardNumText.Text.Length;
            }
        }
        private void CreditCardNumText_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // This method was required to get the combo box cursor to start on the left side automatically
            int index = CreditCardNumText.Text.IndexOf(" ");
            if (CreditCardNumText.Text.Equals("    -    -    -"))
                CreditCardNumText.SelectionStart = 0;
            else
            {
                if (index != -1)
                    CreditCardNumText.SelectionStart = index;
                else
                    CreditCardNumText.SelectionStart = CreditCardNumText.Text.Length;
            }
        }
    }
}
