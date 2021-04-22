
namespace Air3550
{
    partial class PrintBoardingPassPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintBoardingPassPage));
            this.BackButton = new System.Windows.Forms.Button();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.UserIDText = new System.Windows.Forms.TextBox();
            this.FirstNameText = new System.Windows.Forms.TextBox();
            this.LastNameText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LastName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Destination = new System.Windows.Forms.Label();
            this.OriginText = new System.Windows.Forms.TextBox();
            this.DepartureTime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DepText = new System.Windows.Forms.TextBox();
            this.ArrivalText = new System.Windows.Forms.TextBox();
            this.FlightIDText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DesText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BackButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.BackButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackButton.Location = new System.Drawing.Point(8, 22);
            this.BackButton.Margin = new System.Windows.Forms.Padding(2);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(131, 46);
            this.BackButton.TabIndex = 47;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // LogOutButton
            // 
            this.LogOutButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.LogOutButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.LogOutButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogOutButton.Location = new System.Drawing.Point(639, 22);
            this.LogOutButton.Margin = new System.Windows.Forms.Padding(2);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(131, 46);
            this.LogOutButton.TabIndex = 46;
            this.LogOutButton.Text = "Log Out";
            this.LogOutButton.UseVisualStyleBackColor = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.Location = new System.Drawing.Point(1500, 550);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(114, 39);
            this.PrintButton.TabIndex = 49;
            this.PrintButton.Text = "Print";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 25);
            this.label1.TabIndex = 50;
            this.label1.Text = "UserID";
            // 
            // UserIDText
            // 
            this.UserIDText.Location = new System.Drawing.Point(133, 40);
            this.UserIDText.Name = "UserIDText";
            this.UserIDText.ReadOnly = true;
            this.UserIDText.Size = new System.Drawing.Size(222, 30);
            this.UserIDText.TabIndex = 51;
            // 
            // FirstNameText
            // 
            this.FirstNameText.Location = new System.Drawing.Point(133, 112);
            this.FirstNameText.Name = "FirstNameText";
            this.FirstNameText.ReadOnly = true;
            this.FirstNameText.Size = new System.Drawing.Size(222, 30);
            this.FirstNameText.TabIndex = 52;
            // 
            // LastNameText
            // 
            this.LastNameText.Location = new System.Drawing.Point(133, 179);
            this.LastNameText.Name = "LastNameText";
            this.LastNameText.ReadOnly = true;
            this.LastNameText.Size = new System.Drawing.Size(222, 30);
            this.LastNameText.TabIndex = 53;
            this.LastNameText.TextChanged += new System.EventHandler(this.PrintBoardingPassPage_Load);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 25);
            this.label2.TabIndex = 54;
            this.label2.Text = "FirstName";
            // 
            // LastName
            // 
            this.LastName.AutoSize = true;
            this.LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastName.Location = new System.Drawing.Point(12, 184);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(101, 25);
            this.LastName.TabIndex = 55;
            this.LastName.Text = "LastName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(417, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 25);
            this.label4.TabIndex = 56;
            this.label4.Text = "Origin";
            // 
            // Destination
            // 
            this.Destination.AutoSize = true;
            this.Destination.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Destination.Location = new System.Drawing.Point(417, 102);
            this.Destination.Name = "Destination";
            this.Destination.Size = new System.Drawing.Size(109, 25);
            this.Destination.TabIndex = 57;
            this.Destination.Text = "Destination";
            // 
            // OriginText
            // 
            this.OriginText.Location = new System.Drawing.Point(593, 45);
            this.OriginText.Name = "OriginText";
            this.OriginText.ReadOnly = true;
            this.OriginText.Size = new System.Drawing.Size(222, 30);
            this.OriginText.TabIndex = 58;
            // 
            // DepartureTime
            // 
            this.DepartureTime.AutoSize = true;
            this.DepartureTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartureTime.Location = new System.Drawing.Point(379, 184);
            this.DepartureTime.Name = "DepartureTime";
            this.DepartureTime.Size = new System.Drawing.Size(194, 25);
            this.DepartureTime.TabIndex = 62;
            this.DepartureTime.Text = "Departure Date/Time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(379, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 25);
            this.label7.TabIndex = 63;
            this.label7.Text = "Arrival Date/Time";
            // 
            // DepText
            // 
            this.DepText.Location = new System.Drawing.Point(593, 179);
            this.DepText.Name = "DepText";
            this.DepText.ReadOnly = true;
            this.DepText.Size = new System.Drawing.Size(222, 30);
            this.DepText.TabIndex = 60;
            // 
            // ArrivalText
            // 
            this.ArrivalText.Location = new System.Drawing.Point(593, 246);
            this.ArrivalText.Name = "ArrivalText";
            this.ArrivalText.ReadOnly = true;
            this.ArrivalText.Size = new System.Drawing.Size(222, 30);
            this.ArrivalText.TabIndex = 64;
            // 
            // FlightIDText
            // 
            this.FlightIDText.Location = new System.Drawing.Point(133, 247);
            this.FlightIDText.Name = "FlightIDText";
            this.FlightIDText.ReadOnly = true;
            this.FlightIDText.Size = new System.Drawing.Size(222, 30);
            this.FlightIDText.TabIndex = 65;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 25);
            this.label3.TabIndex = 66;
            this.label3.Text = "FlightID";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(904, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(710, 452);
            this.dataGridView1.TabIndex = 67;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // DesText
            // 
            this.DesText.Location = new System.Drawing.Point(593, 102);
            this.DesText.Name = "DesText";
            this.DesText.ReadOnly = true;
            this.DesText.Size = new System.Drawing.Size(222, 30);
            this.DesText.TabIndex = 68;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DesText);
            this.groupBox1.Controls.Add(this.DepText);
            this.groupBox1.Controls.Add(this.DepartureTime);
            this.groupBox1.Controls.Add(this.ArrivalText);
            this.groupBox1.Controls.Add(this.UserIDText);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.FlightIDText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.FirstNameText);
            this.groupBox1.Controls.Add(this.LastName);
            this.groupBox1.Controls.Add(this.Destination);
            this.groupBox1.Controls.Add(this.OriginText);
            this.groupBox1.Controls.Add(this.LastNameText);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(60, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(821, 452);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Boarding Pass";
            // 
            // PrintBoardingPassPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1638, 601);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.LogOutButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PrintBoardingPassPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Air3550";
            this.Load += new System.EventHandler(this.PrintBoardingPassPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button LogOutButton;
        private System.Windows.Forms.Button PrintButton;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserIDText;
        private System.Windows.Forms.TextBox FirstNameText;
        private System.Windows.Forms.TextBox LastNameText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LastName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Destination;
        private System.Windows.Forms.TextBox OriginText;
        private System.Windows.Forms.Label DepartureTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox DepText;
        private System.Windows.Forms.TextBox ArrivalText;
        private System.Windows.Forms.TextBox FlightIDText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox DesText;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

