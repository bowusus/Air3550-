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
        private static LoadEngineerRoutesPage instance;

        public LoadEngineerRoutesPage()
        {
            InitializeComponent();
        }

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

        private void flightGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadEngineerRoutesPage_Load(object sender, EventArgs e)
        {
            routeGrid.DataSource = SqliteDataAccess.GetRouteDT();
        }
    }
}
