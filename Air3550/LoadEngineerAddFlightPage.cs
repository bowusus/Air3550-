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
        // This file is specifically used for the load engineer add page
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
        /* On loading the page it gets all of the origin and destination
         * codes for the drop down boxes, and sets the routeTimePicker to the
         * correct format while hidding both the time picker and the add flgiht button 
         */
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
            AddFlightButton.Visible = false;
        }
        /* Searchs for all the paths between the selected origin and destination
         */
        private void searchButton_Click(object sender, EventArgs e)
        {
            routesGridView.Rows.Clear();
            List<Airport> airports = SqliteDataAccess.GetAirports();
            List<FlightModel> directFlights = SqliteDataAccess.GetDirectFlights();
            Airport origin = airports.Find(airport => airport.Code == originDropDown.Text);
            Airport destination = airports.Find(airport => airport.Code == destinationDropDown.Text);

            // Create a new pathfinder object based on the origin, destination, airports, and direct flgihts
            PathFinder pf = new PathFinder(origin, destination, airports, directFlights);
            // call the Breadth-First Search algorithm to find all paths from the origin to the destination with
            // less than 3 layovers
            paths = pf.BFS();
            // for every path found create a new row in the data grid view for this page 
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
        /* When a selection for the route is made change the visibility of the time picker and the
         * add button to true */
        private void routesGridView_SelectionChanged(object sender, EventArgs e)
        {
            routeTimePicker.Visible = true;
            AddFlightButton.Visible = true;
        }
        /* Call the helper method to generate all the new master flights and route */
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
                        SqliteDataAccess.UpdateLastMasterID(currentFlightID);
                        currentFlightID++;
                    }

                    /* 
                     * hours is calculated by time it take to get to destination at 500 mph
                     * plus 30 minutes exiting and entering runway. This with give us the duration of the
                     * current flight
                     */
                    decimal hours = (decimal)(distance / 500.0) + .5M + (40 / 60.0M);
                    decimal minutes = (decimal)(hours - Math.Floor(hours)) * 60.0M;
                    decimal adjustment = minutes % 5;
                    hours = Math.Floor(hours);
                    if (adjustment != 0) minutes = (minutes - adjustment) + 5;

                    // Take the duration of the current flight and add it to the departure time so that the
                    // departure time of the next flight is set
                    DateTime newDepartureTime = departureTime.AddHours((double)hours).AddMinutes((double)minutes);
                    departureTime = newDepartureTime;
                }

                int routeID = SqliteDataAccess.GetLastRouteID();
                // No layovers
                if (selectedPath.NumberOfLayovers == 0)
                {
                    // Check to see if the route already exists
                    if (SqliteDataAccess.RouteExists(flightIDs[0].ToString()))
                    {
                        MessageBox.Show("Cannot create route as it already exists.", "Error: Route Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Add route to the routes table
                    SqliteDataAccess.AddToRoute(routeID, selectedPath.Airports[0].Code,
                                                selectedPath.Airports[selectedPath.NumberOfLayovers + 1].Code,
                                                selectedPath.NumberOfLayovers, flightIDs[0].ToString());
                    SqliteDataAccess.UpdateLastRouteID(routeID);
                    // Add any new flights to the flight master table
                    if (newFlights.Count != 0)
                    {
                        SqliteDataAccess.AddFlightToMaster(newFlights);
                        LoadEngineerLoadingPage.GetInstance.Show();
                        LoadEngineerLoadingPage.GetInstance.Refresh();
                        LoadEngineerLoadingPage.GetInstance.Location = this.Location;
                        foreach (FlightModel flight in newFlights) SystemAction.GenerateFlight(flight);
                        LoadEngineerLoadingPage.GetInstance.Dispose();
                    }
                }
                // Only one layover
                else if (selectedPath.NumberOfLayovers == 1)
                {
                    // Check to see if the route already exists
                    if (SqliteDataAccess.RouteExists(flightIDs[0].ToString(), flightIDs[1].ToString()))
                    {
                        MessageBox.Show("Cannot create route as it already exists.", "Error: Route Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Add route to the routes table
                    SqliteDataAccess.AddToRoute(routeID, selectedPath.Airports[0].Code,
                                                selectedPath.Airports[selectedPath.NumberOfLayovers + 1].Code,
                                                selectedPath.NumberOfLayovers, flightIDs[0].ToString(),
                                                flightIDs[1].ToString());
                    SqliteDataAccess.UpdateLastRouteID(routeID);
                    // Add any new flights to the flight master table
                    if (newFlights.Count != 0)
                    {
                        SqliteDataAccess.AddFlightToMaster(newFlights);
                        LoadEngineerLoadingPage.GetInstance.Show();
                        LoadEngineerLoadingPage.GetInstance.Refresh();
                        LoadEngineerLoadingPage.GetInstance.Location = this.Location;
                        foreach (FlightModel flight in newFlights) SystemAction.GenerateFlight(flight);
                        LoadEngineerLoadingPage.GetInstance.Dispose();
                    }
                }
                // Two layovers
                else if (selectedPath.NumberOfLayovers == 2)
                {
                    // Check to see if the route already exists
                    if (SqliteDataAccess.RouteExists(flightIDs[0].ToString(), flightIDs[1].ToString(), flightIDs[2].ToString()))
                    {
                        MessageBox.Show("Cannot create route as it already exists.", "Error: Route Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Add route to the routes table
                    SqliteDataAccess.AddToRoute(routeID, selectedPath.Airports[0].Code,
                                                selectedPath.Airports[selectedPath.NumberOfLayovers + 1].Code,
                                                selectedPath.NumberOfLayovers, flightIDs[0].ToString(),
                                                flightIDs[1].ToString(), flightIDs[2].ToString());
                    SqliteDataAccess.UpdateLastRouteID(routeID);
                    // Add any new flights to the flight master table
                    if (newFlights.Count != 0)
                    {
                        SqliteDataAccess.AddFlightToMaster(newFlights);
                        LoadEngineerLoadingPage.GetInstance.Show();
                        LoadEngineerLoadingPage.GetInstance.Refresh();
                        LoadEngineerLoadingPage.GetInstance.Location = this.Location;
                        foreach (FlightModel flight in newFlights) SystemAction.GenerateFlight(flight);
                        LoadEngineerLoadingPage.GetInstance.Dispose();
                    }
                }
            }
            // Load the home page and dispose of the current page
            LoadEngineerHomePage.GetInstance.LoadFlightGrid();
            LoadEngineerHomePage.GetInstance.Show();
            this.Dispose();
        }
        /* Change the destination codes given if the origin code was changed so that 
         * it is impossible to choose the same origin and destination */
        private void originDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currentDestination = destinationDropDown.Text;
            List<string> destinationCodes = new List<string>();
            destinationCodes = SqliteDataAccess.GetAirportCodes();
            destinationCodes.Remove(originDropDown.Text);
            destinationDropDown.DataSource = destinationCodes;
            
            if(originDropDown.Text != currentDestination) destinationDropDown.Text = currentDestination;
        }
        /* Returns to home page and disposes of the current page when back button
         * is selected */
        private void backButton_Click(object sender, EventArgs e)
        {
            LoadEngineerHomePage.GetInstance.LoadFlightGrid();
            LoadEngineerHomePage.GetInstance.Show();
            this.Dispose();
        }
        /* Make it so that the route time picker only increments in 5 for minutes */
        private void routeTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.routeTimePicker.Value.Minute % 5 == 0) 
                return;
            else if (this.routeTimePicker.Value.Minute % 5 == 1)
                this.routeTimePicker.Value = this.routeTimePicker.Value.AddMinutes(4);
            else if (this.routeTimePicker.Value.Minute % 5 == 4)
                this.routeTimePicker.Value = this.routeTimePicker.Value.AddMinutes(-4);
        }
        /* Ask user if they are sure they want to exit the application then close if the program if they confirm 
         * yes */
        private void LoadEngineerAddFlightPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Add message box to ask user if they want to exit program
            // yes than close LogInPage
            // no cancel form close
            DialogResult result = MessageBox.Show("Are you sure you would like to exit?\nAny changes not saved will not be updated.", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (result == DialogResult.Yes)
                LogInPage.GetInstance.Close();
            else
                e.Cancel = true;
        }
    }
}
