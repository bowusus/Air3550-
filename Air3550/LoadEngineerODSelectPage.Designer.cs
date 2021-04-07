
namespace Air3550
{
    partial class LoadEngineerODSelectPage
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
            this.originDropDown = new System.Windows.Forms.ComboBox();
            this.destinationDropDown = new System.Windows.Forms.ComboBox();
            this.originCodeLabel = new System.Windows.Forms.Label();
            this.destinationCodeLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // originDropDown
            // 
            this.originDropDown.BackColor = System.Drawing.SystemColors.Window;
            this.originDropDown.FormattingEnabled = true;
            this.originDropDown.Location = new System.Drawing.Point(176, 221);
            this.originDropDown.Name = "originDropDown";
            this.originDropDown.Size = new System.Drawing.Size(121, 21);
            this.originDropDown.TabIndex = 0;
            // 
            // destinationDropDown
            // 
            this.destinationDropDown.FormattingEnabled = true;
            this.destinationDropDown.Location = new System.Drawing.Point(370, 221);
            this.destinationDropDown.Name = "destinationDropDown";
            this.destinationDropDown.Size = new System.Drawing.Size(121, 21);
            this.destinationDropDown.TabIndex = 1;
            // 
            // originCodeLabel
            // 
            this.originCodeLabel.AutoSize = true;
            this.originCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.originCodeLabel.Location = new System.Drawing.Point(201, 193);
            this.originCodeLabel.Name = "originCodeLabel";
            this.originCodeLabel.Size = new System.Drawing.Size(69, 25);
            this.originCodeLabel.TabIndex = 2;
            this.originCodeLabel.Text = "Origin";
            // 
            // destinationCodeLabel
            // 
            this.destinationCodeLabel.AutoSize = true;
            this.destinationCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationCodeLabel.Location = new System.Drawing.Point(371, 193);
            this.destinationCodeLabel.Name = "destinationCodeLabel";
            this.destinationCodeLabel.Size = new System.Drawing.Size(120, 25);
            this.destinationCodeLabel.TabIndex = 3;
            this.destinationCodeLabel.Text = "Destination";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(285, 275);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(93, 40);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // LoadEngineerODSelectPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 517);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.destinationCodeLabel);
            this.Controls.Add(this.originCodeLabel);
            this.Controls.Add(this.destinationDropDown);
            this.Controls.Add(this.originDropDown);
            this.Name = "LoadEngineerODSelectPage";
            this.Text = "LoadEngineerODSelectPage";
            this.Load += new System.EventHandler(this.LoadEngineerODSelectPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox originDropDown;
        private System.Windows.Forms.ComboBox destinationDropDown;
        private System.Windows.Forms.Label originCodeLabel;
        private System.Windows.Forms.Label destinationCodeLabel;
        private System.Windows.Forms.Button submitButton;
    }
}