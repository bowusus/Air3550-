using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace Air3550
{
    public partial class LoadEngineerODSelectPage : Form
    {
        public static string originCode = "";
        public static string destinationCode = "";
        public LoadEngineerODSelectPage()
        {
            InitializeComponent();
        }

        private void LoadEngineerODSelectPage_Load(object sender, EventArgs e)
        {
            originDropDown.DataSource = SqliteDataAccess.GetAirportCodes();
            destinationDropDown.DataSource = SqliteDataAccess.GetAirportCodes();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            originCode = originDropDown.Text;
            destinationCode = destinationDropDown.Text;

            LoadEngineerFlightSelectPage newForm = new LoadEngineerFlightSelectPage();
            newForm.Location = this.Location;
            newForm.Size = this.Size;
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.FormClosing += delegate { this.Show(); };
            newForm.Show();
            this.Hide();
        }
    }
}
