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
        private DataTable flightList = new DataTable();


        // This form file is to document the actions done on the Customer Home Page specifically
        public AccountingManagerHomePage()
        {
            InitializeComponent();
            FromTimePicker.CustomFormat = " ";
            FromTimePicker.Format = DateTimePickerFormat.Custom;
            ToTimePicker.CustomFormat = " ";
            ToTimePicker.Format = DateTimePickerFormat.Custom;
            accountPage.Visible = false;


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
            List<FlightModel> flightcap = new List<FlightModel>();



            double capacityPercentage = 0;

            foreach (FlightModel id in flightcap)
            {
                // get the capacity percentage by dividing #of vacant by # plane cap *100

                capacityPercentage = 1 - Math.Round((double)(id.numberOfVacantSeats / SqliteDataAccess.GetPlaneCapacity(id.planeType) * 100));
            }
           





            //   List<int> routeID = SqliteDataAccess.GetTakenFlightIDs(currCustomer.userID);

            string originName = null;
            string destinationName = null;
            // set the dates to the default min value
            DateTime fromDate = DateTimePicker.MinimumDateTime;
            DateTime toDate = DateTimePicker.MinimumDateTime;

            totalFlights.Text = "Total Flights Traveled: " + SqliteDataAccess.GetCompanyFlightCount(originName, destinationName, fromDate, toDate).ToString();
            totalRevenue.Text = "Total Company Income: $" + SqliteDataAccess.GetCompanyIncome(originName, destinationName, fromDate, toDate).ToString("0.00");

            //  accountPage.Rows.Add(totalRevenue);



        }


        private void CreateButton_Click(object sender, EventArgs e)
        {
            {
                List<FlightModel> flightcap = new List<FlightModel>();
                double capacityPercentage = 0;

                foreach (FlightModel id in flightcap)
                {
                    // get the capacity percentage by dividing #of vacant by # plane cap *100

                    capacityPercentage = 1 - Math.Round((double)(id.numberOfVacantSeats / SqliteDataAccess.GetPlaneCapacity(id.planeType) * 100));
                }
               
                // This method displays a list of the flights that have the values that the flight manager filtered on
                BeforeFromDateError.Visible = false;
                string origin = null;
                string destination = null;
                // set the dates to the default min value
                DateTime fromDate = DateTimePicker.MinimumDateTime;
                DateTime toDate = DateTimePicker.MinimumDateTime;
                // if the depart city is not null, then get the origin airport code from the drop down

                // if the arrive city is not null, then get the arrive airport code from the drop down

                // if the from date picker is selected, then get that date
                if (FromTimePicker.Value.TimeOfDay.Ticks == 0)
                {
                    fromDate = FromTimePicker.Value;
                }
                // if the to date picker is selected, then get that date
                if (ToTimePicker.Value.TimeOfDay.Ticks == 0)
                {
                    toDate = ToTimePicker.Value;
                }
                if (fromDate != DateTimePicker.MinimumDateTime && toDate != DateTimePicker.MinimumDateTime && fromDate > toDate)
                    BeforeFromDateError.Visible = true;
                else
                {
                    // change the fromDate and toDate back to the minValue to send through the query
                    if (fromDate == DateTimePicker.MinimumDateTime)
                        fromDate = DateTime.MinValue;
                    if (toDate == DateTimePicker.MinimumDateTime)
                        toDate = DateTime.MinValue;
                    accountPage.DataSource = SqliteDataAccess.GetFlights(origin, destination, fromDate, toDate); // get the flights that have the specified values

                    accountPage.Visible = true; // display the table
                    accountPage.ClearSelection();

                    FormatGrid(); // format the grid
                }
            }
        }

        // formats the datagrid to match right info
        private void FormatGrid()
        {
            //removes information not need on page
            accountPage.Columns.Remove("masterFlightID_fk");
            accountPage.Columns.Remove("distance");
            //  accountPage.Columns.Remove("planeType_fk");
            accountPage.Columns.Remove("flightIncome");


            // renames the column to match correct info
            accountPage.Columns[0].HeaderText = "Flight ID";
            accountPage.Columns[1].HeaderText = "Origin Code";
            accountPage.Columns[2].HeaderText = "Destination Code";
            accountPage.Columns[3].HeaderText = "Departure Date";
            accountPage.Columns[4].HeaderText = "Departure Time";
            accountPage.Columns[5].HeaderText = "Duration";
            accountPage.Columns[6].HeaderText = "Plane Type";
            accountPage.Columns[7].HeaderText = "Cost";
            accountPage.Columns[8].HeaderText = "Number of Vacant Seats";
            //  flightList.Columns.Add("Capacity Percentage", typeof(string));


        }

        Bitmap bmp;

        private void PrintButton_Click(object sender, EventArgs e)
        {
            // get the page height and width to print the data view correctly
            int height = accountPage.Height;
            accountPage.Height = accountPage.RowCount * accountPage.RowTemplate.Height * 2;
            bmp = new Bitmap(accountPage.Width, accountPage.Height);
            accountPage.DrawToBitmap(bmp, new Rectangle(0, 0, accountPage.Width, accountPage.Height));
            accountPage.Height = height;
            printPreviewDialog1.ShowDialog();

        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void FromTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // Once the fromDatePicker's value has changed, the values will be default formatted and the date of the selected date will be selected
            FromTimePicker.CustomFormat = "dddd, MMMM  dd,  yyyy";
            FromTimePicker.Value = FromTimePicker.Value.Date; // this sets the time to midnight, so ticks = 0
            FromDateAfterTodayError.Visible = false;
            var delta = FromTimePicker.Value.Subtract(DateTime.Today); // get the difference between the to date and today
            if (delta.TotalMinutes > 0) // if the from date is after today
                FromDateAfterTodayError.Visible = true;
        }

        private void ToTimePicker_ValueChanged(object sender, EventArgs e)
        {
            {
                // Once the toDatePicker's value has changed, the values will be default formatted and the date of the selected date will be selected
                // This method also makes sure the selected date is the same or after the from date picker
                ToTimePicker.CustomFormat = "dddd, MMMM  dd,  yyyy";
                ToTimePicker.Value = ToTimePicker.Value.Date; // this sets the time to midnight, so ticks = 0
                BeforeFromDateError.Visible = false;
                ToDateAfterTodayError.Visible = false;
                if (FromTimePicker.Value.TimeOfDay.Ticks == 0)
                {
                    var delta1 = ToTimePicker.Value.Subtract(FromTimePicker.Value); // get the difference between the from date and the to date
                    if (delta1.TotalMinutes < 0) // if the to date is before the from date
                        BeforeFromDateError.Visible = true;
                }
                var delta2 = ToTimePicker.Value.Subtract(DateTime.Today); // get the difference between the to date and today
                if (delta2.TotalMinutes > 0) // if the to date is after today
                    ToDateAfterTodayError.Visible = true;
            }
        }

        private void accountPage_SelectionChanged(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            // This method clears all filters and resets them to their defaults
            FromTimePicker.Value = DateTimePicker.MinimumDateTime;
            FromTimePicker.CustomFormat = " ";
            FromTimePicker.Format = DateTimePickerFormat.Custom;
            ToTimePicker.Value = DateTimePicker.MinimumDateTime;
            ToTimePicker.CustomFormat = " ";
            ToTimePicker.Format = DateTimePickerFormat.Custom;
        }

        private void LogOut_Click(object sender, EventArgs e)
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
    }
}