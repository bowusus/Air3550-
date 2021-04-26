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
        private static CustomerHomePage instance; // singleton instance
        private static CustomerModel currCustomer; // make a local object that can be read in the current context
        public CustomerHomePage()
        {
            InitializeComponent();
        }
        public CustomerHomePage(ref CustomerModel customer) 
        {
            // This constructor allows for the object to be accessed in this form
            InitializeComponent();
            currCustomer = customer;
        }
        public static CustomerHomePage GetInstance(ref CustomerModel customer)
        {
            // This method follows the singleton pattern to allow for one form to be used rather than multiple being created
            if (instance == null || instance.IsDisposed)
            {
                instance = new CustomerHomePage(ref customer);
            }
            return instance;
        }
        private void BookFlightButton_Click(object sender, EventArgs e)
        {
            // This method transitions the displayed page from the customer home page to the 
            // book flight page
            BookFlightPage.GetInstance(ref currCustomer).Show();
            this.Dispose();
        }
        private void CancelFlightButton_Click(object sender, EventArgs e)
        {
            // This method transitions the displayed page from the customer home page to the 
            // cancel flight page
            CancelFlightPage.GetInstance(ref currCustomer).Show();
            this.Dispose();
        }
        public void AccountInformationButton_Click(object sender, EventArgs e)
        {
            // This method transitions the displayed page from the customer home page to the 
            // account information page
            AccountInformationPage.GetInstance(ref currCustomer).Show();
            this.Dispose();
        }
        private void AccountHistoryButton_Click(object sender, EventArgs e)
        {
            // This method transitions the displayed page from the customer home page to the 
            // account history page
            AccountHistoryPage.GetInstance(ref currCustomer).Show();
            this.Dispose();
        }
        private void PrintBoardingPassButton_Click(object sender, EventArgs e)
        {
            // This method transitions the displayed page from the customer home page to the 
            // print boarding pass page
            PrintBoardingPassPage.GetInstance(ref currCustomer).Show();
            this.Dispose();
        }
        private void LogOutButton_Click(object sender, EventArgs e)
        {
            // This method allows the user to return to the log in page
            // This page will close
            // The log in page will open
            // A message asks if the customer has saved everything they desire
            DialogResult result = MessageBox.Show("Are you sure that you want to log out?\nAny changes not saved will not be updated.", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (result == DialogResult.Yes)
            {
                LogInPage.GetInstance.Show();
                this.Dispose();
            }
        }
        private void CustomerHomePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            // This message checks if the user wants to exit
            // If they do, then the application closes
            // If they cancel, then the current page stays open
            DialogResult result = MessageBox.Show("Are you sure you would like to exit?\nAny changes not saved will not be updated.", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (result == DialogResult.Yes)
                LogInPage.GetInstance.Dispose();
            else
                e.Cancel = true;
        }
    }
}
