
namespace Air3550
{
    partial class LoadEngineerEditFlightPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadEngineerEditFlightPage));
            this.routeTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFlight = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // routeTimePicker
            // 
            this.routeTimePicker.Font = new System.Drawing.Font("Rockwell", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.routeTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.routeTimePicker.Location = new System.Drawing.Point(146, 226);
            this.routeTimePicker.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.routeTimePicker.Name = "routeTimePicker";
            this.routeTimePicker.Size = new System.Drawing.Size(295, 58);
            this.routeTimePicker.TabIndex = 17;
            this.routeTimePicker.ValueChanged += new System.EventHandler(this.routeTimePicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(481, 161);
            this.label1.TabIndex = 19;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // saveFlight
            // 
            this.saveFlight.BackColor = System.Drawing.SystemColors.HotTrack;
            this.saveFlight.Font = new System.Drawing.Font("Rockwell", 10F);
            this.saveFlight.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.saveFlight.Location = new System.Drawing.Point(142, 293);
            this.saveFlight.Name = "saveFlight";
            this.saveFlight.Size = new System.Drawing.Size(299, 72);
            this.saveFlight.TabIndex = 38;
            this.saveFlight.Text = "Save Changes";
            this.saveFlight.UseVisualStyleBackColor = false;
            // 
            // LoadEngineerEditFlightPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(586, 454);
            this.Controls.Add(this.saveFlight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.routeTimePicker);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadEngineerEditFlightPage";
            this.Text = "LoadEngineerEditFlightPage";
            this.Load += new System.EventHandler(this.LoadEngineerEditFlightPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker routeTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveFlight;
    }
}