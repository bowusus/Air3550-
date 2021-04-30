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
        private string originCode, destinationCode, time;
        private int flightID;
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

        public string OriginCode { get => originCode; set => originCode = value; }
        public string DestinationCode { get => destinationCode; set => destinationCode = value; }
        public string Time { get => time; set => time = value; }
        public int FlightID { get => flightID; set => flightID = value; }

        private void LoadEngineerHomePage_Load(object sender, EventArgs e)
        {
            LoadFlightGrid();
        }

        private void AddFlight_Click(object sender, EventArgs e)
        {
            LoadEngineerAddFlightPage.GetInstance.Show();
            LoadEngineerAddFlightPage.GetInstance.Location = this.Location;
            this.Hide();
        }

        private void removeFlight_Click(object sender, EventArgs e)
        {
            if (flightGrid.SelectedRows.Count > 0)
            {
                int flightID = Convert.ToInt32(flightGrid.SelectedRows[0].Cells["masterFlightID"].Value.ToString());
                SqliteDataAccess.RemoveMasterFlight(flightID);
                SqliteDataAccess.SetRemovalDateRoutes(flightID);
                LoadFlightGrid();
            }
        }

        private void LoadEngineerHomePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogInPage.GetInstance.Close();
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            // This method allows the user to return to the log in page
            // All open forms will close
            // The log in page will open
            // A message asks if the customer has saved everything they desire
            DialogResult result = MessageBox.Show("Are you sure that you want to log out?\nAny changes not saved will not be updated.", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (result == DialogResult.Yes)
            {
                LogInPage.GetInstance.Show();
                this.Dispose();
            }
        }

        private void editFlight_Click(object sender, EventArgs e)
        {
            if (flightGrid.SelectedRows.Count > 0)
            {
                this.originCode = flightGrid.SelectedRows[0].Cells["originCode_fk"].Value.ToString();
                this.destinationCode = flightGrid.SelectedRows[0].Cells["destinationCode_fk"].Value.ToString();
                this.time = string.Format("1-1-2021 {0}", flightGrid.SelectedRows[0].Cells["departureTime"].Value.ToString());
                this.flightID = Convert.ToInt32(flightGrid.SelectedRows[0].Cells["masterFlightID"].Value.ToString());
                LoadEngineerEditFlightPage.GetInstance.Show();
                LoadEngineerEditFlightPage.GetInstance.Location = this.Location;
            }
        }

        public void LoadFlightGrid()
        {
            flightGrid.DataSource = SqliteDataAccess.GetMasterFlightDT();
        }

    }
}
