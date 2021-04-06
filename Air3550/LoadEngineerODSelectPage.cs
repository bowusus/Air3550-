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
        public LoadEngineerODSelectPage()
        {
            InitializeComponent();
        }

        private void LoadEngineerODSelectPage_Load(object sender, EventArgs e)
        {
            originDropDown.DataSource = SqliteDataAccess.GetAirportCodes();
            destinationDropDown.DataSource = SqliteDataAccess.GetAirportCodes();
        }
    }
}
