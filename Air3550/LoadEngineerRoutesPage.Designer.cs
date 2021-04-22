
namespace Air3550
{
    partial class LoadEngineerRoutesPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.routeGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.routeGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // routeGrid
            // 
            this.routeGrid.AllowUserToAddRows = false;
            this.routeGrid.AllowUserToDeleteRows = false;
            this.routeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.routeGrid.Location = new System.Drawing.Point(12, 12);
            this.routeGrid.Name = "routeGrid";
            this.routeGrid.ReadOnly = true;
            this.routeGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.routeGrid.ShowCellToolTips = false;
            this.routeGrid.Size = new System.Drawing.Size(533, 493);
            this.routeGrid.TabIndex = 1;
            this.routeGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.flightGrid_CellContentClick);
            // 
            // LoadEngineerRoutesPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 516);
            this.Controls.Add(this.routeGrid);
            this.Name = "LoadEngineerRoutesPage";
            this.Text = "LoadEngineerRoutesPage";
            this.Load += new System.EventHandler(this.LoadEngineerRoutesPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.routeGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView routeGrid;
    }
}