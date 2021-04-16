
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
            this.searchButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.routeTimePicker = new System.Windows.Forms.DateTimePicker();
            this.routesGridView = new System.Windows.Forms.DataGridView();
            this.pathID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfLayoversColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.originColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.layoverOneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.layoverTwoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinationCodeLabel = new System.Windows.Forms.Label();
            this.originCodeLabel = new System.Windows.Forms.Label();
            this.destinationDropDown = new System.Windows.Forms.ComboBox();
            this.originDropDown = new System.Windows.Forms.ComboBox();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.routesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(511, 11);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(139, 25);
            this.searchButton.TabIndex = 19;
            this.searchButton.Text = "Find Routes";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(660, 192);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(111, 49);
            this.saveButton.TabIndex = 18;
            this.saveButton.Text = "Save Changes";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // routeTimePicker
            // 
            this.routeTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.routeTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.routeTimePicker.Location = new System.Drawing.Point(660, 155);
            this.routeTimePicker.Name = "routeTimePicker";
            this.routeTimePicker.Size = new System.Drawing.Size(111, 31);
            this.routeTimePicker.TabIndex = 17;
            this.routeTimePicker.ValueChanged += new System.EventHandler(this.routeTimePicker_ValueChanged);
            // 
            // routesGridView
            // 
            this.routesGridView.AllowUserToAddRows = false;
            this.routesGridView.AllowUserToDeleteRows = false;
            this.routesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.routesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pathID,
            this.numberOfLayoversColumn,
            this.originColumn,
            this.layoverOneColumn,
            this.layoverTwoColumn,
            this.destinationColumn});
            this.routesGridView.Location = new System.Drawing.Point(33, 41);
            this.routesGridView.MultiSelect = false;
            this.routesGridView.Name = "routesGridView";
            this.routesGridView.ReadOnly = true;
            this.routesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.routesGridView.Size = new System.Drawing.Size(621, 399);
            this.routesGridView.TabIndex = 16;
            // 
            // pathID
            // 
            this.pathID.HeaderText = "Path ID";
            this.pathID.Name = "pathID";
            this.pathID.ReadOnly = true;
            // 
            // numberOfLayoversColumn
            // 
            this.numberOfLayoversColumn.HeaderText = "Number Of Layovers";
            this.numberOfLayoversColumn.Name = "numberOfLayoversColumn";
            this.numberOfLayoversColumn.ReadOnly = true;
            // 
            // originColumn
            // 
            this.originColumn.HeaderText = "Origin";
            this.originColumn.Name = "originColumn";
            this.originColumn.ReadOnly = true;
            // 
            // layoverOneColumn
            // 
            this.layoverOneColumn.HeaderText = "Layover 1";
            this.layoverOneColumn.Name = "layoverOneColumn";
            this.layoverOneColumn.ReadOnly = true;
            // 
            // layoverTwoColumn
            // 
            this.layoverTwoColumn.HeaderText = "Layover 2";
            this.layoverTwoColumn.Name = "layoverTwoColumn";
            this.layoverTwoColumn.ReadOnly = true;
            // 
            // destinationColumn
            // 
            this.destinationColumn.HeaderText = "Destination";
            this.destinationColumn.Name = "destinationColumn";
            this.destinationColumn.ReadOnly = true;
            // 
            // destinationCodeLabel
            // 
            this.destinationCodeLabel.AutoSize = true;
            this.destinationCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationCodeLabel.Location = new System.Drawing.Point(232, 11);
            this.destinationCodeLabel.Name = "destinationCodeLabel";
            this.destinationCodeLabel.Size = new System.Drawing.Size(120, 25);
            this.destinationCodeLabel.TabIndex = 15;
            this.destinationCodeLabel.Text = "Destination";
            // 
            // originCodeLabel
            // 
            this.originCodeLabel.AutoSize = true;
            this.originCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.originCodeLabel.Location = new System.Drawing.Point(30, 10);
            this.originCodeLabel.Name = "originCodeLabel";
            this.originCodeLabel.Size = new System.Drawing.Size(69, 25);
            this.originCodeLabel.TabIndex = 14;
            this.originCodeLabel.Text = "Origin";
            // 
            // destinationDropDown
            // 
            this.destinationDropDown.FormattingEnabled = true;
            this.destinationDropDown.Location = new System.Drawing.Point(358, 14);
            this.destinationDropDown.Name = "destinationDropDown";
            this.destinationDropDown.Size = new System.Drawing.Size(121, 21);
            this.destinationDropDown.TabIndex = 13;
            // 
            // originDropDown
            // 
            this.originDropDown.BackColor = System.Drawing.SystemColors.Window;
            this.originDropDown.FormattingEnabled = true;
            this.originDropDown.Location = new System.Drawing.Point(105, 14);
            this.originDropDown.Name = "originDropDown";
            this.originDropDown.Size = new System.Drawing.Size(121, 21);
            this.originDropDown.TabIndex = 12;
            this.originDropDown.SelectedIndexChanged += new System.EventHandler(this.originDropDown_SelectedIndexChanged);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(660, 247);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(111, 49);
            this.backButton.TabIndex = 22;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // LoadEngineerEditFlightPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.routeTimePicker);
            this.Controls.Add(this.routesGridView);
            this.Controls.Add(this.destinationCodeLabel);
            this.Controls.Add(this.originCodeLabel);
            this.Controls.Add(this.destinationDropDown);
            this.Controls.Add(this.originDropDown);
            this.Name = "LoadEngineerEditFlightPage";
            this.Text = "LoadEngineerEditFlightPage";
            this.Load += new System.EventHandler(this.LoadEngineerEditFlightPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.routesGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DateTimePicker routeTimePicker;
        private System.Windows.Forms.DataGridView routesGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathID;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfLayoversColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn originColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn layoverOneColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn layoverTwoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinationColumn;
        private System.Windows.Forms.Label destinationCodeLabel;
        private System.Windows.Forms.Label originCodeLabel;
        private System.Windows.Forms.ComboBox destinationDropDown;
        private System.Windows.Forms.ComboBox originDropDown;
        private System.Windows.Forms.Button backButton;
    }
}