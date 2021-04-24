
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.FlightManifestLabel.Location = new System.Drawing.Point(444, 63);
            this.FlightManifestLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FlightManifestLabel.Name = "FlightManifestLabel";
            this.FlightManifestLabel.Size = new System.Drawing.Size(559, 46);
            this.FlightManifestLabel.TabIndex = 64;
            this.FlightManifestLabel.Text = "Flight Manifest for Flight ID #";
            this.FlightManifestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogOutButton
            // 
            this.LogOutButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.LogOutButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.LogOutButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogOutButton.Location = new System.Drawing.Point(1261, 63);
            this.LogOutButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(184, 46);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FlightManifestTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.FlightManifestTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FlightManifestTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.FlightManifestTable.Enabled = false;
            this.FlightManifestTable.Location = new System.Drawing.Point(127, 244);
            this.FlightManifestTable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FlightManifestTable.MultiSelect = false;
            this.FlightManifestTable.Name = "FlightManifestTable";
            this.FlightManifestTable.ReadOnly = true;
            this.FlightManifestTable.RowHeadersVisible = false;
            this.FlightManifestTable.RowHeadersWidth = 82;
            this.FlightManifestTable.RowTemplate.Height = 33;
            this.FlightManifestTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FlightManifestTable.Size = new System.Drawing.Size(1401, 403);
            this.FlightManifestTable.TabIndex = 74;
            // 
            // PrintButton
            // 
            this.PrintButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.PrintButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.PrintButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PrintButton.Location = new System.Drawing.Point(1321, 170);
            this.PrintButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(125, 54);
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
            this.BackButton.Location = new System.Drawing.Point(45, 63);
            this.BackButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(184, 46);
            this.BackButton.TabIndex = 80;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // FlightManifest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1447, 675);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.FlightManifestTable);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.FlightManifestLabel);
            this.Controls.Add(this.LogOutButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(1505, 752);
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

