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
        public void AccountInformationButton_Click(object sender, EventArgs e)
        {
            // This method transitions the displayed page from the customer home page to the 
            // account information page
            AccountInformationPage accountInformation = new AccountInformationPage(ref currCustomer); // create the next form
            accountInformation.Show(); // show the next form
            this.Hide(); // hide the main form, so it can be accessed again
        }
    }
}
