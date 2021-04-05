
namespace Air3550
{
    partial class CancelFlightPage
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
            this.LogOutButton = new System.Windows.Forms.Button();
            this.CancelFlightLabel = new System.Windows.Forms.Label();
            this.CancelFlightTable = new System.Windows.Forms.DataGridView();
            this.BackButton = new System.Windows.Forms.Button();
            this.CancelFlightsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CancelFlightTable)).BeginInit();
            this.SuspendLayout();
            // 
            // LogOutButton
            // 
            this.LogOutButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.LogOutButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.LogOutButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.LogOutButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogOutButton.Location = new System.Drawing.Point(959, 34);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(196, 72);
            this.LogOutButton.TabIndex = 37;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // CancelFlightLabel
            // 
            this.CancelFlightLabel.AutoSize = true;
            this.CancelFlightLabel.Font = new System.Drawing.Font("Rockwell", 24F);
            this.CancelFlightLabel.Location = new System.Drawing.Point(348, 34);
            this.CancelFlightLabel.Name = "CancelFlightLabel";
            this.CancelFlightLabel.Size = new System.Drawing.Size(557, 72);
            this.CancelFlightLabel.TabIndex = 36;
            this.CancelFlightLabel.Text = "Scheduled Flights";
            this.CancelFlightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CancelFlightTable
            // 
            this.CancelFlightTable.AllowUserToAddRows = false;
            this.CancelFlightTable.AllowUserToOrderColumns = true;
            this.CancelFlightTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CancelFlightTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CancelFlightTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.CancelFlightTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CancelFlightTable.Location = new System.Drawing.Point(61, 133);
            this.CancelFlightTable.Name = "CancelFlightTable";
            this.CancelFlightTable.RowHeadersVisible = false;
            this.CancelFlightTable.RowHeadersWidth = 82;
            this.CancelFlightTable.RowTemplate.Height = 33;
            this.CancelFlightTable.Size = new System.Drawing.Size(1054, 673);
            this.CancelFlightTable.TabIndex = 38;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BackButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.BackButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackButton.Location = new System.Drawing.Point(583, 833);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(276, 72);
            this.BackButton.TabIndex = 40;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // CancelFlightsButton
            // 
            this.CancelFlightsButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.CancelFlightsButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.CancelFlightsButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelFlightsButton.Location = new System.Drawing.Point(879, 833);
            this.CancelFlightsButton.Name = "CancelFlightsButton";
            this.CancelFlightsButton.Size = new System.Drawing.Size(276, 72);
            this.CancelFlightsButton.TabIndex = 39;
            this.CancelFlightsButton.Text = "Cancel Flights";
            this.CancelFlightsButton.UseVisualStyleBackColor = false;
            this.CancelFlightsButton.Click += new System.EventHandler(this.CancelFlightButton_Click);
            // 
            // CancelFlightPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1173, 938);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.CancelFlightsButton);
            this.Controls.Add(this.CancelFlightTable);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.CancelFlightLabel);
            this.Name = "CancelFlightPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air3550";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CancelFlightPage_FormClosing);
            this.Load += new System.EventHandler(this.CancelFlightPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CancelFlightTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Label CancelFlightLabel;
        private System.Windows.Forms.DataGridView CancelFlightTable;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button CancelFlightsButton;
    }
}

