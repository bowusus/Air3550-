
namespace Air3550
{
    partial class LoadEngineerTimeSelectPage
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
            this.routeTimePicker = new System.Windows.Forms.DateTimePicker();
            this.addButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // routeTimePicker
            // 
            this.routeTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.routeTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.routeTimePicker.Location = new System.Drawing.Point(279, 210);
            this.routeTimePicker.Name = "routeTimePicker";
            this.routeTimePicker.Size = new System.Drawing.Size(138, 31);
            this.routeTimePicker.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(279, 263);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(138, 49);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add Flight";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // LoadEngineerTimeSelectPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 517);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.routeTimePicker);
            this.Name = "LoadEngineerTimeSelectPage";
            this.Text = "LoadEngineerTimeSelectPage";
            this.Load += new System.EventHandler(this.LoadEngineerTimeSelectPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker routeTimePicker;
        private System.Windows.Forms.Button addButton;
    }
}