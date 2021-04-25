
namespace Air3550
{
    partial class LoadEngineerAddFlightPage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.destinationCodeLabel = new System.Windows.Forms.Label();
            this.originCodeLabel = new System.Windows.Forms.Label();
            this.destinationDropDown = new System.Windows.Forms.ComboBox();
            this.originDropDown = new System.Windows.Forms.ComboBox();
            this.routesGridView = new System.Windows.Forms.DataGridView();
            this.pathID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfLayoversColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.originColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.layoverOneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.layoverTwoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routeTimePicker = new System.Windows.Forms.DateTimePicker();
            this.AddFlightButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.SearchFlightsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.routesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // destinationCodeLabel
            // 
            this.destinationCodeLabel.AutoSize = true;
            this.destinationCodeLabel.Font = new System.Drawing.Font("Rockwell", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationCodeLabel.Location = new System.Drawing.Point(474, 55);
            this.destinationCodeLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.destinationCodeLabel.Name = "destinationCodeLabel";
            this.destinationCodeLabel.Size = new System.Drawing.Size(246, 49);
            this.destinationCodeLabel.TabIndex = 7;
            this.destinationCodeLabel.Text = "Destination";
            // 
            // originCodeLabel
            // 
            this.originCodeLabel.AutoSize = true;
            this.originCodeLabel.Font = new System.Drawing.Font("Rockwell", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.originCodeLabel.Location = new System.Drawing.Point(40, 55);
            this.originCodeLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.originCodeLabel.Name = "originCodeLabel";
            this.originCodeLabel.Size = new System.Drawing.Size(150, 49);
            this.originCodeLabel.TabIndex = 6;
            this.originCodeLabel.Text = "Origin";
            // 
            // destinationDropDown
            // 
            this.destinationDropDown.Font = new System.Drawing.Font("Rockwell", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationDropDown.FormattingEnabled = true;
            this.destinationDropDown.Location = new System.Drawing.Point(748, 57);
            this.destinationDropDown.Margin = new System.Windows.Forms.Padding(6);
            this.destinationDropDown.Name = "destinationDropDown";
            this.destinationDropDown.Size = new System.Drawing.Size(238, 50);
            this.destinationDropDown.TabIndex = 5;
            // 
            // originDropDown
            // 
            this.originDropDown.BackColor = System.Drawing.SystemColors.Window;
            this.originDropDown.Font = new System.Drawing.Font("Rockwell", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.originDropDown.FormattingEnabled = true;
            this.originDropDown.Location = new System.Drawing.Point(202, 57);
            this.originDropDown.Margin = new System.Windows.Forms.Padding(6);
            this.originDropDown.Name = "originDropDown";
            this.originDropDown.Size = new System.Drawing.Size(238, 50);
            this.originDropDown.TabIndex = 4;
            this.originDropDown.SelectedIndexChanged += new System.EventHandler(this.originDropDown_SelectedIndexChanged);
            // 
            // routesGridView
            // 
            this.routesGridView.AllowUserToAddRows = false;
            this.routesGridView.AllowUserToDeleteRows = false;
            this.routesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.routesGridView.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Rockwell", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.routesGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.routesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.routesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pathID,
            this.numberOfLayoversColumn,
            this.originColumn,
            this.layoverOneColumn,
            this.layoverTwoColumn,
            this.destinationColumn});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Rockwell", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.routesGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.routesGridView.Location = new System.Drawing.Point(38, 126);
            this.routesGridView.Margin = new System.Windows.Forms.Padding(6);
            this.routesGridView.MultiSelect = false;
            this.routesGridView.Name = "routesGridView";
            this.routesGridView.ReadOnly = true;
            this.routesGridView.RowHeadersWidth = 82;
            this.routesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.routesGridView.Size = new System.Drawing.Size(1289, 767);
            this.routesGridView.TabIndex = 8;
            this.routesGridView.SelectionChanged += new System.EventHandler(this.routesGridView_SelectionChanged);
            // 
            // pathID
            // 
            this.pathID.HeaderText = "Path ID";
            this.pathID.MinimumWidth = 10;
            this.pathID.Name = "pathID";
            this.pathID.ReadOnly = true;
            // 
            // numberOfLayoversColumn
            // 
            this.numberOfLayoversColumn.HeaderText = "Number Of Layovers";
            this.numberOfLayoversColumn.MinimumWidth = 10;
            this.numberOfLayoversColumn.Name = "numberOfLayoversColumn";
            this.numberOfLayoversColumn.ReadOnly = true;
            // 
            // originColumn
            // 
            this.originColumn.HeaderText = "Origin";
            this.originColumn.MinimumWidth = 10;
            this.originColumn.Name = "originColumn";
            this.originColumn.ReadOnly = true;
            // 
            // layoverOneColumn
            // 
            this.layoverOneColumn.HeaderText = "Layover 1";
            this.layoverOneColumn.MinimumWidth = 10;
            this.layoverOneColumn.Name = "layoverOneColumn";
            this.layoverOneColumn.ReadOnly = true;
            // 
            // layoverTwoColumn
            // 
            this.layoverTwoColumn.HeaderText = "Layover 2";
            this.layoverTwoColumn.MinimumWidth = 10;
            this.layoverTwoColumn.Name = "layoverTwoColumn";
            this.layoverTwoColumn.ReadOnly = true;
            // 
            // destinationColumn
            // 
            this.destinationColumn.HeaderText = "Destination";
            this.destinationColumn.MinimumWidth = 10;
            this.destinationColumn.Name = "destinationColumn";
            this.destinationColumn.ReadOnly = true;
            // 
            // routeTimePicker
            // 
            this.routeTimePicker.Font = new System.Drawing.Font("Rockwell", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.routeTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.routeTimePicker.Location = new System.Drawing.Point(1352, 339);
            this.routeTimePicker.Margin = new System.Windows.Forms.Padding(6);
            this.routeTimePicker.Name = "routeTimePicker";
            this.routeTimePicker.Size = new System.Drawing.Size(299, 58);
            this.routeTimePicker.TabIndex = 9;
            this.routeTimePicker.ValueChanged += new System.EventHandler(this.routeTimePicker_ValueChanged);
            // 
            // AddFlightButton
            // 
            this.AddFlightButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.AddFlightButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.AddFlightButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.AddFlightButton.Location = new System.Drawing.Point(1352, 426);
            this.AddFlightButton.Name = "AddFlightButton";
            this.AddFlightButton.Size = new System.Drawing.Size(299, 72);
            this.AddFlightButton.TabIndex = 35;
            this.AddFlightButton.Text = "Add Flight";
            this.AddFlightButton.UseVisualStyleBackColor = false;
            this.AddFlightButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.BackButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.BackButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackButton.Location = new System.Drawing.Point(1352, 45);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(299, 72);
            this.BackButton.TabIndex = 36;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // SearchFlightsButton
            // 
            this.SearchFlightsButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.SearchFlightsButton.Font = new System.Drawing.Font("Rockwell", 10F);
            this.SearchFlightsButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SearchFlightsButton.Location = new System.Drawing.Point(1028, 45);
            this.SearchFlightsButton.Name = "SearchFlightsButton";
            this.SearchFlightsButton.Size = new System.Drawing.Size(299, 72);
            this.SearchFlightsButton.TabIndex = 37;
            this.SearchFlightsButton.Text = "Search";
            this.SearchFlightsButton.UseVisualStyleBackColor = false;
            this.SearchFlightsButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // LoadEngineerAddFlightPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1688, 938);
            this.Controls.Add(this.SearchFlightsButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.AddFlightButton);
            this.Controls.Add(this.routeTimePicker);
            this.Controls.Add(this.routesGridView);
            this.Controls.Add(this.destinationCodeLabel);
            this.Controls.Add(this.originCodeLabel);
            this.Controls.Add(this.destinationDropDown);
            this.Controls.Add(this.originDropDown);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximumSize = new System.Drawing.Size(1714, 1009);
            this.Name = "LoadEngineerAddFlightPage";
            this.Text = "LoadEngineerAddFlightPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoadEngineerAddFlightPage_FormClosing);
            this.Load += new System.EventHandler(this.LoadEngineerAddFlightPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.routesGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label destinationCodeLabel;
        private System.Windows.Forms.Label originCodeLabel;
        private System.Windows.Forms.ComboBox destinationDropDown;
        private System.Windows.Forms.ComboBox originDropDown;
        private System.Windows.Forms.DataGridView routesGridView;
        private System.Windows.Forms.DateTimePicker routeTimePicker;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathID;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfLayoversColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn originColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn layoverOneColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn layoverTwoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinationColumn;
        private System.Windows.Forms.Button AddFlightButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button SearchFlightsButton;
    }
}