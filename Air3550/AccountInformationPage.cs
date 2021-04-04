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
            EmailText.Text = customer.email;
            AgeComboBox.Text = customer.age.ToString();
            //PasswordText.Text = customer.password;
        }
        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            
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
            Console.WriteLine(e.CloseReason);
            Console.WriteLine(ActiveControl.Text);
            if (String.IsNullOrEmpty(ActiveControl.Text) && e.CloseReason != CloseReason.ApplicationExitCall)
            {
                DialogResult result = MessageBox.Show("Are you sure that you want to exit?\nAny changes not saved will not be updated.", "Exit Air3550", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (result == DialogResult.Yes)
                    Application.Exit();
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
