
namespace Air3550
{
    partial class PrintBoardingPassPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintBoardingPassPage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PrintButton = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.UserIDLabel = new System.Windows.Forms.Label();
            this.UserIDText = new System.Windows.Forms.TextBox();
            this.FirstNameText = new System.Windows.Forms.TextBox();
            this.LastNameText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LastName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Destination = new System.Windows.Forms.Label();
            this.OriginText = new System.Windows.Forms.TextBox();
            this.DepartureTime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DepText = new System.Windows.Forms.TextBox();
            this.ArrivalText = new System.Windows.Forms.TextBox();
            this.FlightIDText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DesText = new System.Windows.Forms.TextBox();
            this.BoardingPassGroupBox = new System.Windows.Forms.GroupBox();
            this.BoardingPassTable = new System.Windows.Forms.DataGridView();
            this.NoFlightLabel = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.CancelFlightLabel = new System.Windows.Forms.Label();
            this.PrintBoardingPassButton = new System.Windows.Forms.Button();
            this.BoardingPassGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoardingPassTable)).BeginInit();
            this.SuspendLayout();
            // 
            // PrintButton
            // 
            this.PrintButton.Location = new System.Drawing.Point(2250, 859);
            this.PrintButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(171, 61);
            this.PrintButton.TabIndex = 49;
            this.PrintButton.Text = "Print";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintBoardingPassButton_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
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
            // UserIDLabel
            // 
            this.UserIDLabel.AutoSize = true;
            this.UserIDLabel.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserIDLabel.Location = new System.Drawing.Point(18, 70);
            this.UserIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UserIDLabel.Name = "UserIDLabel";
            this.UserIDLabel.Size = new System.Drawing.Size(115, 36);
            this.UserIDLabel.TabIndex = 50;
            this.UserIDLabel.Text = "UserID";
            // 
            // UserIDText
            // 
            this.UserIDText.Location = new System.Drawing.Point(200, 62);
            this.UserIDText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UserIDText.Name = "UserIDText";
            this.UserIDText.ReadOnly = true;
            this.UserIDText.Size = new System.Drawing.Size(331, 45);
            this.UserIDText.TabIndex = 51;
            // 
            // FirstNameText
            // 
            this.FirstNameText.Location = new System.Drawing.Point(200, 175);
            this.FirstNameText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FirstNameText.Name = "FirstNameText";
            this.FirstNameText.ReadOnly = true;
            this.FirstNameText.Size = new System.Drawing.Size(331, 45);
            this.FirstNameText.TabIndex = 52;
            // 
            // LastNameText
            // 
            this.LastNameText.Location = new System.Drawing.Point(200, 280);
            this.LastNameText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LastNameText.Name = "LastNameText";
            this.LastNameText.ReadOnly = true;
            this.LastNameText.Size = new System.Drawing.Size(331, 45);
            this.LastNameText.TabIndex = 53;
            this.LastNameText.TextChanged += new System.EventHandler(this.PrintBoardingPassPage_Load);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 183);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 36);
            this.label2.TabIndex = 54;
            this.label2.Text = "FirstName";
            // 
            // LastName
            // 
            this.LastName.AutoSize = true;
            this.LastName.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastName.Location = new System.Drawing.Point(18, 288);
            this.LastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(160, 36);
            this.LastName.TabIndex = 55;
            this.LastName.Text = "LastName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(626, 67);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 36);
            this.label4.TabIndex = 56;
            this.label4.Text = "Origin";
            // 
            // Destination
            // 
            this.Destination.AutoSize = true;
            this.Destination.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Destination.Location = new System.Drawing.Point(626, 178);
            this.Destination.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Destination.Name = "Destination";
            this.Destination.Size = new System.Drawing.Size(178, 36);
            this.Destination.TabIndex = 57;
            this.Destination.Text = "Destination";
            // 
            // OriginText
            // 
            this.OriginText.Location = new System.Drawing.Point(980, 62);
            this.OriginText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OriginText.Name = "OriginText";
            this.OriginText.ReadOnly = true;
            this.OriginText.Size = new System.Drawing.Size(346, 45);
            this.OriginText.TabIndex = 58;
            // 
            // DepartureTime
            // 
            this.DepartureTime.AutoSize = true;
            this.DepartureTime.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartureTime.Location = new System.Drawing.Point(626, 288);
            this.DepartureTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DepartureTime.Name = "DepartureTime";
            this.DepartureTime.Size = new System.Drawing.Size(327, 36);
            this.DepartureTime.TabIndex = 62;
            this.DepartureTime.Text = "Departure Date/Time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(626, 383);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(275, 36);
            this.label7.TabIndex = 63;
            this.label7.Text = "Arrival Date/Time";
            // 
            // DepText
            // 
            this.DepText.Location = new System.Drawing.Point(980, 285);
            this.DepText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DepText.Name = "DepText";
            this.DepText.ReadOnly = true;
            this.DepText.Size = new System.Drawing.Size(346, 45);
            this.DepText.TabIndex = 60;
            // 
            // ArrivalText
            // 
            this.ArrivalText.Location = new System.Drawing.Point(980, 383);
            this.ArrivalText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ArrivalText.Name = "ArrivalText";
            this.ArrivalText.ReadOnly = true;
            this.ArrivalText.Size = new System.Drawing.Size(346, 45);
            this.ArrivalText.TabIndex = 64;
            // 
            // FlightIDText
            // 
            this.FlightIDText.Location = new System.Drawing.Point(200, 386);
            this.FlightIDText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FlightIDText.Name = "FlightIDText";
            this.FlightIDText.ReadOnly = true;
            this.FlightIDText.Size = new System.Drawing.Size(331, 45);
            this.FlightIDText.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 394);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 36);
            this.label3.TabIndex = 66;
            this.label3.Text = "FlightID";
            // 
            // DesText
            // 
            this.DesText.Location = new System.Drawing.Point(980, 174);
            this.DesText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DesText.Name = "DesText";
            this.DesText.ReadOnly = true;
            this.DesText.Size = new System.Drawing.Size(346, 45);
            this.DesText.TabIndex = 68;
            // 
            // BoardingPassGroupBox
            // 
            this.BoardingPassGroupBox.Controls.Add(this.UserIDLabel);
            this.BoardingPassGroupBox.Controls.Add(this.DesText);
            this.BoardingPassGroupBox.Controls.Add(this.DepText);
            this.BoardingPassGroupBox.Controls.Add(this.DepartureTime);
            this.BoardingPassGroupBox.Controls.Add(this.ArrivalText);
            this.BoardingPassGroupBox.Controls.Add(this.UserIDText);
            this.BoardingPassGroupBox.Controls.Add(this.label7);
            this.BoardingPassGroupBox.Controls.Add(this.label2);
            this.BoardingPassGroupBox.Controls.Add(this.FlightIDText);
            this.BoardingPassGroupBox.Controls.Add(this.label3);
            this.BoardingPassGroupBox.Controls.Add(this.FirstNameText);
            this.BoardingPassGroupBox.Controls.Add(this.LastName);
            this.BoardingPassGroupBox.Controls.Add(this.Destination);
            this.BoardingPassGroupBox.Controls.Add(this.OriginText);
            this.BoardingPassGroupBox.Controls.Add(this.LastNameText);
            this.BoardingPassGroupBox.Controls.Add(this.label4);
            this.BoardingPassGroupBox.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoardingPassGroupBox.Location = new System.Drawing.Point(24, 556);
            this.BoardingPassGroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BoardingPassGroupBox.Name = "BoardingPassGroupBox";
            this.BoardingPassGroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BoardingPassGroupBox.Size = new System.Drawing.Size(1391, 482);
            this.BoardingPassGroupBox.TabIndex = 69;
            this.BoardingPassGroupBox.TabStop = false;
            this.BoardingPassGroupBox.Text = "Boarding Pass";
            // 
            // BoardingPassTable
            // 
            this.BoardingPassTable.AllowUserToAddRows = false;
            this.BoardingPassTable.AllowUserToOrderColumns = true;
            this.BoardingPassTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BoardingPassTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BoardingPassTable.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BoardingPassTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.BoardingPassTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BoardingPassTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.BoardingPassTable.Location = new System.Drawing.Point(24, 133);
            this.BoardingPassTable.MultiSelect = false;
            this.BoardingPassTable.Name = "BoardingPassTable";
            this.BoardingPassTable.ReadOnly = true;
            this.BoardingPassTable.RowHeadersWidth = 82;
            this.BoardingPassTable.RowTemplate.Height = 33;
            this.BoardingPassTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BoardingPassTable.Size = new System.Drawing.Size(2171, 394);
            this.BoardingPassTable.TabIndex = 70;
            this.BoardingPassTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BoardingPassTable_CellClick);
            // 
            // NoFlightLabel
            // 
            this.NoFlightLabel.AutoSize = true;
            this.NoFlightLabel.Font = new System.Drawing.Font("Rockwell", 24F);
            this.NoFlightLabel.Location = new System.Drawing.Point(472, 308);
            this.NoFlightLabel.Name = "NoFlightLabel";
            this.NoFlightLabel.Size = new System.Drawing.Size(1256, 72);
            this.NoFlightLabel.TabIndex = 71;
            this.NoFlightLabel.Text = "You Currently Have No Scheduled Flights";
            this.NoFlightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BackButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.BackButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackButton.Location = new System.Drawing.Point(24, 40);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(276, 72);
            this.BackButton.TabIndex = 74;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // LogOutButton
            // 
            this.LogOutButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.LogOutButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.LogOutButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.LogOutButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogOutButton.Location = new System.Drawing.Point(1919, 40);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(276, 72);
            this.LogOutButton.TabIndex = 73;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // CancelFlightLabel
            // 
            this.CancelFlightLabel.AutoSize = true;
            this.CancelFlightLabel.Font = new System.Drawing.Font("Rockwell", 24F);
            this.CancelFlightLabel.Location = new System.Drawing.Point(812, 40);
            this.CancelFlightLabel.Name = "CancelFlightLabel";
            this.CancelFlightLabel.Size = new System.Drawing.Size(557, 72);
            this.CancelFlightLabel.TabIndex = 72;
            this.CancelFlightLabel.Text = "Scheduled Flights";
            this.CancelFlightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PrintBoardingPassButton
            // 
            this.PrintBoardingPassButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.PrintBoardingPassButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.PrintBoardingPassButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PrintBoardingPassButton.Location = new System.Drawing.Point(1682, 762);
            this.PrintBoardingPassButton.Name = "PrintBoardingPassButton";
            this.PrintBoardingPassButton.Size = new System.Drawing.Size(276, 72);
            this.PrintBoardingPassButton.TabIndex = 75;
            this.PrintBoardingPassButton.Text = "Print";
            this.PrintBoardingPassButton.UseVisualStyleBackColor = false;
            this.PrintBoardingPassButton.Click += new System.EventHandler(this.PrintBoardingPassButton_Click);
            // 
            // PrintBoardingPassPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(2218, 1064);
            this.Controls.Add(this.PrintBoardingPassButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.CancelFlightLabel);
            this.Controls.Add(this.NoFlightLabel);
            this.Controls.Add(this.BoardingPassTable);
            this.Controls.Add(this.BoardingPassGroupBox);
            this.Controls.Add(this.PrintButton);
            this.MaximumSize = new System.Drawing.Size(2244, 1135);
            this.Name = "PrintBoardingPassPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air3550";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrintBoardingPassPage_FormClosing);
            this.Load += new System.EventHandler(this.PrintBoardingPassPage_Load);
            this.BoardingPassGroupBox.ResumeLayout(false);
            this.BoardingPassGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoardingPassTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button PrintButton;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label UserIDLabel;
        private System.Windows.Forms.TextBox UserIDText;
        private System.Windows.Forms.TextBox FirstNameText;
        private System.Windows.Forms.TextBox LastNameText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LastName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Destination;
        private System.Windows.Forms.TextBox OriginText;
        private System.Windows.Forms.Label DepartureTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox DepText;
        private System.Windows.Forms.TextBox ArrivalText;
        private System.Windows.Forms.TextBox FlightIDText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DesText;
        private System.Windows.Forms.GroupBox BoardingPassGroupBox;
        private System.Windows.Forms.DataGridView BoardingPassTable;
        private System.Windows.Forms.Label NoFlightLabel;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Label CancelFlightLabel;
        private System.Windows.Forms.Button PrintBoardingPassButton;
    }
}

