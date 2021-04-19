﻿using ClassLibrary;
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
        public static int tempFlightSelected; // route that the user temporarily selects
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
            //List<int> flightIDs;
            bookedFlights = new List<FlightModel>();
            List<int> routeIDs = SqliteDataAccess.GetBookedFlightsRouteID(currCustomer.userID);
            if (routeIDs.Count != 0)
            {
                foreach (int rID in routeIDs)
                {
                    List<FlightModel> flights = SystemAction.GetCurrentFlights(rID);
                    foreach (FlightModel flight in flights)
                        bookedFlights.Add(flight);
                }
            }
            // This list of FlightModel objects will be the data source of the datagridview table
            CancelFlightTable.DataSource = bookedFlights;
            FormatDataGrid();
            if (bookedFlights.Count == 0)
                NoFlightLabel.Visible = true;
            else
                NoFlightLabel.Visible = false;
        }
        public void FormatDataGrid()
        {
            // This method renames and removes some columns that do not get updated when the data in the datagridview gets updated
            // Remove some information that the employees need but not the customer
            CancelFlightTable.Columns.Remove("masterFlightID");
            CancelFlightTable.Columns.Remove("planeType");
            CancelFlightTable.Columns.Remove("distance");
            CancelFlightTable.Columns.Remove("numberOfVacantSeats");
            CancelFlightTable.Columns.Remove("flightIncome");
            // change the name of the columns
            CancelFlightTable.Columns[0].HeaderText = "FlightID";
            CancelFlightTable.Columns[1].HeaderText = "Origin Code";
            CancelFlightTable.Columns[2].HeaderText = "Origin Name";
            CancelFlightTable.Columns[3].HeaderText = "Destination Code";
            CancelFlightTable.Columns[4].HeaderText = "Destination Name";
            CancelFlightTable.Columns[5].HeaderText = "Departure Date and Time";
            CancelFlightTable.Columns[6].HeaderText = "Duration";
            CancelFlightTable.Columns[7].HeaderText = "Cost";
            CancelFlightTable.Columns[8].HeaderText = "Number of Points";
        }
        private void CancelFlightTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // This method prevents the column header row from being clicked and it gets the route id from the row that has been clicked
            if (e.RowIndex != -1 && CancelFlightTable.Rows[e.RowIndex].Cells[0].Value != null)
                tempFlightSelected = e.RowIndex;
        }
        private void CancelSelectedFlightButton_Click(object sender, EventArgs e)
        {
            // This method cancels the selected flight
            // Tables updated: bookedFlights, cancelledFlights, credits, and availableFlight
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
                    var delta = bookedFlights[0].departureDateTime.Subtract(time); // get the difference in times between now and departure time
                    cancelFlightButtonClicked = true; // used to access the red x later
                                                      // if the difference in time between now and departure time is great than 60 minutes then the cancellation can proceed
                                                      // otherwise, a message appears notifying the customer that they can no longer cancel the flight
                    if (delta.TotalMinutes > 60)
                    {
                        int totalPoints = 0;
                        double totalCredit = 0;
                        FlightModel selectedFlight = bookedFlights[tempFlightSelected];
                        string paymentMethod = SqliteDataAccess.GetPaymentMethod(currCustomer.userID, selectedFlight.flightID);
                        if (paymentMethod == "Dollars" || paymentMethod == "AirlineCredit")
                        {
                            totalCredit = SystemAction.CancelFlight(currCustomer.userID, selectedFlight, paymentMethod, totalCredit, totalPoints);
                            SqliteDataAccess.DeleteTransaction(currCustomer.userID, selectedFlight.flightID);
                        }
                        else
                        {
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
                    var delta = bookedFlights[0].departureDateTime.Subtract(time); // get the difference in times between now and departure time
                    cancelFlightButtonClicked = true; // used to access the red x later
                                                      // if the difference in time between now and departure time is great than 60 minutes then the cancellation can proceed
                                                      // otherwise, a message appears notifying the customer that they can no longer cancel the flight
                    if (delta.TotalMinutes > 60)
                    {
                        int totalPoints = 0;
                        double totalCredit = 0;
                        foreach (FlightModel flight in bookedFlights)
                        {
                            string paymentMethod = SqliteDataAccess.GetPaymentMethod(currCustomer.userID, flight.flightID);
                            if (paymentMethod == "Dollars" || paymentMethod == "AirlineCredit")
                            {
                                totalCredit = SystemAction.CancelFlight(currCustomer.userID, flight, paymentMethod, totalCredit, totalPoints);
                                SqliteDataAccess.DeleteTransaction(currCustomer.userID, flight.flightID);
                            }
                            else
                            {
                                totalPoints = Convert.ToInt32(SystemAction.CancelFlight(currCustomer.userID, flight, paymentMethod, totalCredit, totalPoints));
                                SqliteDataAccess.DeleteTransaction(currCustomer.userID, flight.flightID);
                            }
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
                        List<int> routeIDs = SqliteDataAccess.GetBookedFlightsRouteID(currCustomer.userID);
                        if (routeIDs.Count != 0)
                        {
                            foreach (int rID in routeIDs)
                            {
                                List<FlightModel> flights = SystemAction.GetCurrentFlights(rID);
                                foreach (FlightModel flight in flights)
                                    bookedFlights.Add(flight);
                            }
                        }
                        else
                        {
                            bookedFlights.Clear();
                            NoFlightLabel.Visible = true;
                        }
                        CancelFlightTable.DataSource = bookedFlights;
                        FormatDataGrid(); // remove and rename certain columns
                    }
                    else
                        MessageBox.Show("You are within an hour of your flight and can no longer cancel it", "Error: Cannot Cancel Flight", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
