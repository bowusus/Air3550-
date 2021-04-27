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
    public partial class LoadEngineerRoutesPage : Form
    {
        // This file is specifically used for the load engineer routes page
        private static LoadEngineerRoutesPage instance; //Singleton-Pattern Instance
        public LoadEngineerRoutesPage()
        {
            InitializeComponent();
        }
        /* Get an already existing instance of this form if it does not exist
         * create it */
        public static LoadEngineerRoutesPage GetInstance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new LoadEngineerRoutesPage();
                }
                return instance;
            }
        }
        /* On load of this page set the data source to the route data grid to the route SQL table */
        private void LoadEngineerRoutesPage_Load(object sender, EventArgs e)
        {
            routeGrid.DataSource = SqliteDataAccess.GetRouteDT();
            routeGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            // change the name of the columns
            routeGrid.Columns[0].HeaderText = "Route ID";
            routeGrid.Columns[1].HeaderText = "Origin Code";
            routeGrid.Columns[2].HeaderText = "Destination Code";
            routeGrid.Columns[3].HeaderText = "Number of Layovers";
            routeGrid.Columns[4].HeaderText = "Master Flight ID #1";
            routeGrid.Columns[5].HeaderText = "Master Flight ID #2";
            routeGrid.Columns[6].HeaderText = "Master Flight ID #3";
            routeGrid.Columns[7].HeaderText = "Last Flight Date";
        }
    }
}
