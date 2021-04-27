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
    public partial class CancelFlightPage : Form
    {
        // This form file is to document the actions done on the Cancel Flight Page specifically
        private static CancelFlightPage instance; // singleton instance
        public static CustomerModel currCustomer; // make a local object that can be read in the current context
        public static List<FlightModel> bookedFlights; // list of booked flights that gets updated throughout the form
        public static int tempFlightSelected; // route that the user temporarily selects
        public CancelFlightPage()
        {
            InitializeComponent();
        }
        public CancelFlightPage(ref CustomerModel customer)
        {
            // This constructor allows for the object to be accessed in this form
            InitializeComponent();
            // get the current customer and pass that information to the textboxes
            currCustomer = customer;
        }
        public static CancelFlightPage GetInstance(ref CustomerModel customer)
        {
            // This method follows the singleton pattern to allow for one form to be used rather than multiple being created
            if (instance == null || instance.IsDisposed)
            {
                instance = new CancelFlightPage(ref customer);
            }
            return instance;
        }
        private void CancelFlightPage_Load(object sender, EventArgs e)
        {
            // This method loads all current flights for the current customer
            // These are the flights that the customer has currently booked
            // There can be multiple flights due to a round trip or if a flight has layovers
            NoFlightLabel.Visible = false;
            bookedFlights = new List<FlightModel>();
            int i = 0;
            List<int> flightID = SqliteDataAccess.GetBookedFlightIDs(currCustomer.userID);
            // as long as there are currently booked flights, go through each flight that is currently booked
            // get the flight data, origin and destination airport names, departure and arrival datetimes, costs, and duration
            // add that to the booked flights list
            if (flightID.Count != 0)
            {
                foreach (int fID in flightID)
                {
                    // due to flights being part of a route, get that route id for the current flight
                    // get the number of flight ids in that route
                    int routeID = SqliteDataAccess.GetBookedFlightsRouteID(fID);
                    List<int> flightIDs = SqliteDataAccess.GetFlightIDsInRoute(routeID);
                    int count = flightIDs.Count;

                    List<string> flightData = SqliteDataAccess.GetFlightData(fID);
                    string originName = SqliteDataAccess.GetFlightNames(flightData[2]);
                    string destinationName = SqliteDataAccess.GetFlightNames(flightData[3]);

                    DateTime departureDateTime = DateTime.Parse(flightData[4] + " " + flightData[5]);
                    DateTime arriveDateTime = departureDateTime.AddHours(Convert.ToDouble(flightData[7]));

                    int depHour = departureDateTime.Hour;
                    int arrHour = arriveDateTime.Hour;

                    double currCost;
                    if (i == 0)
                        currCost = SystemAction.CalculateCost(depHour, arrHour, Convert.ToDouble(flightData[9]) + 50);
                    else
                        currCost = SystemAction.CalculateCost(depHour, arrHour, Convert.ToDouble(flightData[9]) + 8);
                    int currPoints = Convert.ToInt32(currCost * 100);

                    var duration = arriveDateTime.Subtract(departureDateTime);
                    duration = new TimeSpan(duration.Ticks / TimeSpan.TicksPerSecond * TimeSpan.TicksPerSecond);

                    departureDateTime = arriveDateTime.Subtract(duration);

                    FlightModel flight = new FlightModel(int.Parse(flightData[0]), int.Parse(flightData[1]), flightData[2], originName, flightData[3], destinationName, int.Parse(flightData[6]), departureDateTime, arriveDateTime, duration, flightData[8], Math.Round(currCost, 2), currPoints, int.Parse(flightData[10]), Convert.ToDouble(flightData[11]));

                    bookedFlights.Add(flight);
                    
                    // use the count of flight ids in the list to determine when to reset i
                    if (i == count - 1)
                        i = 0;
                    else
                        i++;
                }
            }
            // set the booked flights list to be the data source of the table
            CancelFlightTable.DataSource = bookedFlights;
            CancelFlightTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            CancelFlightTable.Visible = true;
            // if the count is 0, then display a label
            if (bookedFlights.Count == 0)
                NoFlightLabel.Visible = true;
            else
                NoFlightLabel.Visible = false;
            FormatDataGrid();
        }
        public void FormatDataGrid()
        {
            // This method renames and removes some columns that do not get updated when the data in the datagridview gets updated
            // Remove some information that the employees need but not the customer
            CancelFlightTable.Columns.Remove("durDouble");
            CancelFlightTable.Columns.Remove("masterFlightID");
            CancelFlightTable.Columns.Remove("firstName");
            CancelFlightTable.Columns.Remove("userid");
            CancelFlightTable.Columns.Remove("lastName");
            CancelFlightTable.Columns.Remove("planeType");
            CancelFlightTable.Columns.Remove("numberOfVacantSeats");
            CancelFlightTable.Columns.Remove("flightIncome");
            CancelFlightTable.Columns.Remove("percentFull");
            // change the name of the columns
            CancelFlightTable.Columns[0].HeaderText = "FlightID";
            CancelFlightTable.Columns[1].HeaderText = "Origin Code";
            CancelFlightTable.Columns[2].HeaderText = "Origin Name";
            CancelFlightTable.Columns[3].HeaderText = "Destination Code";
            CancelFlightTable.Columns[4].HeaderText = "Destination Name";
            CancelFlightTable.Columns[5].HeaderText = "Distance (in miles)";
            CancelFlightTable.Columns[6].HeaderText = "Departure Date and Time";
            CancelFlightTable.Columns[7].HeaderText = "Est. Arrival Date and Time";
            CancelFlightTable.Columns[8].HeaderText = "Est. Duration (h:mm:ss)";
            CancelFlightTable.Columns[9].HeaderText = "Cost (in dollars)";
            CancelFlightTable.Columns[10].HeaderText = "Number of Points";
            CancelFlightTable.ClearSelection();
        }
        private void CancelFlightTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // This method prevents the column header row from being clicked and it gets the route id from the row that has been clicked
            if (e.RowIndex != -1 && CancelFlightTable.Rows[e.RowIndex].Cells[0].Value != null)
                tempFlightSelected = e.RowIndex;
        }
        private void CancelSelectedButton_Click(object sender, EventArgs e)
        {
            // This method cancels the selected flight
            // Tables updated: bookedFlights, cancelledFlights, credits, and availableFlight
            // Points or balance are returned based on what the customer originally used as payment
            // The airline only decreases flight income if the customer cancelling used cash or a credit to pay originally 
            // If there are flights to be cancelled, go through and change the database tables
            // else a label will be displayed to tell the customer that nothing can be cancelled
            if (bookedFlights.Count == 0)
                NoFlightLabel.Visible = true;
            else
            {
                NoFlightLabel.Visible = false;
                DialogResult result = MessageBox.Show("Are you sure that you would like to cancel the selected flight(s)?\nYou will get a refund in the way you paid.", "Cancel Flight", MessageBoxButtons.YesNo, MessageBoxIcon.None);
                if (result == DialogResult.Yes)
                {
                    DateTime time = DateTime.Now; // get the current time that the customer is trying to cancel the flight
                    var delta = bookedFlights[0].departureDateTime.Subtract(time); // get the difference in times between now and departure time
                    // if the difference in time between now and departure time is greater than 60 minutes then the cancellation can proceed
                    // otherwise, a message appears notifying the customer that they can no longer cancel the flight
                    if (delta.TotalMinutes > 60)
                    {
                        int totalPoints = 0;
                        double totalCredit = 0;
                        FlightModel selectedFlight = bookedFlights[tempFlightSelected]; // get the selected row's flight information
                        string paymentMethod = SqliteDataAccess.GetPaymentMethod(currCustomer.userID, selectedFlight.flightID); // get the payment method of the selected flight
                        if (paymentMethod == "Dollars" || paymentMethod == "AirlineCredit")
                        {
                            // if the payment method is dollars or a credit, then cancel the flight, increase the credit the person receives, and delete the flight from the transaction table
                            totalCredit = SystemAction.CancelFlight(currCustomer.userID, selectedFlight, paymentMethod, totalCredit, totalPoints);
                            SqliteDataAccess.DeleteTransaction(currCustomer.userID, selectedFlight.flightID);
                        }
                        else
                        {
                            // if the payment method is points, then cancel the flight, increase the points the person receives, and delete the flight from the transaction table
                            totalPoints = Convert.ToInt32(SystemAction.CancelFlight(currCustomer.userID, selectedFlight, paymentMethod, totalCredit, totalPoints));
                            SqliteDataAccess.DeleteTransaction(currCustomer.userID, selectedFlight.flightID);
                        }
                        // since bookedFlights stores the current flights, those flights need to be updated
                        // the data grid view also needs updating, so set the datasource to null and repopulate it with the bookedFlights list
                        if (totalCredit != 0)
                            MessageBox.Show("Your Flights have been successfully cancelled.\nYour account will now reflect that cancellation.\nYou are receiving " + totalCredit + " dollars credited back to your account.", "Cancel Flight", MessageBoxButtons.OK, MessageBoxIcon.None);
                        else
                            MessageBox.Show("Your Flights have been successfully cancelled.\nYour account will now reflect that cancellation.\nYou are receiving " + totalPoints + " points credited back to your account.", "Cancel Flight", MessageBoxButtons.OK, MessageBoxIcon.None);

                        // clear data source, and add any still booked flights to the data grid view
                        // otherwise, show a no booked flights label and format the grid
                        CancelFlightTable.DataSource = null;
                        bookedFlights.Remove(bookedFlights[tempFlightSelected]);
                        if (bookedFlights.Count == 0)
                            NoFlightLabel.Visible = true;
                        CancelFlightTable.DataSource = bookedFlights;
                        CancelFlightTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        FormatDataGrid(); // remove and rename certain columns
                    }
                    else
                        MessageBox.Show("You are within an hour of your flight and can no longer cancel it", "Error: Cannot Cancel Flight", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CancelAllFlightsButton_Click(object sender, EventArgs e)
        {
            // This method cancels all flights
            // It checks if the first flight does not occur within an hour. If it does, then a pop up appears.
            // If the first flight does not occur within an hour, all of the flights are cancelled, and the specific
            // tables are updated
            // Tables updated: bookedFlights, cancelledFlights, credits, availableFlight, and transactionTable
            // Points or balanced are returned based on what the customer originally used as payment
            // The airline only decreases flight income if the customer cancelling used cash or a credit to pay originally 
            // If there are flights to be cancelled, go through and change the database tables
            // else produce a pop up saying nothing can be cancelled
            if (bookedFlights.Count == 0)
                NoFlightLabel.Visible = true;
            else
            {
                NoFlightLabel.Visible = false;
                DialogResult result = MessageBox.Show("Are you sure that you would like to cancel your scheduled flight(s)?\nAll flights will be cancelled, and you will get a refund in the way you paid.", "Cancel Flight", MessageBoxButtons.YesNo, MessageBoxIcon.None);
                if (result == DialogResult.Yes)
                {
                    DateTime time = DateTime.Now; // get the current time that the customer is trying to cancel the flight
                    int totalPoints = 0;
                    double totalCredit = 0;
                    int withinHour = 0;
                    int flightCount = bookedFlights.Count;
                    // since all of the flights are to deleted, go through each flight, and delete the flight and transaction and credit the customer's account
                    foreach (FlightModel flight in bookedFlights)
                    {
                        // if the difference in time between now and departure time is great than 60 minutes then the cancellation can proceed
                        // otherwise, increment a counter, to then show to the customer than some of their flights cannot be cancelled
                        var delta = flight.departureDateTime.Subtract(time); // get the difference in times between now and departure time
                        if (delta.TotalMinutes > 60)
                        {
                            string paymentMethod = SqliteDataAccess.GetPaymentMethod(currCustomer.userID, flight.flightID); // get the current flight's payment method
                            if (paymentMethod == "Dollars" || paymentMethod == "AirlineCredit")
                            {
                                // if the payment method is dollars or a credit, then cancel the flight, increase the credit the person receives, and delete the flight from the transaction table
                                totalCredit = SystemAction.CancelFlight(currCustomer.userID, flight, paymentMethod, totalCredit, totalPoints);
                                SqliteDataAccess.DeleteTransaction(currCustomer.userID, flight.flightID);
                            }
                            else
                            {
                                // if the payment method is points, then cancel the flight, increase the points the person receives, and delete the flight from the transaction table
                                totalPoints = Convert.ToInt32(SystemAction.CancelFlight(currCustomer.userID, flight, paymentMethod, totalCredit, totalPoints));
                                SqliteDataAccess.DeleteTransaction(currCustomer.userID, flight.flightID);
                            }
                        }
                        else
                            withinHour += 1;
                    }
                    if (withinHour != 0)
                        MessageBox.Show(withinHour + " of your flights is/are within an hour of your flight and can no longer be cancelled", "Error: Cannot Cancel Flight", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // since bookedFlights stores the current flights, those flights need to be updated
                    // the data grid view also needs updating, so set the datasource to null and repopulate it with the bookedFlights list
                    if (withinHour != flightCount)
                    {
                        if (totalCredit != 0)
                            MessageBox.Show("Your Flights have been successfully cancelled.\nYour account will now reflect that cancellation.\nYou are receiving " + totalCredit + " dollars credited back to your account.", "Cancel Flight", MessageBoxButtons.OK, MessageBoxIcon.None);
                        else
                            MessageBox.Show("Your Flights have been successfully cancelled.\nYour account will now reflect that cancellation.\nYou are receiving " + totalPoints + " points credited back to your account.", "Cancel Flight", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    // clear data source, and add any still booked flights to the data grid view
                    // otherwise, show a no booked flights label and format the grid
                    CancelFlightTable.DataSource = null;
                    // all of the flights should be taken out of the database, but if there are any, then they are displayed --> just like a catch all
                    // otherwise, bookedFlights is cleared and a no flights label is displayed
                    bookedFlights = new List<FlightModel>();
                    int i = 0;
                    List<int> flightID = SqliteDataAccess.GetBookedFlightIDs(currCustomer.userID);
                    if (flightID.Count != 0)
                    {
                        foreach (int fID in flightID)
                        {
                            // due to flights being part of a route, get that route id for the current flight
                            // get the number of flight ids in that route
                            int routeID = SqliteDataAccess.GetBookedFlightsRouteID(fID);
                            List<int> flightIDs = SqliteDataAccess.GetFlightIDsInRoute(routeID);
                            int count = flightIDs.Count;

                            List<string> flightData = SqliteDataAccess.GetFlightData(fID);
                            string originName = SqliteDataAccess.GetFlightNames(flightData[2]);
                            string destinationName = SqliteDataAccess.GetFlightNames(flightData[3]);

                            DateTime departureDateTime = DateTime.Parse(flightData[4] + " " + flightData[5]);
                            DateTime arriveDateTime = departureDateTime.AddHours(Convert.ToDouble(flightData[7]));

                            int depHour = departureDateTime.Hour;
                            int arrHour = arriveDateTime.Hour;

                            double currCost;
                            if (i == 0)
                                currCost = SystemAction.CalculateCost(depHour, arrHour, Convert.ToDouble(flightData[9]) + 50);
                            else
                                currCost = SystemAction.CalculateCost(depHour, arrHour, Convert.ToDouble(flightData[9]) + 8);
                            int currPoints = Convert.ToInt32(currCost * 100);

                            var duration = arriveDateTime.Subtract(departureDateTime);
                            duration = new TimeSpan(duration.Ticks / TimeSpan.TicksPerSecond * TimeSpan.TicksPerSecond);

                            departureDateTime = arriveDateTime.Subtract(duration);

                            FlightModel flight = new FlightModel(int.Parse(flightData[0]), int.Parse(flightData[1]), flightData[2], originName, flightData[3], destinationName, int.Parse(flightData[6]), departureDateTime, arriveDateTime, duration, flightData[8], Math.Round(currCost, 2), currPoints, int.Parse(flightData[10]), Convert.ToDouble(flightData[11]));

                            bookedFlights.Add(flight);
                            // use the count of flight ids in the list to determine when to reset i
                            if (i == count - 1)
                                i = 0;
                            else
                                i++;
                        }
                    }
                    else
                    {
                        // clear the list of flights booked and display no flights label
                        bookedFlights.Clear();
                        NoFlightLabel.Visible = true;
                    }
                    CancelFlightTable.DataSource = bookedFlights;
                    CancelFlightTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    FormatDataGrid(); // remove and rename certain columns
                }
            }
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            // This methods allows the user to return to the Log In page
            // The current form will close
            // The customer home page will open
            DialogResult result = MessageBox.Show("Are you sure that you want to return home?\nAny changes not saved will not be updated.", "Account Information", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (result == DialogResult.Yes)
            {
                CustomerHomePage.GetInstance(ref currCustomer).Show();
                this.Dispose();
            }
        }
        private void LogOutButton_Click(object sender, EventArgs e)
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
        private void CancelFlightPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            // This method allows the exit button to be used to end the application
            // If the exit button is clicked, a message will make sure the customer wants to leave
            // then the application ends or the customer cancels
            DialogResult result = MessageBox.Show("Are you sure you would like to exit?\nAny changes not saved will not be updated.", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (result == DialogResult.Yes)
                LogInPage.GetInstance.Close();
            else
                e.Cancel = true;
        }
    }
}
