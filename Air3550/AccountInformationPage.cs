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
        // This form file is to document the actions done on the Log In Page specifically
        public static ClassLibrary.CustomerModel currCustomer;
        public AccountInformationPage()
        {
            InitializeComponent();
        }
        public AccountInformationPage(ref ClassLibrary.CustomerModel customer)
        {
            InitializeComponent();
            currCustomer = customer;
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
            string first = FirstNameText.Text;
            string last = LastNameText.Text;
            string password = PasswordText.Text;
            string pass = null;
            string street = StreetText.Text;
            string city = CityText.Text;
            string state = StateComboBox.Text;
            string zip = ZipText.Text;
            string phone = PhoneText.Text;
            string creditCard = CreditCardNumText.Text;
            string email = EmailText.Text;
            int age = int.Parse(AgeComboBox.Text);

            if (!String.IsNullOrEmpty(password))
                pass = SystemAction.EncryptPassword(password);
            SqliteDataAccess.UpdateUser(currCustomer.userID, pass, first, last, street, city, state, zip, phone, creditCard, age, email);
            MessageBox.Show("Your Information has been successfully updated and saved", "Account Information Updated and Saved", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
        private void ReturnHomeButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure that you want to return home?\nAny changes not saved will not be updated.", "Account Information", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (result == DialogResult.Yes)
                this.Close();
            int i = 0;
            // close the log in form and the create customer form
            while (i < Application.OpenForms.Count) // look at what forms are open
            {
                if (Application.OpenForms[i].Name == "CustomerHomePage") // close everything that isn't the customer home page
                    Application.OpenForms[i].Show();// if the current form is the log in form, make it accessible to change the main form to the home page
                i += 1;
            }
        }
        private void LogOutButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure that you want to log out?\nAny changes not saved will not be updated.", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (result == DialogResult.Yes)
            {
                int i = 0;
                // close the log in form and the create customer form
                while (i < Application.OpenForms.Count) // look at what forms are open
                {
                    if (Application.OpenForms[i].Name != "LogInPage") // close everything that isn't the customer home page
                        Application.OpenForms[i].Close();// if the current form is the log in form, make it accessible to change the main form to the home page
                    else
                        i += 1;
                }
                Application.OpenForms[0].Show();
            }
        }
        private void AccountInformationPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ActiveControl.Text == currCustomer.firstName && e.CloseReason != CloseReason.ApplicationExitCall)
            {
                DialogResult result = MessageBox.Show("Are you sure that you want to exit?\nAny changes not saved will not be updated.", "Exit Air3550", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (result == DialogResult.Yes)
                    Application.Exit(); // close the application
                else
                    e.Cancel = true; // cancel the closing of the form
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
