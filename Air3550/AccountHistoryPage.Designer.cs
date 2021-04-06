
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
            this.LogOutButton = new System.Windows.Forms.Button();
            this.CreditsButton = new System.Windows.Forms.Button();
            this.FlightsTakenButton = new System.Windows.Forms.Button();
            this.FlightsCancelledButton = new System.Windows.Forms.Button();
            this.FlightsBookedButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogOutButton
            // 
            this.LogOutButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.LogOutButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.LogOutButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogOutButton.Location = new System.Drawing.Point(959, 34);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(196, 72);
            this.LogOutButton.TabIndex = 42;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // CreditsButton
            // 
            this.CreditsButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreditsButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.CreditsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.CreditsButton.Location = new System.Drawing.Point(442, 604);
            this.CreditsButton.Name = "CreditsButton";
            this.CreditsButton.Size = new System.Drawing.Size(288, 79);
            this.CreditsButton.TabIndex = 41;
            this.CreditsButton.Text = "Credits";
            this.CreditsButton.UseVisualStyleBackColor = false;
            this.CreditsButton.Click += new System.EventHandler(this.CreditsButton_Click);
            // 
            // FlightsTakenButton
            // 
            this.FlightsTakenButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FlightsTakenButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.FlightsTakenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlightsTakenButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.FlightsTakenButton.Location = new System.Drawing.Point(442, 488);
            this.FlightsTakenButton.Name = "FlightsTakenButton";
            this.FlightsTakenButton.Size = new System.Drawing.Size(288, 79);
            this.FlightsTakenButton.TabIndex = 40;
            this.FlightsTakenButton.Text = "Flights Taken";
            this.FlightsTakenButton.UseVisualStyleBackColor = false;
            this.FlightsTakenButton.Click += new System.EventHandler(this.FlightsTakenButton_Click);
            // 
            // FlightsCancelledButton
            // 
            this.FlightsCancelledButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FlightsCancelledButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.FlightsCancelledButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlightsCancelledButton.Font = new System.Drawing.Font("Rockwell", 9F);
            this.FlightsCancelledButton.Location = new System.Drawing.Point(442, 372);
            this.FlightsCancelledButton.Name = "FlightsCancelledButton";
            this.FlightsCancelledButton.Size = new System.Drawing.Size(288, 79);
            this.FlightsCancelledButton.TabIndex = 39;
            this.FlightsCancelledButton.Text = "Flights Cancelled";
            this.FlightsCancelledButton.UseVisualStyleBackColor = false;
            this.FlightsCancelledButton.Click += new System.EventHandler(this.FlightsCancelledButton_Click);
            // 
            // FlightsBookedButton
            // 
            this.FlightsBookedButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FlightsBookedButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.FlightsBookedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlightsBookedButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.FlightsBookedButton.Location = new System.Drawing.Point(442, 256);
            this.FlightsBookedButton.Name = "FlightsBookedButton";
            this.FlightsBookedButton.Size = new System.Drawing.Size(288, 79);
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
            this.BackButton.Location = new System.Drawing.Point(12, 34);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(196, 72);
            this.BackButton.TabIndex = 43;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // AccountHistoryPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1173, 938);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.CreditsButton);
            this.Controls.Add(this.FlightsTakenButton);
            this.Controls.Add(this.FlightsCancelledButton);
            this.Controls.Add(this.FlightsBookedButton);
            this.Name = "AccountHistoryPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air3550";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Button CreditsButton;
        private System.Windows.Forms.Button FlightsTakenButton;
        private System.Windows.Forms.Button FlightsCancelledButton;
        private System.Windows.Forms.Button FlightsBookedButton;
        private System.Windows.Forms.Button BackButton;
    }
}

