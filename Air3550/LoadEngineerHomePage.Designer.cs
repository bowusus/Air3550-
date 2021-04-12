
namespace Air3550
{
    partial class LoadEngineerHomePage
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
            this.flightGrid = new System.Windows.Forms.DataGridView();
            this.addFlight = new System.Windows.Forms.Button();
            this.removeFlight = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.flightGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // flightGrid
            // 
            this.flightGrid.AllowUserToAddRows = false;
            this.flightGrid.AllowUserToDeleteRows = false;
            this.flightGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.flightGrid.Location = new System.Drawing.Point(12, 12);
            this.flightGrid.Name = "flightGrid";
            this.flightGrid.ReadOnly = true;
            this.flightGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.flightGrid.Size = new System.Drawing.Size(533, 493);
            this.flightGrid.TabIndex = 0;
            // 
            // addFlight
            // 
            this.addFlight.Location = new System.Drawing.Point(551, 44);
            this.addFlight.Name = "addFlight";
            this.addFlight.Size = new System.Drawing.Size(133, 47);
            this.addFlight.TabIndex = 1;
            this.addFlight.Text = "Add Flight";
            this.addFlight.UseVisualStyleBackColor = true;
            this.addFlight.Click += new System.EventHandler(this.AddFlight_Click);
            // 
            // removeFlight
            // 
            this.removeFlight.Location = new System.Drawing.Point(551, 97);
            this.removeFlight.Name = "removeFlight";
            this.removeFlight.Size = new System.Drawing.Size(133, 47);
            this.removeFlight.TabIndex = 2;
            this.removeFlight.Text = "Remove Flight";
            this.removeFlight.UseVisualStyleBackColor = true;
            this.removeFlight.Click += new System.EventHandler(this.removeFlight_Click);
            // 
            // LoadEngineerHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(696, 517);
            this.Controls.Add(this.removeFlight);
            this.Controls.Add(this.addFlight);
            this.Controls.Add(this.flightGrid);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoadEngineerHomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air3550";
            this.Load += new System.EventHandler(this.LoadEngineerHomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flightGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView flightGrid;
        private System.Windows.Forms.Button addFlight;
        private System.Windows.Forms.Button removeFlight;
    }
}

