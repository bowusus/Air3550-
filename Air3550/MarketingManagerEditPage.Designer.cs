
namespace Air3550
{
    partial class MarketingManagerEditPage
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
            this.planeTypeDropDown = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // planeTypeDropDown
            // 
            this.planeTypeDropDown.Font = new System.Drawing.Font("Rockwell", 10F);
            this.planeTypeDropDown.FormattingEnabled = true;
            this.planeTypeDropDown.Location = new System.Drawing.Point(27, 60);
            this.planeTypeDropDown.Margin = new System.Windows.Forms.Padding(6);
            this.planeTypeDropDown.Name = "planeTypeDropDown";
            this.planeTypeDropDown.Size = new System.Drawing.Size(410, 39);
            this.planeTypeDropDown.TabIndex = 21;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.saveButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.saveButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.saveButton.Location = new System.Drawing.Point(75, 130);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(299, 72);
            this.saveButton.TabIndex = 39;
            this.saveButton.Text = "Save Changes";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // MarketingManagerEditPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(464, 262);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.planeTypeDropDown);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MarketingManagerEditPage";
            this.Text = "MarketingManagerEditPage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MarketingManagerEditPage_FormClosing);
            this.Load += new System.EventHandler(this.MarketingManagerEditPage_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox planeTypeDropDown;
        private System.Windows.Forms.Button saveButton;
    }
}