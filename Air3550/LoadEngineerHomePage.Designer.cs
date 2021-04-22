
namespace Air3550
{
    partial class LoadEngineerHomePage
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
            this.flightGrid = new System.Windows.Forms.DataGridView();
            this.addFlight = new System.Windows.Forms.Button();
            this.removeFlight = new System.Windows.Forms.Button();
            this.editFlight = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            this.routeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.flightGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // flightGrid
            // 
            this.flightGrid.AllowUserToAddRows = false;
            this.flightGrid.AllowUserToDeleteRows = false;
            this.flightGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.flightGrid.Location = new System.Drawing.Point(12, 12);
            this.flightGrid.Name = "flightGrid";
            this.flightGrid.ReadOnly = true;
            this.flightGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.flightGrid.Size = new System.Drawing.Size(533, 493);
            this.flightGrid.TabIndex = 0;
            // 
            // addFlight
            // 
            this.addFlight.Location = new System.Drawing.Point(551, 115);
            this.addFlight.Name = "addFlight";
            this.addFlight.Size = new System.Drawing.Size(133, 47);
            this.addFlight.TabIndex = 1;
            this.addFlight.Text = "Add Flight";
            this.addFlight.UseVisualStyleBackColor = true;
            this.addFlight.Click += new System.EventHandler(this.AddFlight_Click);
            // 
            // removeFlight
            // 
            this.removeFlight.Location = new System.Drawing.Point(551, 168);
            this.removeFlight.Name = "removeFlight";
            this.removeFlight.Size = new System.Drawing.Size(133, 47);
            this.removeFlight.TabIndex = 2;
            this.removeFlight.Text = "Remove Flight";
            this.removeFlight.UseVisualStyleBackColor = true;
            this.removeFlight.Click += new System.EventHandler(this.removeFlight_Click);
            // 
            // editFlight
            // 
            this.editFlight.Location = new System.Drawing.Point(551, 221);
            this.editFlight.Name = "editFlight";
            this.editFlight.Size = new System.Drawing.Size(133, 47);
            this.editFlight.TabIndex = 3;
            this.editFlight.Text = "Edit Flight";
            this.editFlight.UseVisualStyleBackColor = true;
            this.editFlight.Click += new System.EventHandler(this.editFlight_Click);
            // 
            // logOutButton
            // 
            this.logOutButton.Location = new System.Drawing.Point(551, 12);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(133, 47);
            this.logOutButton.TabIndex = 4;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // routeButton
            // 
            this.routeButton.Location = new System.Drawing.Point(551, 274);
            this.routeButton.Name = "routeButton";
            this.routeButton.Size = new System.Drawing.Size(133, 47);
            this.routeButton.TabIndex = 5;
            this.routeButton.Text = "View Routes Offered";
            this.routeButton.UseVisualStyleBackColor = true;
            this.routeButton.Click += new System.EventHandler(this.routeButton_Click);
            // 
            // LoadEngineerHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(696, 517);
            this.Controls.Add(this.routeButton);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.editFlight);
            this.Controls.Add(this.removeFlight);
            this.Controls.Add(this.addFlight);
            this.Controls.Add(this.flightGrid);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoadEngineerHomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air3550";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoadEngineerHomePage_FormClosing);
            this.Load += new System.EventHandler(this.LoadEngineerHomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flightGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView flightGrid;
        private System.Windows.Forms.Button addFlight;
        private System.Windows.Forms.Button removeFlight;
        private System.Windows.Forms.Button editFlight;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Button routeButton;
    }
}

