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
    public partial class AccountingManagerHomePage : Form
    {
        public static List<FlightModel> bookedFlights = new List<FlightModel>();
        public static CustomerModel currCustomer;
        public static int currFlightID;
        public static List<string> departAirports; // list of depart airports
        public static List<string> arriveAirports; // list of arrival airports
        private DataTable flightList = new DataTable();


        // This form file is to document the actions done on the Customer Home Page specifically
        public AccountingManagerHomePage()
        {
            InitializeComponent();
            accountPage.Visible = false;
            departAirports = new List<string>(); // create the list of departing airports
            arriveAirports = new List<string>(); // create the list of arrival airport
        }
        public AccountingManagerHomePage(int flightID)
        {
            InitializeComponent();
            currFlightID = flightID;
        }
        public AccountingManagerHomePage(ref CustomerModel customer)
        {
            // This constructor allows for the object to be accessed in this form
            InitializeComponent();
            // get the current customer and pass that information to the textboxes
            currCustomer = customer;
        }
        private void AccountingManagerHomePage_Load(object sender, EventArgs e)
        {
            bookedFlights = new List<FlightModel>();
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
            accountPage.Visible = false;
            FlightManagerLabel.Visible = false;
            CompanyStatisticsGroupBox.Visible = false;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            // This method displays a list of the flights that have the values that the flight manager filtered on
            BeforeFromDateError.Visible = false;
            DifferentLocationError.Visible = false;
            string origin = null;
            string destination = null;
            // set the dates to the default min value
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
            if (toDate.Date == DateTime.Now.Date)
            {
                toDate = DateTime.Now;
            }
            if (!String.IsNullOrEmpty(DepartComboBox.Text) && !String.IsNullOrEmpty(ArriveComboBox.Text) && DepartComboBox.Text == ArriveComboBox.Text)
                DifferentLocationError.Visible = true;
            if (fromDate.Date > toDate.Date)
                BeforeFromDateError.Visible = true;
            if (BeforeFromDateError.Visible == false && DifferentLocationError.Visible == false)
            {
                CompanyStatisticsGroupBox.Visible = true;
                accountPage.DataSource = SqliteDataAccess.GetFlights(origin, destination, fromDate, toDate); // get the flights that have the specified values
                accountPage.Visible = true; // display the table
                accountPage.ClearSelection();
                TotalFlightCountLabel.Text = "Total Flights Traveled: " + SqliteDataAccess.GetCompanyFlightCount(origin, destination, fromDate, toDate).ToString();
                TotalRevenueLabel.Text = "Total Company Income: $" + SqliteDataAccess.GetCompanyIncome(origin, destination, fromDate, toDate).ToString("0.00");
                FlightManagerLabel.Visible = true;
                FormatGrid(); // format the grid
            }
        }

        // formats the datagrid to match right info
        private void FormatGrid()
        {
            accountPage.Columns.Remove("userid");
            accountPage.Columns.Remove("firstName");
            accountPage.Columns.Remove("lastName");
            accountPage.Columns.Remove("originName");
            accountPage.Columns.Remove("destinationName");
            accountPage.Columns.Remove("arrivalDateTime");
            accountPage.Columns.Remove("duration");
            accountPage.Columns.Remove("numOfPoints");
            // change the name of the columns
            accountPage.Columns[0].HeaderText = "Flight ID";
            accountPage.Columns[1].HeaderText = "Master Flight ID";
            accountPage.Columns[2].HeaderText = "Origin Code";
            accountPage.Columns[3].HeaderText = "Destination Code";
            accountPage.Columns[4].HeaderText = "Distance (in miles)";
            accountPage.Columns[5].HeaderText = "Departure Date and Time";
            accountPage.Columns[6].HeaderText = "Duration (in hours...ex: 1.5 = 1 hour 30 minutes)";
            accountPage.Columns[7].HeaderText = "Plane Type";
            accountPage.Columns[8].HeaderText = "Cost (in dollars)";
            accountPage.Columns[9].HeaderText = "Number of Vacant Seats";
            accountPage.Columns[10].HeaderText = "% Full Capacity";
            accountPage.Columns[11].HeaderText = "Flight Income (in dollars)";
            accountPage.ClearSelection();
        }

        Bitmap bmp;

        private void PrintButton_Click(object sender, EventArgs e)
        {
            // get the page height and width to print the data view correctly
            int height = accountPage.Height;
            accountPage.Height = accountPage.RowCount * accountPage.RowTemplate.Height * 2;
            bmp = new Bitmap(accountPage.Width, accountPage.Height);
            accountPage.DrawToBitmap(bmp, new Rectangle(0, 20, accountPage.Width, accountPage.Height));
            accountPage.Height = height;
            printPreviewDialog1.ShowDialog();

        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 20);
            var g = e.Graphics;
            var srcRect = new Rectangle(0, 0, CompanyStatisticsGroupBox.Width, CompanyStatisticsGroupBox.Height);
            var desRect = new Rectangle(e.PageBounds.X, e.PageBounds.Y, e.PageBounds.Width, srcRect.Height);
            //Or to draw within the margin
            using (var bmp = new Bitmap(srcRect.Width, srcRect.Height))
            {
                CompanyStatisticsGroupBox.DrawToBitmap(bmp, srcRect);
                g.DrawImage(bmp, desRect, srcRect, GraphicsUnit.Pixel);
            }
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
        private void accountPage_CellClick(object sender, EventArgs e)
        {
            
            double capacityPercentage = 0;
             if (accountPage.SelectedRows.Count > 0)
            {
                // get the capacity percentage by dividing #of vacant by # plane cap *100
                // add comments
                capacityPercentage = Math.Round((1.0 - (double)((Convert.ToDouble(accountPage.SelectedRows[0].Cells["numOfVacantSeats"].Value.ToString())
                                        / (double)SqliteDataAccess.GetPlaneCapacity(accountPage.SelectedRows[0].Cells["planeType_fk"].Value.ToString())))) * 100.0, 2);
            }

             // displays the plane capacity %
            Label1.Text = "Plane Capacity Percentage: " + capacityPercentage + " % ";
        }
        private void ClearFiltersButton_Click(object sender, EventArgs e)
        {
            // This method clears all filters and resets them to their defaults
            DepartComboBox.SelectedIndex = -1;
            ArriveComboBox.SelectedIndex = -1;
            FromDatePicker.ResetText();
            ToDatePicker.ResetText();
            FlightManagerLabel.Visible = false;
            accountPage.Visible = false;
            BeforeFromDateError.Visible = false;
            DifferentLocationError.Visible = false;
            CompanyStatisticsGroupBox.Visible = false;
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
        private void AccountingManagerHomePage_FormClosing(object sender, FormClosingEventArgs e)
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