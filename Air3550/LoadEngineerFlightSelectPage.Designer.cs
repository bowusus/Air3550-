
namespace Air3550
{
    partial class LoadEngineerFlightSelectPage
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
            this.routesGridView = new System.Windows.Forms.DataGridView();
            this.numberOfLayoversColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.originColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.layoverOneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.layoverTwoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.destinationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.submitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.routesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // routesGridView
            // 
            this.routesGridView.AllowUserToAddRows = false;
            this.routesGridView.AllowUserToDeleteRows = false;
            this.routesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.routesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberOfLayoversColumn,
            this.originColumn,
            this.layoverOneColumn,
            this.layoverTwoColumn,
            this.destinationColumn});
            this.routesGridView.Location = new System.Drawing.Point(13, 13);
            this.routesGridView.MultiSelect = false;
            this.routesGridView.Name = "routesGridView";
            this.routesGridView.ReadOnly = true;
            this.routesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.routesGridView.Size = new System.Drawing.Size(556, 492);
            this.routesGridView.TabIndex = 0;
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
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(603, 211);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(81, 43);
            this.submitButton.TabIndex = 1;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // LoadEngineerFlightSelectPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 517);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.routesGridView);
            this.Name = "LoadEngineerFlightSelectPage";
            this.Text = "LoadEngineerFlightSelectPage";
            this.Load += new System.EventHandler(this.LoadEngineerFlightSelectPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.routesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView routesGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfLayoversColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn originColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn layoverOneColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn layoverTwoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn destinationColumn;
        private System.Windows.Forms.Button submitButton;
    }
}