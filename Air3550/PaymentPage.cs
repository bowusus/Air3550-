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
    public partial class PaymentPage : Form
    {
        // This form file is to document the actions done on the Payment Page specifically
        public static CustomerModel currCustomer; // make a local object that can be read in the current context
        public PaymentPage()
        {
            InitializeComponent();
        }
        public PaymentPage(ref CustomerModel customer)
        {
            // This constructor allows for the object to be accessed in this form
            InitializeComponent();
            // get the current customer and pass that information to the textboxes
            currCustomer = customer;
        }
    }
}
