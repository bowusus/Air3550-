
namespace Air3550
{
    partial class BookFlightPage
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
            this.AvailableFlightTable = new System.Windows.Forms.DataGridView();
            this.RoundTripButton = new System.Windows.Forms.RadioButton();
            this.OneWayButton = new System.Windows.Forms.RadioButton();
            this.BackButton = new System.Windows.Forms.Button();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.BookFlightLabel = new System.Windows.Forms.Label();
            this.DepartLabel = new System.Windows.Forms.Label();
            this.DepartComboBox = new System.Windows.Forms.ComboBox();
            this.ArriveLabel = new System.Windows.Forms.Label();
            this.ArriveComboBox = new System.Windows.Forms.ComboBox();
            this.DepartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.ReturnDatePicker = new System.Windows.Forms.DateTimePicker();
            this.DepartDateLabel = new System.Windows.Forms.Label();
            this.ReturnDateLabel = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.DifferentLocationError = new System.Windows.Forms.Label();
            this.DepartDateError = new System.Windows.Forms.Label();
            this.ReturnFlightButton = new System.Windows.Forms.Button();
            this.BookFlightButton = new System.Windows.Forms.Button();
            this.DepartintFlightsLabel = new System.Windows.Forms.Label();
            this.ReturningFlightsLabel = new System.Windows.Forms.Label();
            this.ChangeDepartingFlightButton = new System.Windows.Forms.Button();
            this.DepartDateAfterTodayError = new System.Windows.Forms.Label();
            this.ReturnBeforeDepartError = new System.Windows.Forms.Label();
            this.ReturnDateError = new System.Windows.Forms.Label();
            this.EmptyError = new System.Windows.Forms.Label();
            this.NoFlightLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AvailableFlightTable)).BeginInit();
            this.SuspendLayout();
            // 
            // AvailableFlightTable
            // 
            this.AvailableFlightTable.AllowUserToAddRows = false;
            this.AvailableFlightTable.AllowUserToOrderColumns = true;
            this.AvailableFlightTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AvailableFlightTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AvailableFlightTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.AvailableFlightTable.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AvailableFlightTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.AvailableFlightTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AvailableFlightTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.AvailableFlightTable.Location = new System.Drawing.Point(67, 456);
            this.AvailableFlightTable.MultiSelect = false;
            this.AvailableFlightTable.Name = "AvailableFlightTable";
            this.AvailableFlightTable.ReadOnly = true;
            this.AvailableFlightTable.RowHeadersWidth = 82;
            this.AvailableFlightTable.RowTemplate.Height = 33;
            this.AvailableFlightTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AvailableFlightTable.Size = new System.Drawing.Size(2101, 486);
            this.AvailableFlightTable.TabIndex = 46;
            this.AvailableFlightTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AvailableFlightTable_CellClick);
            // 
            // RoundTripButton
            // 
            this.RoundTripButton.AutoSize = true;
            this.RoundTripButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.RoundTripButton.Location = new System.Drawing.Point(67, 200);
            this.RoundTripButton.Name = "RoundTripButton";
            this.RoundTripButton.Size = new System.Drawing.Size(181, 35);
            this.RoundTripButton.TabIndex = 47;
            this.RoundTripButton.TabStop = true;
            this.RoundTripButton.Text = "Round Trip";
            this.RoundTripButton.UseVisualStyleBackColor = true;
            this.RoundTripButton.Click += new System.EventHandler(this.RoundTripButton_Click);
            // 
            // OneWayButton
            // 
            this.OneWayButton.AutoSize = true;
            this.OneWayButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.OneWayButton.Location = new System.Drawing.Point(265, 200);
            this.OneWayButton.Name = "OneWayButton";
            this.OneWayButton.Size = new System.Drawing.Size(160, 35);
            this.OneWayButton.TabIndex = 48;
            this.OneWayButton.TabStop = true;
            this.OneWayButton.Text = "One Way";
            this.OneWayButton.UseVisualStyleBackColor = true;
            this.OneWayButton.Click += new System.EventHandler(this.OneWayButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BackButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.BackButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackButton.Location = new System.Drawing.Point(67, 98);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(276, 72);
            this.BackButton.TabIndex = 49;
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
            this.LogOutButton.TabIndex = 50;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // BookFlightLabel
            // 
            this.BookFlightLabel.AutoSize = true;
            this.BookFlightLabel.Font = new System.Drawing.Font("Rockwell", 24F);
            this.BookFlightLabel.Location = new System.Drawing.Point(848, 98);
            this.BookFlightLabel.Name = "BookFlightLabel";
            this.BookFlightLabel.Size = new System.Drawing.Size(527, 72);
            this.BookFlightLabel.TabIndex = 51;
            this.BookFlightLabel.Text = "Available Flights";
            this.BookFlightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DepartLabel
            // 
            this.DepartLabel.AutoSize = true;
            this.DepartLabel.Font = new System.Drawing.Font("Rockwell", 10F);
            this.DepartLabel.Location = new System.Drawing.Point(61, 259);
            this.DepartLabel.Name = "DepartLabel";
            this.DepartLabel.Size = new System.Drawing.Size(199, 31);
            this.DepartLabel.TabIndex = 52;
            this.DepartLabel.Text = "Departure City";
            // 
            // DepartComboBox
            // 
            this.DepartComboBox.Font = new System.Drawing.Font("Rockwell", 10F);
            this.DepartComboBox.FormattingEnabled = true;
            this.DepartComboBox.Location = new System.Drawing.Point(67, 328);
            this.DepartComboBox.Name = "DepartComboBox";
            this.DepartComboBox.Size = new System.Drawing.Size(276, 39);
            this.DepartComboBox.TabIndex = 54;
            // 
            // ArriveLabel
            // 
            this.ArriveLabel.AutoSize = true;
            this.ArriveLabel.Font = new System.Drawing.Font("Rockwell", 10F);
            this.ArriveLabel.Location = new System.Drawing.Point(408, 259);
            this.ArriveLabel.Name = "ArriveLabel";
            this.ArriveLabel.Size = new System.Drawing.Size(159, 31);
            this.ArriveLabel.TabIndex = 56;
            this.ArriveLabel.Text = "Arrival City";
            // 
            // ArriveComboBox
            // 
            this.ArriveComboBox.Font = new System.Drawing.Font("Rockwell", 10F);
            this.ArriveComboBox.FormattingEnabled = true;
            this.ArriveComboBox.Location = new System.Drawing.Point(414, 328);
            this.ArriveComboBox.Name = "ArriveComboBox";
            this.ArriveComboBox.Size = new System.Drawing.Size(276, 39);
            this.ArriveComboBox.TabIndex = 57;
            // 
            // DepartDatePicker
            // 
            this.DepartDatePicker.Font = new System.Drawing.Font("Rockwell", 10F);
            this.DepartDatePicker.Location = new System.Drawing.Point(761, 328);
            this.DepartDatePicker.Name = "DepartDatePicker";
            this.DepartDatePicker.Size = new System.Drawing.Size(539, 39);
            this.DepartDatePicker.TabIndex = 58;
            this.DepartDatePicker.ValueChanged += new System.EventHandler(this.DepartDatePicker_ValueChanged);
            // 
            // ReturnDatePicker
            // 
            this.ReturnDatePicker.Font = new System.Drawing.Font("Rockwell", 10F);
            this.ReturnDatePicker.Location = new System.Drawing.Point(1371, 328);
            this.ReturnDatePicker.Name = "ReturnDatePicker";
            this.ReturnDatePicker.Size = new System.Drawing.Size(539, 39);
            this.ReturnDatePicker.TabIndex = 59;
            this.ReturnDatePicker.ValueChanged += new System.EventHandler(this.ReturnDatePicker_ValueChanged);
            // 
            // DepartDateLabel
            // 
            this.DepartDateLabel.AutoSize = true;
            this.DepartDateLabel.Font = new System.Drawing.Font("Rockwell", 10F);
            this.DepartDateLabel.Location = new System.Drawing.Point(755, 259);
            this.DepartDateLabel.Name = "DepartDateLabel";
            this.DepartDateLabel.Size = new System.Drawing.Size(204, 31);
            this.DepartDateLabel.TabIndex = 60;
            this.DepartDateLabel.Text = "Departure Date";
            // 
            // ReturnDateLabel
            // 
            this.ReturnDateLabel.AutoSize = true;
            this.ReturnDateLabel.Font = new System.Drawing.Font("Rockwell", 10F);
            this.ReturnDateLabel.Location = new System.Drawing.Point(1365, 259);
            this.ReturnDateLabel.Name = "ReturnDateLabel";
            this.ReturnDateLabel.Size = new System.Drawing.Size(158, 31);
            this.ReturnDateLabel.TabIndex = 61;
            this.ReturnDateLabel.Text = "Return Date";
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.SearchButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.SearchButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SearchButton.Location = new System.Drawing.Point(1981, 283);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(187, 84);
            this.SearchButton.TabIndex = 62;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // DifferentLocationError
            // 
            this.DifferentLocationError.AutoSize = true;
            this.DifferentLocationError.ForeColor = System.Drawing.Color.Red;
            this.DifferentLocationError.Location = new System.Drawing.Point(62, 300);
            this.DifferentLocationError.Name = "DifferentLocationError";
            this.DifferentLocationError.Size = new System.Drawing.Size(376, 25);
            this.DifferentLocationError.TabIndex = 63;
            this.DifferentLocationError.Text = "Please Select Two Different Locations";
            this.DifferentLocationError.Visible = false;
            // 
            // DepartDateError
            // 
            this.DepartDateError.AutoSize = true;
            this.DepartDateError.ForeColor = System.Drawing.Color.Red;
            this.DepartDateError.Location = new System.Drawing.Point(756, 300);
            this.DepartDateError.Name = "DepartDateError";
            this.DepartDateError.Size = new System.Drawing.Size(502, 25);
            this.DepartDateError.TabIndex = 64;
            this.DepartDateError.Text = "Please Select a Depart Date that is within 6 months";
            this.DepartDateError.Visible = false;
            // 
            // ReturnFlightButton
            // 
            this.ReturnFlightButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.ReturnFlightButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.ReturnFlightButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ReturnFlightButton.Location = new System.Drawing.Point(1727, 982);
            this.ReturnFlightButton.Name = "ReturnFlightButton";
            this.ReturnFlightButton.Size = new System.Drawing.Size(441, 84);
            this.ReturnFlightButton.TabIndex = 67;
            this.ReturnFlightButton.Text = "Pick Your Return Flight Next";
            this.ReturnFlightButton.UseVisualStyleBackColor = false;
            this.ReturnFlightButton.Click += new System.EventHandler(this.ReturnFlightButton_Click);
            // 
            // BookFlightButton
            // 
            this.BookFlightButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.BookFlightButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.BookFlightButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BookFlightButton.Location = new System.Drawing.Point(1892, 982);
            this.BookFlightButton.Name = "BookFlightButton";
            this.BookFlightButton.Size = new System.Drawing.Size(276, 84);
            this.BookFlightButton.TabIndex = 68;
            this.BookFlightButton.Text = "Book Flight";
            this.BookFlightButton.UseVisualStyleBackColor = false;
            this.BookFlightButton.Click += new System.EventHandler(this.BookFlightButton_Click);
            // 
            // DepartintFlightsLabel
            // 
            this.DepartintFlightsLabel.AutoSize = true;
            this.DepartintFlightsLabel.Font = new System.Drawing.Font("Rockwell", 14F);
            this.DepartintFlightsLabel.Location = new System.Drawing.Point(525, 400);
            this.DepartintFlightsLabel.Name = "DepartintFlightsLabel";
            this.DepartintFlightsLabel.Size = new System.Drawing.Size(1169, 42);
            this.DepartintFlightsLabel.TabIndex = 69;
            this.DepartintFlightsLabel.Text = "Departing Flights *Please Select the Row with the Flight You Want";
            // 
            // ReturningFlightsLabel
            // 
            this.ReturningFlightsLabel.AutoSize = true;
            this.ReturningFlightsLabel.Font = new System.Drawing.Font("Rockwell", 14F);
            this.ReturningFlightsLabel.Location = new System.Drawing.Point(525, 400);
            this.ReturningFlightsLabel.Name = "ReturningFlightsLabel";
            this.ReturningFlightsLabel.Size = new System.Drawing.Size(1163, 42);
            this.ReturningFlightsLabel.TabIndex = 70;
            this.ReturningFlightsLabel.Text = "Returning Flights *Please Select the Row with the Flight You Want";
            // 
            // ChangeDepartingFlightButton
            // 
            this.ChangeDepartingFlightButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ChangeDepartingFlightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeDepartingFlightButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.ChangeDepartingFlightButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ChangeDepartingFlightButton.Location = new System.Drawing.Point(67, 982);
            this.ChangeDepartingFlightButton.Name = "ChangeDepartingFlightButton";
            this.ChangeDepartingFlightButton.Size = new System.Drawing.Size(441, 84);
            this.ChangeDepartingFlightButton.TabIndex = 71;
            this.ChangeDepartingFlightButton.Text = "Change Your Departing Flight";
            this.ChangeDepartingFlightButton.UseVisualStyleBackColor = false;
            this.ChangeDepartingFlightButton.Click += new System.EventHandler(this.ChangeDepartingFlightButton_Click);
            // 
            // DepartDateAfterTodayError
            // 
            this.DepartDateAfterTodayError.AutoSize = true;
            this.DepartDateAfterTodayError.ForeColor = System.Drawing.Color.Red;
            this.DepartDateAfterTodayError.Location = new System.Drawing.Point(756, 300);
            this.DepartDateAfterTodayError.Name = "DepartDateAfterTodayError";
            this.DepartDateAfterTodayError.Size = new System.Drawing.Size(493, 25);
            this.DepartDateAfterTodayError.TabIndex = 72;
            this.DepartDateAfterTodayError.Text = "Please Select a Depart Date that is Today or Later";
            this.DepartDateAfterTodayError.Visible = false;
            // 
            // ReturnBeforeDepartError
            // 
            this.ReturnBeforeDepartError.AutoSize = true;
            this.ReturnBeforeDepartError.ForeColor = System.Drawing.Color.Red;
            this.ReturnBeforeDepartError.Location = new System.Drawing.Point(1366, 300);
            this.ReturnBeforeDepartError.Name = "ReturnBeforeDepartError";
            this.ReturnBeforeDepartError.Size = new System.Drawing.Size(608, 25);
            this.ReturnBeforeDepartError.TabIndex = 73;
            this.ReturnBeforeDepartError.Text = "Please select a Return Date the Same Day or After you Depart";
            this.ReturnBeforeDepartError.Visible = false;
            // 
            // ReturnDateError
            // 
            this.ReturnDateError.AutoSize = true;
            this.ReturnDateError.ForeColor = System.Drawing.Color.Red;
            this.ReturnDateError.Location = new System.Drawing.Point(1366, 300);
            this.ReturnDateError.Name = "ReturnDateError";
            this.ReturnDateError.Size = new System.Drawing.Size(502, 25);
            this.ReturnDateError.TabIndex = 65;
            this.ReturnDateError.Text = "Please Select a Return Date that is within 6 months";
            this.ReturnDateError.Visible = false;
            // 
            // EmptyError
            // 
            this.EmptyError.AutoSize = true;
            this.EmptyError.ForeColor = System.Drawing.Color.Red;
            this.EmptyError.Location = new System.Drawing.Point(62, 300);
            this.EmptyError.Name = "EmptyError";
            this.EmptyError.Size = new System.Drawing.Size(284, 25);
            this.EmptyError.TabIndex = 74;
            this.EmptyError.Text = "Please Fill in Both Locations";
            this.EmptyError.Visible = false;
            // 
            // NoFlightLabel
            // 
            this.NoFlightLabel.AutoSize = true;
            this.NoFlightLabel.Font = new System.Drawing.Font("Rockwell", 24F);
            this.NoFlightLabel.Location = new System.Drawing.Point(664, 760);
            this.NoFlightLabel.Name = "NoFlightLabel";
            this.NoFlightLabel.Size = new System.Drawing.Size(895, 72);
            this.NoFlightLabel.TabIndex = 75;
            this.NoFlightLabel.Text = "There are no flights available";
            this.NoFlightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BookFlightPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(2222, 1078);
            this.Controls.Add(this.NoFlightLabel);
            this.Controls.Add(this.EmptyError);
            this.Controls.Add(this.ReturnBeforeDepartError);
            this.Controls.Add(this.DepartDateAfterTodayError);
            this.Controls.Add(this.ChangeDepartingFlightButton);
            this.Controls.Add(this.ReturningFlightsLabel);
            this.Controls.Add(this.DepartintFlightsLabel);
            this.Controls.Add(this.BookFlightButton);
            this.Controls.Add(this.ReturnFlightButton);
            this.Controls.Add(this.ReturnDateError);
            this.Controls.Add(this.DepartDateError);
            this.Controls.Add(this.DifferentLocationError);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.ReturnDateLabel);
            this.Controls.Add(this.DepartDateLabel);
            this.Controls.Add(this.ReturnDatePicker);
            this.Controls.Add(this.DepartDatePicker);
            this.Controls.Add(this.ArriveComboBox);
            this.Controls.Add(this.ArriveLabel);
            this.Controls.Add(this.DepartComboBox);
            this.Controls.Add(this.DepartLabel);
            this.Controls.Add(this.BookFlightLabel);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.OneWayButton);
            this.Controls.Add(this.RoundTripButton);
            this.Controls.Add(this.AvailableFlightTable);
            this.MaximumSize = new System.Drawing.Size(2248, 1149);
            this.Name = "BookFlightPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air3550";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BookFlightPage_FormClosing);
            this.Load += new System.EventHandler(this.BookFlightPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AvailableFlightTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView AvailableFlightTable;
        private System.Windows.Forms.RadioButton RoundTripButton;
        private System.Windows.Forms.RadioButton OneWayButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Label BookFlightLabel;
        private System.Windows.Forms.Label DepartLabel;
        private System.Windows.Forms.ComboBox DepartComboBox;
        private System.Windows.Forms.Label ArriveLabel;
        private System.Windows.Forms.ComboBox ArriveComboBox;
        private System.Windows.Forms.DateTimePicker DepartDatePicker;
        private System.Windows.Forms.DateTimePicker ReturnDatePicker;
        private System.Windows.Forms.Label DepartDateLabel;
        private System.Windows.Forms.Label ReturnDateLabel;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label DifferentLocationError;
        private System.Windows.Forms.Label DepartDateError;
        private System.Windows.Forms.Button ReturnFlightButton;
        private System.Windows.Forms.Button BookFlightButton;
        private System.Windows.Forms.Label DepartintFlightsLabel;
        private System.Windows.Forms.Label ReturningFlightsLabel;
        private System.Windows.Forms.Button ChangeDepartingFlightButton;
        private System.Windows.Forms.Label DepartDateAfterTodayError;
        private System.Windows.Forms.Label ReturnBeforeDepartError;
        private System.Windows.Forms.Label ReturnDateError;
        private System.Windows.Forms.Label EmptyError;
        private System.Windows.Forms.Label NoFlightLabel;
    }
}

