using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Air3550
{
    public partial class LoadEngineerTimeSelectPage : Form
    {
        public LoadEngineerTimeSelectPage()
        {
            InitializeComponent();
        }

        private void LoadEngineerTimeSelectPage_Load(object sender, EventArgs e)
        {
            routeTimePicker.Format = DateTimePickerFormat.Custom;
            routeTimePicker.CustomFormat = "hh:mm tt";
            routeTimePicker.ShowUpDown = true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            DateTime departureTime = routeTimePicker.Value;
            FlightModel[] flightModels = new FlightModel[LoadEngineerFlightSelectPage.selectedPath.NumberOfLayovers + 1];
            int currentFlightID = SqliteDataAccess.GetLastMasterFlightID();
            for(int i = 0; i < LoadEngineerFlightSelectPage.selectedPath.NumberOfLayovers + 1; i++)
            {
                if (i != 0)
                {
                    int distance = SqliteDataAccess.GetDirectFlightDistance(
                        LoadEngineerFlightSelectPage.selectedPath.Airports[i - 1].Code,
                        LoadEngineerFlightSelectPage.selectedPath.Airports[i].Code);

                    /* 
                     * hours is calculated by time it take to get to destination at 500 mph
                     * plus 30 minutes exiting and entering runway 
                     */
                    decimal hours = (decimal)(distance / 500.0) + .5M + (40/60.0M);
                    decimal minutes = (decimal)(hours - Math.Floor(hours)) * 60.0M;
                    departureTime.AddHours((double)Math.Floor(hours)).AddMinutes((double)(Math.Ceiling(minutes * 5) * 5));

                }

                // Constructing a new flight model for each flight in the path
                flightModels[i] = new FlightModel(
                    currentFlightID,
                    LoadEngineerFlightSelectPage.selectedPath.Airports[i].Code,
                    LoadEngineerFlightSelectPage.selectedPath.Airports[i + 1].Code,
                    SqliteDataAccess.GetDirectFlightDistance(
                        LoadEngineerFlightSelectPage.selectedPath.Airports[i].Code,
                        LoadEngineerFlightSelectPage.selectedPath.Airports[i + 1].Code),
                    departureTime);
                currentFlightID++;
            }
            SqliteDataAccess.AddFlightToMaster(flightModels);
            LoadEngineerHomePage.GetInstance.Show();
            this.Hide();
        }
    }
}
