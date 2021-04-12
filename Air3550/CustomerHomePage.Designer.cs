
namespace Air3550
{
    partial class CustomerHomePage
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
            this.BookFlightButton = new System.Windows.Forms.Button();
            this.CancelFlightButton = new System.Windows.Forms.Button();
            this.AccountInformationButton = new System.Windows.Forms.Button();
            this.AccountHistoryButton = new System.Windows.Forms.Button();
            this.PrintBoardingPassButton = new System.Windows.Forms.Button();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BookFlightButton
            // 
            this.BookFlightButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BookFlightButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BookFlightButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BookFlightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BookFlightButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.BookFlightButton.Location = new System.Drawing.Point(442, 197);
            this.BookFlightButton.Name = "BookFlightButton";
            this.BookFlightButton.Size = new System.Drawing.Size(288, 79);
            this.BookFlightButton.TabIndex = 0;
            this.BookFlightButton.Text = "Book Flight";
            this.BookFlightButton.UseVisualStyleBackColor = false;
            this.BookFlightButton.Click += new System.EventHandler(this.BookFlightButton_Click);
            // 
            // CancelFlightButton
            // 
            this.CancelFlightButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CancelFlightButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.CancelFlightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelFlightButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.CancelFlightButton.Location = new System.Drawing.Point(442, 313);
            this.CancelFlightButton.Name = "CancelFlightButton";
            this.CancelFlightButton.Size = new System.Drawing.Size(288, 79);
            this.CancelFlightButton.TabIndex = 1;
            this.CancelFlightButton.Text = "Cancel Flight";
            this.CancelFlightButton.UseVisualStyleBackColor = false;
            this.CancelFlightButton.Click += new System.EventHandler(this.CancelFlightButton_Click);
            // 
            // AccountInformationButton
            // 
            this.AccountInformationButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AccountInformationButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.AccountInformationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AccountInformationButton.Font = new System.Drawing.Font("Rockwell", 9F);
            this.AccountInformationButton.Location = new System.Drawing.Point(442, 429);
            this.AccountInformationButton.Name = "AccountInformationButton";
            this.AccountInformationButton.Size = new System.Drawing.Size(288, 79);
            this.AccountInformationButton.TabIndex = 2;
            this.AccountInformationButton.Text = "Account Information";
            this.AccountInformationButton.UseVisualStyleBackColor = false;
            this.AccountInformationButton.Click += new System.EventHandler(this.AccountInformationButton_Click);
            // 
            // AccountHistoryButton
            // 
            this.AccountHistoryButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AccountHistoryButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.AccountHistoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AccountHistoryButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.AccountHistoryButton.Location = new System.Drawing.Point(442, 545);
            this.AccountHistoryButton.Name = "AccountHistoryButton";
            this.AccountHistoryButton.Size = new System.Drawing.Size(288, 79);
            this.AccountHistoryButton.TabIndex = 3;
            this.AccountHistoryButton.Text = "Account History";
            this.AccountHistoryButton.UseVisualStyleBackColor = false;
            this.AccountHistoryButton.Click += new System.EventHandler(this.AccountHistoryButton_Click);
            // 
            // PrintBoardingPassButton
            // 
            this.PrintBoardingPassButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PrintBoardingPassButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PrintBoardingPassButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrintBoardingPassButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.PrintBoardingPassButton.Location = new System.Drawing.Point(442, 661);
            this.PrintBoardingPassButton.Name = "PrintBoardingPassButton";
            this.PrintBoardingPassButton.Size = new System.Drawing.Size(288, 79);
            this.PrintBoardingPassButton.TabIndex = 4;
            this.PrintBoardingPassButton.Text = "Print Boarding Pass";
            this.PrintBoardingPassButton.UseVisualStyleBackColor = false;
            this.PrintBoardingPassButton.Click += new System.EventHandler(this.PrintBoardingPassButton_Click);
            // 
            // LogOutButton
            // 
            this.LogOutButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.LogOutButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.LogOutButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogOutButton.Location = new System.Drawing.Point(959, 34);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(196, 72);
            this.LogOutButton.TabIndex = 36;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // CustomerHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1173, 938);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.PrintBoardingPassButton);
            this.Controls.Add(this.AccountHistoryButton);
            this.Controls.Add(this.AccountInformationButton);
            this.Controls.Add(this.CancelFlightButton);
            this.Controls.Add(this.BookFlightButton);
            this.MaximumSize = new System.Drawing.Size(1199, 1009);
            this.Name = "CustomerHomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air3550";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomerHomePage_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BookFlightButton;
        private System.Windows.Forms.Button CancelFlightButton;
        private System.Windows.Forms.Button AccountInformationButton;
        private System.Windows.Forms.Button AccountHistoryButton;
        private System.Windows.Forms.Button PrintBoardingPassButton;
        private System.Windows.Forms.Button LogOutButton;
    }
}

