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
        private static LoadEngineerEditFlightPage instance;
        private List<Path> paths;
        public LoadEngineerEditFlightPage()
        {
            InitializeComponent();
        }

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

        private void LoadEngineerEditFlightPage_Load(object sender, EventArgs e)
        {
            List<String> airportCodes = new List<string>();
            airportCodes = SqliteDataAccess.GetAirportCodes();
            originDropDown.DataSource = airportCodes;
            airportCodes.Remove(originDropDown.Text);
            destinationDropDown.DataSource = airportCodes;

            originDropDown.SelectedIndex = originDropDown.FindStringExact(LoadEngineerHomePage.GetInstance.OriginCode);
            destinationDropDown.SelectedIndex = destinationDropDown.FindStringExact(LoadEngineerHomePage.GetInstance.DestinationCode);

            routeTimePicker.Format = DateTimePickerFormat.Custom;
            routeTimePicker.CustomFormat = "hh:mm tt";
            routeTimePicker.ShowUpDown = true;
            routeTimePicker.Value = Convert.ToDateTime(LoadEngineerHomePage.GetInstance.Time);
        }

        private void originDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> airportCodes = new List<string>();
            airportCodes = SqliteDataAccess.GetAirportCodes();
            airportCodes.Remove(originDropDown.Text);
            destinationDropDown.DataSource = airportCodes;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (routesGridView.SelectedRows.Count > 0)
            {
                Path selectedPath;
                int pathID;
                if (routesGridView.SelectedRows.Count > 0)
                {
                    pathID = Convert.ToInt32(routesGridView.SelectedRows[0].Cells["pathID"].Value.ToString());
                    selectedPath = paths.Find(path => path.PathID == pathID);

                    DateTime departureTime = routeTimePicker.Value;
                    List<FlightModel> flightModels = new List<FlightModel>();
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
                    SqliteDataAccess.RemoveMasterFlight(LoadEngineerHomePage.GetInstance.FlightID);
                    LoadEngineerHomePage.GetInstance.LoadFlightGrid();
                    LoadEngineerHomePage.GetInstance.Show();
                    this.Dispose();
                }
            }
            else
            {
                int newFlightID = SqliteDataAccess.GetLastMasterFlightID();
                SqliteDataAccess.ChangeTimeMaster(LoadEngineerHomePage.GetInstance.FlightID, routeTimePicker.Value, newFlightID);
                LoadEngineerHomePage.GetInstance.LoadFlightGrid();
                LoadEngineerHomePage.GetInstance.Show();
                this.Dispose();
            }
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

        private void LoadEngineerEditFlightPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Add message box to ask user if they want to exit program
            //yes than close LogInPage
            //no cancel form close
            LoadEngineerHomePage.GetInstance.Close();
        }
    }
}
