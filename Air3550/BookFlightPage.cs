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
    public partial class BookFlightPage : Form
    {
        // This form file is to document the actions done on the Book Flight Page specifically
        public static CustomerModel currCustomer; // make a local object that can be read in the current context
        public static bool logOutButtonClicked = false;
        public static bool backButtonClicked = false;
        public static List<string> departAirports; // list of depart airports
        public static List<string> arriveAirports; // list of arrival airports
        public static List<Route> departingRoutes; // list of departing flights that gets updated throughout the form
        public static List<Route> returningRoutes; // list of returning flights that gets updated throughout the form
        public static List<Route> selectedRoutes; // list of selected routes
        public static int tempRouteSelected; // route that the user temporarily selects
        public BookFlightPage()
        {
            InitializeComponent();
        }
        public BookFlightPage(ref CustomerModel customer)
        {
            // This constructor allows for the object to be accessed in this form
            InitializeComponent();
            // get the current customer and pass that information to the textboxes
            currCustomer = customer;
            // create a new list for the airports that will be displayed
            departAirports = new List<string>(); // create the list of departing airports
            arriveAirports = new List<string>(); // create the list of arrival airports
        }
        private void BookFlightPage_Load(object sender, EventArgs e)
        {
            // This method gets the available airports/locations that the customer can depart/arrive at
            // It fills the combo boxes with the airport data, sets the default trip to a round trip,
            // and makes the table that shows the available flights initially not visible
            List<Airport> airportList;
            airportList = SqliteDataAccess.GetAirports();
            foreach (Airport airport in airportList)
            {
                string currAir = airport.Code + " (" + airport.Name + ")";
                departAirports.Add(currAir);
                arriveAirports.Add(currAir);
            }
            // add the depart airports and default text
            DepartComboBox.DataSource = departAirports;
            DepartComboBox.SelectedItem = null;
            DepartComboBox.SelectedText = "--Select Location--";
            // add the arrive airports and default text
            ArriveComboBox.DataSource = arriveAirports;
            ArriveComboBox.SelectedItem = null;
            ArriveComboBox.SelectedText = "--Select Location--";

            // set all of the default values and visibility of errors and buttons
            DepartDatePicker.Value = DateTime.Today;
            ReturnDatePicker.Value = DateTime.Today;

            RoundTripButton.Checked = true;
            OneWayButton.Checked = false;
            DifferentLocationError.Visible = false;
            DepartDateError.Visible = false;
            DepartDateAfterTodayError.Visible = false;
            ReturnDateError.Visible = false;
            ReturnBeforeDepartError.Visible = false;
            AvailableFlightTable.Visible = false;
            ReturnFlightButton.Visible = false;
            BookFlightButton.Visible = false;
            DepartintFlightsLabel.Visible = false;
            ReturningFlightsLabel.Visible = false;
            ChangeDepartingFlightButton.Visible = false;
        }
        private void RoundTripButton_Click(object sender, EventArgs e)
        {
            // This method checks if the round trip button is clicked (or it is left as the default),
            // then it makes the return date label and picker and return flight button visible to the customer
            ReturnDateLabel.Visible = true;
            ReturnDatePicker.Visible = true;
            if (AvailableFlightTable.Visible)
            {
                ReturnFlightButton.Visible = true;
                BookFlightButton.Visible = false;
            }
        }
        private void OneWayButton_Click(object sender, EventArgs e)
        {
            // This method checks if the one way button is clicked, then it makes the return date label
            // and picker and return flight button no longer visible to the customer
            ReturnDateLabel.Visible = false;
            ReturnDatePicker.Visible = false;
            if (AvailableFlightTable.Visible)
            {
                AvailableFlightTable.DataSource = null;
                AvailableFlightTable.DataSource = departingRoutes;
                selectedRoutes.Clear();
                ReturnFlightButton.Visible = false;
                if (ReturningFlightsLabel.Visible)
                    ChangeDepartingFlightButton.Visible = false;
                BookFlightButton.Visible = true;
                ReturningFlightsLabel.Visible = false;
                DepartintFlightsLabel.Visible = true;
                FormatGrid();
            }
        }
        private void DepartDatePicker_ValueChanged(object sender, EventArgs e)
        {
            // When the depart date is changed, this method checks if the entered date is 
            // within 6 months and is today or later. If it is within 6 months and after today or today, then the depart date error stays 
            // not visible to the customer. Otherwise, the depart date error is visible
            // to the customer
            DepartDateError.Visible = false;
            DepartDateAfterTodayError.Visible = false;
            DateTime date = DateTime.Today; // get the current time that the customer wants to depart
            var delta1 = DepartDatePicker.Value.Subtract(date.AddMonths(6)); // get the difference in times between 6 months from now and the depart date
            var delta2 = DepartDatePicker.Value.Subtract(date);
            if (delta1.TotalMinutes > 0)
                DepartDateError.Visible = true;
            else if (delta2.TotalMinutes < 0 || DepartDatePicker.Value == DepartDatePicker.MinDate)
                DepartDateAfterTodayError.Visible = true;
        }
        private void ReturnDatePicker_ValueChanged(object sender, EventArgs e)
        {
            // When the return date is changed, this method checks if the entered date is 
            // within 6 months and is after the depart date. If it is within 6 months and after the depart date, then the return date error stays 
            // not visible to the customer. Otherwise, the return date error is visible
            // to the customer
            ReturnDateError.Visible = false;
            ReturnBeforeDepartError.Visible = false;
            DateTime date = DateTime.Today; // get the current time that the customer wants to return
            var delta1 = ReturnDatePicker.Value.Subtract(date.AddMonths(6)); // get the difference in times between 6 months from now and the depart date
            var delta2 = ReturnDatePicker.Value.Subtract(DepartDatePicker.Value);
            if (delta1.TotalMinutes > 0)
                ReturnDateError.Visible = true;
            else if (delta2.TotalMinutes < 0 || ReturnDatePicker.Value == ReturnDatePicker.MinDate)
                ReturnBeforeDepartError.Visible = true;
        }
        private void FormatGrid()
        {
            // This method formats the data grid view with different column names
            AvailableFlightTable.Columns[0].HeaderText = "ID";
            AvailableFlightTable.Columns[1].HeaderText = "Departure Time";
            AvailableFlightTable.Columns[2].HeaderText = "Estimated Arrival Time";
            AvailableFlightTable.Columns[3].HeaderText = "Estimated Duration";
            AvailableFlightTable.Columns[4].HeaderText = "Number of Layovers";
            AvailableFlightTable.Columns[5].HeaderText = "Layover Flight IDs";
            AvailableFlightTable.Columns[6].HeaderText = "Change Plane";
            AvailableFlightTable.Columns[7].HeaderText = "Seats Available on Each Flight";
            AvailableFlightTable.Columns[8].HeaderText = "Cost/Points";
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            // This method first checks if the depart and arrive locations are the same or null.
            // if they are, then errors appear. Otherwise, this method allows the user to select a flight for their depart flight
            var delta1 = ReturnDatePicker.Value.Subtract(DateTime.Today.AddMonths(6)); // get the difference in times between 6 months from now and the depart date
            var delta2 = ReturnDatePicker.Value.Subtract(DepartDatePicker.Value);
            if (delta1.TotalMinutes > 0)
                ReturnDateError.Visible = true;
            else if (delta2.TotalMinutes < 0 || ReturnDatePicker.Value == ReturnDatePicker.MinDate)
                ReturnBeforeDepartError.Visible = true;
            else
            {
                selectedRoutes = new List<Route>();
                DifferentLocationError.Visible = false;
                EmptyError.Visible = false;
                if (DepartComboBox.SelectedValue == ArriveComboBox.SelectedValue)
                    DifferentLocationError.Visible = true;
                else if (DepartComboBox.SelectedIndex == -1 || ArriveComboBox.SelectedIndex == -1)
                    EmptyError.Visible = true;
                else
                {
                    AvailableFlightTable.Visible = true;
                    ChangeDepartingFlightButton.Visible = false;
                    DepartintFlightsLabel.Visible = true;
                    ReturningFlightsLabel.Visible = false;
                    if (OneWayButton.Checked)
                    {
                        ReturnFlightButton.Visible = false;
                        BookFlightButton.Visible = true;
                    }
                    else
                    {
                        ReturnFlightButton.Visible = true;
                        BookFlightButton.Visible = false;
                    }

                    departingRoutes = new List<Route>();
                    // get all of the available flights for the specified origin and destination
                    departingRoutes = SystemAction.GetAvailableRoutes(DepartComboBox.Text.Substring(0, 3), ArriveComboBox.Text.Substring(0, 3));
                    //List<Route> filteredRoutes = SystemAction.FilterRoutes(departingRoutes, departingR);
                    // the available routes list is the datasource for the available flight table
                    AvailableFlightTable.DataSource = departingRoutes;
                    AvailableFlightTable.ClearSelection();
                    FormatGrid();
                }
            }
        }
        private void ReturnFlightButton_Click(object sender, EventArgs e)
        {
            // This method allows the user to select a flight for their return flight
            if (AvailableFlightTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("No Departure Flight was Selected. Please Select a Departure Flight before continuing.", "Error: Choose a Departure Flight", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                selectedRoutes.Add(departingRoutes[tempRouteSelected]);
                AvailableFlightTable.Visible = true;
                ReturnFlightButton.Visible = false;
                BookFlightButton.Visible = true;
                ChangeDepartingFlightButton.Visible = true;
                DepartintFlightsLabel.Visible = false;
                ReturningFlightsLabel.Visible = true;

                returningRoutes = new List<Route>();
                // get all of the available flights for the specified origin and destination
                AvailableFlightTable.DataSource = null;
                returningRoutes = SystemAction.GetAvailableRoutes(DepartComboBox.Text.Substring(0, 3), ArriveComboBox.Text.Substring(0, 3));
                // the available routes list is the datasource for the available flight table
                AvailableFlightTable.DataSource = returningRoutes;
                FormatGrid();
                AvailableFlightTable.ClearSelection();
            }
        }
        private void ChangeDepartingFlightButton_Click(object sender, EventArgs e)
        {
            // This method allows for the user to return to the departing flights table and change their selection
            // It sets the data source of the table to the departing routes and changes some of the buttons' visibility
            selectedRoutes.Clear();
            AvailableFlightTable.ClearSelection();
            AvailableFlightTable.Visible = true;
            ReturnFlightButton.Visible = true;
            BookFlightButton.Visible = false;
            ChangeDepartingFlightButton.Visible = false;
            DepartintFlightsLabel.Visible = true;
            ReturningFlightsLabel.Visible = false;

            AvailableFlightTable.DataSource = null;
            AvailableFlightTable.DataSource = departingRoutes;
            FormatGrid();
        }
        private void BookFlightButton_Click(object sender, EventArgs e)
        {
            // This method is called when the book flight button is clicked
            // First it checks if a flight was selected, then a message pops up if no flight was selected
            // Otherwise, it will add the last flight to a list, then show the payment page and hide this page
            if (AvailableFlightTable.SelectedRows.Count == 0)
                MessageBox.Show("No Flight was Selected. Please Select a Flight before continuing.", "Error: Choose a Flight", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (OneWayButton.Checked)
                {
                    selectedRoutes.Add(departingRoutes[tempRouteSelected]); 
                    ReturnFlightButton.Visible = false;
                    BookFlightButton.Visible = true;
                }
                else
                {
                    selectedRoutes.Add(returningRoutes[tempRouteSelected]);
                    ReturnFlightButton.Visible = true;
                    BookFlightButton.Visible = false;
                }
                PaymentPage payment = new PaymentPage(ref currCustomer, selectedRoutes, DepartDatePicker.Value, ReturnDatePicker.Value, DepartComboBox.SelectedValue.ToString(), ArriveComboBox.SelectedValue.ToString());
                payment.Show();
                selectedRoutes.Clear();
                AvailableFlightTable.ClearSelection();
                AvailableFlightTable.Visible = true;
                ChangeDepartingFlightButton.Visible = false;
                DepartintFlightsLabel.Visible = true;
                ReturningFlightsLabel.Visible = false;
                AvailableFlightTable.DataSource = null;
                AvailableFlightTable.DataSource = departingRoutes;
                FormatGrid();
                this.Hide();
            }
        }
        private void AvailableFlightTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // This method prevents the column header row from being clicked and it gets the route id from the row that has been clicked
            if (e.RowIndex != -1 && AvailableFlightTable.Rows[e.RowIndex].Cells[0].Value != null)
                tempRouteSelected = e.RowIndex;
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            // This method allows the user to return to the home page
            // The current form will close
            // The home page will open
            DialogResult result = MessageBox.Show("Are you sure that you want to return home?\nAny changes not saved will not be updated.", "Account Information", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (result == DialogResult.Yes)
            {
                backButtonClicked = true;
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
                this.Close();
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
    }
}
