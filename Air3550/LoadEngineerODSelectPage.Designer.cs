
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
            this.SuspendLayout();
            // 
            // originDropDown
            // 
            this.originDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.originDropDown.FormattingEnabled = true;
            this.originDropDown.Location = new System.Drawing.Point(195, 205);
            this.originDropDown.Name = "originDropDown";
            this.originDropDown.Size = new System.Drawing.Size(121, 21);
            this.originDropDown.TabIndex = 0;
            // 
            // destinationDropDown
            // 
            this.destinationDropDown.FormattingEnabled = true;
            this.destinationDropDown.Location = new System.Drawing.Point(432, 205);
            this.destinationDropDown.Name = "destinationDropDown";
            this.destinationDropDown.Size = new System.Drawing.Size(121, 21);
            this.destinationDropDown.TabIndex = 1;
            // 
            // LoadEngineerODSelectPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.destinationDropDown);
            this.Controls.Add(this.originDropDown);
            this.Name = "LoadEngineerODSelectPage";
            this.Text = "LoadEngineerODSelectPage";
            this.Load += new System.EventHandler(this.LoadEngineerODSelectPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox originDropDown;
        private System.Windows.Forms.ComboBox destinationDropDown;
    }
}