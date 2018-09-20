namespace Toxikon.ProtocolManager.Views.Reports
{
    partial class ReportView
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
            this.Yearlabel = new System.Windows.Forms.Label();
            this.QuarterLabel = new System.Windows.Forms.Label();
            this.ReportButton = new System.Windows.Forms.Button();
            this.YearComboBox = new System.Windows.Forms.ComboBox();
            this.QuarterComboBox = new System.Windows.Forms.ComboBox();
            this.ReportListView = new System.Windows.Forms.ListView();
            this.ExportToExcelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Yearlabel
            // 
            this.Yearlabel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Yearlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Yearlabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Yearlabel.Location = new System.Drawing.Point(24, 10);
            this.Yearlabel.Name = "Yearlabel";
            this.Yearlabel.Size = new System.Drawing.Size(50, 23);
            this.Yearlabel.TabIndex = 0;
            this.Yearlabel.Text = "Year";
            this.Yearlabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QuarterLabel
            // 
            this.QuarterLabel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.QuarterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuarterLabel.Location = new System.Drawing.Point(263, 10);
            this.QuarterLabel.Name = "QuarterLabel";
            this.QuarterLabel.Size = new System.Drawing.Size(66, 24);
            this.QuarterLabel.TabIndex = 1;
            this.QuarterLabel.Text = "Quarter";
            this.QuarterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReportButton
            // 
            this.ReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportButton.Location = new System.Drawing.Point(588, 6);
            this.ReportButton.Name = "ReportButton";
            this.ReportButton.Size = new System.Drawing.Size(146, 32);
            this.ReportButton.TabIndex = 2;
            this.ReportButton.Text = "Generate Report";
            this.ReportButton.UseVisualStyleBackColor = true;
            this.ReportButton.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // YearComboBox
            // 
            this.YearComboBox.FormattingEnabled = true;
            this.YearComboBox.Location = new System.Drawing.Point(93, 12);
            this.YearComboBox.Name = "YearComboBox";
            this.YearComboBox.Size = new System.Drawing.Size(77, 21);
            this.YearComboBox.TabIndex = 3;
            // 
            // QuarterComboBox
            // 
            this.QuarterComboBox.FormattingEnabled = true;
            this.QuarterComboBox.Location = new System.Drawing.Point(348, 13);
            this.QuarterComboBox.Name = "QuarterComboBox";
            this.QuarterComboBox.Size = new System.Drawing.Size(95, 21);
            this.QuarterComboBox.TabIndex = 4;
            // 
            // ReportListView
            // 
            this.ReportListView.GridLines = true;
            this.ReportListView.Location = new System.Drawing.Point(3, 44);
            this.ReportListView.Name = "ReportListView";
            this.ReportListView.Size = new System.Drawing.Size(993, 541);
            this.ReportListView.TabIndex = 6;
            this.ReportListView.UseCompatibleStateImageBehavior = false;
            this.ReportListView.View = System.Windows.Forms.View.Details;
            // 
            // ExportToExcelButton
            // 
            this.ExportToExcelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportToExcelButton.Location = new System.Drawing.Point(766, 6);
            this.ExportToExcelButton.Name = "ExportToExcelButton";
            this.ExportToExcelButton.Size = new System.Drawing.Size(145, 32);
            this.ExportToExcelButton.TabIndex = 7;
            this.ExportToExcelButton.Text = "Export to Excel";
            this.ExportToExcelButton.UseVisualStyleBackColor = true;
            this.ExportToExcelButton.Click += new System.EventHandler(this.ExportToExcel_Click);
            // 
            // ReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ExportToExcelButton);
            this.Controls.Add(this.ReportListView);
            this.Controls.Add(this.QuarterComboBox);
            this.Controls.Add(this.YearComboBox);
            this.Controls.Add(this.ReportButton);
            this.Controls.Add(this.QuarterLabel);
            this.Controls.Add(this.Yearlabel);
            this.Name = "ReportView";
            this.Size = new System.Drawing.Size(1008, 603);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Yearlabel;
        private System.Windows.Forms.Label QuarterLabel;
        private System.Windows.Forms.Button ReportButton;
        private System.Windows.Forms.ComboBox YearComboBox;
        private System.Windows.Forms.ComboBox QuarterComboBox;
        private System.Windows.Forms.ListView ReportListView;
        private System.Windows.Forms.Button ExportToExcelButton;
    }
}