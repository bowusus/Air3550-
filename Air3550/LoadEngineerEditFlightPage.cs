using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace Air3550
{
    public partial class LoadEngineerEditFlightPage : Form
    {
        private static LoadEngineerEditFlightPage instance;
        public LoadEngineerEditFlightPage()
        {
            InitializeComponent();
        }

        public static LoadEngineerEditFlightPage GetInstance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new LoadEngineerEditFlightPage();
                }
                return instance;
            }
        }

        private void LoadEngineerEditFlightPage_Load(object sender, EventArgs e)
        {
            routeTimePicker.Format = DateTimePickerFormat.Custom;
            routeTimePicker.CustomFormat = "hh:mm tt";
            routeTimePicker.ShowUpDown = true;
            routeTimePicker.Value = Convert.ToDateTime(LoadEngineerHomePage.GetInstance.Time);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int newFlightID = SqliteDataAccess.GetLastMasterFlightID();
            SqliteDataAccess.ChangeTimeMaster(LoadEngineerHomePage.GetInstance.FlightID, routeTimePicker.Value, newFlightID);
            SqliteDataAccess.SetRemovalDateRoutes(LoadEngineerHomePage.GetInstance.FlightID);
            SqliteDataAccess.RemoveMasterFlight(LoadEngineerHomePage.GetInstance.FlightID);
            LoadEngineerHomePage.GetInstance.LoadFlightGrid();
            this.Dispose();
        }

        private void routeTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.routeTimePicker.Value.Minute % 5 == 0)
                return;
            else if (this.routeTimePicker.Value.Minute % 5 == 1)
                this.routeTimePicker.Value = this.routeTimePicker.Value.AddMinutes(4);
            else if (this.routeTimePicker.Value.Minute % 5 == 4)
                this.routeTimePicker.Value = this.routeTimePicker.Value.AddMinutes(-4);
        }
    }
}
