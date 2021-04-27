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
    public partial class LoadEngineerEditFlightPage : Form
    {
        // This file is specifically used for the load engineer edit page
        private static LoadEngineerEditFlightPage instance; // Singleton-Pattern Instance
        public LoadEngineerEditFlightPage()
        {
            InitializeComponent();
        }
        /* Get an already existing instance of this page if it does not exist then create it */
        public static LoadEngineerEditFlightPage GetInstance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new LoadEngineerEditFlightPage();
                }
                return instance;
            }
        }
        /* On load set the time picker to the correct format */
        private void LoadEngineerEditFlightPage_Load(object sender, EventArgs e)
        {
            routeTimePicker.Format = DateTimePickerFormat.Custom;
            routeTimePicker.CustomFormat = "hh:mm tt";
            routeTimePicker.ShowUpDown = true;
            routeTimePicker.Value = Convert.ToDateTime(LoadEngineerHomePage.GetInstance.Time);
        }
        /* When save button is clicked any routes using the flightID modified are set to be deleted 6 months
         * and 1 day from now, the old flight is deleted and a new one is created with new time and new ID */
        private void saveButton_Click(object sender, EventArgs e)
        {
            if(SqliteDataAccess.MasterFlightExists(LoadEngineerHomePage.GetInstance.OriginCode, LoadEngineerHomePage.GetInstance.DestinationCode,
                                                   routeTimePicker.Value.ToShortTimeString()))
            {
                MessageBox.Show("Cannot use this time as a flight with this time already exists.", "Error: Flight Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int newFlightID = SqliteDataAccess.GetLastMasterFlightID();
                SqliteDataAccess.ChangeTimeMaster(LoadEngineerHomePage.GetInstance.FlightID, routeTimePicker.Value, newFlightID);
                SqliteDataAccess.SetRemovalDateRoutes(LoadEngineerHomePage.GetInstance.FlightID);
                SqliteDataAccess.RemoveMasterFlight(LoadEngineerHomePage.GetInstance.FlightID);
                LoadEngineerHomePage.GetInstance.LoadFlightGrid();
                this.Dispose();
            }
        }
        /* Make it so that the time picker increments / decrements by 5 for minutes */
        private void routeTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.routeTimePicker.Value.Minute % 5 == 0)
                return;
            else if (this.routeTimePicker.Value.Minute % 5 == 1)
                this.routeTimePicker.Value = this.routeTimePicker.Value.AddMinutes(4);
            else if (this.routeTimePicker.Value.Minute % 5 == 4)
                this.routeTimePicker.Value = this.routeTimePicker.Value.AddMinutes(-4);
        }
    }
}
