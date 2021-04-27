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
    public partial class FlightManifest : Form
    {
        // This form file is to document the actions done on the Flight Manifest Page specifically
        public static FlightManifest instance; // singleton instance
        public static int currFlightID; // get the flight id of the previously selected flight
        public static FlightModel flight; // get the flight selected
        public FlightManifest()
        {
            InitializeComponent();
        }
        public FlightManifest(int flightID)
        {
            // This constructor sets the flight to be looked at as the flight selected from the last page
            InitializeComponent();
            currFlightID = flightID;
            flight = SystemAction.GetFlight(flightID, 0);
            // set values of the labels on page to the flight details
            OriginLabel.Text += flight.originCode;
            DestinationLabel.Text += flight.destinationCode;
            DepartureDateTimeLabel.Text += flight.departureDateTime;
            DurationLabel.Text += flight.duration;
            DistanceLabel.Text += flight.distance;
            PlaneTypeLabel.Text += flight.planeType;
            FlightIncomeLabel.Text += flight.flightIncome;
            VacantSeatsLabel.Text += flight.numberOfVacantSeats;
            NoPassengersLabel.Visible = false;
        }
        public static FlightManifest GetInstance(int flightID)
        {
            // This method follows the singleton pattern to allow for one form to be used rather than multiple being created
            if (instance == null || instance.IsDisposed)
            {
                instance = new FlightManifest(flightID);
            }
            return instance;
        }
        private void FlightManifest_Load(object sender, EventArgs e)
        {
            // This method loads the table on this page with passengers who are on the selected flight

            NoPassengersLabel.Visible = false;
            // Put the flight ID at the top of the page
            FlightManifestLabel.Text += currFlightID;
            // get all of the passengers
            List<int> passengerIDs = SqliteDataAccess.GetFlightPassengers(currFlightID);
            List<CustomerModel> passengers = new List<CustomerModel>();
            // for each of the passengers, get their userID, first name, last name, phone number, and email address
            foreach (int pID in passengerIDs)
            {
                List<string> userData = SqliteDataAccess.GetUserData(pID);
                CustomerModel passenger = new CustomerModel(pID, userData[1], userData[2], userData[3], userData[4], userData[5], userData[6], userData[7], userData[8], userData[9], int.Parse(userData[10]), userData[11]);
                passengers.Add(passenger);
            }
            if (passengers.Count == 0)
                NoPassengersLabel.Visible = true;
            else
                NoPassengersLabel.Visible = false;
            // set this list of passengers as the datasource of the page
            FlightManifestTable.DataSource = passengers;
            FormatGrid();
            FlightManifestTable.ClearSelection();
        }
        private void FormatGrid()
        {
            // This method formats the data grid view with different column names
            // remmove some of the columns
            FlightManifestTable.Columns.Remove("password");
            FlightManifestTable.Columns.Remove("street");
            FlightManifestTable.Columns.Remove("city");
            FlightManifestTable.Columns.Remove("state");
            FlightManifestTable.Columns.Remove("zipCode");
            FlightManifestTable.Columns.Remove("creditCardNumber");
            FlightManifestTable.Columns.Remove("age");
            // rename some of the columns
            FlightManifestTable.Columns[0].HeaderText = "User ID";
            FlightManifestTable.Columns[1].HeaderText = "First Name";
            FlightManifestTable.Columns[2].HeaderText = "Last Name";
            FlightManifestTable.Columns[3].HeaderText = "Phone Number";
            FlightManifestTable.Columns[4].HeaderText = "Email";
        }
        private void PrintButton_Click(object sender, EventArgs e)
        {
            // This method simply tells the user that the flight manifest is printing
            MessageBox.Show("The Flight Manifest for Flight ID #" + currFlightID + " is printing now.", "Printing Flight Manifest", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            // This methods allows the user to return to the Log In page
            // The current form will close
            // The flight manager home page will open
            DialogResult result = MessageBox.Show("Are you sure that you want to return home?\nAny changes not saved will not be updated.", "Account Information", MessageBoxButtons.YesNo, MessageBoxIcon.None);
            if (result == DialogResult.Yes)
            {
                FlightManagerHomePage.GetInstance().Show();
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
        private void FlightManifest_FormClosing(object sender, FormClosingEventArgs e)
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
