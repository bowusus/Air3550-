
namespace Air3550
{
    partial class FlightManifest
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
            this.FlightIncomeLabel = new System.Windows.Forms.Label();
            this.VacantSeatsLabel = new System.Windows.Forms.Label();
            this.PlaneTypeLabel = new System.Windows.Forms.Label();
            this.DurationLabel = new System.Windows.Forms.Label();
            this.DistanceLabel = new System.Windows.Forms.Label();
            this.DepartureDateTimeLabel = new System.Windows.Forms.Label();
            this.DestinationLabel = new System.Windows.Forms.Label();
            this.OriginLabel = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.FlightManifestTable = new System.Windows.Forms.DataGridView();
            this.PrintButton = new System.Windows.Forms.Button();
            this.FlightManifestLabel = new System.Windows.Forms.Label();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.NoPassengersLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FlightManifestTable)).BeginInit();
            this.SuspendLayout();
            // 
            // FlightIncomeLabel
            // 
            this.FlightIncomeLabel.AutoSize = true;
            this.FlightIncomeLabel.Font = new System.Drawing.Font("Rockwell", 12F);
            this.FlightIncomeLabel.Location = new System.Drawing.Point(1603, 185);
            this.FlightIncomeLabel.Name = "FlightIncomeLabel";
            this.FlightIncomeLabel.Size = new System.Drawing.Size(230, 36);
            this.FlightIncomeLabel.TabIndex = 107;
            this.FlightIncomeLabel.Text = "Flight Income: ";
            // 
            // VacantSeatsLabel
            // 
            this.VacantSeatsLabel.AutoSize = true;
            this.VacantSeatsLabel.Font = new System.Drawing.Font("Rockwell", 12F);
            this.VacantSeatsLabel.Location = new System.Drawing.Point(1550, 270);
            this.VacantSeatsLabel.Name = "VacantSeatsLabel";
            this.VacantSeatsLabel.Size = new System.Drawing.Size(283, 36);
            this.VacantSeatsLabel.TabIndex = 106;
            this.VacantSeatsLabel.Text = "# of Vacant Seats: ";
            // 
            // PlaneTypeLabel
            // 
            this.PlaneTypeLabel.AutoSize = true;
            this.PlaneTypeLabel.Font = new System.Drawing.Font("Rockwell", 12F);
            this.PlaneTypeLabel.Location = new System.Drawing.Point(1084, 185);
            this.PlaneTypeLabel.Name = "PlaneTypeLabel";
            this.PlaneTypeLabel.Size = new System.Drawing.Size(193, 36);
            this.PlaneTypeLabel.TabIndex = 104;
            this.PlaneTypeLabel.Text = "Plane Type: ";
            // 
            // DurationLabel
            // 
            this.DurationLabel.AutoSize = true;
            this.DurationLabel.Font = new System.Drawing.Font("Rockwell", 12F);
            this.DurationLabel.Location = new System.Drawing.Point(358, 270);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(157, 36);
            this.DurationLabel.TabIndex = 103;
            this.DurationLabel.Text = "Duration: ";
            // 
            // DistanceLabel
            // 
            this.DistanceLabel.AutoSize = true;
            this.DistanceLabel.Font = new System.Drawing.Font("Rockwell", 12F);
            this.DistanceLabel.Location = new System.Drawing.Point(1084, 270);
            this.DistanceLabel.Name = "DistanceLabel";
            this.DistanceLabel.Size = new System.Drawing.Size(158, 36);
            this.DistanceLabel.TabIndex = 102;
            this.DistanceLabel.Text = "Distance: ";
            // 
            // DepartureDateTimeLabel
            // 
            this.DepartureDateTimeLabel.AutoSize = true;
            this.DepartureDateTimeLabel.Font = new System.Drawing.Font("Rockwell", 12F);
            this.DepartureDateTimeLabel.Location = new System.Drawing.Point(358, 185);
            this.DepartureDateTimeLabel.Name = "DepartureDateTimeLabel";
            this.DepartureDateTimeLabel.Size = new System.Drawing.Size(330, 36);
            this.DepartureDateTimeLabel.TabIndex = 101;
            this.DepartureDateTimeLabel.Text = "Departure DateTime: ";
            // 
            // DestinationLabel
            // 
            this.DestinationLabel.AutoSize = true;
            this.DestinationLabel.Font = new System.Drawing.Font("Rockwell", 12F);
            this.DestinationLabel.Location = new System.Drawing.Point(55, 270);
            this.DestinationLabel.Name = "DestinationLabel";
            this.DestinationLabel.Size = new System.Drawing.Size(195, 36);
            this.DestinationLabel.TabIndex = 100;
            this.DestinationLabel.Text = "Destination: ";
            // 
            // OriginLabel
            // 
            this.OriginLabel.AutoSize = true;
            this.OriginLabel.Font = new System.Drawing.Font("Rockwell", 12F);
            this.OriginLabel.Location = new System.Drawing.Point(55, 185);
            this.OriginLabel.Name = "OriginLabel";
            this.OriginLabel.Size = new System.Drawing.Size(125, 36);
            this.OriginLabel.TabIndex = 99;
            this.OriginLabel.Text = "Origin: ";
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BackButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.BackButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackButton.Location = new System.Drawing.Point(62, 75);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(276, 72);
            this.BackButton.TabIndex = 97;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // FlightManifestTable
            // 
            this.FlightManifestTable.AllowUserToAddRows = false;
            this.FlightManifestTable.AllowUserToOrderColumns = true;
            this.FlightManifestTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FlightManifestTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FlightManifestTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.FlightManifestTable.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FlightManifestTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.FlightManifestTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FlightManifestTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.FlightManifestTable.Enabled = false;
            this.FlightManifestTable.Location = new System.Drawing.Point(62, 359);
            this.FlightManifestTable.MultiSelect = false;
            this.FlightManifestTable.Name = "FlightManifestTable";
            this.FlightManifestTable.ReadOnly = true;
            this.FlightManifestTable.RowHeadersVisible = false;
            this.FlightManifestTable.RowHeadersWidth = 82;
            this.FlightManifestTable.RowTemplate.Height = 33;
            this.FlightManifestTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FlightManifestTable.Size = new System.Drawing.Size(2101, 630);
            this.FlightManifestTable.TabIndex = 96;
            // 
            // PrintButton
            // 
            this.PrintButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.PrintButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.PrintButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PrintButton.Location = new System.Drawing.Point(1976, 243);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(187, 84);
            this.PrintButton.TabIndex = 95;
            this.PrintButton.Text = "Print";
            this.PrintButton.UseVisualStyleBackColor = false;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // FlightManifestLabel
            // 
            this.FlightManifestLabel.AutoSize = true;
            this.FlightManifestLabel.Font = new System.Drawing.Font("Rockwell", 24F);
            this.FlightManifestLabel.Location = new System.Drawing.Point(661, 75);
            this.FlightManifestLabel.Name = "FlightManifestLabel";
            this.FlightManifestLabel.Size = new System.Drawing.Size(891, 72);
            this.FlightManifestLabel.TabIndex = 94;
            this.FlightManifestLabel.Text = "Flight Manifest for Flight ID #";
            this.FlightManifestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogOutButton
            // 
            this.LogOutButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.LogOutButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.LogOutButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogOutButton.Location = new System.Drawing.Point(1887, 75);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(276, 72);
            this.LogOutButton.TabIndex = 93;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // NoPassengersLabel
            // 
            this.NoPassengersLabel.AutoSize = true;
            this.NoPassengersLabel.Font = new System.Drawing.Font("Rockwell", 24F);
            this.NoPassengersLabel.Location = new System.Drawing.Point(584, 702);
            this.NoPassengersLabel.Name = "NoPassengersLabel";
            this.NoPassengersLabel.Size = new System.Drawing.Size(1143, 72);
            this.NoPassengersLabel.TabIndex = 108;
            this.NoPassengersLabel.Text = "There are no passengers on this flight";
            this.NoPassengersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FlightManifest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(2218, 1064);
            this.Controls.Add(this.NoPassengersLabel);
            this.Controls.Add(this.FlightIncomeLabel);
            this.Controls.Add(this.VacantSeatsLabel);
            this.Controls.Add(this.PlaneTypeLabel);
            this.Controls.Add(this.DurationLabel);
            this.Controls.Add(this.DistanceLabel);
            this.Controls.Add(this.DepartureDateTimeLabel);
            this.Controls.Add(this.DestinationLabel);
            this.Controls.Add(this.OriginLabel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.FlightManifestTable);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.FlightManifestLabel);
            this.Controls.Add(this.LogOutButton);
            this.MaximumSize = new System.Drawing.Size(2244, 1135);
            this.Name = "FlightManifest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air3550";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FlightManifest_FormClosing);
            this.Load += new System.EventHandler(this.FlightManifest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FlightManifestTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FlightIncomeLabel;
        private System.Windows.Forms.Label VacantSeatsLabel;
        private System.Windows.Forms.Label PlaneTypeLabel;
        private System.Windows.Forms.Label DurationLabel;
        private System.Windows.Forms.Label DistanceLabel;
        private System.Windows.Forms.Label DepartureDateTimeLabel;
        private System.Windows.Forms.Label DestinationLabel;
        private System.Windows.Forms.Label OriginLabel;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.DataGridView FlightManifestTable;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Label FlightManifestLabel;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Label NoPassengersLabel;
    }
}

