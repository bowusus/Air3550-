
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
            this.CreateButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.ToDateLabel = new System.Windows.Forms.Label();
            this.FromDateLabel = new System.Windows.Forms.Label();
            this.ToTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FromTimePicker = new System.Windows.Forms.DateTimePicker();
            this.totalFlights = new System.Windows.Forms.Label();
            this.totalRevenue = new System.Windows.Forms.Label();
            this.BeforeFromDateError = new System.Windows.Forms.Label();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.FromDateAfterTodayError = new System.Windows.Forms.Label();
            this.ToDateAfterTodayError = new System.Windows.Forms.Label();
            this.accountPage = new System.Windows.Forms.DataGridView();
            this.Label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.LogOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.accountPage)).BeginInit();
            this.SuspendLayout();
            // 
            // CreateButton
            // 
            this.CreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.CreateButton.Font = new System.Drawing.Font("Rockwell", 14F);
            this.CreateButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CreateButton.Location = new System.Drawing.Point(890, 81);
            this.CreateButton.Margin = new System.Windows.Forms.Padding(2);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(123, 33);
            this.CreateButton.TabIndex = 11;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = false;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PrintButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.PrintButton.Font = new System.Drawing.Font("Rockwell", 14F);
            this.PrintButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PrintButton.Location = new System.Drawing.Point(1031, 479);
            this.PrintButton.Margin = new System.Windows.Forms.Padding(2);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(123, 33);
            this.PrintButton.TabIndex = 12;
            this.PrintButton.Text = "Print";
            this.PrintButton.UseVisualStyleBackColor = false;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // ToDateLabel
            // 
            this.ToDateLabel.AutoSize = true;
            this.ToDateLabel.Font = new System.Drawing.Font("Rockwell", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToDateLabel.Location = new System.Drawing.Point(286, 81);
            this.ToDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ToDateLabel.Name = "ToDateLabel";
            this.ToDateLabel.Size = new System.Drawing.Size(47, 27);
            this.ToDateLabel.TabIndex = 3;
            this.ToDateLabel.Text = "To:";
            // 
            // FromDateLabel
            // 
            this.FromDateLabel.AutoSize = true;
            this.FromDateLabel.Font = new System.Drawing.Font("Rockwell", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromDateLabel.Location = new System.Drawing.Point(286, 31);
            this.FromDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FromDateLabel.Name = "FromDateLabel";
            this.FromDateLabel.Size = new System.Drawing.Size(77, 27);
            this.FromDateLabel.TabIndex = 2;
            this.FromDateLabel.Text = "From:";
            // 
            // ToTimePicker
            // 
            this.ToTimePicker.CalendarFont = new System.Drawing.Font("Rockwell", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToTimePicker.Font = new System.Drawing.Font("Rockwell", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToTimePicker.Location = new System.Drawing.Point(376, 75);
            this.ToTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.ToTimePicker.Name = "ToTimePicker";
            this.ToTimePicker.Size = new System.Drawing.Size(427, 35);
            this.ToTimePicker.TabIndex = 1;
            this.ToTimePicker.ValueChanged += new System.EventHandler(this.ToTimePicker_ValueChanged);
            // 
            // FromTimePicker
            // 
            this.FromTimePicker.CalendarFont = new System.Drawing.Font("Rockwell", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromTimePicker.Font = new System.Drawing.Font("Rockwell", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromTimePicker.Location = new System.Drawing.Point(376, 23);
            this.FromTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.FromTimePicker.Name = "FromTimePicker";
            this.FromTimePicker.Size = new System.Drawing.Size(427, 35);
            this.FromTimePicker.TabIndex = 0;
            this.FromTimePicker.ValueChanged += new System.EventHandler(this.FromTimePicker_ValueChanged);
            // 
            // totalFlights
            // 
            this.totalFlights.AutoSize = true;
            this.totalFlights.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalFlights.Location = new System.Drawing.Point(12, 153);
            this.totalFlights.Name = "totalFlights";
            this.totalFlights.Size = new System.Drawing.Size(79, 29);
            this.totalFlights.TabIndex = 14;
            this.totalFlights.Text = "label1";
            // 
            // totalRevenue
            // 
            this.totalRevenue.AutoSize = true;
            this.totalRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalRevenue.Location = new System.Drawing.Point(12, 199);
            this.totalRevenue.Name = "totalRevenue";
            this.totalRevenue.Size = new System.Drawing.Size(79, 29);
            this.totalRevenue.TabIndex = 15;
            this.totalRevenue.Text = "label2";
            // 
            // BeforeFromDateError
            // 
            this.BeforeFromDateError.AutoSize = true;
            this.BeforeFromDateError.Location = new System.Drawing.Point(696, 115);
            this.BeforeFromDateError.Name = "BeforeFromDateError";
            this.BeforeFromDateError.Size = new System.Drawing.Size(107, 17);
            this.BeforeFromDateError.TabIndex = 16;
            this.BeforeFromDateError.Text = "Select a to date";
            this.BeforeFromDateError.Visible = false;
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
            // FromDateAfterTodayError
            // 
            this.FromDateAfterTodayError.AutoSize = true;
            this.FromDateAfterTodayError.ForeColor = System.Drawing.Color.Red;
            this.FromDateAfterTodayError.Location = new System.Drawing.Point(373, 9);
            this.FromDateAfterTodayError.Name = "FromDateAfterTodayError";
            this.FromDateAfterTodayError.Size = new System.Drawing.Size(168, 17);
            this.FromDateAfterTodayError.TabIndex = 17;
            this.FromDateAfterTodayError.Text = "Please select a from date";
            this.FromDateAfterTodayError.Visible = false;
            // 
            // ToDateAfterTodayError
            // 
            this.ToDateAfterTodayError.AutoSize = true;
            this.ToDateAfterTodayError.ForeColor = System.Drawing.Color.Red;
            this.ToDateAfterTodayError.Location = new System.Drawing.Point(373, 112);
            this.ToDateAfterTodayError.Name = "ToDateAfterTodayError";
            this.ToDateAfterTodayError.Size = new System.Drawing.Size(152, 17);
            this.ToDateAfterTodayError.TabIndex = 18;
            this.ToDateAfterTodayError.Text = "Please select a to date";
            this.ToDateAfterTodayError.Visible = false;
            // 
            // accountPage
            // 
            this.accountPage.AllowUserToAddRows = false;
            this.accountPage.AllowUserToDeleteRows = false;
            this.accountPage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accountPage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accountPage.Location = new System.Drawing.Point(12, 244);
            this.accountPage.Name = "accountPage";
            this.accountPage.ReadOnly = true;
            this.accountPage.RowHeadersWidth = 51;
            this.accountPage.RowTemplate.Height = 24;
            this.accountPage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.accountPage.Size = new System.Drawing.Size(1142, 230);
            this.accountPage.TabIndex = 13;
            this.accountPage.SelectionChanged += new System.EventHandler(this.accountPage_SelectionChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(762, 199);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(0, 25);
            this.Label1.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Font = new System.Drawing.Font("Rockwell", 14F);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(864, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 33);
            this.button1.TabIndex = 20;
            this.button1.Text = "Clear Date ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LogOut
            // 
            this.LogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogOut.BackColor = System.Drawing.SystemColors.HotTrack;
            this.LogOut.Font = new System.Drawing.Font("Rockwell", 14F);
            this.LogOut.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogOut.Location = new System.Drawing.Point(1032, 25);
            this.LogOut.Margin = new System.Windows.Forms.Padding(2);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(123, 33);
            this.LogOut.TabIndex = 21;
            this.LogOut.Text = "LogOut";
            this.LogOut.UseVisualStyleBackColor = false;
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // AccountingManagerHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1166, 530);
            this.Controls.Add(this.LogOut);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.ToDateAfterTodayError);
            this.Controls.Add(this.FromDateAfterTodayError);
            this.Controls.Add(this.BeforeFromDateError);
            this.Controls.Add(this.totalRevenue);
            this.Controls.Add(this.totalFlights);
            this.Controls.Add(this.accountPage);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.ToDateLabel);
            this.Controls.Add(this.FromDateLabel);
            this.Controls.Add(this.ToTimePicker);
            this.Controls.Add(this.FromTimePicker);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AccountingManagerHomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air3550";
            this.Load += new System.EventHandler(this.AccountingManagerHomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.accountPage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Label ToDateLabel;
        private System.Windows.Forms.Label FromDateLabel;
        private System.Windows.Forms.DateTimePicker ToTimePicker;
        private System.Windows.Forms.DateTimePicker FromTimePicker;
        private System.Windows.Forms.Label totalFlights;
        private System.Windows.Forms.Label totalRevenue;
        private System.Windows.Forms.Label BeforeFromDateError;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label FromDateAfterTodayError;
        private System.Windows.Forms.Label ToDateAfterTodayError;
        private System.Windows.Forms.DataGridView accountPage;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button LogOut;
    }
}

