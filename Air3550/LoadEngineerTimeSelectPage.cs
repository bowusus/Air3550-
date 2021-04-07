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
    public partial class LoadEngineerTimeSelectPage : Form
    {
        public LoadEngineerTimeSelectPage()
        {
            InitializeComponent();
        }

        private void routeTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void LoadEngineerTimeSelectPage_Load(object sender, EventArgs e)
        {
            routeTimePicker.Format = DateTimePickerFormat.Custom;
            routeTimePicker.CustomFormat = "hh:mm tt";
            routeTimePicker.ShowUpDown = true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            LoadEngineerHomePage.GetInstance.Show();
            this.Hide();
        }
    }
}
