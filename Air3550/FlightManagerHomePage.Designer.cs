
namespace Air3550
{
    partial class FlightManagerHomePage
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
            this.SearchButton = new System.Windows.Forms.Button();
            this.ToDateLabel = new System.Windows.Forms.Label();
            this.FromDateLabel = new System.Windows.Forms.Label();
            this.ToDatePicker = new System.Windows.Forms.DateTimePicker();
            this.FromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.ArriveComboBox = new System.Windows.Forms.ComboBox();
            this.ArriveLabel = new System.Windows.Forms.Label();
            this.DepartComboBox = new System.Windows.Forms.ComboBox();
            this.DepartLabel = new System.Windows.Forms.Label();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.FlightTable = new System.Windows.Forms.DataGridView();
            this.BeforeFromDateError = new System.Windows.Forms.Label();
            this.ClearFiltersButton = new System.Windows.Forms.Button();
            this.FlightManagerLabel = new System.Windows.Forms.Label();
            this.ViewFlightManifestButton = new System.Windows.Forms.Button();
            this.FromDateAfterTodayError = new System.Windows.Forms.Label();
            this.ToDateAfterTodayError = new System.Windows.Forms.Label();
            this.FlightManagerHomeLabel = new System.Windows.Forms.Label();
            this.DifferentLocationError = new System.Windows.Forms.Label();
            this.NoFlightLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FlightTable)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.SearchButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.SearchButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SearchButton.Location = new System.Drawing.Point(1982, 266);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(188, 84);
            this.SearchButton.TabIndex = 73;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ToDateLabel
            // 
            this.ToDateLabel.AutoSize = true;
            this.ToDateLabel.Font = new System.Drawing.Font("Rockwell", 10F);
            this.ToDateLabel.Location = new System.Drawing.Point(1365, 242);
            this.ToDateLabel.Name = "ToDateLabel";
            this.ToDateLabel.Size = new System.Drawing.Size(44, 31);
            this.ToDateLabel.TabIndex = 72;
            this.ToDateLabel.Text = "To";
            // 
            // FromDateLabel
            // 
            this.FromDateLabel.AutoSize = true;
            this.FromDateLabel.Font = new System.Drawing.Font("Rockwell", 10F);
            this.FromDateLabel.Location = new System.Drawing.Point(754, 242);
            this.FromDateLabel.Name = "FromDateLabel";
            this.FromDateLabel.Size = new System.Drawing.Size(78, 31);
            this.FromDateLabel.TabIndex = 71;
            this.FromDateLabel.Text = "From";
            // 
            // ToDatePicker
            // 
            this.ToDatePicker.Font = new System.Drawing.Font("Rockwell", 10F);
            this.ToDatePicker.Location = new System.Drawing.Point(1371, 311);
            this.ToDatePicker.Name = "ToDatePicker";
            this.ToDatePicker.Size = new System.Drawing.Size(540, 39);
            this.ToDatePicker.TabIndex = 70;
            this.ToDatePicker.ValueChanged += new System.EventHandler(this.ToDatePicker_ValueChanged);
            // 
            // FromDatePicker
            // 
            this.FromDatePicker.Font = new System.Drawing.Font("Rockwell", 10F);
            this.FromDatePicker.Location = new System.Drawing.Point(760, 311);
            this.FromDatePicker.Name = "FromDatePicker";
            this.FromDatePicker.Size = new System.Drawing.Size(540, 39);
            this.FromDatePicker.TabIndex = 69;
            this.FromDatePicker.ValueChanged += new System.EventHandler(this.FromDatePicker_ValueChanged);
            // 
            // ArriveComboBox
            // 
            this.ArriveComboBox.Font = new System.Drawing.Font("Rockwell", 10F);
            this.ArriveComboBox.FormattingEnabled = true;
            this.ArriveComboBox.Location = new System.Drawing.Point(414, 311);
            this.ArriveComboBox.Name = "ArriveComboBox";
            this.ArriveComboBox.Size = new System.Drawing.Size(276, 39);
            this.ArriveComboBox.TabIndex = 68;
            // 
            // ArriveLabel
            // 
            this.ArriveLabel.AutoSize = true;
            this.ArriveLabel.Font = new System.Drawing.Font("Rockwell", 10F);
            this.ArriveLabel.Location = new System.Drawing.Point(408, 242);
            this.ArriveLabel.Name = "ArriveLabel";
            this.ArriveLabel.Size = new System.Drawing.Size(159, 31);
            this.ArriveLabel.TabIndex = 67;
            this.ArriveLabel.Text = "Arrival City";
            // 
            // DepartComboBox
            // 
            this.DepartComboBox.Font = new System.Drawing.Font("Rockwell", 10F);
            this.DepartComboBox.FormattingEnabled = true;
            this.DepartComboBox.Location = new System.Drawing.Point(68, 311);
            this.DepartComboBox.Name = "DepartComboBox";
            this.DepartComboBox.Size = new System.Drawing.Size(276, 39);
            this.DepartComboBox.TabIndex = 66;
            // 
            // DepartLabel
            // 
            this.DepartLabel.AutoSize = true;
            this.DepartLabel.Font = new System.Drawing.Font("Rockwell", 10F);
            this.DepartLabel.Location = new System.Drawing.Point(62, 242);
            this.DepartLabel.Name = "DepartLabel";
            this.DepartLabel.Size = new System.Drawing.Size(199, 31);
            this.DepartLabel.TabIndex = 65;
            this.DepartLabel.Text = "Departure City";
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
            // FlightTable
            // 
            this.FlightTable.AllowUserToAddRows = false;
            this.FlightTable.AllowUserToOrderColumns = true;
            this.FlightTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FlightTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FlightTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.FlightTable.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FlightTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.FlightTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FlightTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.FlightTable.Location = new System.Drawing.Point(70, 441);
            this.FlightTable.MultiSelect = false;
            this.FlightTable.Name = "FlightTable";
            this.FlightTable.ReadOnly = true;
            this.FlightTable.RowHeadersWidth = 82;
            this.FlightTable.RowTemplate.Height = 33;
            this.FlightTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FlightTable.Size = new System.Drawing.Size(2102, 509);
            this.FlightTable.TabIndex = 74;
            this.FlightTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FlightTable_CellClick);
            // 
            // BeforeFromDateError
            // 
            this.BeforeFromDateError.AutoSize = true;
            this.BeforeFromDateError.ForeColor = System.Drawing.Color.Red;
            this.BeforeFromDateError.Location = new System.Drawing.Point(1371, 283);
            this.BeforeFromDateError.Name = "BeforeFromDateError";
            this.BeforeFromDateError.Size = new System.Drawing.Size(540, 25);
            this.BeforeFromDateError.TabIndex = 78;
            this.BeforeFromDateError.Text = "Please Select a Second Date that is after the First Date";
            this.BeforeFromDateError.Visible = false;
            // 
            // ClearFiltersButton
            // 
            this.ClearFiltersButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClearFiltersButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.ClearFiltersButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClearFiltersButton.Location = new System.Drawing.Point(68, 98);
            this.ClearFiltersButton.Name = "ClearFiltersButton";
            this.ClearFiltersButton.Size = new System.Drawing.Size(276, 72);
            this.ClearFiltersButton.TabIndex = 79;
            this.ClearFiltersButton.Text = "Clear Filters";
            this.ClearFiltersButton.UseVisualStyleBackColor = false;
            this.ClearFiltersButton.Click += new System.EventHandler(this.ClearFiltersButton_Click);
            // 
            // FlightManagerLabel
            // 
            this.FlightManagerLabel.AutoSize = true;
            this.FlightManagerLabel.Font = new System.Drawing.Font("Rockwell", 18F);
            this.FlightManagerLabel.Location = new System.Drawing.Point(681, 377);
            this.FlightManagerLabel.Name = "FlightManagerLabel";
            this.FlightManagerLabel.Size = new System.Drawing.Size(863, 54);
            this.FlightManagerLabel.TabIndex = 80;
            this.FlightManagerLabel.Text = "Select a flight to see its Flight Manifest";
            // 
            // ViewFlightManifestButton
            // 
            this.ViewFlightManifestButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ViewFlightManifestButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.ViewFlightManifestButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ViewFlightManifestButton.Location = new System.Drawing.Point(1892, 981);
            this.ViewFlightManifestButton.Name = "ViewFlightManifestButton";
            this.ViewFlightManifestButton.Size = new System.Drawing.Size(276, 84);
            this.ViewFlightManifestButton.TabIndex = 81;
            this.ViewFlightManifestButton.Text = "View Flight Manifest";
            this.ViewFlightManifestButton.UseVisualStyleBackColor = false;
            this.ViewFlightManifestButton.Click += new System.EventHandler(this.ViewFlightManifestButton_Click);
            // 
            // FromDateAfterTodayError
            // 
            this.FromDateAfterTodayError.AutoSize = true;
            this.FromDateAfterTodayError.ForeColor = System.Drawing.Color.Red;
            this.FromDateAfterTodayError.Location = new System.Drawing.Point(756, 283);
            this.FromDateAfterTodayError.Name = "FromDateAfterTodayError";
            this.FromDateAfterTodayError.Size = new System.Drawing.Size(348, 25);
            this.FromDateAfterTodayError.TabIndex = 82;
            this.FromDateAfterTodayError.Text = "Please Select a Date Before Today";
            this.FromDateAfterTodayError.Visible = false;
            // 
            // ToDateAfterTodayError
            // 
            this.ToDateAfterTodayError.AutoSize = true;
            this.ToDateAfterTodayError.ForeColor = System.Drawing.Color.Red;
            this.ToDateAfterTodayError.Location = new System.Drawing.Point(1366, 283);
            this.ToDateAfterTodayError.Name = "ToDateAfterTodayError";
            this.ToDateAfterTodayError.Size = new System.Drawing.Size(370, 25);
            this.ToDateAfterTodayError.TabIndex = 83;
            this.ToDateAfterTodayError.Text = "Please Select Today or Before Today";
            this.ToDateAfterTodayError.Visible = false;
            // 
            // FlightManagerHomeLabel
            // 
            this.FlightManagerHomeLabel.AutoSize = true;
            this.FlightManagerHomeLabel.Font = new System.Drawing.Font("Rockwell", 24F);
            this.FlightManagerHomeLabel.Location = new System.Drawing.Point(776, 98);
            this.FlightManagerHomeLabel.Name = "FlightManagerHomeLabel";
            this.FlightManagerHomeLabel.Size = new System.Drawing.Size(670, 72);
            this.FlightManagerHomeLabel.TabIndex = 84;
            this.FlightManagerHomeLabel.Text = "Flight Manager Home";
            this.FlightManagerHomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DifferentLocationError
            // 
            this.DifferentLocationError.AutoSize = true;
            this.DifferentLocationError.ForeColor = System.Drawing.Color.Red;
            this.DifferentLocationError.Location = new System.Drawing.Point(63, 283);
            this.DifferentLocationError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DifferentLocationError.Name = "DifferentLocationError";
            this.DifferentLocationError.Size = new System.Drawing.Size(376, 25);
            this.DifferentLocationError.TabIndex = 85;
            this.DifferentLocationError.Text = "Please Select Two Different Locations";
            this.DifferentLocationError.Visible = false;
            // 
            // NoFlightLabel
            // 
            this.NoFlightLabel.AutoSize = true;
            this.NoFlightLabel.Font = new System.Drawing.Font("Rockwell", 24F);
            this.NoFlightLabel.Location = new System.Drawing.Point(535, 768);
            this.NoFlightLabel.Name = "NoFlightLabel";
            this.NoFlightLabel.Size = new System.Drawing.Size(1162, 72);
            this.NoFlightLabel.TabIndex = 86;
            this.NoFlightLabel.Text = "There are no flights that have taken off";
            this.NoFlightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FlightManagerHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(2222, 1078);
            this.Controls.Add(this.NoFlightLabel);
            this.Controls.Add(this.DifferentLocationError);
            this.Controls.Add(this.FlightManagerHomeLabel);
            this.Controls.Add(this.ToDateAfterTodayError);
            this.Controls.Add(this.FromDateAfterTodayError);
            this.Controls.Add(this.ViewFlightManifestButton);
            this.Controls.Add(this.FlightManagerLabel);
            this.Controls.Add(this.ClearFiltersButton);
            this.Controls.Add(this.BeforeFromDateError);
            this.Controls.Add(this.FlightTable);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.ToDateLabel);
            this.Controls.Add(this.FromDateLabel);
            this.Controls.Add(this.ToDatePicker);
            this.Controls.Add(this.FromDatePicker);
            this.Controls.Add(this.ArriveComboBox);
            this.Controls.Add(this.ArriveLabel);
            this.Controls.Add(this.DepartComboBox);
            this.Controls.Add(this.DepartLabel);
            this.Controls.Add(this.LogOutButton);
            this.MaximumSize = new System.Drawing.Size(2248, 1149);
            this.Name = "FlightManagerHomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air3550";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FlightManagerHomePage_FormClosing);
            this.Load += new System.EventHandler(this.FlightManagerHomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FlightTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label ToDateLabel;
        private System.Windows.Forms.Label FromDateLabel;
        private System.Windows.Forms.DateTimePicker ToDatePicker;
        private System.Windows.Forms.DateTimePicker FromDatePicker;
        private System.Windows.Forms.ComboBox ArriveComboBox;
        private System.Windows.Forms.Label ArriveLabel;
        private System.Windows.Forms.ComboBox DepartComboBox;
        private System.Windows.Forms.Label DepartLabel;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.DataGridView FlightTable;
        private System.Windows.Forms.Label BeforeFromDateError;
        private System.Windows.Forms.Button ClearFiltersButton;
        private System.Windows.Forms.Label FlightManagerLabel;
        private System.Windows.Forms.Button ViewFlightManifestButton;
        private System.Windows.Forms.Label FromDateAfterTodayError;
        private System.Windows.Forms.Label ToDateAfterTodayError;
        private System.Windows.Forms.Label FlightManagerHomeLabel;
        private System.Windows.Forms.Label DifferentLocationError;
        private System.Windows.Forms.Label NoFlightLabel;
    }
}

