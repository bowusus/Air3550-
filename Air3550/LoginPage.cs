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
    public partial class LogInPage : Form
    {
        // This form file is to document the actions done on the Log In Page specifically
        public LogInPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 
            //Console.WriteLine(SqliteDataAccess.GetRandUserID());
            //string pass = "apple";
            //Console.WriteLine(SystemAction.EncryptPassword(pass));
        }

        private void CreateCustomerAccountButton_Click(object sender, EventArgs e)
        {
            CreateCustomerPage createCustomer = new CreateCustomerPage(); 
            createCustomer.Show();
        }
    }
}
