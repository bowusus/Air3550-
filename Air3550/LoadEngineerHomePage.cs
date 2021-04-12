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
    public partial class LoadEngineerHomePage : Form
    {
        private static LoadEngineerHomePage instance;
        public LoadEngineerHomePage()
        {
            InitializeComponent();
        }

        public static LoadEngineerHomePage GetInstance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new LoadEngineerHomePage();
                }
                return instance;
            }
        }

        private void LoadEngineerHomePage_Load(object sender, EventArgs e)
        {
            LoadFlightGrid();
        }

        private void AddFlight_Click(object sender, EventArgs e)
        {
            //LoadEngineerODSelectPage newForm = new LoadEngineerODSelectPage();
            //newForm.Location = this.Location;
            //newForm.Size = this.Size;
            //newForm.StartPosition = FormStartPosition.Manual;
            //newForm.FormClosing += delegate { this.Show(); };
            //newForm.Show();
            //this.Hide();

            LoadEngineerAddFlightPage.GetInstance.Show();
            this.Hide();
        }

        private void removeFlight_Click(object sender, EventArgs e)
        {
            if (flightGrid.SelectedRows.Count > 0)
            {
                int flightID = Convert.ToInt32(flightGrid.SelectedRows[0].Cells["flightID"].Value.ToString());
                SqliteDataAccess.RemoveMasterFlight(flightID);
                LoadFlightGrid();
            }
        }

        public void LoadFlightGrid()
        {
            flightGrid.DataSource = SqliteDataAccess.GetMasterFlightDT();
        }
    }
}
