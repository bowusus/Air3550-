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
    public partial class CustomerHomePage : Form
    {
        // This form file is to document the actions done on the Customer Home Page specifically
        public static CustomerModel currCustomer; // make a local object that can be read in the current context
        public static bool logOutButtonClicked = false;
        public CustomerHomePage()
        {
            InitializeComponent();
        }
        public CustomerHomePage(ref CustomerModel customer) 
        {
            // This constructor allows for the object to be accessed in this form
            InitializeComponent();
            currCustomer = customer;
            logOutButtonClicked = false;
    }
        private void CancelFlightButton_Click(object sender, EventArgs e)
        {
            // This method transitions the displayed page from the customer home page to the 
            // account information page
            CancelFlightPage cancelFlight = new CancelFlightPage(ref currCustomer); // create the next form
            cancelFlight.Show(); // show the next form
            logOutButtonClicked = false;
            this.Hide(); // hide the main form, so it can be accessed again
        }
        public void AccountInformationButton_Click(object sender, EventArgs e)
        {
            // This method transitions the displayed page from the customer home page to the 
            // account information page
            AccountInformationPage accountInformation = new AccountInformationPage(ref currCustomer); // create the next form
            accountInformation.Show(); // show the next form
            logOutButtonClicked = false;
            this.Hide(); // hide the main form, so it can be accessed again
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
                this.Close(); // close current form
                Application.OpenForms[0].Show(); // open log in form
            }
        }
        private void CustomerHomePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            // This method allows the red X to be used to end the application
            // If the red X is clicked, a message will make sure the customer wants to leave
            // then the application ends or the customer cancels
            /*System.Diagnostics.Debug.WriteLine(ActiveControl.Text);
            if (CustomerHomePage.logOutButtonClicked == false)
            {
                DialogResult result = MessageBox.Show("Are you sure that you want to exit?\nAny changes not saved will not be updated.", "Exit Air3550 2", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (result == DialogResult.Yes)
                    Application.Exit(); // close the application
                else
                    e.Cancel = true; // cancel the closing of the form
            }*/
        }
    }
}
