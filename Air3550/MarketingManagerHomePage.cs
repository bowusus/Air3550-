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
    public partial class MarketingManagerHomePage : Form
    {
        private static MarketingManagerHomePage instance;
        private string planeType;
        private int flightID;

        // This form file is to document the actions done on the Customer Home Page specifically
        public MarketingManagerHomePage()
        {
            InitializeComponent();
        }

        public string PlaneType { get => planeType; set => planeType = value; }
        public int FlightID { get => flightID; set => flightID = value; }
        public static MarketingManagerHomePage GetInstance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new MarketingManagerHomePage();
                }
                return instance;
            }
        }


        private void editFlight_Click(object sender, EventArgs e)
        {
            if (flightGrid.SelectedRows.Count > 0)
            {
                planeType = flightGrid.SelectedRows[0].Cells["planeType"].Value.ToString();
                flightID = Convert.ToInt32(flightGrid.SelectedRows[0].Cells["masterFlightID"].Value.ToString());
                MarketingManagerEditPage.GetInstance.Show();
                MarketingManagerEditPage.GetInstance.Location = this.Location;
            }
        }

        public void LoadFlightGrid()
        {
            flightGrid.DataSource = SqliteDataAccess.GetMasterFlightDT();
        }

        private void MarketingManagerHomePage_Load(object sender, EventArgs e)
        {
            LoadFlightGrid();
        }
    }
}
