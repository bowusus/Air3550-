
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
            this.BackButton = new System.Windows.Forms.Button();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.CancelFlightTable = new System.Windows.Forms.DataGridView();
            this.RoundTripButton = new System.Windows.Forms.RadioButton();
            this.OneWayButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.CancelFlightTable)).BeginInit();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BackButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.BackButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackButton.Location = new System.Drawing.Point(12, 34);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(196, 72);
            this.BackButton.TabIndex = 45;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // LogOutButton
            // 
            this.LogOutButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.LogOutButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.LogOutButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogOutButton.Location = new System.Drawing.Point(959, 34);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(196, 72);
            this.LogOutButton.TabIndex = 44;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // CancelFlightTable
            // 
            this.CancelFlightTable.AllowUserToAddRows = false;
            this.CancelFlightTable.AllowUserToOrderColumns = true;
            this.CancelFlightTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CancelFlightTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CancelFlightTable.BackgroundColor = System.Drawing.SystemColors.Window;
            this.CancelFlightTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CancelFlightTable.Location = new System.Drawing.Point(12, 240);
            this.CancelFlightTable.Name = "CancelFlightTable";
            this.CancelFlightTable.RowHeadersVisible = false;
            this.CancelFlightTable.RowHeadersWidth = 82;
            this.CancelFlightTable.RowTemplate.Height = 33;
            this.CancelFlightTable.Size = new System.Drawing.Size(948, 673);
            this.CancelFlightTable.TabIndex = 46;
            // 
            // RoundTripButton
            // 
            this.RoundTripButton.AutoSize = true;
            this.RoundTripButton.Location = new System.Drawing.Point(12, 132);
            this.RoundTripButton.Name = "RoundTripButton";
            this.RoundTripButton.Size = new System.Drawing.Size(149, 29);
            this.RoundTripButton.TabIndex = 47;
            this.RoundTripButton.TabStop = true;
            this.RoundTripButton.Text = "Round Trip";
            this.RoundTripButton.UseVisualStyleBackColor = true;
            // 
            // OneWayButton
            // 
            this.OneWayButton.AutoSize = true;
            this.OneWayButton.Location = new System.Drawing.Point(12, 181);
            this.OneWayButton.Name = "OneWayButton";
            this.OneWayButton.Size = new System.Drawing.Size(175, 29);
            this.OneWayButton.TabIndex = 48;
            this.OneWayButton.TabStop = true;
            this.OneWayButton.Text = "One Way Trip";
            this.OneWayButton.UseVisualStyleBackColor = true;
            // 
            // BookFlightPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1173, 938);
            this.Controls.Add(this.OneWayButton);
            this.Controls.Add(this.RoundTripButton);
            this.Controls.Add(this.CancelFlightTable);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.LogOutButton);
            this.Name = "BookFlightPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air3550";
            ((System.ComponentModel.ISupportInitialize)(this.CancelFlightTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.DataGridView CancelFlightTable;
        private System.Windows.Forms.RadioButton RoundTripButton;
        private System.Windows.Forms.RadioButton OneWayButton;
    }
}

