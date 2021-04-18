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
    public partial class BookFlightPage : Form
    {
        // This form file is to document the actions done on the Book Flight Page specifically
        public static CustomerModel currCustomer; // make a local object that can be read in the current context
        public static bool logOutButtonClicked = false;
        public static bool backButtonClicked = false;
        public static List<string> airportsShown;
        public static List<string> departAirports;
        public static List<string> arriveAirports;
        public static List<Route> availableRoutes; // list of available routes that gets updated throughout the form
        public BookFlightPage()
        {
            InitializeComponent();
        }
        public BookFlightPage(ref CustomerModel customer)
        {
            // This constructor allows for the object to be accessed in this form
            InitializeComponent();
            // get the current customer and pass that information to the textboxes
            currCustomer = customer;
            // create a new list for the airports that will be displayed
            airportsShown = new List<string>();
            departAirports = new List<string>();
            arriveAirports = new List<string>();
        }
        private void BookFlightPage_Load(object sender, EventArgs e)
        {
            // This method gets the available airports/locations that the customer can depart/arrive at
            // It fills the combo boxes with the airport data, sets the default trip to a round trip,
            // and makes the table that shows the available flights initially not visible
            List<Airport> airportList;
            airportList = SqliteDataAccess.GetAirports();
            foreach (Airport airport in airportList)
            {
                string currAir = airport.Code + " (" + airport.Name + ")";
                airportsShown.Add(currAir);
                departAirports.Add(currAir);
                arriveAirports.Add(currAir);
            }
            // add the depart airports and default text
            DepartComboBox.DataSource = departAirports;
            DepartComboBox.SelectedItem = null;
            DepartComboBox.SelectedText = "--Select Location--";
            // add the arrive airports and default text
            ArriveComboBox.DataSource = arriveAirports;
            ArriveComboBox.SelectedItem = null;
            ArriveComboBox.SelectedText = "--Select Location--";
            // set all of the default values and visibility of errors and buttons
            RoundTripButton.Checked = true;
            OneWayButton.Checked = false;
            DifferentLocationError.Visible = false;
            DepartDateError.Visible = false;
            DepartDateAfterTodayError.Visible = false;
            ReturnDateError.Visible = false;
            ReturnBeforeDepartError.Visible = false;
            AvailableFlightTable.Visible = false;
        }
        private void RoundTripButton_Click(object sender, EventArgs e)
        {
            // This method checks if the round trip button is clicked (or it is left as the default),
            // then it makes the return date label and picker visible to the customer
            ReturnDateLabel.Visible = true;
            ReturnDatePicker.Visible = true;
        }
        private void OneWayButton_Click(object sender, EventArgs e)
        {
            // This method checks if the one way button is clicked, then it makes the return date label
            // and picker no longer visible to the customer
            ReturnDateLabel.Visible = false;
            ReturnDatePicker.Visible = false;
        }
        private void DepartDatePicker_ValueChanged(object sender, EventArgs e)
        {
            // When the depart date is changed, this method checks if the entered date is 
            // within 6 months and is today or later. If it is within 6 months and after today or today, then the depart date error stays 
            // not visible to the customer. Otherwise, the depart date error is visible
            // to the customer
            DepartDateError.Visible = false;
            DepartDateAfterTodayError.Visible = false;
            DateTime date = DateTime.Today; // get the current time that the customer wants to depart
            var delta1 = DepartDatePicker.Value.Subtract(date.AddMonths(6)); // get the difference in times between 6 months from now and the depart date
            var delta2 = DepartDatePicker.Value.Subtract(date);
            if (delta1.TotalMinutes > 0)
                DepartDateError.Visible = true;
            else if (delta2.TotalMinutes < 0)
                DepartDateAfterTodayError.Visible = true;
        }
        private void ReturnDatePicker_ValueChanged(object sender, EventArgs e)
        {
            // When the return date is changed, this method checks if the entered date is 
            // within 6 months and is after the depart date. If it is within 6 months and after the depart date, then the return date error stays 
            // not visible to the customer. Otherwise, the return date error is visible
            // to the customer
            ReturnDateError.Visible = false;
            ReturnBeforeDepartError.Visible = false;
            DateTime date = DateTime.Today; // get the current time that the customer wants to return
            var delta1 = ReturnDatePicker.Value.Subtract(date.AddMonths(6)); // get the difference in times between 6 months from now and the depart date
            var delta2 = ReturnDatePicker.Value.Subtract(DepartDatePicker.Value);
            if (delta1.TotalMinutes > 0)
                ReturnDateError.Visible = true;
            else if (delta2.TotalMinutes < 0)
                ReturnBeforeDepartError.Visible = true;
        }
        private void FormatGrid()
        {
            // This method formats the data grid view with different column names
            AvailableFlightTable.Columns[0].HeaderText = "Route ID";
            AvailableFlightTable.Columns[1].HeaderText = "Departure Time";
            AvailableFlightTable.Columns[2].HeaderText = "Estimated Arrival Time";
            AvailableFlightTable.Columns[3].HeaderText = "Estimated Duration";
            AvailableFlightTable.Columns[4].HeaderText = "Number of Layovers";
            AvailableFlightTable.Columns[5].HeaderText = "Flight IDs";
            AvailableFlightTable.Columns[6].HeaderText = "Change Airport Code";
            AvailableFlightTable.Columns[7].HeaderText = "Change Airport Name";
            AvailableFlightTable.Columns[8].HeaderText = "Seats Available on Each Flight";
            AvailableFlightTable.Columns[9].HeaderText = "Cost/Points";
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            // This method first checks if the depart and arrive locations are the same or null.
            // if they are, then errors appear. Otherwise, this method allows the user to select a flight for their depart flight
            DifferentLocationError.Visible = false;
            if (DepartComboBox.SelectedValue == ArriveComboBox.SelectedValue)
                DifferentLocationError.Visible = true;
            else if (String.IsNullOrEmpty(DepartComboBox.SelectedValue.ToString()) || String.IsNullOrEmpty(ArriveComboBox.SelectedValue.ToString()))
                DifferentLocationError.Visible = true;
            else
            {
                AvailableFlightTable.Visible = true;
                // get the route ID and number of Layovers for the specified origin and destination
                List<(int, int)> routeInfo = SqliteDataAccess.GetRouteInfo(DepartComboBox.Text.Substring(0, 3), ArriveComboBox.Text.Substring(0, 3));
                availableRoutes = new List<Route>();
                // go through the route IDs that were found for the specified origin and destination
                // and get the flightIDs in that route, then get information to display to the customer
                foreach ((int, int) id in routeInfo)
                {
                    List<int> flightIDs = SqliteDataAccess.GetFlightIDsInRoute(id.Item1);
                    List<FlightModel> flights = new List<FlightModel>();
                    // initialization/declaration of values to be returned in data grid view
                    string routeList = null;
                    DateTime depart;
                    string departString;
                    DateTime arrive;
                    string arriveString;
                    string changeCode = null;
                    string changeName = null;
                    string seatsAvailable = null;
                    double cost = 0;
                    int points = 0;
                    int i = 0; // used for grabbing information from the availableRoutes list
                    // go through each of these flight IDs and check if the depart date is the same as the 
                    // depart date in the departDatePicker. If it is, get the specific information to be displayed
                    // and add that flight to the list of available flights.
                    // otherwise, do not add it
                    foreach (int fID in flightIDs)
                    {
                        List<string> flightsBookedData = SqliteDataAccess.GetFlightData(fID);
                        if (DateTime.Parse(flightsBookedData[5]).Date == DepartDatePicker.Value.Date)
                        {
                            string originName = SqliteDataAccess.GetFlightNames(flightsBookedData[2]);
                            string destinationName = SqliteDataAccess.GetFlightNames(flightsBookedData[3]);
                            FlightModel flight = new FlightModel(int.Parse(flightsBookedData[0]), int.Parse(flightsBookedData[1]), flightsBookedData[2], originName, flightsBookedData[3], destinationName, int.Parse(flightsBookedData[4]), DateTime.Parse(flightsBookedData[5]), Convert.ToDouble(flightsBookedData[6]), flightsBookedData[7], DateTime.Parse(flightsBookedData[8]), Convert.ToDouble(flightsBookedData[9]), int.Parse(flightsBookedData[10]), int.Parse(flightsBookedData[11]), Convert.ToDouble(flightsBookedData[12]));
                            flights.Add(flight);
                            cost += flights[i].cost;
                            points += flights[i].amountOfPoints;
                            // mainly for formating purposes, check if the current Flight ID is the last in the list
                            // if it is, then do not add extra lines
                            if (fID == flightIDs[flightIDs.Count - 1])
                            {
                                routeList += fID;
                                seatsAvailable += flights[i].numberOfVacantSeats;
                            }
                            else
                            {
                                routeList += fID + Environment.NewLine;
                                changeCode += flights[i].destinationCode + Environment.NewLine;
                                changeName += flights[i].destinationName + Environment.NewLine;
                                seatsAvailable += flights[i].numberOfVacantSeats + Environment.NewLine;
                            }
                            i += 1;
                        }
                    }
                    // as long as the flight count is not 0, get the depart time, arrive time, duration, and total credits, 
                    // add that all to a route object, and add that route object to the available routes list
                    if (flights.Count != 0)
                    {
                        depart = flights[0].departureDateTime;
                        departString = flights[0].departureDateTime.ToShortTimeString();
                        arrive = flights[flightIDs.Count - 1].departureDateTime.AddHours(flights[flightIDs.Count - 1].totalTime);
                        arriveString = flights[flightIDs.Count - 1].departureDateTime.AddHours(flights[flightIDs.Count - 1].totalTime).ToShortTimeString();
                        var duration = arrive.Subtract(depart);
                        string credits = "$" + cost + " (" + points + " points)";
                        Route route = new Route(id.Item1, departString, arriveString, duration, id.Item2, routeList, changeCode, changeName, seatsAvailable, credits);
                        availableRoutes.Add(route);
                    }
                }
                // the available routes list is the datasource for the available flight table
                AvailableFlightTable.DataSource = availableRoutes;
                FormatGrid();

            }
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            // This method allows the user to return to the home page
            // The current form will close
            // The home page will open
            DialogResult result = MessageBox.Show("Are you sure that you want to return home?\nAny changes not saved will not be updated.", "Account Information", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (result == DialogResult.Yes)
            {
                backButtonClicked = true;
                this.Close(); // close the current form if the customer confirms that they would like to log out
                int i = 0;
                // close the log in form and the create customer form
                while (i < Application.OpenForms.Count) // look at what forms are open
                {
                    if (Application.OpenForms[i].Name == "CustomerHomePage")
                        Application.OpenForms[i].Show();// if the current form is the customer home page, show it
                    i += 1;
                }
            }
        }
        private void LogOutButton_Click(object sender, EventArgs e)
        {
            // This method allows the user to return to the log in page
            // All open forms will close
            // The log in page will open
            // A message asks if the customer has saved everything they desire
            DialogResult result = MessageBox.Show("Are you sure that you want to log out?\nAny changes not saved will not be updated.", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (result == DialogResult.Yes)
            {
                logOutButtonClicked = true; // used to access red x later
                CustomerHomePage.logOutButtonClicked = false;
                int i = 0;
                int indexAccount = 0;
                int indexLogIn = 0;
                this.Close();
                while (i < Application.OpenForms.Count) // look at what forms are open
                {
                    if (Application.OpenForms[i].Name != "LogInPage") // get location of other form
                        indexAccount = i;
                    else
                        indexLogIn = i;
                    i += 1;
                }
                Application.OpenForms[indexAccount].Close(); // close other form open
                Application.OpenForms[indexLogIn].Show(); // show the log in page that was hiding
            }
        }
    }
}
