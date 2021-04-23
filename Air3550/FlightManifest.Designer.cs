
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FlightManifestLabel = new System.Windows.Forms.Label();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.FlightManifestTable = new System.Windows.Forms.DataGridView();
            this.PrintButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.OriginLabel = new System.Windows.Forms.Label();
            this.DestinationLabel = new System.Windows.Forms.Label();
            this.DepartureDateTimeLabel = new System.Windows.Forms.Label();
            this.DistanceLabel = new System.Windows.Forms.Label();
            this.DurationLabel = new System.Windows.Forms.Label();
            this.PlaneTypeLabel = new System.Windows.Forms.Label();
            this.CostLabel = new System.Windows.Forms.Label();
            this.VacantSeatsLabel = new System.Windows.Forms.Label();
            this.FlightIncomeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FlightManifestTable)).BeginInit();
            this.SuspendLayout();
            // 
            // FlightManifestLabel
            // 
            this.FlightManifestLabel.AutoSize = true;
            this.FlightManifestLabel.Font = new System.Drawing.Font("Rockwell", 24F);
            this.FlightManifestLabel.Location = new System.Drawing.Point(666, 98);
            this.FlightManifestLabel.Name = "FlightManifestLabel";
            this.FlightManifestLabel.Size = new System.Drawing.Size(891, 72);
            this.FlightManifestLabel.TabIndex = 64;
            this.FlightManifestLabel.Text = "Flight Manifest for Flight ID #";
            this.FlightManifestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogOutButton
            // 
            this.LogOutButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.LogOutButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.LogOutButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogOutButton.Location = new System.Drawing.Point(1892, 98);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(276, 72);
            this.LogOutButton.TabIndex = 63;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // FlightManifestTable
            // 
            this.FlightManifestTable.AllowUserToAddRows = false;
            this.FlightManifestTable.AllowUserToOrderColumns = true;
            this.FlightManifestTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FlightManifestTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FlightManifestTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.FlightManifestTable.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FlightManifestTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.FlightManifestTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FlightManifestTable.DefaultCellStyle = dataGridViewCellStyle8;
            this.FlightManifestTable.Enabled = false;
            this.FlightManifestTable.Location = new System.Drawing.Point(67, 382);
            this.FlightManifestTable.MultiSelect = false;
            this.FlightManifestTable.Name = "FlightManifestTable";
            this.FlightManifestTable.ReadOnly = true;
            this.FlightManifestTable.RowHeadersVisible = false;
            this.FlightManifestTable.RowHeadersWidth = 82;
            this.FlightManifestTable.RowTemplate.Height = 33;
            this.FlightManifestTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FlightManifestTable.Size = new System.Drawing.Size(2101, 630);
            this.FlightManifestTable.TabIndex = 74;
            // 
            // PrintButton
            // 
            this.PrintButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.PrintButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.PrintButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PrintButton.Location = new System.Drawing.Point(1981, 266);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(187, 84);
            this.PrintButton.TabIndex = 73;
            this.PrintButton.Text = "Print";
            this.PrintButton.UseVisualStyleBackColor = false;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BackButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.BackButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackButton.Location = new System.Drawing.Point(67, 98);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(276, 72);
            this.BackButton.TabIndex = 80;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 81;
            this.label1.Text = "label1";
            // 
            // OriginLabel
            // 
            this.OriginLabel.AutoSize = true;
            this.OriginLabel.Font = new System.Drawing.Font("Rockwell", 12F);
            this.OriginLabel.Location = new System.Drawing.Point(60, 208);
            this.OriginLabel.Name = "OriginLabel";
            this.OriginLabel.Size = new System.Drawing.Size(125, 36);
            this.OriginLabel.TabIndex = 82;
            this.OriginLabel.Text = "Origin: ";
            // 
            // DestinationLabel
            // 
            this.DestinationLabel.AutoSize = true;
            this.DestinationLabel.Font = new System.Drawing.Font("Rockwell", 12F);
            this.DestinationLabel.Location = new System.Drawing.Point(60, 293);
            this.DestinationLabel.Name = "DestinationLabel";
            this.DestinationLabel.Size = new System.Drawing.Size(195, 36);
            this.DestinationLabel.TabIndex = 85;
            this.DestinationLabel.Text = "Destination: ";
            // 
            // DepartureDateTimeLabel
            // 
            this.DepartureDateTimeLabel.AutoSize = true;
            this.DepartureDateTimeLabel.Font = new System.Drawing.Font("Rockwell", 12F);
            this.DepartureDateTimeLabel.Location = new System.Drawing.Point(363, 208);
            this.DepartureDateTimeLabel.Name = "DepartureDateTimeLabel";
            this.DepartureDateTimeLabel.Size = new System.Drawing.Size(330, 36);
            this.DepartureDateTimeLabel.TabIndex = 86;
            this.DepartureDateTimeLabel.Text = "Departure DateTime: ";
            // 
            // DistanceLabel
            // 
            this.DistanceLabel.AutoSize = true;
            this.DistanceLabel.Font = new System.Drawing.Font("Rockwell", 12F);
            this.DistanceLabel.Location = new System.Drawing.Point(672, 293);
            this.DistanceLabel.Name = "DistanceLabel";
            this.DistanceLabel.Size = new System.Drawing.Size(158, 36);
            this.DistanceLabel.TabIndex = 87;
            this.DistanceLabel.Text = "Distance: ";
            // 
            // DurationLabel
            // 
            this.DurationLabel.AutoSize = true;
            this.DurationLabel.Font = new System.Drawing.Font("Rockwell", 12F);
            this.DurationLabel.Location = new System.Drawing.Point(363, 293);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(157, 36);
            this.DurationLabel.TabIndex = 88;
            this.DurationLabel.Text = "Duration: ";
            // 
            // PlaneTypeLabel
            // 
            this.PlaneTypeLabel.AutoSize = true;
            this.PlaneTypeLabel.Font = new System.Drawing.Font("Rockwell", 12F);
            this.PlaneTypeLabel.Location = new System.Drawing.Point(1089, 208);
            this.PlaneTypeLabel.Name = "PlaneTypeLabel";
            this.PlaneTypeLabel.Size = new System.Drawing.Size(193, 36);
            this.PlaneTypeLabel.TabIndex = 89;
            this.PlaneTypeLabel.Text = "Plane Type: ";
            // 
            // CostLabel
            // 
            this.CostLabel.AutoSize = true;
            this.CostLabel.Font = new System.Drawing.Font("Rockwell", 12F);
            this.CostLabel.Location = new System.Drawing.Point(1089, 293);
            this.CostLabel.Name = "CostLabel";
            this.CostLabel.Size = new System.Drawing.Size(116, 36);
            this.CostLabel.TabIndex = 90;
            this.CostLabel.Text = "Cost: $";
            // 
            // VacantSeatsLabel
            // 
            this.VacantSeatsLabel.AutoSize = true;
            this.VacantSeatsLabel.Font = new System.Drawing.Font("Rockwell", 12F);
            this.VacantSeatsLabel.Location = new System.Drawing.Point(1555, 293);
            this.VacantSeatsLabel.Name = "VacantSeatsLabel";
            this.VacantSeatsLabel.Size = new System.Drawing.Size(283, 36);
            this.VacantSeatsLabel.TabIndex = 91;
            this.VacantSeatsLabel.Text = "# of Vacant Seats: ";
            // 
            // FlightIncomeLabel
            // 
            this.FlightIncomeLabel.AutoSize = true;
            this.FlightIncomeLabel.Font = new System.Drawing.Font("Rockwell", 12F);
            this.FlightIncomeLabel.Location = new System.Drawing.Point(1608, 208);
            this.FlightIncomeLabel.Name = "FlightIncomeLabel";
            this.FlightIncomeLabel.Size = new System.Drawing.Size(230, 36);
            this.FlightIncomeLabel.TabIndex = 92;
            this.FlightIncomeLabel.Text = "Flight Income: ";
            // 
            // FlightManifest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(2222, 1078);
            this.Controls.Add(this.FlightIncomeLabel);
            this.Controls.Add(this.VacantSeatsLabel);
            this.Controls.Add(this.CostLabel);
            this.Controls.Add(this.PlaneTypeLabel);
            this.Controls.Add(this.DurationLabel);
            this.Controls.Add(this.DistanceLabel);
            this.Controls.Add(this.DepartureDateTimeLabel);
            this.Controls.Add(this.DestinationLabel);
            this.Controls.Add(this.OriginLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.FlightManifestTable);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.FlightManifestLabel);
            this.Controls.Add(this.LogOutButton);
            this.MaximumSize = new System.Drawing.Size(2248, 1149);
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
        private System.Windows.Forms.Label FlightManifestLabel;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.DataGridView FlightManifestTable;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label OriginLabel;
        private System.Windows.Forms.Label DestinationLabel;
        private System.Windows.Forms.Label DepartureDateTimeLabel;
        private System.Windows.Forms.Label DistanceLabel;
        private System.Windows.Forms.Label DurationLabel;
        private System.Windows.Forms.Label PlaneTypeLabel;
        private System.Windows.Forms.Label CostLabel;
        private System.Windows.Forms.Label VacantSeatsLabel;
        private System.Windows.Forms.Label FlightIncomeLabel;
    }
}

