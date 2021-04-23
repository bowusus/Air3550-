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
        public static FlightManagerHomePage instance;
        public static List<string> departAirports; // list of depart airports
        public static List<string> arriveAirports; // list of arrival airports
        public static int tempFlightSelected; // route that the user temporarily selects
        DateTime fromTempVariable;
        DateTime toTempVariable;
        public FlightManagerHomePage()
        {
            // This method sets the default values of the datetimepickers and makes the table not visible
            InitializeComponent();
            FromDatePicker.CustomFormat = " ";
            FromDatePicker.Format = DateTimePickerFormat.Custom;
            ToDatePicker.CustomFormat = " ";
            ToDatePicker.Format = DateTimePickerFormat.Custom;
            FlightTable.Visible = false;
            departAirports = new List<string>(); // create the list of departing airports
            arriveAirports = new List<string>(); // create the list of arrival airports
            fromTempVariable = DateTime.Now;
            toTempVariable = DateTime.Now;
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
            // This method adds the airports to the airport cities dropdowns
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
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            // This method displays a list of the flights that have the values that the flight manager filtered on
            BeforeFromDateError.Visible = false;
            string origin = null;
            string destination = null;
            // set the dates to the default min value
            DateTime fromDate = DateTime.Now;
            DateTime toDate = DateTime.Now;
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
            // if the from date picker is selected, then get that date
            if (fromTempVariable == DateTime.MinValue || !FromDatePicker.Text.Equals(" "))
            {
                fromDate = FromDatePicker.Value.Date;
            }
            // if the to date picker is selected, then get that date
            if (toTempVariable == DateTime.MinValue || !ToDatePicker.Text.Equals(" "))
            {
                toDate = ToDatePicker.Value.Date;
            }
            if ((fromTempVariable == DateTime.MinValue || !FromDatePicker.Text.Equals(" ")) && (toTempVariable == DateTime.MinValue || !ToDatePicker.Text.Equals(" ")) && fromDate > toDate)
                BeforeFromDateError.Visible = true;
            else
            {
                // change the fromDate and toDate back to the minValue to send through the query
                if (fromDate.TimeOfDay.Ticks != 0)
                    fromDate = DateTime.MinValue.Date;
                if (toDate.TimeOfDay.Ticks != 0)
                    toDate = DateTime.MinValue.Date;
                FlightTable.DataSource = SqliteDataAccess.GetFlights(origin, destination, fromDate, toDate); // get the flights that have the specified values
                FlightTable.Visible = true; // display the table
                FlightTable.ClearSelection();
                ViewFlightManifestButton.Visible = true;
                FlightManagerLabel.Visible = true;
                FormatGrid(); // format the grid
            }
        }
        private void FormatGrid()
        {
            // This method formats the data grid view with different column names
            FlightTable.Columns[0].HeaderText = "Flight ID";
            FlightTable.Columns[1].HeaderText = "Master Flight ID";
            FlightTable.Columns[2].HeaderText = "Origin Code";
            FlightTable.Columns[3].HeaderText = "Destination Code";
            FlightTable.Columns[4].HeaderText = "Departure Date";
            FlightTable.Columns[5].HeaderText = "Departure Time";
            FlightTable.Columns[6].HeaderText = "Distance";
            FlightTable.Columns[7].HeaderText = "Duration";
            FlightTable.Columns[8].HeaderText = "Plane Type";
            FlightTable.Columns[9].HeaderText = "Cost";
            FlightTable.Columns[10].HeaderText = "Number of Vacant Seats";
            FlightTable.Columns[11].HeaderText = "Flight Income";
        }
        private void ClearFiltersButton_Click(object sender, EventArgs e)
        {
            // This method clears all filters and resets them to their defaults
            DepartComboBox.SelectedIndex = -1; 
            ArriveComboBox.SelectedIndex = -1;
            FromDatePicker.Value = DateTime.Now;
            FromDatePicker.CustomFormat = " ";
            FromDatePicker.Format = DateTimePickerFormat.Custom;
            fromTempVariable = DateTime.Now;
            ToDatePicker.Value = DateTime.Now;
            ToDatePicker.CustomFormat = " ";
            ToDatePicker.Format = DateTimePickerFormat.Custom;
            toTempVariable = DateTime.Now;
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
            FromDatePicker.Value = FromDatePicker.Value.Date; // this sets the time to midnight, so ticks = 0
            FromDateAfterTodayError.Visible = false;
            var delta = FromDatePicker.Value.Subtract(DateTime.Today); // get the difference between the to date and today
            if (delta.TotalMinutes > 0) // if the from date is after today
                FromDateAfterTodayError.Visible = true;
            else
                this.fromTempVariable = DateTime.MinValue;
        }
        private void ToDatePicker_ValueChanged(object sender, EventArgs e)
        {
            // Once the toDatePicker's value has changed, the values will be default formatted and the date of the selected date will be selected
            // This method also makes sure the selected date is the same or after the from date picker
            ToDatePicker.CustomFormat = "dddd, MMMM  dd,  yyyy";
            ToDatePicker.Value = ToDatePicker.Value.Date; // this sets the time to midnight, so ticks = 0
            BeforeFromDateError.Visible = false;
            ToDateAfterTodayError.Visible = false;
            var delta2 = ToDatePicker.Value.Subtract(DateTime.Today); // get the difference between the to date and today
            if (this.fromTempVariable == DateTime.MinValue)
            {
                var delta1 = ToDatePicker.Value.Subtract(FromDatePicker.Value); // get the difference between the from date and the to date
                if (delta1.TotalMinutes < 0) // if the to date is before the from date
                    BeforeFromDateError.Visible = true;
                else if (delta2.TotalMinutes > 0) // if the to date is after today
                    ToDateAfterTodayError.Visible = true;
                else
                    this.toTempVariable = DateTime.MinValue;
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
        private void FlightManagerHomePage_FormClosing(object sender, FormClosingEventArgs e)
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
