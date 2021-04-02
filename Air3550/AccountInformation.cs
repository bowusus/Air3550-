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
    public partial class AccountInformation : Form
    {
        // This form file is to document the actions done on the Log In Page specifically
        public AccountInformation()
        {
            InitializeComponent();
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            
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
