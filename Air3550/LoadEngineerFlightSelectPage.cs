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
    public partial class LoadEngineerFlightSelectPage : Form
    {
        public static Path selectedPath;
        private List<Path> paths;
        public LoadEngineerFlightSelectPage()
        {
            InitializeComponent();
        }

        private void LoadEngineerFlightSelectPage_Load(object sender, EventArgs e)
        {
            List<Airport> airports = SqliteDataAccess.GetAirports();
            List<FlightModel> directFlights = SqliteDataAccess.GetDirectFlights();
            Airport origin = airports.Find(airport => airport.Code == LoadEngineerODSelectPage.originCode);
            Airport destination = airports.Find(airport => airport.Code == LoadEngineerODSelectPage.destinationCode);
            PathFinder pf = new PathFinder(origin, destination, airports, directFlights);
            paths = pf.BFS();

            foreach(Path path in paths)
            {
                if (path.NumberOfLayovers == 0)
                    routesGridView.Rows.Add(
                        path.PathID, path.NumberOfLayovers, path.Airports[0].Code,
                        "N/A", "N/A", path.Airports[1].Code);

                else if (path.NumberOfLayovers == 1)
                    routesGridView.Rows.Add(
                        path.PathID, path.NumberOfLayovers, path.Airports[0].Code, 
                        path.Airports[1].Code, "N/A", path.Airports[2].Code);

                else
                    routesGridView.Rows.Add(
                        path.PathID, path.NumberOfLayovers, path.Airports[0].Code, 
                        path.Airports[1].Code, path.Airports[2].Code, path.Airports[3].Code);
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            int pathID;
            if(routesGridView.SelectedRows.Count > 0)
            {
                pathID = Convert.ToInt32(routesGridView.SelectedRows[0].Cells["pathID"].Value.ToString());
                selectedPath = paths.Find(path => path.PathID == pathID);
            }

            LoadEngineerTimeSelectPage newForm = new LoadEngineerTimeSelectPage();
            newForm.Location = this.Location;
            newForm.Size = this.Size;
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.FormClosing += delegate { this.Show(); };
            newForm.Show();
            this.Hide();
        }
    }
}
