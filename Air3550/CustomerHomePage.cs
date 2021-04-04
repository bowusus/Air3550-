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
        public static ClassLibrary.CustomerModel currCustomer;
        public CustomerHomePage()
        {
            InitializeComponent();
        }
        public CustomerHomePage(ref ClassLibrary.CustomerModel customer) 
        {
            InitializeComponent();
            currCustomer = customer;
        }
        public void AccountInformationButton_Click(object sender, EventArgs e)
        {
            // This method transitions the displayed page from the customer home page to the 
            // account information page
            //Console.WriteLine(currCustomer.firstName);
            AccountInformationPage accountInformation = new AccountInformationPage(ref currCustomer); // create the next form
            accountInformation.Show(); // show the next form
            this.Hide();
        }
    }
}
