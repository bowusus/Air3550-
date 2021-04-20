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
    public partial class PaymentPage : Form
    {
        // This form file is to document the actions done on the Payment Page specifically
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
            DepartureFlightLabel.Text = DepartureFlightLabel.Text + depart.Date.ToString("MM/dd/yyyy");
            ReturnFlightLabel.Text = ReturnFlightLabel.Text + returnDate.Date.ToString("MM/dd/yyyy");
            DepartureCitiesLabel.Text = origin + " → " + destination;
            ReturnCitiesLabel.Text = destination + " → " + origin;
        }
        private void PaymentPage_Load(object sender, EventArgs e)
        {
            int indexOfSpace;
            int indexOfPoints;
            if (selectedRoutes.Count == 1)
            {
                ReturnFlightDetailsTable.Visible = false;
                ReturnCitiesLabel.Visible = false;
                ReturnFlightLabel.Visible = false;
            } 
            else 
            {
                ReturnFlightDetailsTable.Rows.Add(selectedRoutes[1].routeID, selectedRoutes[1].departTime, selectedRoutes[1].arriveTime, selectedRoutes[1].duration, selectedRoutes[1].numOfLayovers, selectedRoutes[1].flightIDs, selectedRoutes[1].planeChange, selectedRoutes[1].availableSeats, selectedRoutes[1].credits);
                ReturnFlightDetailsTable.ClearSelection();
                indexOfSpace = selectedRoutes[1].credits.IndexOf(" ");
                indexOfPoints = selectedRoutes[1].credits.IndexOf("p") - 1;
                total += Convert.ToDouble(selectedRoutes[1].credits.Substring(1, indexOfSpace - 1));
                indexOfSpace += 2;
                points += int.Parse(selectedRoutes[1].credits.Substring(indexOfSpace, indexOfPoints-indexOfSpace));
            }
            DepartureFlightDetailsTable.Rows.Add(selectedRoutes[0].routeID, selectedRoutes[0].departTime, selectedRoutes[0].arriveTime, selectedRoutes[0].duration, selectedRoutes[0].numOfLayovers, selectedRoutes[0].flightIDs, selectedRoutes[0].planeChange, selectedRoutes[0].availableSeats, selectedRoutes[0].credits);
            DepartureFlightDetailsTable.ClearSelection();
            indexOfSpace = selectedRoutes[0].credits.IndexOf(" ");
            indexOfPoints = selectedRoutes[0].credits.IndexOf("p") - 1;
            total += Convert.ToDouble(selectedRoutes[0].credits.Substring(1, indexOfSpace - 1));
            indexOfSpace += 2;
            points += int.Parse(selectedRoutes[0].credits.Substring(indexOfSpace, indexOfPoints - indexOfSpace));
            TotalLabel.Text = TotalLabel.Text + " $" + String.Format("{0:0,0.00}", total) + " or " + String.Format("{0:0,0}", points) + " points";
        }
        private void BookFlightButton_Click(object sender, EventArgs e)
        {
            List<int> routeIDs = new List<int>();
            routeIDs.Add(Convert.ToInt32(DepartureFlightDetailsTable.Rows[0].Cells[0].Value));
            int available = SqliteDataAccess.GetAvailablePoints(currCustomer.userID);
            int used = SqliteDataAccess.GetUsedPoints(currCustomer.userID);
            int bal = SqliteDataAccess.GetBalance(currCustomer.userID);
            List<FlightModel> departFlights = SystemAction.GetCurrentFlights(routeIDs[0]);
            List<FlightModel> returnFlights = new List<FlightModel>();
            if (ReturnFlightDetailsTable.Visible)
            {
                routeIDs.Add(Convert.ToInt32(ReturnFlightDetailsTable.Rows[0].Cells[0].Value));
                returnFlights = SystemAction.GetCurrentFlights(routeIDs[1]);
            }
            if (CreditCardButton.Checked)
            {
                if (ReturnFlightDetailsTable.Visible)
                {
                    foreach (FlightModel id in returnFlights)
                    {
                        SqliteDataAccess.UpdateFlightIncome(id.flightID, id.flightIncome + id.cost);
                        SqliteDataAccess.AddToFlightsBooked(currCustomer.userID, id.flightID, routeIDs[1], "Dollars");
                        SqliteDataAccess.AddTransaction(currCustomer.userID, id.flightID, id.cost, "Dollars");
                        SqliteDataAccess.UpdateNumOfVacantSeats(id.flightID, id.numberOfVacantSeats - 1);
                    }
                }
                foreach (FlightModel id in departFlights)
                {
                    SqliteDataAccess.UpdateFlightIncome(id.flightID, id.flightIncome + id.cost);
                    SqliteDataAccess.AddToFlightsBooked(currCustomer.userID, id.flightID, routeIDs[0], "Dollars");
                    SqliteDataAccess.AddTransaction(currCustomer.userID, id.flightID, id.cost, "Dollars");
                    SqliteDataAccess.UpdateNumOfVacantSeats(id.flightID, id.numberOfVacantSeats - 1);
                }
                SqliteDataAccess.UpdateAvailablePoints(currCustomer.userID, available + points);
                MessageBox.Show("You are now scheduled for your flight(s).", "Success: Flight(s) Booked", MessageBoxButtons.OK, MessageBoxIcon.None);
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
                            SqliteDataAccess.AddTransaction(currCustomer.userID, id.flightID, id.numOfPoints, "Points");
                            SqliteDataAccess.UpdateNumOfVacantSeats(id.flightID, id.numberOfVacantSeats - 1);
                        }
                    }
                    foreach (FlightModel id in departFlights)
                    {
                        SqliteDataAccess.AddToFlightsBooked(currCustomer.userID, id.flightID, routeIDs[0], "Points");
                        SqliteDataAccess.AddTransaction(currCustomer.userID, id.flightID, id.numOfPoints, "Points");
                        SqliteDataAccess.UpdateNumOfVacantSeats(id.flightID, id.numberOfVacantSeats - 1);
                    }
                    SqliteDataAccess.UpdateAvailablePoints(currCustomer.userID, available - points);
                    SqliteDataAccess.UpdateUsedPoints(currCustomer.userID, used + points);
                    MessageBox.Show("You are now scheduled for your flight(s).", "Success: Flight(s) Booked", MessageBoxButtons.OK, MessageBoxIcon.None);
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
                            SqliteDataAccess.AddTransaction(currCustomer.userID, id.flightID, id.cost, "AirlineCredit");
                            SqliteDataAccess.UpdateNumOfVacantSeats(id.flightID, id.numberOfVacantSeats - 1);
                        }
                    }
                    foreach (FlightModel id in departFlights)
                    {
                        SqliteDataAccess.UpdateFlightIncome(id.flightID, id.flightIncome + id.cost);
                        SqliteDataAccess.AddToFlightsBooked(currCustomer.userID, id.flightID, routeIDs[0], "AirlineCredit");
                        SqliteDataAccess.AddTransaction(currCustomer.userID, id.flightID, id.cost, "AirlineCredit");
                        SqliteDataAccess.UpdateNumOfVacantSeats(id.flightID, id.numberOfVacantSeats - 1);
                    }
                    SqliteDataAccess.UpdateBalance(currCustomer.userID, bal - total);
                    MessageBox.Show("You are now scheduled for your flight(s).", "Success: Flight(s) Booked", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
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
                this.Close(); // close the current form if the customer confirms that they would like to log out
                int i = 0;
                // close the log in form and the create customer form
                while (i < Application.OpenForms.Count) // look at what forms are open
                {
                    if (Application.OpenForms[i].Name == "BookFlightPageCopy")
                        Application.OpenForms[i].Show();// if the current form is the customer home page, show it
                    i += 1;
                }
            }
        }
        private void LogOutButton_Click(object sender, EventArgs e)
        {

        }
    }
}
