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
    public partial class FlightManagerHomePage : Form
    {
        // This form file is to document the actions done on the Customer Home Page specifically
        public static FlightManagerHomePage instance; // singleton instance
        public static List<string> departAirports; // list of depart airports
        public static List<string> arriveAirports; // list of arrival airports
        public static int tempFlightSelected; // route that the user temporarily selects
        public FlightManagerHomePage()
        {
            // This method sets the default values of the datetimepickers and makes the table not visible
            InitializeComponent();
            FlightTable.Visible = false;
            departAirports = new List<string>(); // create the list of departing airports
            arriveAirports = new List<string>(); // create the list of arrival airports
        }
        public static FlightManagerHomePage GetInstance()
        {
            // This method follows the singleton pattern to allow for one form to be used rather than multiple being created
            if (instance == null || instance.IsDisposed)
            {
                instance = new FlightManagerHomePage();
            }
            return instance;
        }
        private void FlightManagerHomePage_Load(object sender, EventArgs e)
        {
            // This method sets the default values for the page

            // get the airports that are currently used
            List<Airport> airportList;
            airportList = SqliteDataAccess.GetAirports();
            foreach (Airport airport in airportList)
            {
                string currAir = airport.Code + " (" + airport.Name + ")";
                departAirports.Add(currAir);
                arriveAirports.Add(currAir);
            }
            // add an empty row to allow the customer to "reset" the dropdown
            departAirports.Add("");
            arriveAirports.Add("");
            // add the depart airports and default text
            DepartComboBox.DataSource = departAirports;
            DepartComboBox.SelectedItem = null;
            DepartComboBox.SelectedText = "";
            // add the arrive airports and default text
            ArriveComboBox.DataSource = arriveAirports;
            ArriveComboBox.SelectedItem = null;
            ArriveComboBox.SelectedText = "";
            FlightTable.Visible = false;
            ViewFlightManifestButton.Visible = false;
            FlightManagerLabel.Visible = false;
            NoFlightLabel.Visible = false;
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            // This method displays a list of the flights that have the values that the flight manager filtered on

            // set the error labels to not be visible
            BeforeFromDateError.Visible = false;
            DifferentLocationError.Visible = false;

            // set the default origin and destination to null
            string origin = null;
            string destination = null;
            // set the default dates to today
            DateTime fromDate = FromDatePicker.Value.Date;
            DateTime toDate = ToDatePicker.Value;

            // if the depart city is not null, then get the origin airport code from the drop down
            if (!String.IsNullOrEmpty(DepartComboBox.Text))
            {
                origin = DepartComboBox.Text.Substring(0, 3);
            }
            // if the arrive city is not null, then get the arrive airport code from the drop down
            if (!String.IsNullOrEmpty(ArriveComboBox.Text))
            {
                destination = ArriveComboBox.Text.Substring(0, 3);
            }
            // if the fromDate and toDate are the same, set the fromDate to midnight of the same day to get all flights of that day
            if (fromDate == toDate)
            {
                fromDate = fromDate.Date;
            }
            // if the toDate is today, set the time to now to be able to check all flights before now
            // else set the time to 11:59 of that day to allow for all flights in that date range to be seen
            if (toDate.Date == DateTime.Now.Date)
            {
                toDate = DateTime.Now;
            }
            else
            {
                toDate = toDate.Date.AddDays(1).AddSeconds(-1);
            }
            // if the origin and destination are provided and are the same, provide an error that says pick two different locations
            if (!String.IsNullOrEmpty(DepartComboBox.Text) && !String.IsNullOrEmpty(ArriveComboBox.Text) && DepartComboBox.Text == ArriveComboBox.Text)
                DifferentLocationError.Visible = true;
            // if the fromDate is after the toDate, provide an error that says pick a toDate that is after the fromDate
            if (fromDate.Date > toDate.Date)
                BeforeFromDateError.Visible = true;
            // if no errors are visible, then get the company statistics and fill the flights table
            if (BeforeFromDateError.Visible == false && DifferentLocationError.Visible == false)
            {
                List<FlightModel> flights = SqliteDataAccess.GetFlights(origin, destination, fromDate, toDate); // get the flights that have the specified values
                FlightTable.DataSource = flights;
                FlightTable.Visible = true; // display the table
                FlightTable.ClearSelection();
                ViewFlightManifestButton.Visible = true;
                FlightManagerLabel.Visible = true;
                // if there are no flights available in that date range with the provided information, display a no flights label
                if (flights.Count == 0)
                    NoFlightLabel.Visible = true;
                else
                    NoFlightLabel.Visible = false;
                FormatGrid(); // format the grid
            }
        }
        private void FormatGrid()
        {
            // This method formats the data grid view with different column names
            FlightTable.Columns.Remove("userid");
            FlightTable.Columns.Remove("firstName");
            FlightTable.Columns.Remove("lastName");
            FlightTable.Columns.Remove("originName");
            FlightTable.Columns.Remove("destinationName");
            FlightTable.Columns.Remove("arrivalDateTime");
            FlightTable.Columns.Remove("duration"); 
            FlightTable.Columns.Remove("numOfPoints");
            // change the name of the columns
            FlightTable.Columns[0].HeaderText = "Flight ID";
            FlightTable.Columns[1].HeaderText = "Master Flight ID";
            FlightTable.Columns[2].HeaderText = "Origin Code";
            FlightTable.Columns[3].HeaderText = "Destination Code"; 
            FlightTable.Columns[4].HeaderText = "Distance (in miles)";
            FlightTable.Columns[5].HeaderText = "Departure Date and Time";
            FlightTable.Columns[6].HeaderText = "Duration (in hours)";
            FlightTable.Columns[7].HeaderText = "Plane Type";
            FlightTable.Columns[8].HeaderText = "Cost (in dollars)";
            FlightTable.Columns[9].HeaderText = "Number of Vacant Seats";
            FlightTable.Columns[10].HeaderText = "% Full Capacity";
            FlightTable.Columns[11].HeaderText = "Flight Income (in dollars)";
            // clear the selection from the table
            FlightTable.ClearSelection();
        }
        private void ClearFiltersButton_Click(object sender, EventArgs e)
        {
            // This method clears all filters and resets them to their defaults
            DepartComboBox.SelectedIndex = -1; 
            ArriveComboBox.SelectedIndex = -1;
            FromDatePicker.ResetText();
            ToDatePicker.ResetText();
            FlightManagerLabel.Visible = false;
            FlightTable.Visible = false;
            BeforeFromDateError.Visible = false;
            DifferentLocationError.Visible = false;
            NoFlightLabel.Visible = false;
        }
        private void ViewFlightManifestButton_Click(object sender, EventArgs e)
        {
            // This method shows the selected Flight's manifest if a row is selected
            // If a row is not selected, then the user is notified with a popup
            if (FlightTable.SelectedRows.Count != 0)
            {
                FlightManifest.GetInstance(tempFlightSelected).Show();
                this.Hide();
            }
            else
                MessageBox.Show("No Flight was Selected. Please Select a Flight before continuing.", "Error: Choose a Departure Flight", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void FlightTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // This method prevents the column header row from being clicked and it gets the route id from the row that has been clicked
            if (e.RowIndex != -1 && FlightTable.Rows[e.RowIndex].Cells[0].Value != null)
                tempFlightSelected = Convert.ToInt32(FlightTable.Rows[e.RowIndex].Cells[0].Value);
        }
        private void FromDatePicker_ValueChanged(object sender, EventArgs e)
        {
            // Once the fromDatePicker's value has changed, the values will be default formatted and the date of the selected date will be selected
            FromDatePicker.CustomFormat = "dddd, MMMM  dd,  yyyy";
            FromDateAfterTodayError.Visible = false;
            var delta = FromDatePicker.Value.Date.Subtract(DateTime.Today.Date); // get the difference between the to date and today
            if (delta.TotalMinutes > 0) // if the from date is after today
                FromDateAfterTodayError.Visible = true;
        }
        private void ToDatePicker_ValueChanged(object sender, EventArgs e)
        {
            // Once the toDatePicker's value has changed, the values will be default formatted and the date of the selected date will be selected
            // This method also makes sure the selected date is the same or after the from date picker
            ToDatePicker.CustomFormat = "dddd, MMMM  dd,  yyyy";
            BeforeFromDateError.Visible = false;
            ToDateAfterTodayError.Visible = false;
            var delta1 = ToDatePicker.Value.Date.Subtract(FromDatePicker.Value.Date); // get the difference between the from date and the to date
            var delta2 = ToDatePicker.Value.Date.Subtract(DateTime.Today.Date); // get the difference between the to date and today
            if (delta1.TotalMinutes < 0) // if the to date is before the from date
                BeforeFromDateError.Visible = true;
            else if (delta2.TotalMinutes > 0) // if the to date is after today
                ToDateAfterTodayError.Visible = true;          
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
        private void FlightManagerHomePage_FormClosing(object sender, FormClosingEventArgs e)
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
