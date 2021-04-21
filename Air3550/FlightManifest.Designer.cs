
namespace Air3550
{
    partial class FlightManifest
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FlightManifestLabel = new System.Windows.Forms.Label();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.FlightManifestTable = new System.Windows.Forms.DataGridView();
            this.PrintButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FlightManifestTable)).BeginInit();
            this.SuspendLayout();
            // 
            // FlightManifestLabel
            // 
            this.FlightManifestLabel.AutoSize = true;
            this.FlightManifestLabel.Font = new System.Drawing.Font("Rockwell", 24F);
            this.FlightManifestLabel.Location = new System.Drawing.Point(666, 98);
            this.FlightManifestLabel.Name = "FlightManifestLabel";
            this.FlightManifestLabel.Size = new System.Drawing.Size(891, 72);
            this.FlightManifestLabel.TabIndex = 64;
            this.FlightManifestLabel.Text = "Flight Manifest for Flight ID #";
            this.FlightManifestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // FlightManifestTable
            // 
            this.FlightManifestTable.AllowUserToAddRows = false;
            this.FlightManifestTable.AllowUserToOrderColumns = true;
            this.FlightManifestTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FlightManifestTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FlightManifestTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.FlightManifestTable.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FlightManifestTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.FlightManifestTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FlightManifestTable.DefaultCellStyle = dataGridViewCellStyle4;
            this.FlightManifestTable.Enabled = false;
            this.FlightManifestTable.Location = new System.Drawing.Point(67, 382);
            this.FlightManifestTable.MultiSelect = false;
            this.FlightManifestTable.Name = "FlightManifestTable";
            this.FlightManifestTable.ReadOnly = true;
            this.FlightManifestTable.RowHeadersVisible = false;
            this.FlightManifestTable.RowHeadersWidth = 82;
            this.FlightManifestTable.RowTemplate.Height = 33;
            this.FlightManifestTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FlightManifestTable.Size = new System.Drawing.Size(2101, 630);
            this.FlightManifestTable.TabIndex = 74;
            // 
            // PrintButton
            // 
            this.PrintButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.PrintButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.PrintButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PrintButton.Location = new System.Drawing.Point(1981, 266);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(187, 84);
            this.PrintButton.TabIndex = 73;
            this.PrintButton.Text = "Print";
            this.PrintButton.UseVisualStyleBackColor = false;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BackButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.BackButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackButton.Location = new System.Drawing.Point(67, 98);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(276, 72);
            this.BackButton.TabIndex = 80;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // FlightManifest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(2222, 1078);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.FlightManifestTable);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.FlightManifestLabel);
            this.Controls.Add(this.LogOutButton);
            this.MaximumSize = new System.Drawing.Size(2248, 1149);
            this.Name = "FlightManifest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air3550";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FlightManifest_FormClosing);
            this.Load += new System.EventHandler(this.FlightManifest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FlightManifestTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label FlightManifestLabel;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.DataGridView FlightManifestTable;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Button BackButton;
    }
}

