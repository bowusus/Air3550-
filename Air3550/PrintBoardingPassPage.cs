﻿using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Air3550
{
    public partial class PrintBoardingPassPage : Form
    {
        // This form file is to document the actions done on the Print Boarding Pass Page specifically
        public static CustomerModel currCustomer; // make a local object that can be read in the current context
        public static bool logOutButtonClicked = false; 
        public static bool backButtonClicked = false;
        public static List<FlightModel> bookedFlights = new List<FlightModel>();
        public static FlightModel flight;
        public static List<CustomerModel> name;
        public static PrintBoardingPassPage instance;
       private bool printbuttonclicked = false;



        public PrintBoardingPassPage()
        {
            InitializeComponent();
        }
        public PrintBoardingPassPage(ref CustomerModel customer)
        {
            //This constructor allows for the object to be accessed in this form

            InitializeComponent();
            // get the current customer and pass that information to the textboxes

            currCustomer = customer;

        }
        public static PrintBoardingPassPage GetInstance(ref CustomerModel customer)
        {
            // This method follows the singleton pattern to allow for one form to be used rather than multiple being created
            if (instance == null || instance.IsDisposed)
            {
                instance = new PrintBoardingPassPage(ref customer);
            }
            return instance;
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


        private void PrintBoardingPassPage_Load(object sender, EventArgs e)
        {
            // Loads all the customers booked flight onto a datagrid view 
            // and allow the customer to select which boarding pass to print
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
                                    flight = SystemAction.GetBoardingFlights(flightIDs_Booked[j], i, ref currCustomer);
                                    i = 0;
                                }
                                else
                                {
                                    flight = SystemAction.GetBoardingFlights(flightIDs_Booked[j], i, ref currCustomer);
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
            FormatDataGrid(); // remove and rename certain columns
        }
        // Used to rename and remove certain columns not needed in the boarding pass
        public void FormatDataGrid()
        {
            // This method renames and removes some columns that do not get updated when the data in the datagridview gets updated
            // Remove some information that the employees need but not the customer

            dataGridView1.Columns["durDouble"].Visible = false;
            dataGridView1.Columns["masterFlightID"].Visible = false;
            dataGridView1.Columns["originCode"].Visible = false;
            dataGridView1.Columns["destinationCode"].Visible = false;
            dataGridView1.Columns["distance"].Visible = false;
            dataGridView1.Columns["planeType"].Visible = false;
            dataGridView1.Columns["cost"].Visible = false;
            dataGridView1.Columns["numOfPoints"].Visible = false;
            dataGridView1.Columns["numberOfVacantSeats"].Visible = false;
            dataGridView1.Columns["flightIncome"].Visible = false;







            // change the name of the columns
            dataGridView1.Columns[0].HeaderText = "FlightID";
            dataGridView1.Columns[1].HeaderText = "UserID";
            dataGridView1.Columns[2].HeaderText = "First Name";
            dataGridView1.Columns[3].HeaderText = "Last Name";
            dataGridView1.Columns[7].HeaderText = "Origin Name";
            dataGridView1.Columns[9].HeaderText = "Destination Name";
            dataGridView1.Columns[11].HeaderText = "Depature Time and Date";
            dataGridView1.Columns[12].HeaderText = "Arrival Time and Date";
            dataGridView1.Columns[13].HeaderText = "Duration";

        }


        private void PrintButton_Click(object sender, EventArgs e)
        {

            DateTime time = DateTime.Now;

            if (bookedFlights.Count == 0)
                MessageBox.Show("You do not have any booked flights available", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DialogResult result = MessageBox.Show("Are you sure that you would like to print board pass?", "Print pass", MessageBoxButtons.YesNo, MessageBoxIcon.None);
                if (result == DialogResult.Yes)


                    if (result == DialogResult.Yes)
                    {
                        var _time = bookedFlights[0].departureDateTime.Subtract(time);
                        printbuttonclicked = true;

                        // Boarding will be available to print 24 hours before a flight is scheduled to depart
                        if (_time.TotalMinutes > 1440)
                        {
                            PrintPreviewDialog ppd = new PrintPreviewDialog();
                            PrintDocument Pd = new PrintDocument();
                            PrinterSettings PrinterSetting = new PrinterSettings();
                          //  Pd.PrinterSettings.PrinterName = "Eltron P310 Card Printer";
                            Pd.PrinterSettings.Copies = 1;
                            Pd.PrinterSettings.DefaultPageSettings.Landscape = true;

                            Pd.PrintPage += printDocument1_PrintPage;
                            ppd.Document = Pd;
                            printPreviewDialog1.ShowDialog();

                        }

                        else
                            MessageBox.Show("You are within 24 hours of your flight and can not print boaring pass", "Print Boarding Pass", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

            }
        }

        // this method prints the groupbox object with all the information in it 
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var g = e.Graphics;
            var srcRect = new Rectangle(0, 0, groupBox1.Width, groupBox1.Height);
            var desRect = new Rectangle(e.PageBounds.X, e.PageBounds.Y, e.PageBounds.Width, srcRect.Height);
            //Or to draw within the margin
           

            using (var bmp = new Bitmap(srcRect.Width, srcRect.Height))
            {
                groupBox1.DrawToBitmap(bmp, srcRect);
                g.DrawImage(bmp, desRect, srcRect, GraphicsUnit.Pixel);
            }
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FormatDataGrid();
            if (e.RowIndex != -1)
            {
               
                // Populate to the boarding pass page the info needed for the boarding pass
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                FlightIDText.Text = row.Cells[0].Value.ToString();
                OriginText.Text = row.Cells[7].Value.ToString();
                FirstNameText.Text = row.Cells[2].Value.ToString();
                UserIDText.Text = row.Cells[1].Value.ToString();
                DesText.Text = row.Cells[9].Value.ToString();
                DepText.Text = row.Cells[11].Value.ToString();
                ArrivalText.Text = row.Cells[12].Value.ToString();
                LastNameText.Text = row.Cells[3].Value.ToString();


            }
        }
    }
}
