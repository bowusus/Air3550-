
namespace Air3550
{
    partial class PaymentPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FlightPaymentInfoLabel = new System.Windows.Forms.Label();
            this.PaymentLabel = new System.Windows.Forms.Label();
            this.CreditCardButton = new System.Windows.Forms.RadioButton();
            this.BookFlightButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.PointsButton = new System.Windows.Forms.RadioButton();
            this.AirlineCreditButton = new System.Windows.Forms.RadioButton();
            this.DepartureFlightLabel = new System.Windows.Forms.Label();
            this.ReturnFlightLabel = new System.Windows.Forms.Label();
            this.DepartureFlightDetailsTable = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartureTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstimatedArrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstimatedDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfLayovers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LayoverFlightIDs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangePlane = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeatsAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartureCitiesLabel = new System.Windows.Forms.Label();
            this.ReturnCitiesLabel = new System.Windows.Forms.Label();
            this.ReturnFlightDetailsTable = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DepartureFlightDetailsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReturnFlightDetailsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // FlightPaymentInfoLabel
            // 
            this.FlightPaymentInfoLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FlightPaymentInfoLabel.AutoSize = true;
            this.FlightPaymentInfoLabel.Font = new System.Drawing.Font("Rockwell", 24F);
            this.FlightPaymentInfoLabel.Location = new System.Drawing.Point(754, 98);
            this.FlightPaymentInfoLabel.Name = "FlightPaymentInfoLabel";
            this.FlightPaymentInfoLabel.Size = new System.Drawing.Size(715, 72);
            this.FlightPaymentInfoLabel.TabIndex = 52;
            this.FlightPaymentInfoLabel.Text = "Flight and Price Details";
            this.FlightPaymentInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PaymentLabel
            // 
            this.PaymentLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PaymentLabel.AutoSize = true;
            this.PaymentLabel.Font = new System.Drawing.Font("Rockwell", 18F);
            this.PaymentLabel.Location = new System.Drawing.Point(67, 939);
            this.PaymentLabel.Name = "PaymentLabel";
            this.PaymentLabel.Size = new System.Drawing.Size(737, 54);
            this.PaymentLabel.TabIndex = 81;
            this.PaymentLabel.Text = "Please Select a Payment Method";
            this.PaymentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CreditCardButton
            // 
            this.CreditCardButton.AutoSize = true;
            this.CreditCardButton.Font = new System.Drawing.Font("Rockwell", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditCardButton.Location = new System.Drawing.Point(857, 955);
            this.CreditCardButton.Name = "CreditCardButton";
            this.CreditCardButton.Size = new System.Drawing.Size(253, 46);
            this.CreditCardButton.TabIndex = 82;
            this.CreditCardButton.TabStop = true;
            this.CreditCardButton.Text = "Credit Card";
            this.CreditCardButton.UseVisualStyleBackColor = true;
            // 
            // BookFlightButton
            // 
            this.BookFlightButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.BookFlightButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.BookFlightButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BookFlightButton.Location = new System.Drawing.Point(1904, 939);
            this.BookFlightButton.Name = "BookFlightButton";
            this.BookFlightButton.Size = new System.Drawing.Size(276, 84);
            this.BookFlightButton.TabIndex = 85;
            this.BookFlightButton.Text = "Purchase ";
            this.BookFlightButton.UseVisualStyleBackColor = false;
            this.BookFlightButton.Click += new System.EventHandler(this.BookFlightButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BackButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.BackButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackButton.Location = new System.Drawing.Point(67, 98);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(276, 72);
            this.BackButton.TabIndex = 87;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // LogOutButton
            // 
            this.LogOutButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.LogOutButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.LogOutButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogOutButton.Location = new System.Drawing.Point(1892, 98);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(276, 72);
            this.LogOutButton.TabIndex = 88;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // TotalLabel
            // 
            this.TotalLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TotalLabel.AutoSize = true;
            this.TotalLabel.Font = new System.Drawing.Font("Rockwell", 18F);
            this.TotalLabel.Location = new System.Drawing.Point(67, 816);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(259, 54);
            this.TotalLabel.TabIndex = 77;
            this.TotalLabel.Text = "Total Price";
            this.TotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PointsButton
            // 
            this.PointsButton.AutoSize = true;
            this.PointsButton.Font = new System.Drawing.Font("Rockwell", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointsButton.Location = new System.Drawing.Point(1176, 955);
            this.PointsButton.Name = "PointsButton";
            this.PointsButton.Size = new System.Drawing.Size(151, 46);
            this.PointsButton.TabIndex = 99;
            this.PointsButton.TabStop = true;
            this.PointsButton.Text = "Points";
            this.PointsButton.UseVisualStyleBackColor = true;
            // 
            // AirlineCreditButton
            // 
            this.AirlineCreditButton.AutoSize = true;
            this.AirlineCreditButton.Font = new System.Drawing.Font("Rockwell", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AirlineCreditButton.Location = new System.Drawing.Point(1423, 955);
            this.AirlineCreditButton.Name = "AirlineCreditButton";
            this.AirlineCreditButton.Size = new System.Drawing.Size(283, 46);
            this.AirlineCreditButton.TabIndex = 100;
            this.AirlineCreditButton.TabStop = true;
            this.AirlineCreditButton.Text = "Airline Credit";
            this.AirlineCreditButton.UseVisualStyleBackColor = true;
            // 
            // DepartureFlightLabel
            // 
            this.DepartureFlightLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DepartureFlightLabel.AutoSize = true;
            this.DepartureFlightLabel.Font = new System.Drawing.Font("Rockwell", 14F);
            this.DepartureFlightLabel.Location = new System.Drawing.Point(69, 192);
            this.DepartureFlightLabel.Name = "DepartureFlightLabel";
            this.DepartureFlightLabel.Size = new System.Drawing.Size(341, 42);
            this.DepartureFlightLabel.TabIndex = 53;
            this.DepartureFlightLabel.Text = "Departure Flight - ";
            this.DepartureFlightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReturnFlightLabel
            // 
            this.ReturnFlightLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ReturnFlightLabel.AutoSize = true;
            this.ReturnFlightLabel.Font = new System.Drawing.Font("Rockwell", 14F);
            this.ReturnFlightLabel.Location = new System.Drawing.Point(69, 506);
            this.ReturnFlightLabel.Name = "ReturnFlightLabel";
            this.ReturnFlightLabel.Size = new System.Drawing.Size(276, 42);
            this.ReturnFlightLabel.TabIndex = 54;
            this.ReturnFlightLabel.Text = "Return Flight - ";
            this.ReturnFlightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DepartureFlightDetailsTable
            // 
            this.DepartureFlightDetailsTable.AllowUserToAddRows = false;
            this.DepartureFlightDetailsTable.AllowUserToOrderColumns = true;
            this.DepartureFlightDetailsTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DepartureFlightDetailsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DepartureFlightDetailsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DepartureFlightDetailsTable.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DepartureFlightDetailsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DepartureFlightDetailsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DepartureFlightDetailsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DepartureTime,
            this.EstimatedArrivalTime,
            this.EstimatedDuration,
            this.NumberOfLayovers,
            this.LayoverFlightIDs,
            this.ChangePlane,
            this.SeatsAvailable,
            this.Credits});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DepartureFlightDetailsTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.DepartureFlightDetailsTable.Enabled = false;
            this.DepartureFlightDetailsTable.Location = new System.Drawing.Point(67, 245);
            this.DepartureFlightDetailsTable.MultiSelect = false;
            this.DepartureFlightDetailsTable.Name = "DepartureFlightDetailsTable";
            this.DepartureFlightDetailsTable.ReadOnly = true;
            this.DepartureFlightDetailsTable.RowHeadersWidth = 50;
            this.DepartureFlightDetailsTable.RowTemplate.Height = 33;
            this.DepartureFlightDetailsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DepartureFlightDetailsTable.Size = new System.Drawing.Size(2101, 254);
            this.DepartureFlightDetailsTable.TabIndex = 102;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 10;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // DepartureTime
            // 
            this.DepartureTime.HeaderText = "Departure Time";
            this.DepartureTime.MinimumWidth = 10;
            this.DepartureTime.Name = "DepartureTime";
            this.DepartureTime.ReadOnly = true;
            // 
            // EstimatedArrivalTime
            // 
            this.EstimatedArrivalTime.HeaderText = "Estimated Arrival Time";
            this.EstimatedArrivalTime.MinimumWidth = 10;
            this.EstimatedArrivalTime.Name = "EstimatedArrivalTime";
            this.EstimatedArrivalTime.ReadOnly = true;
            // 
            // EstimatedDuration
            // 
            this.EstimatedDuration.HeaderText = "Estimated Duration";
            this.EstimatedDuration.MinimumWidth = 10;
            this.EstimatedDuration.Name = "EstimatedDuration";
            this.EstimatedDuration.ReadOnly = true;
            // 
            // NumberOfLayovers
            // 
            this.NumberOfLayovers.HeaderText = "Number of Layovers";
            this.NumberOfLayovers.MinimumWidth = 10;
            this.NumberOfLayovers.Name = "NumberOfLayovers";
            this.NumberOfLayovers.ReadOnly = true;
            // 
            // LayoverFlightIDs
            // 
            this.LayoverFlightIDs.HeaderText = "Layover Flight IDs";
            this.LayoverFlightIDs.MinimumWidth = 10;
            this.LayoverFlightIDs.Name = "LayoverFlightIDs";
            this.LayoverFlightIDs.ReadOnly = true;
            // 
            // ChangePlane
            // 
            this.ChangePlane.HeaderText = "Change Plane";
            this.ChangePlane.MinimumWidth = 10;
            this.ChangePlane.Name = "ChangePlane";
            this.ChangePlane.ReadOnly = true;
            // 
            // SeatsAvailable
            // 
            this.SeatsAvailable.HeaderText = "Seats Available on Each Flight";
            this.SeatsAvailable.MinimumWidth = 10;
            this.SeatsAvailable.Name = "SeatsAvailable";
            this.SeatsAvailable.ReadOnly = true;
            // 
            // Credits
            // 
            this.Credits.HeaderText = "Cost/Points";
            this.Credits.MinimumWidth = 10;
            this.Credits.Name = "Credits";
            this.Credits.ReadOnly = true;
            // 
            // DepartureCitiesLabel
            // 
            this.DepartureCitiesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DepartureCitiesLabel.AutoSize = true;
            this.DepartureCitiesLabel.Font = new System.Drawing.Font("Rockwell", 14F);
            this.DepartureCitiesLabel.Location = new System.Drawing.Point(801, 192);
            this.DepartureCitiesLabel.Name = "DepartureCitiesLabel";
            this.DepartureCitiesLabel.Size = new System.Drawing.Size(309, 42);
            this.DepartureCitiesLabel.TabIndex = 105;
            this.DepartureCitiesLabel.Text = "Departure Cities";
            this.DepartureCitiesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReturnCitiesLabel
            // 
            this.ReturnCitiesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ReturnCitiesLabel.AutoSize = true;
            this.ReturnCitiesLabel.Font = new System.Drawing.Font("Rockwell", 14F);
            this.ReturnCitiesLabel.Location = new System.Drawing.Point(801, 506);
            this.ReturnCitiesLabel.Name = "ReturnCitiesLabel";
            this.ReturnCitiesLabel.Size = new System.Drawing.Size(244, 42);
            this.ReturnCitiesLabel.TabIndex = 106;
            this.ReturnCitiesLabel.Text = "Return Cities";
            this.ReturnCitiesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReturnFlightDetailsTable
            // 
            this.ReturnFlightDetailsTable.AllowUserToAddRows = false;
            this.ReturnFlightDetailsTable.AllowUserToOrderColumns = true;
            this.ReturnFlightDetailsTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ReturnFlightDetailsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ReturnFlightDetailsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ReturnFlightDetailsTable.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ReturnFlightDetailsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ReturnFlightDetailsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReturnFlightDetailsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ReturnFlightDetailsTable.DefaultCellStyle = dataGridViewCellStyle4;
            this.ReturnFlightDetailsTable.Enabled = false;
            this.ReturnFlightDetailsTable.Location = new System.Drawing.Point(67, 559);
            this.ReturnFlightDetailsTable.MultiSelect = false;
            this.ReturnFlightDetailsTable.Name = "ReturnFlightDetailsTable";
            this.ReturnFlightDetailsTable.ReadOnly = true;
            this.ReturnFlightDetailsTable.RowHeadersWidth = 50;
            this.ReturnFlightDetailsTable.RowTemplate.Height = 33;
            this.ReturnFlightDetailsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ReturnFlightDetailsTable.Size = new System.Drawing.Size(2101, 254);
            this.ReturnFlightDetailsTable.TabIndex = 107;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Departure Time";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Estimated Arrival Time";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Estimated Duration";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Number of Layovers";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Layover Flight IDs";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Change Plane";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Seats Available on Each Flight";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Cost/Points";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // PaymentPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(2222, 1078);
            this.Controls.Add(this.ReturnFlightDetailsTable);
            this.Controls.Add(this.ReturnCitiesLabel);
            this.Controls.Add(this.DepartureCitiesLabel);
            this.Controls.Add(this.DepartureFlightDetailsTable);
            this.Controls.Add(this.AirlineCreditButton);
            this.Controls.Add(this.PointsButton);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.BookFlightButton);
            this.Controls.Add(this.CreditCardButton);
            this.Controls.Add(this.PaymentLabel);
            this.Controls.Add(this.TotalLabel);
            this.Controls.Add(this.ReturnFlightLabel);
            this.Controls.Add(this.DepartureFlightLabel);
            this.Controls.Add(this.FlightPaymentInfoLabel);
            this.MaximumSize = new System.Drawing.Size(2248, 1149);
            this.Name = "PaymentPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air3550";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PaymentPage_FormClosing);
            this.Load += new System.EventHandler(this.PaymentPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DepartureFlightDetailsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReturnFlightDetailsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label FlightPaymentInfoLabel;
        private System.Windows.Forms.Label PaymentLabel;
        private System.Windows.Forms.RadioButton CreditCardButton;
        private System.Windows.Forms.Button BookFlightButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Label TotalLabel;
        private System.Windows.Forms.RadioButton PointsButton;
        private System.Windows.Forms.RadioButton AirlineCreditButton;
        private System.Windows.Forms.Label DepartureFlightLabel;
        private System.Windows.Forms.Label ReturnFlightLabel;
        private System.Windows.Forms.DataGridView DepartureFlightDetailsTable;
        private System.Windows.Forms.Label DepartureCitiesLabel;
        private System.Windows.Forms.Label ReturnCitiesLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartureTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstimatedArrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstimatedDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfLayovers;
        private System.Windows.Forms.DataGridViewTextBoxColumn LayoverFlightIDs;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChangePlane;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeatsAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Credits;
        private System.Windows.Forms.DataGridView ReturnFlightDetailsTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}

