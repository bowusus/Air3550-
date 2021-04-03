
namespace Air3550
{
    partial class AccountingManagerHomePage
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
            this.CreateButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.ToDateLabel = new System.Windows.Forms.Label();
            this.FromDateLabel = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // CreateButton
            // 
            this.CreateButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreateButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.CreateButton.Font = new System.Drawing.Font("Rockwell", 14F);
            this.CreateButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CreateButton.Location = new System.Drawing.Point(912, 37);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(185, 51);
            this.CreateButton.TabIndex = 11;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = false;
            // 
            // PrintButton
            // 
            this.PrintButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PrintButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.PrintButton.Font = new System.Drawing.Font("Rockwell", 14F);
            this.PrintButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PrintButton.Location = new System.Drawing.Point(912, 122);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(185, 51);
            this.PrintButton.TabIndex = 12;
            this.PrintButton.Text = "Print";
            this.PrintButton.UseVisualStyleBackColor = false;
            // 
            // ToDateLabel
            // 
            this.ToDateLabel.AutoSize = true;
            this.ToDateLabel.Font = new System.Drawing.Font("Rockwell", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToDateLabel.Location = new System.Drawing.Point(122, 131);
            this.ToDateLabel.Name = "ToDateLabel";
            this.ToDateLabel.Size = new System.Drawing.Size(71, 42);
            this.ToDateLabel.TabIndex = 3;
            this.ToDateLabel.Text = "To:";
            // 
            // FromDateLabel
            // 
            this.FromDateLabel.AutoSize = true;
            this.FromDateLabel.Font = new System.Drawing.Font("Rockwell", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromDateLabel.Location = new System.Drawing.Point(76, 46);
            this.FromDateLabel.Name = "FromDateLabel";
            this.FromDateLabel.Size = new System.Drawing.Size(117, 42);
            this.FromDateLabel.TabIndex = 2;
            this.FromDateLabel.Text = "From:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Rockwell", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Font = new System.Drawing.Font("Rockwell", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Location = new System.Drawing.Point(199, 122);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(639, 51);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Rockwell", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Rockwell", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(199, 37);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(639, 51);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // AccountingManagerHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1173, 938);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.ToDateLabel);
            this.Controls.Add(this.FromDateLabel);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "AccountingManagerHomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air3550";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Label ToDateLabel;
        private System.Windows.Forms.Label FromDateLabel;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}

