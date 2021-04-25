
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CancelAllFlightsButton = new System.Windows.Forms.Button();
            this.NoFlightLabel = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.CancelSelectedButton = new System.Windows.Forms.Button();
            this.CancelFlightTable = new System.Windows.Forms.DataGridView();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.CancelFlightLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CancelFlightTable)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelAllFlightsButton
            // 
            this.CancelAllFlightsButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.CancelAllFlightsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelAllFlightsButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.CancelAllFlightsButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CancelAllFlightsButton.Location = new System.Drawing.Point(1584, 895);
            this.CancelAllFlightsButton.Name = "CancelAllFlightsButton";
            this.CancelAllFlightsButton.Size = new System.Drawing.Size(276, 72);
            this.CancelAllFlightsButton.TabIndex = 49;
            this.CancelAllFlightsButton.Text = "Cancel All";
            this.CancelAllFlightsButton.UseVisualStyleBackColor = false;
            this.CancelAllFlightsButton.Click += new System.EventHandler(this.CancelAllFlightsButton_Click);
            // 
            // NoFlightLabel
            // 
            this.NoFlightLabel.AutoSize = true;
            this.NoFlightLabel.Font = new System.Drawing.Font("Rockwell", 24F);
            this.NoFlightLabel.Location = new System.Drawing.Point(473, 481);
            this.NoFlightLabel.Name = "NoFlightLabel";
            this.NoFlightLabel.Size = new System.Drawing.Size(1256, 72);
            this.NoFlightLabel.TabIndex = 48;
            this.NoFlightLabel.Text = "You Currently Have No Scheduled Flights";
            this.NoFlightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BackButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.BackButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackButton.Location = new System.Drawing.Point(58, 88);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(276, 72);
            this.BackButton.TabIndex = 47;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // CancelSelectedButton
            // 
            this.CancelSelectedButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.CancelSelectedButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.CancelSelectedButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelSelectedButton.Location = new System.Drawing.Point(1882, 895);
            this.CancelSelectedButton.Name = "CancelSelectedButton";
            this.CancelSelectedButton.Size = new System.Drawing.Size(276, 72);
            this.CancelSelectedButton.TabIndex = 46;
            this.CancelSelectedButton.Text = "Cancel Selected";
            this.CancelSelectedButton.UseVisualStyleBackColor = false;
            this.CancelSelectedButton.Click += new System.EventHandler(this.CancelSelectedButton_Click);
            // 
            // CancelFlightTable
            // 
            this.CancelFlightTable.AllowUserToAddRows = false;
            this.CancelFlightTable.AllowUserToOrderColumns = true;
            this.CancelFlightTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CancelFlightTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CancelFlightTable.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CancelFlightTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CancelFlightTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CancelFlightTable.DefaultCellStyle = dataGridViewCellStyle2;
            this.CancelFlightTable.Location = new System.Drawing.Point(58, 234);
            this.CancelFlightTable.MultiSelect = false;
            this.CancelFlightTable.Name = "CancelFlightTable";
            this.CancelFlightTable.ReadOnly = true;
            this.CancelFlightTable.RowHeadersWidth = 82;
            this.CancelFlightTable.RowTemplate.Height = 33;
            this.CancelFlightTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CancelFlightTable.Size = new System.Drawing.Size(2102, 606);
            this.CancelFlightTable.TabIndex = 45;
            this.CancelFlightTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CancelFlightTable_CellClick);
            // 
            // LogOutButton
            // 
            this.LogOutButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.LogOutButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.LogOutButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.LogOutButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogOutButton.Location = new System.Drawing.Point(1882, 88);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(276, 72);
            this.LogOutButton.TabIndex = 44;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // CancelFlightLabel
            // 
            this.CancelFlightLabel.AutoSize = true;
            this.CancelFlightLabel.Font = new System.Drawing.Font("Rockwell", 24F);
            this.CancelFlightLabel.Location = new System.Drawing.Point(822, 88);
            this.CancelFlightLabel.Name = "CancelFlightLabel";
            this.CancelFlightLabel.Size = new System.Drawing.Size(557, 72);
            this.CancelFlightLabel.TabIndex = 43;
            this.CancelFlightLabel.Text = "Scheduled Flights";
            this.CancelFlightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CancelFlightPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(2218, 1064);
            this.Controls.Add(this.CancelAllFlightsButton);
            this.Controls.Add(this.NoFlightLabel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.CancelSelectedButton);
            this.Controls.Add(this.CancelFlightTable);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.CancelFlightLabel);
            this.MaximumSize = new System.Drawing.Size(2244, 1135);
            this.Name = "CancelFlightPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air3550";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CancelFlightPage_FormClosing);
            this.Load += new System.EventHandler(this.CancelFlightPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CancelFlightTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelAllFlightsButton;
        private System.Windows.Forms.Label NoFlightLabel;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button CancelSelectedButton;
        private System.Windows.Forms.DataGridView CancelFlightTable;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Label CancelFlightLabel;
    }
}

