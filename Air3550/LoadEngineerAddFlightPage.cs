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
            List<string> originCodes = new List<string>();
            List<string> destinationCodes = new List<string>();
            originCodes = SqliteDataAccess.GetAirportCodes();
            destinationCodes = SqliteDataAccess.GetAirportCodes();
            originDropDown.DataSource = originCodes;
            destinationCodes.Remove(originDropDown.Text);
            destinationDropDown.DataSource = destinationCodes;

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
            generateFlightsAndRoute();
        }

        /*
         * Helper method to generate all new Flights and the Route for the selected path
         * 
         */
        private void generateFlightsAndRoute()
        {
            List<int> flightIDs = new List<int>();
            Path selectedPath;
            int pathID;

            if (routesGridView.SelectedRows.Count > 0)
            {
                pathID = Convert.ToInt32(routesGridView.SelectedRows[0].Cells["pathID"].Value.ToString());
                selectedPath = paths.Find(path => path.PathID == pathID);

                DateTime departureTime = routeTimePicker.Value;
                int currentFlightID = SqliteDataAccess.GetLastMasterFlightID();
                List<FlightModel> newFlights = new List<FlightModel>();

                // loop through selected path creating flights for each pair of airports if it
                // does not already exist
                for (int i = 0; i < selectedPath.NumberOfLayovers + 1; i++)
                {
                    int distance = SqliteDataAccess.GetDirectFlightDistance(selectedPath.Airports[i].Code,
                                                        selectedPath.Airports[i + 1].Code);

                    // if the flight in the route exists then add its flight id to the list
                    if (SqliteDataAccess.MasterFlightExists(selectedPath.Airports[i].Code,
                                        selectedPath.Airports[i + 1].Code,
                                        departureTime.ToShortTimeString()))
                    {
                        flightIDs.Add(SqliteDataAccess.GetFlightIDFromMaster(selectedPath.Airports[i].Code,
                                                                              selectedPath.Airports[i + 1].Code,
                                                                              departureTime.ToShortTimeString()));
                    }
                    // create a new flight and add it to new flight list
                    else 
                    {
                        newFlights.Add(new FlightModel(currentFlightID, selectedPath.Airports[i].Code,
                                                       selectedPath.Airports[i + 1].Code, distance,
                                                       departureTime, "Boeing 737 MAX 7"));
                        flightIDs.Add(currentFlightID);
                        currentFlightID++;
                    }

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
                    departureTime = newDepartureTime;
                }

                int routeID = SqliteDataAccess.GetLastRouteID();
                if (selectedPath.NumberOfLayovers == 0)
                {
                    if (SqliteDataAccess.RouteExists(flightIDs[0].ToString()))
                    {
                        MessageBox.Show("Cannot create route as it already exists.", "Error: Route Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    SqliteDataAccess.AddToRoute(routeID, selectedPath.Airports[0].Code,
                                                selectedPath.Airports[selectedPath.NumberOfLayovers + 1].Code,
                                                selectedPath.NumberOfLayovers, flightIDs[0].ToString());
                    if (newFlights.Count != 0)
                    {
                        SqliteDataAccess.AddFlightToMaster(newFlights);
                        foreach (FlightModel flight in newFlights) SystemAction.GenerateFlight(flight);
                    }
                }
                else if (selectedPath.NumberOfLayovers == 1)
                {
                    if (SqliteDataAccess.RouteExists(flightIDs[0].ToString(), flightIDs[1].ToString()))
                    {
                        MessageBox.Show("Cannot create route as it already exists.", "Error: Route Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    SqliteDataAccess.AddToRoute(routeID, selectedPath.Airports[0].Code,
                                                selectedPath.Airports[selectedPath.NumberOfLayovers + 1].Code,
                                                selectedPath.NumberOfLayovers, flightIDs[0].ToString(),
                                                flightIDs[1].ToString());
                    if (newFlights.Count != 0)
                    {
                        SqliteDataAccess.AddFlightToMaster(newFlights);
                        foreach (FlightModel flight in newFlights) SystemAction.GenerateFlight(flight);
                    }
                }
                else if (selectedPath.NumberOfLayovers == 2)
                {
                    if(SqliteDataAccess.RouteExists(flightIDs[0].ToString(), flightIDs[1].ToString(), flightIDs[2].ToString()))
                    {
                        MessageBox.Show("Cannot create route as it already exists.", "Error: Route Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    SqliteDataAccess.AddToRoute(routeID, selectedPath.Airports[0].Code,
                                                selectedPath.Airports[selectedPath.NumberOfLayovers + 1].Code,
                                                selectedPath.NumberOfLayovers, flightIDs[0].ToString(),
                                                flightIDs[1].ToString(), flightIDs[2].ToString());
                    if (newFlights.Count != 0)
                    {
                        SqliteDataAccess.AddFlightToMaster(newFlights);
                        foreach (FlightModel flight in newFlights) SystemAction.GenerateFlight(flight);
                    }
                }
            }
            LoadEngineerHomePage.GetInstance.LoadFlightGrid();
            LoadEngineerHomePage.GetInstance.Show();
            this.Dispose();
        }

        private void originDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currentDestination = destinationDropDown.Text;
            List<string> destinationCodes = new List<string>();
            destinationCodes = SqliteDataAccess.GetAirportCodes();
            destinationCodes.Remove(originDropDown.Text);
            destinationDropDown.DataSource = destinationCodes;
            
            if(originDropDown.Text != currentDestination) destinationDropDown.Text = currentDestination;
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

        private void routesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
