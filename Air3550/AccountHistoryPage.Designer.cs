
namespace Air3550
{
    partial class AccountHistoryPage
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
            this.LogOutButton = new System.Windows.Forms.Button();
            this.FlightsTakenButton = new System.Windows.Forms.Button();
            this.FlightsCancelledButton = new System.Windows.Forms.Button();
            this.FlightsBookedButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.AvailableBalanceLabel = new System.Windows.Forms.Label();
            this.PointsAvailableLabel = new System.Windows.Forms.Label();
            this.PointsUsedLabel = new System.Windows.Forms.Label();
            this.PointsText = new System.Windows.Forms.TextBox();
            this.PointsAvailableText = new System.Windows.Forms.TextBox();
            this.AvailableBalanceText = new System.Windows.Forms.TextBox();
            this.AccountHistoryTable = new System.Windows.Forms.DataGridView();
            this.NoTakenFlightLabel = new System.Windows.Forms.Label();
            this.NoBookedFlightLabel = new System.Windows.Forms.Label();
            this.NoCancelledFlightLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AccountHistoryTable)).BeginInit();
            this.SuspendLayout();
            // 
            // LogOutButton
            // 
            this.LogOutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogOutButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.LogOutButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.LogOutButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogOutButton.Location = new System.Drawing.Point(1892, 98);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(276, 72);
            this.LogOutButton.TabIndex = 42;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // FlightsTakenButton
            // 
            this.FlightsTakenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FlightsTakenButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.FlightsTakenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlightsTakenButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.FlightsTakenButton.Location = new System.Drawing.Point(903, 200);
            this.FlightsTakenButton.Name = "FlightsTakenButton";
            this.FlightsTakenButton.Size = new System.Drawing.Size(288, 80);
            this.FlightsTakenButton.TabIndex = 40;
            this.FlightsTakenButton.Text = "Flights Taken";
            this.FlightsTakenButton.UseVisualStyleBackColor = false;
            this.FlightsTakenButton.Click += new System.EventHandler(this.FlightsTakenButton_Click);
            // 
            // FlightsCancelledButton
            // 
            this.FlightsCancelledButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FlightsCancelledButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.FlightsCancelledButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlightsCancelledButton.Font = new System.Drawing.Font("Rockwell", 9F);
            this.FlightsCancelledButton.Location = new System.Drawing.Point(1228, 200);
            this.FlightsCancelledButton.Name = "FlightsCancelledButton";
            this.FlightsCancelledButton.Size = new System.Drawing.Size(288, 80);
            this.FlightsCancelledButton.TabIndex = 39;
            this.FlightsCancelledButton.Text = "Flights Cancelled";
            this.FlightsCancelledButton.UseVisualStyleBackColor = false;
            this.FlightsCancelledButton.Click += new System.EventHandler(this.FlightsCancelledButton_Click);
            // 
            // FlightsBookedButton
            // 
            this.FlightsBookedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FlightsBookedButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.FlightsBookedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlightsBookedButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.FlightsBookedButton.Location = new System.Drawing.Point(1551, 199);
            this.FlightsBookedButton.Name = "FlightsBookedButton";
            this.FlightsBookedButton.Size = new System.Drawing.Size(288, 80);
            this.FlightsBookedButton.TabIndex = 38;
            this.FlightsBookedButton.Text = "Flights Booked";
            this.FlightsBookedButton.UseVisualStyleBackColor = false;
            this.FlightsBookedButton.Click += new System.EventHandler(this.FlightsBookedButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BackButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.BackButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackButton.Location = new System.Drawing.Point(67, 98);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(276, 72);
            this.BackButton.TabIndex = 43;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // AvailableBalanceLabel
            // 
            this.AvailableBalanceLabel.AutoSize = true;
            this.AvailableBalanceLabel.Font = new System.Drawing.Font("Rockwell", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvailableBalanceLabel.Location = new System.Drawing.Point(58, 666);
            this.AvailableBalanceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AvailableBalanceLabel.Name = "AvailableBalanceLabel";
            this.AvailableBalanceLabel.Size = new System.Drawing.Size(336, 42);
            this.AvailableBalanceLabel.TabIndex = 44;
            this.AvailableBalanceLabel.Text = "Available Balance:";
            // 
            // PointsAvailableLabel
            // 
            this.PointsAvailableLabel.AutoSize = true;
            this.PointsAvailableLabel.Font = new System.Drawing.Font("Rockwell", 14F);
            this.PointsAvailableLabel.Location = new System.Drawing.Point(58, 487);
            this.PointsAvailableLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PointsAvailableLabel.Name = "PointsAvailableLabel";
            this.PointsAvailableLabel.Size = new System.Drawing.Size(312, 42);
            this.PointsAvailableLabel.TabIndex = 45;
            this.PointsAvailableLabel.Text = "Points Available:";
            // 
            // PointsUsedLabel
            // 
            this.PointsUsedLabel.AutoSize = true;
            this.PointsUsedLabel.Font = new System.Drawing.Font("Rockwell", 14F);
            this.PointsUsedLabel.Location = new System.Drawing.Point(58, 308);
            this.PointsUsedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PointsUsedLabel.Name = "PointsUsedLabel";
            this.PointsUsedLabel.Size = new System.Drawing.Size(233, 42);
            this.PointsUsedLabel.TabIndex = 46;
            this.PointsUsedLabel.Text = "Points Used:";
            // 
            // PointsText
            // 
            this.PointsText.Font = new System.Drawing.Font("Rockwell", 14F);
            this.PointsText.Location = new System.Drawing.Point(65, 393);
            this.PointsText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PointsText.Name = "PointsText";
            this.PointsText.Size = new System.Drawing.Size(358, 51);
            this.PointsText.TabIndex = 47;
            // 
            // PointsAvailableText
            // 
            this.PointsAvailableText.Font = new System.Drawing.Font("Rockwell", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointsAvailableText.Location = new System.Drawing.Point(65, 572);
            this.PointsAvailableText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PointsAvailableText.Name = "PointsAvailableText";
            this.PointsAvailableText.Size = new System.Drawing.Size(358, 51);
            this.PointsAvailableText.TabIndex = 48;
            // 
            // AvailableBalanceText
            // 
            this.AvailableBalanceText.Font = new System.Drawing.Font("Rockwell", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvailableBalanceText.Location = new System.Drawing.Point(67, 751);
            this.AvailableBalanceText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AvailableBalanceText.Name = "AvailableBalanceText";
            this.AvailableBalanceText.Size = new System.Drawing.Size(358, 51);
            this.AvailableBalanceText.TabIndex = 49;
            // 
            // AccountHistoryTable
            // 
            this.AccountHistoryTable.AllowUserToAddRows = false;
            this.AccountHistoryTable.AllowUserToDeleteRows = false;
            this.AccountHistoryTable.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Rockwell", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AccountHistoryTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.AccountHistoryTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AccountHistoryTable.Location = new System.Drawing.Point(582, 308);
            this.AccountHistoryTable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AccountHistoryTable.Name = "AccountHistoryTable";
            this.AccountHistoryTable.ReadOnly = true;
            this.AccountHistoryTable.RowHeadersWidth = 51;
            this.AccountHistoryTable.RowTemplate.Height = 24;
            this.AccountHistoryTable.Size = new System.Drawing.Size(1586, 723);
            this.AccountHistoryTable.TabIndex = 50;
            // 
            // NoTakenFlightLabel
            // 
            this.NoTakenFlightLabel.AutoSize = true;
            this.NoTakenFlightLabel.Font = new System.Drawing.Font("Rockwell", 24F);
            this.NoTakenFlightLabel.Location = new System.Drawing.Point(793, 612);
            this.NoTakenFlightLabel.Name = "NoTakenFlightLabel";
            this.NoTakenFlightLabel.Size = new System.Drawing.Size(1125, 72);
            this.NoTakenFlightLabel.TabIndex = 51;
            this.NoTakenFlightLabel.Text = "You Currently Have No Flights Taken";
            this.NoTakenFlightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NoBookedFlightLabel
            // 
            this.NoBookedFlightLabel.AutoSize = true;
            this.NoBookedFlightLabel.Font = new System.Drawing.Font("Rockwell", 24F);
            this.NoBookedFlightLabel.Location = new System.Drawing.Point(793, 612);
            this.NoBookedFlightLabel.Name = "NoBookedFlightLabel";
            this.NoBookedFlightLabel.Size = new System.Drawing.Size(1168, 72);
            this.NoBookedFlightLabel.TabIndex = 52;
            this.NoBookedFlightLabel.Text = "You Currently Have No Flights Booked";
            this.NoBookedFlightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NoCancelledFlightLabel
            // 
            this.NoCancelledFlightLabel.AutoSize = true;
            this.NoCancelledFlightLabel.Font = new System.Drawing.Font("Rockwell", 24F);
            this.NoCancelledFlightLabel.Location = new System.Drawing.Point(793, 612);
            this.NoCancelledFlightLabel.Name = "NoCancelledFlightLabel";
            this.NoCancelledFlightLabel.Size = new System.Drawing.Size(1248, 72);
            this.NoCancelledFlightLabel.TabIndex = 53;
            this.NoCancelledFlightLabel.Text = "You Currently Have No Flights Cancelled";
            this.NoCancelledFlightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AccountHistoryPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(2222, 1078);
            this.Controls.Add(this.NoCancelledFlightLabel);
            this.Controls.Add(this.NoBookedFlightLabel);
            this.Controls.Add(this.NoTakenFlightLabel);
            this.Controls.Add(this.AccountHistoryTable);
            this.Controls.Add(this.AvailableBalanceText);
            this.Controls.Add(this.PointsAvailableText);
            this.Controls.Add(this.PointsText);
            this.Controls.Add(this.PointsUsedLabel);
            this.Controls.Add(this.PointsAvailableLabel);
            this.Controls.Add(this.AvailableBalanceLabel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.FlightsTakenButton);
            this.Controls.Add(this.FlightsCancelledButton);
            this.Controls.Add(this.FlightsBookedButton);
            this.MaximumSize = new System.Drawing.Size(2248, 1149);
            this.Name = "AccountHistoryPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air3550";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AccountHistoryPage_FormClosing);
            this.Load += new System.EventHandler(this.AccountHistoryPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AccountHistoryTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Button FlightsTakenButton;
        private System.Windows.Forms.Button FlightsCancelledButton;
        private System.Windows.Forms.Button FlightsBookedButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label AvailableBalanceLabel;
        private System.Windows.Forms.Label PointsAvailableLabel;
        private System.Windows.Forms.Label PointsUsedLabel;
        private System.Windows.Forms.TextBox PointsText;
        private System.Windows.Forms.TextBox PointsAvailableText;
        private System.Windows.Forms.TextBox AvailableBalanceText;
        private System.Windows.Forms.DataGridView AccountHistoryTable;
        private System.Windows.Forms.Label NoTakenFlightLabel;
        private System.Windows.Forms.Label NoBookedFlightLabel;
        private System.Windows.Forms.Label NoCancelledFlightLabel;
    }
}

