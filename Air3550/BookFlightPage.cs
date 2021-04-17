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
        public static List<string> airportsShown;
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
            airportsShown = new List<string>();
            // make the various error labels initially not visible
            DifferentLocationError.Visible = false;
            DepartDateError.Visible = false;
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
                airportsShown.Add(currAir);
            }
            DepartComboBox.DataSource = airportsShown;
            DepartComboBox.SelectedItem = null;
            DepartComboBox.SelectedText = "--Select Location--";
            ArriveComboBox.DataSource = airportsShown;
            ArriveComboBox.SelectedItem = null;
            ArriveComboBox.SelectedText = "--Select Location--";
            RoundTripButton.Checked = true;
            OneWayButton.Checked = false;
            AvailableFlightTable.Visible = false;
        }
        private void RoundTripButton_Click(object sender, EventArgs e)
        {
            // This method checks if the round trip button is clicked (or it is left as the default),
            // then it makes the return date label and picker visible to the customer
            ReturnDateLabel.Visible = true;
            ReturnDatePicker.Visible = true;
        }
        private void OneWayButton_Click(object sender, EventArgs e)
        {
            // This method checks if the one way button is clicked, then it makes the return date label
            // and picker no longer visible to the customer
            ReturnDateLabel.Visible = false;
            ReturnDatePicker.Visible = false;
        }
        private void DepartDatePicker_ValueChanged(object sender, EventArgs e)
        {
            // When the depart date is changed, this method checks if the entered date is 
            // within 6 months. If it is within 6 months, then the depart date error stays 
            // not visible to the customer. Otherwise, the depart date error is visible
            // to the customer
            DepartDateError.Visible = false;
            DateTime date = DateTime.Today; // get the current time that the customer wants to depart
            var delta = DepartDatePicker.Value.Subtract(date.AddMonths(6)); // get the difference in times between 6 months from now and the depart date
            if (delta.TotalMinutes > 0)
                DepartDateError.Visible = true;
        }
        private void ReturnDatePicker_ValueChanged(object sender, EventArgs e)
        {
            // When the return date is changed, this method checks if the entered date is 
            // within 6 months. If it is within 6 months, then the return date error stays 
            // not visible to the customer. Otherwise, the return date error is visible
            // to the customer
            ReturnDateError.Visible = false;
            DateTime date = DateTime.Today; // get the current time that the customer wants to return
            var delta = ReturnDatePicker.Value.Subtract(date.AddMonths(6)); // get the difference in times between 6 months from now and the return date
            if (delta.TotalMinutes > 0)
                ReturnDateError.Visible = true;
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            // This method first checks if the depart and arrive locations are the same or null.
            // if they are, then errors appear. Otherwise, the available flights appear.
            DifferentLocationError.Visible = false;
            if (DepartComboBox.SelectedValue == ArriveComboBox.SelectedValue)
                DifferentLocationError.Visible = true;
            else if (String.IsNullOrEmpty(DepartComboBox.SelectedValue.ToString()) || String.IsNullOrEmpty(ArriveComboBox.SelectedValue.ToString()))
                DifferentLocationError.Visible = true;
            else
                AvailableFlightTable.Visible = true;
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
