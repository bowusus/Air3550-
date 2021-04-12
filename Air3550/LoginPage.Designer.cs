
namespace Air3550
{
    partial class LogInPage
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
            this.UserIDButton = new System.Windows.Forms.Button();
            this.PasswordButton = new System.Windows.Forms.Button();
            this.PasswordText = new System.Windows.Forms.TextBox();
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.LogInLabel = new System.Windows.Forms.Label();
            this.LogInButton = new System.Windows.Forms.Button();
            this.CreateCustomerAccountButton = new System.Windows.Forms.Button();
            this.UserIDText = new System.Windows.Forms.MaskedTextBox();
            this.UserIDError = new System.Windows.Forms.Label();
            this.PasswordError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UserIDButton
            // 
            this.UserIDButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserIDButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.UserIDButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserIDButton.Font = new System.Drawing.Font("Rockwell", 18F);
            this.UserIDButton.Location = new System.Drawing.Point(272, 373);
            this.UserIDButton.Name = "UserIDButton";
            this.UserIDButton.Size = new System.Drawing.Size(289, 72);
            this.UserIDButton.TabIndex = 4;
            this.UserIDButton.Text = "UserID";
            this.UserIDButton.UseVisualStyleBackColor = false;
            // 
            // PasswordButton
            // 
            this.PasswordButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PasswordButton.Font = new System.Drawing.Font("Rockwell", 18F);
            this.PasswordButton.Location = new System.Drawing.Point(272, 518);
            this.PasswordButton.Name = "PasswordButton";
            this.PasswordButton.Size = new System.Drawing.Size(289, 72);
            this.PasswordButton.TabIndex = 5;
            this.PasswordButton.Text = "Password";
            this.PasswordButton.UseVisualStyleBackColor = false;
            // 
            // PasswordText
            // 
            this.PasswordText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordText.Font = new System.Drawing.Font("Rockwell", 18F);
            this.PasswordText.Location = new System.Drawing.Point(585, 524);
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.PasswordChar = '*';
            this.PasswordText.Size = new System.Drawing.Size(289, 64);
            this.PasswordText.TabIndex = 1;
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Font = new System.Drawing.Font("Rockwell", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeLabel.Location = new System.Drawing.Point(89, 120);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(994, 106);
            this.WelcomeLabel.TabIndex = 6;
            this.WelcomeLabel.Text = "Welcome to Air3550! ";
            this.WelcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogInLabel
            // 
            this.LogInLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogInLabel.AutoSize = true;
            this.LogInLabel.Font = new System.Drawing.Font("Rockwell", 24F);
            this.LogInLabel.Location = new System.Drawing.Point(271, 255);
            this.LogInLabel.Name = "LogInLabel";
            this.LogInLabel.Size = new System.Drawing.Size(617, 72);
            this.LogInLabel.TabIndex = 7;
            this.LogInLabel.Text = "Please Log In Below";
            this.LogInLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogInButton
            // 
            this.LogInButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogInButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.LogInButton.Font = new System.Drawing.Font("Rockwell", 18F);
            this.LogInButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogInButton.Location = new System.Drawing.Point(442, 665);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(253, 72);
            this.LogInButton.TabIndex = 2;
            this.LogInButton.Text = "Log In";
            this.LogInButton.UseVisualStyleBackColor = false;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // CreateCustomerAccountButton
            // 
            this.CreateCustomerAccountButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreateCustomerAccountButton.BackColor = System.Drawing.Color.Transparent;
            this.CreateCustomerAccountButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CreateCustomerAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateCustomerAccountButton.Font = new System.Drawing.Font("Rockwell", 8F);
            this.CreateCustomerAccountButton.Location = new System.Drawing.Point(321, 776);
            this.CreateCustomerAccountButton.Name = "CreateCustomerAccountButton";
            this.CreateCustomerAccountButton.Size = new System.Drawing.Size(496, 43);
            this.CreateCustomerAccountButton.TabIndex = 3;
            this.CreateCustomerAccountButton.Text = "Don\'t have an Account? Create One Here";
            this.CreateCustomerAccountButton.UseVisualStyleBackColor = false;
            this.CreateCustomerAccountButton.Click += new System.EventHandler(this.CreateCustomerAccountButton_Click);
            // 
            // UserIDText
            // 
            this.UserIDText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserIDText.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserIDText.Location = new System.Drawing.Point(587, 379);
            this.UserIDText.Mask = "000000";
            this.UserIDText.Name = "UserIDText";
            this.UserIDText.Size = new System.Drawing.Size(287, 64);
            this.UserIDText.TabIndex = 0;
            this.UserIDText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserIDText_MouseClick);
            this.UserIDText.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.UserIDText_MouseDoubleClick);
            // 
            // UserIDError
            // 
            this.UserIDError.AutoSize = true;
            this.UserIDError.ForeColor = System.Drawing.Color.Red;
            this.UserIDError.Location = new System.Drawing.Point(592, 351);
            this.UserIDError.Name = "UserIDError";
            this.UserIDError.Size = new System.Drawing.Size(145, 25);
            this.UserIDError.TabIndex = 44;
            this.UserIDError.Text = "UserID Invalid";
            this.UserIDError.Visible = false;
            // 
            // PasswordError
            // 
            this.PasswordError.AutoSize = true;
            this.PasswordError.ForeColor = System.Drawing.Color.Red;
            this.PasswordError.Location = new System.Drawing.Point(592, 496);
            this.PasswordError.Name = "PasswordError";
            this.PasswordError.Size = new System.Drawing.Size(174, 25);
            this.PasswordError.TabIndex = 45;
            this.PasswordError.Text = "Password Invalid";
            this.PasswordError.Visible = false;
            // 
            // LogInPage
            // 
            this.AcceptButton = this.LogInButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1173, 938);
            this.Controls.Add(this.PasswordError);
            this.Controls.Add(this.UserIDError);
            this.Controls.Add(this.UserIDText);
            this.Controls.Add(this.CreateCustomerAccountButton);
            this.Controls.Add(this.LogInButton);
            this.Controls.Add(this.LogInLabel);
            this.Controls.Add(this.WelcomeLabel);
            this.Controls.Add(this.PasswordText);
            this.Controls.Add(this.PasswordButton);
            this.Controls.Add(this.UserIDButton);
            this.MaximumSize = new System.Drawing.Size(1199, 1009);
            this.Name = "LogInPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air3550";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button UserIDButton;
        private System.Windows.Forms.Button PasswordButton;
        private System.Windows.Forms.TextBox PasswordText;
        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.Label LogInLabel;
        private System.Windows.Forms.Button LogInButton;
        private System.Windows.Forms.Button CreateCustomerAccountButton;
        private System.Windows.Forms.MaskedTextBox UserIDText;
        private System.Windows.Forms.Label UserIDError;
        private System.Windows.Forms.Label PasswordError;
    }
}

