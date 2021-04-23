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
        }
    }
}
