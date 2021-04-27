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

    public partial class LoadEngineerLoadingPage : Form
    {
        // This page is specifically used as a loading screen when the load engineer is adding routes
        private static LoadEngineerLoadingPage instance; // Singleton-Pattern Instance
        public LoadEngineerLoadingPage()
        {
            InitializeComponent();
        }
        /* Get an already existing instance of this page if it does not exist then create it */
        public static LoadEngineerLoadingPage GetInstance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new LoadEngineerLoadingPage();
                }
                return instance;
            }
        }
    }

}
