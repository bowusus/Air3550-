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
    public partial class PaymentPage : Form
    {
        // This form file is to document the actions done on the Payment Page specifically
        private static PaymentPage instance;
        public static CustomerModel currCustomer; // make a local object that can be read in the current context
        public static List<Route> selectedRoutes; // make a local object that can be read in the current context
        public static double total = 0;
        public static int points = 0;
        public PaymentPage()
        {
            InitializeComponent();
        }
        public PaymentPage(ref CustomerModel customer, List<Route> routes, DateTime depart, DateTime returnDate, string origin, string destination)
        {
            // This constructor allows for the object to be accessed in this form
            InitializeComponent();
            // get the current customer and pass that information to the textboxes
            currCustomer = customer;
            selectedRoutes = routes;
            // set the default values in various text boxes
            DepartureFlightLabel.Text = DepartureFlightLabel.Text + depart.Date.ToString("MM/dd/yyyy");
            ReturnFlightLabel.Text = ReturnFlightLabel.Text + returnDate.Date.ToString("MM/dd/yyyy");
            DepartureCitiesLabel.Text = origin + " → " + destination;
            ReturnCitiesLabel.Text = destination + " → " + origin;
        }
        public static PaymentPage GetInstance(ref CustomerModel customer, List<Route> routes, DateTime depart, DateTime returnDate, string origin, string destination)
        {
            // This method follows the singleton pattern to allow for one form to be used rather than multiple being created
            if (instance == null || instance.IsDisposed)
            {
                instance = new PaymentPage(ref customer, routes, depart, returnDate, origin, destination);
            }
            return instance;
        }
        private void PaymentPage_Load(object sender, EventArgs e)
        {
            // This method initally loads a variety of information into the textboxes and shows or doesn't show the labels depending on the input
            // if there is a return flight booked, then the return flight information is shown 
            // otherwise, only show the departure flight
            int indexOfSpace;
            int indexOfPoints;
            if (selectedRoutes.Count == 1)
            {
                // if there is only one flight, then the return information will not be shown
                ReturnFlightDetailsTable.Visible = false;
                ReturnCitiesLabel.Visible = false;
                ReturnFlightLabel.Visible = false;
            } 
            else 
            {
                // if there are two flights chosen, then the return information is shown as well
                // the total price and points are increased as well
                ReturnFlightDetailsTable.Rows.Add(selectedRoutes[1].routeID, selectedRoutes[1].departTime, selectedRoutes[1].arriveTime, selectedRoutes[1].duration, selectedRoutes[1].numOfLayovers, selectedRoutes[1].flightIDs, selectedRoutes[1].planeChange, selectedRoutes[1].availableSeats, selectedRoutes[1].credits);
                ReturnFlightDetailsTable.ClearSelection();
                // the credits are shown as a string, so the price and points need to be parsed out 
                indexOfSpace = selectedRoutes[1].credits.IndexOf(" ");
                indexOfPoints = selectedRoutes[1].credits.IndexOf("p") - 1;
                // increase the total price with the price of the return flight
                total += Convert.ToDouble(selectedRoutes[1].credits.Substring(1, indexOfSpace - 1));
                indexOfSpace += 2;
                // increase the total points with the points of the departure flight
                points += int.Parse(selectedRoutes[1].credits.Substring(indexOfSpace, indexOfPoints-indexOfSpace));
            }
            // regardless of whether there is 1 or 2 flights included, the departure flight details will be shown with no row selected
            DepartureFlightDetailsTable.Rows.Add(selectedRoutes[0].routeID, selectedRoutes[0].departTime, selectedRoutes[0].arriveTime, selectedRoutes[0].duration, selectedRoutes[0].numOfLayovers, selectedRoutes[0].flightIDs, selectedRoutes[0].planeChange, selectedRoutes[0].availableSeats, selectedRoutes[0].credits);
            DepartureFlightDetailsTable.ClearSelection();
            // the credits are shown as a string, so the price and points need to be parsed out 
            indexOfSpace = selectedRoutes[0].credits.IndexOf(" ");
            indexOfPoints = selectedRoutes[0].credits.IndexOf("p") - 1;
            // increase the total price with the price of the departure flight
            total += Convert.ToDouble(selectedRoutes[0].credits.Substring(1, indexOfSpace - 1));
            indexOfSpace += 2;
            // increase the total points with the points of the departure flight
            points += int.Parse(selectedRoutes[0].credits.Substring(indexOfSpace, indexOfPoints - indexOfSpace));
            // return this information in a formated way on the loaded screen
            TotalLabel.Text = TotalLabel.Text + " $" + String.Format("{0:0,0.00}", total) + " or " + String.Format("{0:0,0}", points) + " points";
        }
        private void BookFlightButton_Click(object sender, EventArgs e)
        {
            // This method actually books the selected flight(s)
            // Tables updated: bookedFlights, transaction, availableFlights, credits
            // if the customer wants to use points or an airline credit to pay, an error will appear if they do not have enough available in their account

            // The original list of the flights disappears for some reason, so a new list of those routeIDs are added to a list
            // The departure route ID is added
            List<int> routeIDs = new List<int>();
            routeIDs.Add(Convert.ToInt32(DepartureFlightDetailsTable.Rows[0].Cells[0].Value));
            // get the available points, used points, and balance for the current customer
            int available = SqliteDataAccess.GetAvailablePoints(currCustomer.userID);
            int used = SqliteDataAccess.GetUsedPoints(currCustomer.userID);
            int bal = SqliteDataAccess.GetBalance(currCustomer.userID);
            // get all of the current flights in that chosen route
            List<FlightModel> departFlights = SystemAction.GetCurrentFlights(routeIDs[0]);
            List<FlightModel> returnFlights = new List<FlightModel>();
            if (ReturnFlightDetailsTable.Visible)
            {
                // if there is a return flight chosen, then add the route ID for that flight and get all of the current flights in that chosen route
                routeIDs.Add(Convert.ToInt32(ReturnFlightDetailsTable.Rows[0].Cells[0].Value));
                returnFlights = SystemAction.GetCurrentFlights(routeIDs[1]);
            }
            // Next check what payment method is selected
            // If the credit card is chosen, then the flight income, flights booked, transaction table, available points, and number of seats are updated
            // If points is chosen, first check if you have enough points. If you do, then update flights booked, transaction table, available points, used points, and number of seats
            // IF airline credit is chosen, first check if you have enough airline credit to use. If you do, then update flights booked, transaction table, flight income, available balance and number of seats
            // Finally display a message that says the flight has been booked
            if (CreditCardButton.Checked)
            {
                if (ReturnFlightDetailsTable.Visible)
                {
                    foreach (FlightModel id in returnFlights)
                    {
                        SqliteDataAccess.UpdateFlightIncome(id.flightID, id.flightIncome + id.cost);
                        SqliteDataAccess.AddToFlightsBooked(currCustomer.userID, id.flightID, routeIDs[1], "Dollars");
                        SqliteDataAccess.AddTransaction(currCustomer.userID, id.flightID, id.cost, "Dollars", id.departureDateTime);
                        SqliteDataAccess.UpdateNumOfVacantSeats(id.flightID, id.numberOfVacantSeats - 1);
                    }
                }
                foreach (FlightModel id in departFlights)
                {
                    SqliteDataAccess.UpdateFlightIncome(id.flightID, id.flightIncome + id.cost);
                    SqliteDataAccess.AddToFlightsBooked(currCustomer.userID, id.flightID, routeIDs[0], "Dollars");
                    SqliteDataAccess.AddTransaction(currCustomer.userID, id.flightID, id.cost, "Dollars", id.departureDateTime);
                    SqliteDataAccess.UpdateNumOfVacantSeats(id.flightID, id.numberOfVacantSeats - 1);
                }
                SqliteDataAccess.UpdateAvailablePoints(currCustomer.userID, available + points);
                DialogResult result = MessageBox.Show("You are now scheduled for your flight(s).\nWould you like to schedule any more flights?", "Success: Flight(s) Booked", MessageBoxButtons.YesNo, MessageBoxIcon.None);
                // check if they want to schedule anymore flights
                if (result == DialogResult.Yes)
                {
                    BookFlightPage.GetInstance(ref currCustomer).Show();
                    this.Dispose();
                }
                else
                {
                    CustomerHomePage.GetInstance(ref currCustomer).Show();
                    this.Dispose();
                }
            }
            else if (PointsButton.Checked)
            {
                if (available < points)
                    MessageBox.Show("You do not have enough points in your account to purchase this ticket with points.", "Too Few Points", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (ReturnFlightDetailsTable.Visible)
                    {
                        foreach (FlightModel id in returnFlights)
                        {
                            SqliteDataAccess.AddToFlightsBooked(currCustomer.userID, id.flightID, routeIDs[1], "Points");
                            SqliteDataAccess.AddTransaction(currCustomer.userID, id.flightID, id.numOfPoints, "Points", id.departureDateTime);
                            SqliteDataAccess.UpdateNumOfVacantSeats(id.flightID, id.numberOfVacantSeats - 1);
                        }
                    }
                    foreach (FlightModel id in departFlights)
                    {
                        SqliteDataAccess.AddToFlightsBooked(currCustomer.userID, id.flightID, routeIDs[0], "Points");
                        SqliteDataAccess.AddTransaction(currCustomer.userID, id.flightID, id.numOfPoints, "Points", id.departureDateTime);
                        SqliteDataAccess.UpdateNumOfVacantSeats(id.flightID, id.numberOfVacantSeats - 1);
                    }
                    SqliteDataAccess.UpdateAvailablePoints(currCustomer.userID, available - points);
                    SqliteDataAccess.UpdateUsedPoints(currCustomer.userID, used + points);
                    DialogResult result = MessageBox.Show("You are now scheduled for your flight(s).\nWould you like to schedule any more flights?", "Success: Flight(s) Booked", MessageBoxButtons.YesNo, MessageBoxIcon.None);
                    // check if they want to schedule anymore flights
                    if (result == DialogResult.Yes)
                    {
                        BookFlightPage.GetInstance(ref currCustomer).Show();
                        this.Dispose();
                    }
                    else
                    {
                        CustomerHomePage.GetInstance(ref currCustomer).Show();
                        this.Dispose();
                    }
                }
            }
            else 
            {
                if (bal < total)
                    MessageBox.Show("You do not have enough of an airline credit in your account to purchase this ticket with an airline credit.", "Too Small of an Airline Credit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (ReturnFlightDetailsTable.Visible)
                    {
                        foreach (FlightModel id in returnFlights)
                        {
                            SqliteDataAccess.UpdateFlightIncome(id.flightID, id.flightIncome + id.cost);
                            SqliteDataAccess.AddToFlightsBooked(currCustomer.userID, id.flightID, routeIDs[1], "AirlineCredit");
                            SqliteDataAccess.AddTransaction(currCustomer.userID, id.flightID, id.cost, "AirlineCredit", id.departureDateTime);
                            SqliteDataAccess.UpdateNumOfVacantSeats(id.flightID, id.numberOfVacantSeats - 1);
                        }
                    }
                    foreach (FlightModel id in departFlights)
                    {
                        SqliteDataAccess.UpdateFlightIncome(id.flightID, id.flightIncome + id.cost);
                        SqliteDataAccess.AddToFlightsBooked(currCustomer.userID, id.flightID, routeIDs[0], "AirlineCredit");
                        SqliteDataAccess.AddTransaction(currCustomer.userID, id.flightID, id.cost, "AirlineCredit", id.departureDateTime);
                        SqliteDataAccess.UpdateNumOfVacantSeats(id.flightID, id.numberOfVacantSeats - 1);
                    }
                    SqliteDataAccess.UpdateBalance(currCustomer.userID, bal - total);
                    DialogResult result = MessageBox.Show("You are now scheduled for your flight(s).\nWould you like to schedule any more flights?", "Success: Flight(s) Booked", MessageBoxButtons.YesNo, MessageBoxIcon.None);
                    // check if they want to schedule anymore flights
                    if (result == DialogResult.Yes)
                    {
                        BookFlightPage.GetInstance(ref currCustomer).Show();
                        this.Dispose();
                    }
                    else
                    {
                        CustomerHomePage.GetInstance(ref currCustomer).Show();
                        this.Dispose();
                    }
                }
            }
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            // This methods allows the user to return to the Log In page
            // The current form will close
            // The Log In page will open
            DialogResult result = MessageBox.Show("Are you sure that you want to return to the booking flights home page?\nAny changes not saved will not be updated.", "Payment", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (result == DialogResult.Yes)
            {
                BookFlightPage.GetInstance(ref currCustomer).Show();
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

        private void PaymentPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            // This method allows the red X to be used to end the application
            // If the red X is clicked, a message will make sure the customer wants to leave
            // then the application ends or the customer cancels
            DialogResult result = MessageBox.Show("Are you sure you would like to exit?\nAny changes not saved will not be updated.", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (result == DialogResult.Yes)
                LogInPage.GetInstance.Close();
            else
                e.Cancel = true;
        }
    }
}
