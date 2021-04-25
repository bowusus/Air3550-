
namespace Air3550
{
    partial class MarketingManagerHomePage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flightGrid = new System.Windows.Forms.DataGridView();
            this.logOutButton = new System.Windows.Forms.Button();
            this.editFlightButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.flightGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // flightGrid
            // 
            this.flightGrid.AllowUserToAddRows = false;
            this.flightGrid.AllowUserToDeleteRows = false;
            this.flightGrid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flightGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.flightGrid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Rockwell", 8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.flightGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.flightGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Rockwell", 8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.flightGrid.DefaultCellStyle = dataGridViewCellStyle8;
            this.flightGrid.Location = new System.Drawing.Point(38, 23);
            this.flightGrid.Margin = new System.Windows.Forms.Padding(6);
            this.flightGrid.Name = "flightGrid";
            this.flightGrid.ReadOnly = true;
            this.flightGrid.RowHeadersWidth = 82;
            this.flightGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.flightGrid.Size = new System.Drawing.Size(1525, 892);
            this.flightGrid.TabIndex = 6;
            // 
            // logOutButton
            // 
            this.logOutButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.logOutButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.logOutButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.logOutButton.Location = new System.Drawing.Point(1620, 23);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(299, 72);
            this.logOutButton.TabIndex = 42;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = false;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // editFlightButton
            // 
            this.editFlightButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.editFlightButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.editFlightButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.editFlightButton.Location = new System.Drawing.Point(1620, 433);
            this.editFlightButton.Name = "editFlightButton";
            this.editFlightButton.Size = new System.Drawing.Size(299, 72);
            this.editFlightButton.TabIndex = 43;
            this.editFlightButton.Text = "Edit Flight";
            this.editFlightButton.UseVisualStyleBackColor = false;
            this.editFlightButton.Click += new System.EventHandler(this.editFlight_Click);
            // 
            // MarketingManagerHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1956, 938);
            this.Controls.Add(this.editFlightButton);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.flightGrid);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1982, 1009);
            this.Name = "MarketingManagerHomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air3550";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MarketingManagerHomePage_FormClosing);
            this.Load += new System.EventHandler(this.MarketingManagerHomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flightGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView flightGrid;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Button editFlightButton;
    }
}

