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
        private static CreateCustomerPage instance; // singleton instance
        public CreateCustomerPage()
        {
            InitializeComponent();
        }
        public static CreateCustomerPage GetInstance
        {
            // This method follows the singleton pattern to allow for one form to be used rather than multiple being created
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new CreateCustomerPage();
                }
                return instance;
            }
        }
        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            // This method includes validating the data provided on the Create Account Form
            // and either throwing an error if something is invalid or creating the account 
            // then taking the customer to the customer home page
            // get the values from the text boxes on the form
            string firstName = FirstNameText.Text;
            string lastName = LastNameText.Text;
            string password = PasswordText.Text;
            string passwordMatch = ConfirmPasswordText.Text;
            string street = StreetText.Text;
            string city = CityText.Text;
            string state;
            string zip = ZipText.Text;
            string phone = PhoneText.Text;
            string creditCardNum = CreditCardNumText.Text;
            Regex creditCardReg = new Regex(@"^?\d{4}-?\d{4}-?\d{4}-?\d{4}$");
            Match creditCardMatch = creditCardReg.Match(creditCardNum);
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
            Label[] errorArray = new Label[12] { FirstNameError, LastNameError, StreetError, CityError, ZipError, PhoneError, CreditError, EmailError, PasswordLengthError, ConfirmPasswordMatchError, StateError, AgeError};
            // get any errors from format
            int[] errors = SystemAction.ValidateAccountFormat(firstName, lastName, street, city, zip, phone, email);

            // check if the combo boxes are empty 
            // and check if the password is less than 6 characters and if the two passwords match
            // add any of the invalid information errors to the errors[]
            if (!creditCardMatch.Success)
                errors[6] = 1;
            if (password.Length < 6)
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
                for (int i = 0; i < 12; i++)
                {
                    if (errors[i] == 1)
                        errorArray[i].Visible = true;
                    errors[i] = 0;
                }
            }
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
                    // remove that id from the database
                    SqliteDataAccess.RemoveFromUserIDTable(userID);
                    // encrypt the password
                    string pass = SystemAction.EncryptPassword(password);

                    // create a customer object
                    CustomerModel customer = new CustomerModel(userID, pass, firstName, lastName, street, city, state, zip, phone, creditCardNum, age, email);
                    // add the customer to the database aka create account and add customer the credits table
                    SqliteDataAccess.CreateAccount(userID, pass, firstName, lastName, street, city, state, zip, phone, creditCardNum, age, email);
                    SqliteDataAccess.AddCustomerToCredits(userID);
                    // provide a pop up with the user's userID
                    DialogResult result = MessageBox.Show("Your account has been successfully created. Your USERID is " + userID, "SUCCESS: New Account Created", MessageBoxButtons.OK, MessageBoxIcon.None);
                    if (result == DialogResult.OK)
                    {
                        this.Dispose(); // close the current page
                        CustomerHomePage.GetInstance(ref customer).Show(); // show the customer home page to prevent the need to remember your userID
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("There is already an account linked with this email.\nPress OK to return to the Log In Page to use your previously created account.\nPress CANCEL to modify the email your provided when creating a new account.\n", "ERROR: Account Already Exists", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.OK) // return 
                    {
                        this.Dispose(); // close current page
                        LogInPage.GetInstance.Show();
                    }
                }
            }
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            // This methods allows the user to return to the Log In page
            // The current form will close
            // The Log In page will open
            DialogResult result = MessageBox.Show("Are you sure that you want to return to the log in screen?\nAny changes not saved will not be updated.", "Account Information", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (result == DialogResult.Yes)
            {
                LogInPage.GetInstance.Show();
                this.Dispose();
            }
        }
        private void CreateCustomerPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            // This message checks if the user wants to exit
            // If they do, then the application closes
            // If they cancel, then the current page stays open
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
