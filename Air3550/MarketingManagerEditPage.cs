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
        private static MarketingManagerEditPage instance;

        // This form file is to document the actions done on the Customer Home Page specifically
        public MarketingManagerEditPage()
        {
            InitializeComponent();
        }
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            SqliteDataAccess.UpdateMasterNewPlane(MarketingManagerHomePage.GetInstance.FlightID, planeTypeDropDown.Text);
            MarketingManagerHomePage.GetInstance.LoadFlightGrid();
            this.Dispose();
        }

        private void MarketingManagerEditPage_Load(object sender, EventArgs e)
        {
            planeTypeDropDown.DataSource = SqliteDataAccess.GetPlaneTypes();
            planeTypeDropDown.Text = MarketingManagerHomePage.GetInstance.PlaneType;
        }

        private void MarketingManagerEditPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
