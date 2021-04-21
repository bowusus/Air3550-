
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
            this.saveButton = new System.Windows.Forms.Button();
            this.planeTypeDropDown = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 60);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(121, 49);
            this.saveButton.TabIndex = 20;
            this.saveButton.Text = "Save Changes";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // planeTypeDropDown
            // 
            this.planeTypeDropDown.FormattingEnabled = true;
            this.planeTypeDropDown.Location = new System.Drawing.Point(12, 33);
            this.planeTypeDropDown.Name = "planeTypeDropDown";
            this.planeTypeDropDown.Size = new System.Drawing.Size(121, 21);
            this.planeTypeDropDown.TabIndex = 21;
            // 
            // MarketingManagerEditPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(154, 136);
            this.Controls.Add(this.planeTypeDropDown);
            this.Controls.Add(this.saveButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MarketingManagerEditPage";
            this.Text = "MarketingManagerEditPage";
            this.Load += new System.EventHandler(this.MarketingManagerEditPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ComboBox planeTypeDropDown;
    }
}