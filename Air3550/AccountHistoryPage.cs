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
    public partial class AccountHistoryPage : Form
    {
        // This form file is to document the actions done on the Account History specifically
        public static CustomerModel currCustomer; // make a local object that can be read in the current context
        public static AccountHistoryPage instance; // singleton instance
        public static List<FlightModel> bookedFlights; 
        public static List<FlightModel> takenFlights; 
        public static List<FlightModel> cancelflight; 
        public AccountHistoryPage()
        {
            InitializeComponent();
        }
        public static AccountHistoryPage GetInstance(ref CustomerModel customer)
        {
            // This method follows the singleton pattern to allow for one form to be used rather than multiple being created
            if (instance == null || instance.IsDisposed)
            {
                instance = new AccountHistoryPage(ref customer);
            }
            return instance;
        }
        public AccountHistoryPage(ref CustomerModel customer)
        {
            // This constructor allows for the object to be accessed in this form
            InitializeComponent();
            // get the current customer and pass that information to the textboxes
            currCustomer = customer;
        }
        // Loads all the points available, points used and credits
        private void AccountHistoryPage_Load(object sender, EventArgs e)
        {
            // The main reason for this method is to load this page with default visibility and values of labels and the tables 
            AccountHistoryTable.Visible = false;
            NoBookedFlightLabel.Visible = false;
            NoCancelledFlightLabel.Visible = false;
            NoTakenFlightLabel.Visible = false;
            int availablepoints = SqliteDataAccess.GetAvailablePoints(currCustomer.userID);
            PointsAvailableText.Text = availablepoints.ToString(); // shows the available points 
            int pointsused = SqliteDataAccess.GetUsedPoints(currCustomer.userID);
            PointsText.Text = pointsused.ToString(); // shows amount of points of used
            double credits = SqliteDataAccess.GetBalance(currCustomer.userID);
            AvailableBalanceText.Text = credits.ToString(); // shows credit remaining
        }
        private void FormatDataGrid()
        {
            // removes the information not needed
            AccountHistoryTable.Columns.Remove("durDouble");
            AccountHistoryTable.Columns.Remove("masterFlightID");
            AccountHistoryTable.Columns.Remove("firstName");
            AccountHistoryTable.Columns.Remove("userid");
            AccountHistoryTable.Columns.Remove("lastName");
            AccountHistoryTable.Columns.Remove("planeType");
            AccountHistoryTable.Columns.Remove("numberOfVacantSeats");
            AccountHistoryTable.Columns.Remove("flightIncome");
            AccountHistoryTable.Columns.Remove("percentFull");
            AccountHistoryTable.Columns.Remove("cost");
            AccountHistoryTable.Columns.Remove("numOfPoints");
            // Fix and rename header text
            AccountHistoryTable.Columns[0].HeaderText = "FlightID";
            AccountHistoryTable.Columns[1].HeaderText = "Origin Code";
            AccountHistoryTable.Columns[2].HeaderText = "Origin Name";
            AccountHistoryTable.Columns[3].HeaderText = "Destination Code";
            AccountHistoryTable.Columns[4].HeaderText = "Destination Name";
            AccountHistoryTable.Columns[5].HeaderText = "Distance (in miles)";
            AccountHistoryTable.Columns[6].HeaderText = "Departure Date and Time";
            AccountHistoryTable.Columns[7].HeaderText = "Est. Arrival Date and Time";
            AccountHistoryTable.Columns[8].HeaderText = "Est. Duration (h:mm:ss)";
            AccountHistoryTable.ClearSelection();
        }
        private void FlightsBookedButton_Click(object sender, EventArgs e)
        {
            // This method loads all current flights for the current customer
            // These are the flights that the customer has currently booked
            // There can be multiple flights due to a round trip or if a flight has layovers
            NoBookedFlightLabel.Visible = false;
            NoCancelledFlightLabel.Visible = false;
            NoTakenFlightLabel.Visible = false;
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
                    i += 1;
                }
            }
            // set the booked flights list to be the data source of the table
            AccountHistoryTable.DataSource = bookedFlights;
            AccountHistoryTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            AccountHistoryTable.Visible = true;
            // if the count is 0, then display a label
            if (bookedFlights.Count == 0)
                NoBookedFlightLabel.Visible = true;
            else
                NoBookedFlightLabel.Visible = false;
            FormatDataGrid();
        }
        private void FlightsCancelledButton_Click(object sender, EventArgs e)
        {
            // This method loads all cancelled flights for the current customer
            // These are the flights that the customer already cancelled
            // There can be multiple flights due to a round trip or if a flight has layovers
            NoBookedFlightLabel.Visible = false;
            NoCancelledFlightLabel.Visible = false;
            NoTakenFlightLabel.Visible = false;
            cancelflight = new List<FlightModel>();
            int i = 0;
            List<int> flightID = SqliteDataAccess.GetCancelledFlightIDs(currCustomer.userID);
            // as long as there are currently cancelled flights, go through each flight that is currently cancelled
            // get the flight data, origin and destination airport names, departure and arrival datetimes, costs, and duration
            // add that to the cancelled flights list
            if (flightID.Count != 0)
            {
                foreach (int fID in flightID)
                {
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

                    cancelflight.Add(flight);
                    i += 1;
                }
            }
            // set the cancelled flights list to be the data source of the table
            AccountHistoryTable.DataSource = cancelflight;
            AccountHistoryTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            AccountHistoryTable.Visible = true;
            // if the count is 0, then display a label
            if (cancelflight.Count == 0)
                NoCancelledFlightLabel.Visible = true;
            else
                NoCancelledFlightLabel.Visible = false;
            FormatDataGrid();
        }
        private void FlightsTakenButton_Click(object sender, EventArgs e)
        {
            // This method loads all taken flights for the current customer
            // These are the flights that the customer have taken
            // There can be multiple flights due to a round trip or if a flight has layovers
            NoBookedFlightLabel.Visible = false;
            NoCancelledFlightLabel.Visible = false;
            NoTakenFlightLabel.Visible = false;
            int i = 0;
            takenFlights = new List<FlightModel>();
            List<int> flightID = SqliteDataAccess.GetTakenFlightIDs(currCustomer.userID);
            // as long as there are currently cancelled flights, go through each flight that has been previously taken
            // get the flight data, origin and destination airport names, departure and arrival datetimes, costs, and duration
            // add that to the taken flights list
            if (flightID.Count != 0)
            {
                foreach (int fID in flightID)
                {
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

                    takenFlights.Add(flight);
                    i += 1;
                }
            }
            // set the taken flights list to be the data source of the table
            AccountHistoryTable.DataSource = takenFlights;
            AccountHistoryTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            AccountHistoryTable.Visible = true;
            // if the count is 0, then display a label
            if (takenFlights.Count == 0)
                NoTakenFlightLabel.Visible = true;
            else
                NoTakenFlightLabel.Visible = false;
            FormatDataGrid();
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            // This methods allows the user to return to the customer home page
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
        private void AccountHistoryPage_FormClosing(object sender, FormClosingEventArgs e)
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