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
    public partial class LoadEngineerAddFlightPage : Form
    {
        private List<Path> paths;
        private static LoadEngineerAddFlightPage instance; //Singleton Pattern Instance
        public LoadEngineerAddFlightPage()
        {
            InitializeComponent();
        }

        /*Method to get the forms instance if one does not exist then
         * create a new form and return the form
         */
        public static LoadEngineerAddFlightPage GetInstance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new LoadEngineerAddFlightPage();
                }
                return instance;
            }
        }

        private void LoadEngineerAddFlightPage_Load(object sender, EventArgs e)
        {
            List<String> airportCodes = new List<string>();
            airportCodes = SqliteDataAccess.GetAirportCodes();
            originDropDown.DataSource = airportCodes;
            airportCodes.Remove(originDropDown.Text);
            destinationDropDown.DataSource = airportCodes;

            routeTimePicker.Format = DateTimePickerFormat.Custom;
            routeTimePicker.CustomFormat = "hh:mm tt";
            routeTimePicker.ShowUpDown = true;
            routeTimePicker.Visible = false;
            routeTimePicker.Value = Convert.ToDateTime("12:00 AM");
            addButton.Visible = false;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            routesGridView.Rows.Clear();
            List<Airport> airports = SqliteDataAccess.GetAirports();
            List<FlightModel> directFlights = SqliteDataAccess.GetDirectFlights();
            Airport origin = airports.Find(airport => airport.Code == originDropDown.Text);
            Airport destination = airports.Find(airport => airport.Code == destinationDropDown.Text);
            PathFinder pf = new PathFinder(origin, destination, airports, directFlights);
            paths = pf.BFS();
            foreach (Path path in paths)
            {
                if (path.NumberOfLayovers == 0)
                    routesGridView.Rows.Add(
                        path.PathID, path.NumberOfLayovers, path.Airports[0].Code,
                        "N/A", "N/A", path.Airports[1].Code);

                else if (path.NumberOfLayovers == 1)
                    routesGridView.Rows.Add(
                        path.PathID, path.NumberOfLayovers, path.Airports[0].Code,
                        path.Airports[1].Code, "N/A", path.Airports[2].Code);

                else
                    routesGridView.Rows.Add(
                        path.PathID, path.NumberOfLayovers, path.Airports[0].Code,
                        path.Airports[1].Code, path.Airports[2].Code, path.Airports[3].Code);
            }
        }

        private void routesGridView_SelectionChanged(object sender, EventArgs e)
        {
            routeTimePicker.Visible = true;
            addButton.Visible = true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Path selectedPath;
            int pathID;
            if (routesGridView.SelectedRows.Count > 0)
            {
                pathID = Convert.ToInt32(routesGridView.SelectedRows[0].Cells["pathID"].Value.ToString());
                selectedPath = paths.Find(path => path.PathID == pathID);

                for (int i = 0; i < selectedPath.NumberOfLayovers + 1; i++)
                {
                    if (SqliteDataAccess.MasterFlightExists(selectedPath.Airports[i].Code,
                        selectedPath.Airports[i+1].Code,
                        routeTimePicker.Value.ToShortTimeString()))
                    {
                        MessageBox.Show("Cannot create flight as it already exists.", "Error: Flight Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                DateTime departureTime = routeTimePicker.Value;
                FlightModel[] flightModels = new FlightModel[selectedPath.NumberOfLayovers + 1];
                int currentFlightID = SqliteDataAccess.GetLastMasterFlightID();
                
                // Double-Check to see if table is empty so currentFlightID is set to 1 rather than 2
                if (currentFlightID == 2) currentFlightID = (SqliteDataAccess.CheckMasterFlightEmpty() == 0) ? 1 : 2;
                for (int i = 0; i < selectedPath.NumberOfLayovers + 1; i++)
                {
                    if (i != 0)
                    {
                        int distance = SqliteDataAccess.GetDirectFlightDistance(
                            selectedPath.Airports[i - 1].Code,
                            selectedPath.Airports[i].Code);

                        /* 
                         * hours is calculated by time it take to get to destination at 500 mph
                         * plus 30 minutes exiting and entering runway 
                         */
                        decimal hours = (decimal)(distance / 500.0) + .5M + (40 / 60.0M);
                        decimal minutes = (decimal)(hours - Math.Floor(hours)) * 60.0M;
                        decimal adjustment = minutes % 5;
                        hours = Math.Floor(hours);
                        if (adjustment != 0) minutes = (minutes - adjustment) + 5;
                        DateTime newDepartureTime = departureTime.AddHours((double)hours).AddMinutes((double)minutes);

                        // Constructing a new flight model for each flight in the path
                        flightModels[i] = new FlightModel(
                            currentFlightID,
                            selectedPath.Airports[i].Code,
                            selectedPath.Airports[i + 1].Code,
                            SqliteDataAccess.GetDirectFlightDistance(
                                selectedPath.Airports[i].Code,
                                selectedPath.Airports[i + 1].Code),
                                newDepartureTime, "Boeing 737 MAX 7");
                        departureTime = newDepartureTime;
                    }
                    else
                    {
                        // Constructing a new flight model for each flight in the path
                        flightModels[i] = new FlightModel(
                            currentFlightID,
                            selectedPath.Airports[i].Code,
                            selectedPath.Airports[i + 1].Code,
                            SqliteDataAccess.GetDirectFlightDistance(
                                selectedPath.Airports[i].Code,
                                selectedPath.Airports[i + 1].Code),
                                departureTime, "Boeing 737 MAX 7");
                    }
                    currentFlightID++;
                }
                SqliteDataAccess.AddFlightToMaster(flightModels);
                LoadEngineerHomePage.GetInstance.LoadFlightGrid();
                LoadEngineerHomePage.GetInstance.Show();
                this.Dispose();
            }
        }

        private void originDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> airportCodes = new List<string>();
            airportCodes = SqliteDataAccess.GetAirportCodes();
            airportCodes.Remove(originDropDown.Text);
            destinationDropDown.DataSource = airportCodes;
        }
        private void destinationDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            LoadEngineerHomePage.GetInstance.LoadFlightGrid();
            LoadEngineerHomePage.GetInstance.Show();
            this.Dispose();
        }

        private void routeTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.routeTimePicker.Value.Minute % 5 == 0) 
                return;
            else if (this.routeTimePicker.Value.Minute % 5 == 1)
                this.routeTimePicker.Value = this.routeTimePicker.Value.AddMinutes(4);
            else if (this.routeTimePicker.Value.Minute % 5 == 4)
                this.routeTimePicker.Value = this.routeTimePicker.Value.AddMinutes(-4);
        }

        private void LoadEngineerAddFlightPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Add message box to ask user if they want to exit program
            //yes than close LogInPage
            //no cancel form close
            LoadEngineerHomePage.GetInstance.Close();
        }
    }
}
