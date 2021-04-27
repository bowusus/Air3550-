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
    public partial class MarketingManagerEditPage : Form
    {
        // This file is specifically used for the marketing manager edit plane page
        private static MarketingManagerEditPage instance; // Singleton-Pattern instance
        public MarketingManagerEditPage()
        {
            InitializeComponent();
        }
        /* Gets an already existing instance of this page or creates a 
         * new one if it does not exist */
        public static MarketingManagerEditPage GetInstance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new MarketingManagerEditPage();
                }
                return instance;
            }
        }
        /* Updates the masterFlight with the newly selected plane type and disposes of the page while 
         * reloading the flight grid */
        private void saveButton_Click(object sender, EventArgs e)
        {
            SqliteDataAccess.UpdateMasterNewPlane(MarketingManagerHomePage.GetInstance.FlightID, planeTypeDropDown.Text);
            MarketingManagerHomePage.GetInstance.LoadFlightGrid();
            this.Dispose();
        }
        /* Gets all of the plane types from the plane SQL table and sets the current selection
         * to the previous planeType of the selected flight */
        private void MarketingManagerEditPage_Load(object sender, EventArgs e)
        {
            planeTypeDropDown.DataSource = SqliteDataAccess.GetPlaneTypes();
            planeTypeDropDown.Text = MarketingManagerHomePage.GetInstance.PlaneType;
        }
        /* Dispose of the from on closing */
        private void MarketingManagerEditPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
