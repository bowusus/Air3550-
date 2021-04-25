
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flightGrid = new System.Windows.Forms.DataGridView();
            this.removeFlight = new System.Windows.Forms.Button();
            this.addFlight = new System.Windows.Forms.Button();
            this.editFlight = new System.Windows.Forms.Button();
            this.routeButton = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.flightGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // flightGrid
            // 
            this.flightGrid.AllowUserToAddRows = false;
            this.flightGrid.AllowUserToDeleteRows = false;
            this.flightGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flightGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.flightGrid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Rockwell", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.flightGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.flightGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Rockwell", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.flightGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.flightGrid.Location = new System.Drawing.Point(35, 23);
            this.flightGrid.Margin = new System.Windows.Forms.Padding(6);
            this.flightGrid.Name = "flightGrid";
            this.flightGrid.ReadOnly = true;
            this.flightGrid.RowHeadersWidth = 82;
            this.flightGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.flightGrid.Size = new System.Drawing.Size(1525, 892);
            this.flightGrid.TabIndex = 0;
            // 
            // removeFlight
            // 
            this.removeFlight.BackColor = System.Drawing.SystemColors.HotTrack;
            this.removeFlight.Font = new System.Drawing.Font("Rockwell", 10F);
            this.removeFlight.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.removeFlight.Location = new System.Drawing.Point(1623, 323);
            this.removeFlight.Name = "removeFlight";
            this.removeFlight.Size = new System.Drawing.Size(299, 72);
            this.removeFlight.TabIndex = 38;
            this.removeFlight.Text = "Remove Flight";
            this.removeFlight.UseVisualStyleBackColor = false;
            this.removeFlight.Click += new System.EventHandler(this.removeFlight_Click);
            // 
            // addFlight
            // 
            this.addFlight.BackColor = System.Drawing.SystemColors.HotTrack;
            this.addFlight.Font = new System.Drawing.Font("Rockwell", 10F);
            this.addFlight.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addFlight.Location = new System.Drawing.Point(1623, 222);
            this.addFlight.Name = "addFlight";
            this.addFlight.Size = new System.Drawing.Size(299, 72);
            this.addFlight.TabIndex = 37;
            this.addFlight.Text = "Add Flight";
            this.addFlight.UseVisualStyleBackColor = false;
            this.addFlight.Click += new System.EventHandler(this.AddFlight_Click);
            // 
            // editFlight
            // 
            this.editFlight.BackColor = System.Drawing.SystemColors.HotTrack;
            this.editFlight.Font = new System.Drawing.Font("Rockwell", 10F);
            this.editFlight.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.editFlight.Location = new System.Drawing.Point(1623, 426);
            this.editFlight.Name = "editFlight";
            this.editFlight.Size = new System.Drawing.Size(299, 72);
            this.editFlight.TabIndex = 39;
            this.editFlight.Text = "Edit Flight";
            this.editFlight.UseVisualStyleBackColor = false;
            this.editFlight.Click += new System.EventHandler(this.editFlight_Click);
            // 
            // routeButton
            // 
            this.routeButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.routeButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.routeButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.routeButton.Location = new System.Drawing.Point(1623, 516);
            this.routeButton.Name = "routeButton";
            this.routeButton.Size = new System.Drawing.Size(299, 72);
            this.routeButton.TabIndex = 40;
            this.routeButton.Text = "View Routes Offered";
            this.routeButton.UseVisualStyleBackColor = false;
            this.routeButton.Click += new System.EventHandler(this.routeButton_Click);
            // 
            // logOutButton
            // 
            this.logOutButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.logOutButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.logOutButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.logOutButton.Location = new System.Drawing.Point(1623, 38);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(299, 72);
            this.logOutButton.TabIndex = 41;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = false;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // LoadEngineerHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1956, 938);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.routeButton);
            this.Controls.Add(this.editFlight);
            this.Controls.Add(this.removeFlight);
            this.Controls.Add(this.addFlight);
            this.Controls.Add(this.flightGrid);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1982, 1009);
            this.Name = "LoadEngineerHomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air3550";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoadEngineerHomePage_FormClosing);
            this.Load += new System.EventHandler(this.LoadEngineerHomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flightGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView flightGrid;
        private System.Windows.Forms.Button removeFlight;
        private System.Windows.Forms.Button addFlight;
        private System.Windows.Forms.Button editFlight;
        private System.Windows.Forms.Button routeButton;
        private System.Windows.Forms.Button logOutButton;
    }
}

