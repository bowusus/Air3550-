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
        public static AccountHistoryPage instance;
        public static bool logOutButtonClicked = false;
        public static bool backButtonClicked = false;
        public static List<FlightModel> bookedFlights =  new List<FlightModel>();
        public static List<FlightModel> takenFlights;
        public static List<FlightModel> cancelflight;
        private DataTable flightList = new DataTable();


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
        private void FlightsBookedButton_Click(object sender, EventArgs e)
        {
            List<int> routeIDs = SqliteDataAccess.GetBookedFlightsRouteID(currCustomer.userID); // get the route IDs from the booked flights table
            List<int> flightIDs_Booked = SqliteDataAccess.GetBookedFlightIDs(currCustomer.userID);
            int count = 0;
            int index = 0;
            int i = 0;
            int j = 0;
            if (bookedFlights.Count == 0)
            {
                if (flightIDs_Booked.Count != 0)
                // as long as there is a flight currently booked with a route ID
                // then check if each ID in the route is still booked and add it to the booked flights list
                {
                    foreach (int rID in routeIDs)
                    {
                        List<int> masterFlightIDsRoute = SqliteDataAccess.GetFlightIDsInRoute(rID);
                        count = masterFlightIDsRoute.Count;
                        while (i < count)
                        {
                            if (flightIDs_Booked.Contains(flightIDs_Booked[j]))
                            {
                                FlightModel flight;
                                if (bookedFlights.Count % count == 0 && i != 0)
                                {
                                    flight = SystemAction.GetFlight(flightIDs_Booked[j], i);
                                    i = 0;
                                }
                                else
                                {
                                    flight = SystemAction.GetFlight(flightIDs_Booked[j], i);
                                    i += 1;
                                }
                                bookedFlights.Add(flight);
                            }
                            j += 1;
                        }
                        i = 0;
                    }
                }
            }
            dataGridView1.DataSource = bookedFlights;
             FormatDataGrid();
        }

        private void FormatDataGrid()
        {
            // removes the information not needed
           
            dataGridView1.Columns.Remove("durDouble");
            dataGridView1.Columns.Remove("masterFlightID");
            dataGridView1.Columns.Remove("firstName");
            dataGridView1.Columns.Remove("userid");
            dataGridView1.Columns.Remove("lastName");
            dataGridView1.Columns.Remove("planeType");
            dataGridView1.Columns.Remove("numberOfVacantSeats");
            dataGridView1.Columns.Remove("flightIncome");


            // Fix and rename header text
            dataGridView1.Columns[0].HeaderText = "FlightID";
            dataGridView1.Columns[1].HeaderText = "Origin Code";
            dataGridView1.Columns[2].HeaderText = "Origin Name";
            dataGridView1.Columns[3].HeaderText = "Destination Code";
            dataGridView1.Columns[4].HeaderText = "Destination Name";
            dataGridView1.Columns[5].HeaderText = "Distance (in miles)";
            dataGridView1.Columns[6].HeaderText = "Departure Date and Time";
            dataGridView1.Columns[7].HeaderText = "Est. Arrival Date and Time";
            dataGridView1.Columns[8].HeaderText = "Est. Duration (h:mm:ss)";
            dataGridView1.Columns[9].HeaderText = "Cost (in dollars)";
            dataGridView1.Columns[10].HeaderText = "Number of Points";
            dataGridView1.ClearSelection();
        }

        private void FlightsCancelledButton_Click(object sender, EventArgs e)
        {
            flightList.Rows.Clear(); // clears the data gridview
            cancelflight = new List<FlightModel>();
            int i = 0;
            List<int> flightID = SqliteDataAccess.GetCancelledFlightIDs(currCustomer.userID);
            if (flightID.Count != 0)
            {
                foreach (int rID in flightID)
                {
                    List<string> flightData = SqliteDataAccess.GetFlightData(rID);
                    //        List<string> flightsBookedData = SqliteDataAccess.GetFlightData(rID);
                    string originName = SqliteDataAccess.GetFlightNames(flightData[2]);
                    string destinationName = SqliteDataAccess.GetFlightNames(flightData[3]);
                    // string firsname = SqliteDataAccess.GetUserData(currCustomer.userID).ElementAt(2);
                    //  currCustomer.firstName = firsname;

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
            dataGridView1.DataSource = cancelflight;
            FormatDataGrid();
        }

        private void FlightsTakenButton_Click(object sender, EventArgs e)
        {
            flightList.Rows.Clear(); // clears the data gridview
            int i = 0;
            takenFlights = new List<FlightModel>();

            List<int> flightID = SqliteDataAccess.GetTakenFlightIDs(currCustomer.userID);

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
            dataGridView1.DataSource = takenFlights;
            FormatDataGrid();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            // This methods allows the user to return to the Log In page
            // The current form will close
            // The Log In page will open
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

        // Loads all the points available, points used and credits
        private void AccountHistoryPage_Load(object sender, EventArgs e)
        {
            // FillFlightListColumns();
            dataGridView1.DataSource = flightList;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            int availablepoints = SqliteDataAccess.GetAvailablePoints(currCustomer.userID);
            pointsAvailableText.Text = availablepoints.ToString(); // shows the available points 
            int pointsused = SqliteDataAccess.GetUsedPoints(currCustomer.userID);
            PointsText.Text = pointsused.ToString(); // shows amount of points of used
            int credits = SqliteDataAccess.GetBalance(currCustomer.userID);
            creditText.Text = credits.ToString(); // shows credit remaining
        }
    }
}