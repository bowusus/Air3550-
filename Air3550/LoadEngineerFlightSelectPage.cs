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
            List<Path> paths = pf.BFS();

            foreach(Path path in paths)
            {
                if (path.NumberOfLayovers == 0) 
                    routesGridView.Rows.Add(
                        path.NumberOfLayovers, path.Airports[0].Code, 
                        "N/A", "N/A", path.Airports[1].Code);

                else if (path.NumberOfLayovers == 1)
                    routesGridView.Rows.Add(
                        path.NumberOfLayovers, path.Airports[0].Code, 
                        path.Airports[1].Code, "N/A", path.Airports[2].Code);

                else
                    routesGridView.Rows.Add(
                        path.NumberOfLayovers, path.Airports[0].Code, 
                        path.Airports[1].Code, path.Airports[2].Code, path.Airports[3].Code);
            }
        }

    }
}
