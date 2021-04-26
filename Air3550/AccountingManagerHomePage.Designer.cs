
namespace Air3550
{
    partial class AccountingManagerHomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountingManagerHomePage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CreateButton = new System.Windows.Forms.Button();
            this.TotalFlightCountLabel = new System.Windows.Forms.Label();
            this.TotalRevenueLabel = new System.Windows.Forms.Label();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.Label1 = new System.Windows.Forms.Label();
            this.DifferentLocationError = new System.Windows.Forms.Label();
            this.FlightManagerHomeLabel = new System.Windows.Forms.Label();
            this.ToDateAfterTodayError = new System.Windows.Forms.Label();
            this.FromDateAfterTodayError = new System.Windows.Forms.Label();
            this.ClearFiltersButton = new System.Windows.Forms.Button();
            this.BeforeFromDateError = new System.Windows.Forms.Label();
            this.accountPage = new System.Windows.Forms.DataGridView();
            this.SearchButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ToDatePicker = new System.Windows.Forms.DateTimePicker();
            this.FromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.ArriveComboBox = new System.Windows.Forms.ComboBox();
            this.ArriveLabel = new System.Windows.Forms.Label();
            this.DepartComboBox = new System.Windows.Forms.ComboBox();
            this.DepartLabel = new System.Windows.Forms.Label();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.CompanyStatisticsGroupBox = new System.Windows.Forms.GroupBox();
            this.PrintButton = new System.Windows.Forms.Button();
            this.NoFlightLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.accountPage)).BeginInit();
            this.CompanyStatisticsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateButton
            // 
            this.CreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.CreateButton.Font = new System.Drawing.Font("Rockwell", 14F);
            this.CreateButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CreateButton.Location = new System.Drawing.Point(2248, 1149);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(2248, 1149);
            this.CreateButton.TabIndex = 11;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = false;
            this.CreateButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // TotalFlightCountLabel
            // 
            this.TotalFlightCountLabel.AutoSize = true;
            this.TotalFlightCountLabel.Font = new System.Drawing.Font("Rockwell", 10F);
            this.TotalFlightCountLabel.Location = new System.Drawing.Point(64, 46);
            this.TotalFlightCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TotalFlightCountLabel.Name = "TotalFlightCountLabel";
            this.TotalFlightCountLabel.Size = new System.Drawing.Size(287, 31);
            this.TotalFlightCountLabel.TabIndex = 14;
            this.TotalFlightCountLabel.Text = "TotalFlightCountLabel";
            // 
            // TotalRevenueLabel
            // 
            this.TotalRevenueLabel.AutoSize = true;
            this.TotalRevenueLabel.Font = new System.Drawing.Font("Rockwell", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalRevenueLabel.Location = new System.Drawing.Point(615, 46);
            this.TotalRevenueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TotalRevenueLabel.Name = "TotalRevenueLabel";
            this.TotalRevenueLabel.Size = new System.Drawing.Size(248, 31);
            this.TotalRevenueLabel.TabIndex = 15;
            this.TotalRevenueLabel.Text = "TotalRevenueLabel";
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(1143, 311);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(0, 37);
            this.Label1.TabIndex = 19;
            // 
            // DifferentLocationError
            // 
            this.DifferentLocationError.AutoSize = true;
            this.DifferentLocationError.ForeColor = System.Drawing.Color.Red;
            this.DifferentLocationError.Location = new System.Drawing.Point(55, 234);
            this.DifferentLocationError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DifferentLocationError.Name = "DifferentLocationError";
            this.DifferentLocationError.Size = new System.Drawing.Size(376, 25);
            this.DifferentLocationError.TabIndex = 104;
            this.DifferentLocationError.Text = "Please Select Two Different Locations";
            this.DifferentLocationError.Visible = false;
            // 
            // FlightManagerHomeLabel
            // 
            this.FlightManagerHomeLabel.AutoSize = true;
            this.FlightManagerHomeLabel.Font = new System.Drawing.Font("Rockwell", 24F);
            this.FlightManagerHomeLabel.Location = new System.Drawing.Point(691, 49);
            this.FlightManagerHomeLabel.Name = "FlightManagerHomeLabel";
            this.FlightManagerHomeLabel.Size = new System.Drawing.Size(837, 72);
            this.FlightManagerHomeLabel.TabIndex = 103;
            this.FlightManagerHomeLabel.Text = "Accounting Manager Home";
            this.FlightManagerHomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ToDateAfterTodayError
            // 
            this.ToDateAfterTodayError.AutoSize = true;
            this.ToDateAfterTodayError.ForeColor = System.Drawing.Color.Red;
            this.ToDateAfterTodayError.Location = new System.Drawing.Point(1358, 234);
            this.ToDateAfterTodayError.Name = "ToDateAfterTodayError";
            this.ToDateAfterTodayError.Size = new System.Drawing.Size(370, 25);
            this.ToDateAfterTodayError.TabIndex = 102;
            this.ToDateAfterTodayError.Text = "Please Select Today or Before Today";
            this.ToDateAfterTodayError.Visible = false;
            // 
            // FromDateAfterTodayError
            // 
            this.FromDateAfterTodayError.AutoSize = true;
            this.FromDateAfterTodayError.ForeColor = System.Drawing.Color.Red;
            this.FromDateAfterTodayError.Location = new System.Drawing.Point(747, 234);
            this.FromDateAfterTodayError.Name = "FromDateAfterTodayError";
            this.FromDateAfterTodayError.Size = new System.Drawing.Size(348, 25);
            this.FromDateAfterTodayError.TabIndex = 101;
            this.FromDateAfterTodayError.Text = "Please Select a Date Before Today";
            this.FromDateAfterTodayError.Visible = false;
            // 
            // ClearFiltersButton
            // 
            this.ClearFiltersButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClearFiltersButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.ClearFiltersButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClearFiltersButton.Location = new System.Drawing.Point(60, 49);
            this.ClearFiltersButton.Name = "ClearFiltersButton";
            this.ClearFiltersButton.Size = new System.Drawing.Size(276, 72);
            this.ClearFiltersButton.TabIndex = 98;
            this.ClearFiltersButton.Text = "Clear Filters";
            this.ClearFiltersButton.UseVisualStyleBackColor = false;
            this.ClearFiltersButton.Click += new System.EventHandler(this.ClearFiltersButton_Click);
            // 
            // BeforeFromDateError
            // 
            this.BeforeFromDateError.AutoSize = true;
            this.BeforeFromDateError.ForeColor = System.Drawing.Color.Red;
            this.BeforeFromDateError.Location = new System.Drawing.Point(1358, 234);
            this.BeforeFromDateError.Name = "BeforeFromDateError";
            this.BeforeFromDateError.Size = new System.Drawing.Size(540, 25);
            this.BeforeFromDateError.TabIndex = 97;
            this.BeforeFromDateError.Text = "Please Select a Second Date that is after the First Date";
            this.BeforeFromDateError.Visible = false;
            // 
            // accountPage
            // 
            this.accountPage.AllowUserToAddRows = false;
            this.accountPage.AllowUserToOrderColumns = true;
            this.accountPage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.accountPage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.accountPage.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.accountPage.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.accountPage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.accountPage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.accountPage.DefaultCellStyle = dataGridViewCellStyle4;
            this.accountPage.Location = new System.Drawing.Point(62, 449);
            this.accountPage.MultiSelect = false;
            this.accountPage.Name = "accountPage";
            this.accountPage.ReadOnly = true;
            this.accountPage.RowHeadersWidth = 82;
            this.accountPage.RowTemplate.Height = 33;
            this.accountPage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.accountPage.Size = new System.Drawing.Size(2098, 509);
            this.accountPage.TabIndex = 96;
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.SearchButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.SearchButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SearchButton.Location = new System.Drawing.Point(1974, 217);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(188, 84);
            this.SearchButton.TabIndex = 95;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Rockwell", 10F);
            this.label5.Location = new System.Drawing.Point(1357, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 31);
            this.label5.TabIndex = 94;
            this.label5.Text = "To";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Rockwell", 10F);
            this.label6.Location = new System.Drawing.Point(746, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 31);
            this.label6.TabIndex = 93;
            this.label6.Text = "From";
            // 
            // ToDatePicker
            // 
            this.ToDatePicker.Font = new System.Drawing.Font("Rockwell", 10F);
            this.ToDatePicker.Location = new System.Drawing.Point(1363, 262);
            this.ToDatePicker.Name = "ToDatePicker";
            this.ToDatePicker.Size = new System.Drawing.Size(540, 39);
            this.ToDatePicker.TabIndex = 92;
            this.ToDatePicker.ValueChanged += new System.EventHandler(this.ToDatePicker_ValueChanged);
            // 
            // FromDatePicker
            // 
            this.FromDatePicker.Font = new System.Drawing.Font("Rockwell", 10F);
            this.FromDatePicker.Location = new System.Drawing.Point(752, 262);
            this.FromDatePicker.Name = "FromDatePicker";
            this.FromDatePicker.Size = new System.Drawing.Size(540, 39);
            this.FromDatePicker.TabIndex = 91;
            this.FromDatePicker.ValueChanged += new System.EventHandler(this.FromDatePicker_ValueChanged);
            // 
            // ArriveComboBox
            // 
            this.ArriveComboBox.Font = new System.Drawing.Font("Rockwell", 10F);
            this.ArriveComboBox.FormattingEnabled = true;
            this.ArriveComboBox.Location = new System.Drawing.Point(406, 262);
            this.ArriveComboBox.Name = "ArriveComboBox";
            this.ArriveComboBox.Size = new System.Drawing.Size(276, 39);
            this.ArriveComboBox.TabIndex = 90;
            // 
            // ArriveLabel
            // 
            this.ArriveLabel.AutoSize = true;
            this.ArriveLabel.Font = new System.Drawing.Font("Rockwell", 10F);
            this.ArriveLabel.Location = new System.Drawing.Point(400, 193);
            this.ArriveLabel.Name = "ArriveLabel";
            this.ArriveLabel.Size = new System.Drawing.Size(159, 31);
            this.ArriveLabel.TabIndex = 89;
            this.ArriveLabel.Text = "Arrival City";
            // 
            // DepartComboBox
            // 
            this.DepartComboBox.Font = new System.Drawing.Font("Rockwell", 10F);
            this.DepartComboBox.FormattingEnabled = true;
            this.DepartComboBox.Location = new System.Drawing.Point(60, 262);
            this.DepartComboBox.Name = "DepartComboBox";
            this.DepartComboBox.Size = new System.Drawing.Size(276, 39);
            this.DepartComboBox.TabIndex = 88;
            // 
            // DepartLabel
            // 
            this.DepartLabel.AutoSize = true;
            this.DepartLabel.Font = new System.Drawing.Font("Rockwell", 10F);
            this.DepartLabel.Location = new System.Drawing.Point(54, 193);
            this.DepartLabel.Name = "DepartLabel";
            this.DepartLabel.Size = new System.Drawing.Size(199, 31);
            this.DepartLabel.TabIndex = 87;
            this.DepartLabel.Text = "Departure City";
            // 
            // LogOutButton
            // 
            this.LogOutButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.LogOutButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.LogOutButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogOutButton.Location = new System.Drawing.Point(1884, 49);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(276, 72);
            this.LogOutButton.TabIndex = 86;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // CompanyStatisticsGroupBox
            // 
            this.CompanyStatisticsGroupBox.Controls.Add(this.TotalFlightCountLabel);
            this.CompanyStatisticsGroupBox.Controls.Add(this.TotalRevenueLabel);
            this.CompanyStatisticsGroupBox.Font = new System.Drawing.Font("Rockwell", 10F);
            this.CompanyStatisticsGroupBox.Location = new System.Drawing.Point(60, 326);
            this.CompanyStatisticsGroupBox.Name = "CompanyStatisticsGroupBox";
            this.CompanyStatisticsGroupBox.Size = new System.Drawing.Size(1230, 100);
            this.CompanyStatisticsGroupBox.TabIndex = 106;
            this.CompanyStatisticsGroupBox.TabStop = false;
            this.CompanyStatisticsGroupBox.Text = "Company Statistics";
            // 
            // PrintButton
            // 
            this.PrintButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.PrintButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.PrintButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PrintButton.Location = new System.Drawing.Point(1884, 980);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(276, 72);
            this.PrintButton.TabIndex = 107;
            this.PrintButton.Text = "Print";
            this.PrintButton.UseVisualStyleBackColor = false;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // NoFlightLabel
            // 
            this.NoFlightLabel.AutoSize = true;
            this.NoFlightLabel.Font = new System.Drawing.Font("Rockwell", 24F);
            this.NoFlightLabel.Location = new System.Drawing.Point(522, 794);
            this.NoFlightLabel.Name = "NoFlightLabel";
            this.NoFlightLabel.Size = new System.Drawing.Size(1162, 72);
            this.NoFlightLabel.TabIndex = 108;
            this.NoFlightLabel.Text = "There are no flights that have taken off";
            this.NoFlightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AccountingManagerHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(2218, 1064);
            this.Controls.Add(this.NoFlightLabel);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.CompanyStatisticsGroupBox);
            this.Controls.Add(this.DifferentLocationError);
            this.Controls.Add(this.FlightManagerHomeLabel);
            this.Controls.Add(this.ToDateAfterTodayError);
            this.Controls.Add(this.FromDateAfterTodayError);
            this.Controls.Add(this.ClearFiltersButton);
            this.Controls.Add(this.BeforeFromDateError);
            this.Controls.Add(this.accountPage);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ToDatePicker);
            this.Controls.Add(this.FromDatePicker);
            this.Controls.Add(this.ArriveComboBox);
            this.Controls.Add(this.ArriveLabel);
            this.Controls.Add(this.DepartComboBox);
            this.Controls.Add(this.DepartLabel);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.CreateButton);
            this.MaximumSize = new System.Drawing.Size(2244, 1135);
            this.Name = "AccountingManagerHomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air3550";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AccountingManagerHomePage_FormClosing);
            this.Load += new System.EventHandler(this.AccountingManagerHomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accountPage)).EndInit();
            this.CompanyStatisticsGroupBox.ResumeLayout(false);
            this.CompanyStatisticsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Label TotalFlightCountLabel;
        private System.Windows.Forms.Label TotalRevenueLabel;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label DifferentLocationError;
        private System.Windows.Forms.Label FlightManagerHomeLabel;
        private System.Windows.Forms.Label ToDateAfterTodayError;
        private System.Windows.Forms.Label FromDateAfterTodayError;
        private System.Windows.Forms.Button ClearFiltersButton;
        private System.Windows.Forms.Label BeforeFromDateError;
        private System.Windows.Forms.DataGridView accountPage;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker ToDatePicker;
        private System.Windows.Forms.DateTimePicker FromDatePicker;
        private System.Windows.Forms.ComboBox ArriveComboBox;
        private System.Windows.Forms.Label ArriveLabel;
        private System.Windows.Forms.ComboBox DepartComboBox;
        private System.Windows.Forms.Label DepartLabel;
        private System.Windows.Forms.Button LogOutButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox CompanyStatisticsGroupBox;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Label NoFlightLabel;
    }
}

