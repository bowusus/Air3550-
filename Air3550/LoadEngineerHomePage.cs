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
        // This file is specifically used for the load engineer home page
        private static LoadEngineerHomePage instance; // Singleton-Pattern Instance
        private string originCode, destinationCode, time;
        private int flightID;
        public LoadEngineerHomePage()
        {
            InitializeComponent();
        }
        /* Get an already existing instance of this page if it does not exist then create it */
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
        /* Create and show the add flight form when add flight is clicked */
        private void AddFlight_Click(object sender, EventArgs e)
        {
            LoadEngineerAddFlightPage.GetInstance.Show();
            LoadEngineerAddFlightPage.GetInstance.Location = this.Location;
            this.Hide();
        }
        /* Remove the selected flight from the masterFlight table when remove flight is clicked */
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
        /* Close the application when the X is hit */
        private void LoadEngineerHomePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogInPage.GetInstance.Close();
        }
        /* Log out to the login page and dispose of the page */
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
        /* Show all routes currently being offered */
        private void routeButton_Click(object sender, EventArgs e)
        {
            LoadEngineerRoutesPage.GetInstance.Show();
            LoadEngineerRoutesPage.GetInstance.Location = this.Location;
        }
        /* Create a new edit flight form pop up */
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
        /* Load in the masterFlight SQL table and set it to the flightGrid's datasource */
        public void LoadFlightGrid()
        {
            flightGrid.DataSource = SqliteDataAccess.GetMasterFlightDT();
            flightGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // change the name of the columns
            flightGrid.Columns[0].HeaderText = "Master Flight ID";
            flightGrid.Columns[1].HeaderText = "Origin Code";
            flightGrid.Columns[2].HeaderText = "Destination Code";
            flightGrid.Columns[3].HeaderText = "Distance (in miles)";
            flightGrid.Columns[4].HeaderText = "Departure Time";
            flightGrid.Columns[5].HeaderText = "Plane Type";
            flightGrid.Columns[6].HeaderText = "Capacity";
        }
    }
}
