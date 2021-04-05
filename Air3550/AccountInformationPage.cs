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
    public partial class AccountInformationPage : Form
    {
        // This form file is to document the actions done on the Account Information Page specifically
        public static CustomerModel currCustomer; // make a local object that can be read in the current context
        public static bool saveChangesButtonClicked = false;
        public static bool logOutButtonClicked = false;
        public static bool backButtonClicked = false;
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
            saveChangesButtonClicked = false;
            logOutButtonClicked = false;
            backButtonClicked = false;
            FirstNameText.Text = customer.firstName;
            LastNameText.Text = customer.lastName;
            StreetText.Text = customer.street;
            CityText.Text = customer.city;
            StateComboBox.Text = customer.state;
            ZipText.Text = customer.zipCode;
            PhoneText.Text = customer.phoneNumber;
            CreditCardNumText.Text = customer.creditCardNumber;
            EmailText.Text = customer.email;
            AgeComboBox.Text = customer.age.ToString();
        }
        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            // This method updates the database with any changes the customer makes to their account information 
            // The password is allowed to be left blank
            // Everything else needs to be not blank and in the correct format
            // The fields get autopopulated with the information associated with the current customer
            // It produces a pop up at the end to notify the customer that their information was updated

            // get the values from the current textboxes
            string first = FirstNameText.Text;
            string last = LastNameText.Text;
            string password = PasswordText.Text;
            string pass = null;
            string street = StreetText.Text;
            string city = CityText.Text;
            string state;
            string zip = ZipText.Text;
            string phone = PhoneText.Text;
            string creditCard = CreditCardNumText.Text;
            string email = EmailText.Text;
            int age;
            // see if anything has an invalid format or is blank
            string errorMessage1 = null; // used to check if invalid information was provided
            string errorMessage2 = SystemAction.ValidateAccountFormat(password, first, last, street, city, zip, phone, creditCard, email); // validate the formats
            string totalErrorMessage = null;

            // check if the combo boxes are empty 
            // add any of the invalid information errors to the errorMessage string
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
                state = StateComboBox.Text.ToString(); // get the state
                age = int.Parse(AgeComboBox.Text.ToString()); // get the age
                if (!String.IsNullOrEmpty(password)) // encrypt the new password
                    pass = SystemAction.EncryptPassword(password);
                SqliteDataAccess.UpdateUser(currCustomer.userID, pass, first, last, street, city, state, zip, phone, creditCard, age, email); // update the database
                MessageBox.Show("Your Information has been successfully updated and saved", "Account Information Updated and Saved", MessageBoxButtons.OK, MessageBoxIcon.None);
                saveChangesButtonClicked = true;
            }
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            // This methods allows the user to return to the home page
            // The current form will close
            // The home page will open
            DialogResult result = MessageBox.Show("Are you sure that you want to return home?\nAny changes not saved will not be updated.", "Account Information", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (result == DialogResult.Yes)
            {
                backButtonClicked = true;
                this.Close(); // close the current form if the customer confirms that they would like to log out
                int i = 0;
                // close the log in form and the create customer form
                while (i < Application.OpenForms.Count) // look at what forms are open
                {
                    if (Application.OpenForms[i].Name == "CustomerHomePage")
                        Application.OpenForms[i].Show();// if the current form is the customer home page, show it
                    i += 1;
                }
            }
        }
        private void LogOutButton_Click(object sender, EventArgs e)
        {
            // This method allows the user to return to the log in page
            // All open forms will close
            // The log in page will open
            // A message asks if the customer has saved everything they desire
            DialogResult result = MessageBox.Show("Are you sure that you want to log out?\nAny changes not saved will not be updated.", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (result == DialogResult.Yes)
            {
                logOutButtonClicked = true; // used to access red x later
                CustomerHomePage.logOutButtonClicked = false;
                int i = 0;
                int indexAccount = 0;
                int indexLogIn = 0;
                this.Close();
                while (i < Application.OpenForms.Count) // look at what forms are open
                {
                    if (Application.OpenForms[i].Name != "LogInPage") // get location of other form
                        indexAccount = i;
                    else
                        indexLogIn = i;
                    i += 1;
                }
                Application.OpenForms[indexAccount].Close(); // close other form open
                Application.OpenForms[indexLogIn].Show(); // show the log in page that was hiding
            }
        }
        private void AccountInformationPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            // This method allows the red X to be used to end the application
            // If the red X is clicked, a message will make sure the customer wants to leave
            // then the application ends or the customer cancels
            /*if (CustomerHomePage.logOutButtonClicked == false && AccountInformationPage.backButtonClicked == false && AccountInformationPage.logOutButtonClicked == false && AccountInformationPage.saveChangesButtonClicked == false && e.CloseReason != CloseReason.ApplicationExitCall)
            {
                DialogResult result = MessageBox.Show("Are you sure that you want to exit?\nAny changes not saved will not be updated.", "Exit Air3550 1", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (result == DialogResult.Yes)
                    Application.Exit(); // close the application
                else
                    e.Cancel = true; // cancel the closing of the form
            }*/
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
