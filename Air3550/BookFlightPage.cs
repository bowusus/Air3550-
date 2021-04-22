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
    public partial class BookFlightPage : Form
    {
        // This form file is to document the actions done on the Book Flight Page specifically
        private static BookFlightPage instance;
        public static CustomerModel currCustomer; // make a local object that can be read in the current context
        public static List<string> departAirports; // list of depart airports
        public static List<string> arriveAirports; // list of arrival airports
        public static List<Route> departingRoutes; // list of departing flights that gets updated throughout the form
        public static List<Route> departingFilter; // list of departing flights with flights checked against a few "filters"
        public static List<Route> returningRoutes; // list of returning flights that gets updated throughout the form
        public static List<Route> returningFilter; // list of returning flights with flights checked against a few "filters"
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
        public static BookFlightPage GetInstance(ref CustomerModel customer)
        {
            // This method follows the singleton pattern to allow for one form to be used rather than multiple being created
            if (instance == null || instance.IsDisposed)
            {
                instance = new BookFlightPage(ref customer);
            }
            return instance;
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
            // set buttons, labels, and the table visibility
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
            // if the search has already been clicked, then if the round trip button is clicked, the return flight button should be visible and the book flight button should not be visible
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
            // if the search has already been clicked, then if the one way button is clicked, the return flight button should not be visible and the book flight button should be visible
            if (AvailableFlightTable.Visible)
            {
                // set the datasource to null then departing filtered routes
                AvailableFlightTable.DataSource = null;
                AvailableFlightTable.DataSource = departingFilter;
                // clear the selected routes
                selectedRoutes.Clear();
                // set the button's and label's visibility
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
            var delta2 = DepartDatePicker.Value.Subtract(date); // get the difference between now and the depart date
            if (delta1.TotalMinutes > 0) // if the depart date is not within 6 months, then an error displays
                DepartDateError.Visible = true;
            else if (delta2.TotalMinutes < 0) // if the depart date is before today, then an error displays
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
            DateTime date = DateTime.Today; // get the current datetime
            var delta1 = ReturnDatePicker.Value.Subtract(date.AddMonths(6)); // get the difference in times between 6 months from now and the return date
            var delta2 = ReturnDatePicker.Value.Subtract(DepartDatePicker.Value); // get the difference between the depart date and the return date
            if (delta1.TotalMinutes > 0) // if the return date is not within 6 months, then an error displays
                ReturnDateError.Visible = true;
            else if (delta2.TotalMinutes < 0) // if the return date is before today, then an error displays
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
            // This method first checks if the depart and arrive locations are the same or null and if the departure date is today or later and  return date is within 6 months and after the depart date.
            // if they are, then errors appear. Otherwise, this method allows the user to select a flight for their depart flight
            var delta1 = ReturnDatePicker.Value.Subtract(DateTime.Today.AddMonths(6)); // get the difference in times between 6 months from now and the depart date
            var delta2 = ReturnDatePicker.Value.Subtract(DepartDatePicker.Value); // get the difference between the return date and departure date
            // default set the different locations and empty errors to false
            DifferentLocationError.Visible = false;
            EmptyError.Visible = false;
            // if origin, destination, or depart/return date times are invalid, then produce an error label
            if (!OneWayButton.Checked)
            {
                if (delta1.TotalMinutes > 0)
                    ReturnDateError.Visible = true;
                else if (delta2.TotalMinutes < 0)
                    ReturnBeforeDepartError.Visible = true;
            }
            if (DepartComboBox.SelectedValue == ArriveComboBox.SelectedValue)
                DifferentLocationError.Visible = true;
            else if (DepartComboBox.SelectedIndex == -1 || ArriveComboBox.SelectedIndex == -1)
                EmptyError.Visible = true;
            // if the origin, destination, and depart/return date times are correct, then show available flights
            if (ReturnDateError.Visible == false && ReturnBeforeDepartError.Visible == false && DifferentLocationError.Visible == false && EmptyError.Visible == false)
            {
                selectedRoutes = new List<Route>();
                // set the default visibility of the page features
                AvailableFlightTable.Visible = true;
                ChangeDepartingFlightButton.Visible = false;
                DepartintFlightsLabel.Visible = true;
                ReturningFlightsLabel.Visible = false;
                // if the one way button was clicked, then make the book flight button still visible, and make the return flight button not visible
                // if the round trip button was clicked, then make the book flight button not visible, and make the return flight button visible
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
                departingFilter = new List<Route>();
                // get all of the available flights for the specified origin and destination
                if (OneWayButton.Checked)
                    departingRoutes = SystemAction.GetAvailableRoutes(DepartComboBox.Text.Substring(0, 3), ArriveComboBox.Text.Substring(0, 3), DepartDatePicker.Value.Date, DateTime.MinValue);
                else
                    departingRoutes = SystemAction.GetAvailableRoutes(DepartComboBox.Text.Substring(0, 3), ArriveComboBox.Text.Substring(0, 3), DepartDatePicker.Value.Date, ReturnDatePicker.Value.Date);
                // filter those flights
                //departingFilter = SystemAction.FilterRoutes(departingRoutes, DepartDatePicker.Value, DateTime.Now); ;
                // the filtered departing routes list is the datasource for the available flight table
                AvailableFlightTable.DataSource = departingRoutes;
                // clear the table's selection so no row is clicked
                AvailableFlightTable.ClearSelection();
                FormatGrid();
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
                // add the selected flight to the selected routes list
                selectedRoutes.Add(departingFilter[tempRouteSelected]);
                // set some of the buttons, labels, and the table visibility
                AvailableFlightTable.Visible = true;
                ReturnFlightButton.Visible = false;
                BookFlightButton.Visible = true;
                ChangeDepartingFlightButton.Visible = true;
                DepartintFlightsLabel.Visible = false;
                ReturningFlightsLabel.Visible = true;

                returningRoutes = new List<Route>();
                returningFilter = new List<Route>();
                // get all of the available flights for the specified origin and destination
                AvailableFlightTable.DataSource = null;
                if (OneWayButton.Checked)
                    returningRoutes = SystemAction.GetAvailableRoutes(DepartComboBox.Text.Substring(0, 3), ArriveComboBox.Text.Substring(0, 3), DepartDatePicker.Value.Date, DateTime.MinValue);
                else
                    returningRoutes = SystemAction.GetAvailableRoutes(DepartComboBox.Text.Substring(0, 3), ArriveComboBox.Text.Substring(0, 3), DepartDatePicker.Value.Date, ReturnDatePicker.Value.Date);
                // filter those flights
                returningFilter = SystemAction.FilterRoutes(returningRoutes, ReturnDatePicker.Value, selectedRoutes[0].departTime); ;
                // the filtered returning routes list is the datasource for the available flight table
                AvailableFlightTable.DataSource = returningFilter;
                // clear the table's selection so no row is clicked
                AvailableFlightTable.ClearSelection();
                FormatGrid();
            }
        }
        private void ChangeDepartingFlightButton_Click(object sender, EventArgs e)
        {
            // This method allows for the user to return to the departing flights table and change their selection
            // It sets the data source of the table to the departing filtered routes and changes some of the buttons' visibility
            selectedRoutes.Clear();
            // set button's, table, and labels visibility
            AvailableFlightTable.Visible = true;
            ReturnFlightButton.Visible = true;
            BookFlightButton.Visible = false;
            ChangeDepartingFlightButton.Visible = false;
            DepartintFlightsLabel.Visible = true;
            ReturningFlightsLabel.Visible = false;
            // change the data source the departing filtered routes
            AvailableFlightTable.DataSource = null;
            AvailableFlightTable.DataSource = departingFilter;
            // clear the table's selection
            AvailableFlightTable.ClearSelection();
            FormatGrid();
        }
        private void BookFlightButton_Click(object sender, EventArgs e)
        {
            // This method is called when the book flight button is clicked
            // First it checks if a flight was selected, then a message pops up if no flight was selected
            // Otherwise, it will add the last flight to a list, then show the payment page and hide this page
            // This page is reset to what the user saw when they first pressed search
            if (AvailableFlightTable.SelectedRows.Count == 0)
                MessageBox.Show("No Flight was Selected. Please Select a Flight before continuing.", "Error: Choose a Flight", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                // if the one way button was clicked, then add the selected flight, make the book flight button still visible, and make the return flight button not visible
                // if the round trip button was clicked, then add the selected return flight, make the book flight button not visible, and make the return flight button visible
                if (OneWayButton.Checked)
                {
                    selectedRoutes.Add(departingFilter[tempRouteSelected]); 
                    ReturnFlightButton.Visible = false;
                    BookFlightButton.Visible = true;
                }
                else
                {
                    selectedRoutes.Add(returningFilter[tempRouteSelected]);
                    ReturnFlightButton.Visible = true;
                    BookFlightButton.Visible = false;
                }
                // Get the payment page and send the required information
                PaymentPage.GetInstance(ref currCustomer, selectedRoutes, DepartDatePicker.Value, ReturnDatePicker.Value, DepartComboBox.SelectedValue.ToString(), ArriveComboBox.SelectedValue.ToString()).Show();
                // reset the page to what the user saw when they first started booking a flight plus the table 
                selectedRoutes.Clear();
                AvailableFlightTable.Visible = true;
                ChangeDepartingFlightButton.Visible = false;
                DepartintFlightsLabel.Visible = true;
                ReturningFlightsLabel.Visible = false;
                AvailableFlightTable.DataSource = null;
                AvailableFlightTable.DataSource = departingFilter;
                AvailableFlightTable.ClearSelection();
                FormatGrid();
                this.Dispose();
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
        private void BookFlightPage_FormClosing(object sender, FormClosingEventArgs e)
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
