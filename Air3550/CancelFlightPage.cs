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
        public static CustomerModel currCustomer; // make a local object that can be read in the current context
        public static List<FlightModel> bookedFlights; // list of booked flights that gets updated throughout the form
        // the following variables are used to check what button is clicked to access red x 
        public static bool cancelFlightButtonClicked = false; 
        public static bool logOutButtonClicked = false;
        public static bool backButtonClicked = false;
        public CancelFlightPage()
        {
            InitializeComponent();
        }
        public CancelFlightPage(ref CustomerModel customer)
        {
            // This constructor allows for the object to be accessed in this form
            InitializeComponent();
            // set all of the buttons to false (not being clicked yet)
            cancelFlightButtonClicked = false;
            logOutButtonClicked = false;
            backButtonClicked = false;
            // get the current customer and pass that information to the textboxes
            currCustomer = customer;
        }
        private void CancelFlightPage_Load(object sender, EventArgs e)
        {
            // The main reason for this method is to fill the datagridview initially
            // This method loads all current flights for the current customer
            // These are the flights that the customer can cancel
            // There can be multiple flights due to a round trip or if a flight has layovers
            List<int> flightIDs;
            bookedFlights = new List<FlightModel>();
            flightIDs = SqliteDataAccess.GetCurrentFlightIDs(currCustomer.userID); // get the flight ids of the customer's current flights 
            // for each of these ids, get the flight information (origin, destination, etc.)
            // Then get the name of the airports
            // Finally create a FlightModel object with that information and add it to a list of booked flights to be displayed to the customer
            foreach (int id in flightIDs) 
            {
                List<string> flightsBookedData = SqliteDataAccess.GetFlightData(id);
                string originName = SqliteDataAccess.GetFlightNames(flightsBookedData[1]);
                string destinationName = SqliteDataAccess.GetFlightNames(flightsBookedData[2]);
                FlightModel flight = new FlightModel(int.Parse(flightsBookedData[0]), flightsBookedData[1], originName, flightsBookedData[2], destinationName, int.Parse(flightsBookedData[3]), DateTime.Parse(flightsBookedData[4]), Convert.ToDouble(flightsBookedData[5]), flightsBookedData[6], DateTime.Parse(flightsBookedData[7]), Convert.ToDouble(flightsBookedData[8]), int.Parse(flightsBookedData[9]), int.Parse(flightsBookedData[10]), Convert.ToDouble(flightsBookedData[11]));
                bookedFlights.Add(flight);
            }
            // This list of FlightModel objects will be the data source of the datagridview table
            CancelFlightTable.DataSource = bookedFlights;
            FormatDataGrid();
        }
        public void FormatDataGrid()
        {
            // This method renames and removes some columns that do not get updated when the data in the datagridview gets updated
            // Remove some information that the employees need but not the customer
            CancelFlightTable.Columns.Remove("planeType");
            CancelFlightTable.Columns.Remove("dateCreated");
            CancelFlightTable.Columns.Remove("numberOfVacantSeats");
            CancelFlightTable.Columns.Remove("flightIncome");
            // change the name of the columns
            CancelFlightTable.Columns[0].HeaderText = "FlightID";
            CancelFlightTable.Columns[1].HeaderText = "Origin Code";
            CancelFlightTable.Columns[2].HeaderText = "Origin Name";
            CancelFlightTable.Columns[3].HeaderText = "Destination Code";
            CancelFlightTable.Columns[4].HeaderText = "Destination Name";
            CancelFlightTable.Columns[5].HeaderText = "Distance";
            CancelFlightTable.Columns[6].HeaderText = "Departure Date and Time";
            CancelFlightTable.Columns[7].HeaderText = "Total Time";
            CancelFlightTable.Columns[8].HeaderText = "Cost";
            CancelFlightTable.Columns[9].HeaderText = "Amount of Points";
        }
        private void CancelFlightButton_Click(object sender, EventArgs e)
        {
            // This method cancels the customer's currently booked flights
            // All flights will be cancelled at once
            // Tables updated: bookedFlights, cancelledFlights, credits, and availableFlight
            // Points or balanced are returned based on what the customer originally used as payment
            // The airline only decreases flight income if the customer cancelling used cash to pay originally 
            DateTime time = DateTime.Now; // get the current time that the customer is trying to cancel the flight
            // All of the flights will be cancelled, so bookedFlights is referenced to access each flight 
            // If there are flights to be cancelled, go through and change the database tables
            // else produce a pop up saying nothing can be cancelled
            if (bookedFlights.Count == 0)
                MessageBox.Show("You do not have any flights to be cancelled at the moment.\nReturn to the home page and book a flight.", "Error: Cancel Flight", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                foreach (FlightModel flight in bookedFlights)
                {
                    DialogResult result = MessageBox.Show("Are you sure that you would like to cancel your scheduled flight(s)?\nAll flights will be cancelled, and you will get a refund in the way you paid.", "Cancel Flight", MessageBoxButtons.YesNo, MessageBoxIcon.None);
                    if (result == DialogResult.Yes)
                    {
                        var delta = flight.departureDateTime.Subtract(time); // get the difference in times between now and departure time
                        cancelFlightButtonClicked = true; // used to access the red x later
                                                          // if the difference in time between now and departure time is great than 60 minutes then the cancellation can proceed
                                                          // otherwise, a message appears notifying the customer that they can no longer cancel the flight
                        if (delta.TotalMinutes > 60)
                        {
                            // move this flight from booked to cancelled and increase the number of vacant seats on the plain
                            string paymentMethod = SqliteDataAccess.GetPaymentMethod(currCustomer.userID);
                            SqliteDataAccess.CancelBookedFlight(currCustomer.userID);
                            SqliteDataAccess.AddToCancelledFlights(currCustomer.userID, flight.flightID);
                            SqliteDataAccess.UpdateNumOfVacantSeats(flight.flightID, flight.numberOfVacantSeats + 1);
                            // depending on the payment method, the customer will either get cash back from the airline
                            // which will also decrease their total flight income
                            // or they will receive points back, increasing available points and decreasing used points
                            if (paymentMethod == "Dollars")
                            {
                                int bal = SqliteDataAccess.GetBalance(currCustomer.userID);
                                SqliteDataAccess.UpdateBalance(currCustomer.userID, bal + flight.cost);
                                SqliteDataAccess.UpdateFlightIncome(flight.flightID, flight.flightIncome - flight.cost);
                            }
                            else
                            {
                                int available = SqliteDataAccess.GetAvailablePoints(currCustomer.userID);
                                int used = SqliteDataAccess.GetUsedPoints(currCustomer.userID);
                                SqliteDataAccess.UpdateAvailablePoints(currCustomer.userID, available + flight.amountOfPoints);
                                SqliteDataAccess.UpdateUsedPoints(currCustomer.userID, used - flight.amountOfPoints);
                            }
                            // since bookedFlights stores the current flights, those flights need to be updated
                            // the data grid view also needs updating, so set the datasource to null and repopulate it with the bookedFlights list
                            bookedFlights = SystemAction.GetCurrentFlights(currCustomer.userID);
                            CancelFlightTable.DataSource = null;
                            CancelFlightTable.DataSource = bookedFlights;
                            FormatDataGrid(); // remove and rename certain columns
                            MessageBox.Show("Your Flights have been successfully cancelled.\nYour account will now reflect that cancellation.", "Cancel Flight", MessageBoxButtons.OK, MessageBoxIcon.None);
                            this.Close(); // close the current form
                            int i = 0;
                            // close the log in form and the cancel flight form
                            while (i < Application.OpenForms.Count) // look at what forms are open
                            {
                                if (Application.OpenForms[i].Name == "CustomerHomePage")
                                    Application.OpenForms[i].Show();// if the current form is the customer home page, show it
                                i += 1;
                            }
                        }
                        else
                            MessageBox.Show("You are within an hour of your flight and can no longer cancel it", "Error: Cannot Cancel Flight", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            // This methods allows the user to return to the home page
            // The current form will close
            // The home page will open
            DialogResult result = MessageBox.Show("Are you sure that you want to return home?\nAny changes not saved will not be updated.", "Account Information", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (result == DialogResult.Yes)
            {
                backButtonClicked = true; // used to access red x later
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
                this.Close(); // close current form
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
        private void CancelFlightPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            // This method allows the red X to be used to end the application
            // If the red X is clicked, a message will make sure the customer wants to leave
            // then the application ends or the customer cancels
            /*if (CancelFlightPage.backButtonClicked == false && CancelFlightPage.logOutButtonClicked == false && CancelFlightPage.cancelFlightButtonClicked == false && e.CloseReason != CloseReason.ApplicationExitCall)
            {
                DialogResult result = MessageBox.Show("Are you sure that you want to exit?\nAny changes not saved will not be updated.", "Exit Air3550", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (result == DialogResult.Yes)
                    Application.Exit(); // close the application
                else
                    e.Cancel = true; // cancel the closing of the form
            }*/
        }
    }
}
