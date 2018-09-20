﻿namespace Toxikon.ProtocolManager.Views
{
    partial class DashboardView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.RequestDataGridView = new System.Windows.Forms.DataGridView();
            this.IDCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequestedDateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequestedByCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignedToCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SponsorCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProtocolNumberCountCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.RequestDataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RequestDataGridView
            // 
            this.RequestDataGridView.AllowUserToAddRows = false;
            this.RequestDataGridView.AllowUserToDeleteRows = false;
            this.RequestDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RequestDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.RequestDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.RequestDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RequestDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDCol,
            this.RequestedDateCol,
            this.RequestedByCol,
            this.AssignedToCol,
            this.SponsorCol,
            this.ProtocolNumberCountCol});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RequestDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.RequestDataGridView.Location = new System.Drawing.Point(4, 34);
            this.RequestDataGridView.Name = "RequestDataGridView";
            this.RequestDataGridView.ReadOnly = true;
            this.RequestDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RequestDataGridView.Size = new System.Drawing.Size(787, 414);
            this.RequestDataGridView.TabIndex = 6;
            this.RequestDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RequestDataGridView_CellContentDoubleClick);
            // 
            // IDCol
            // 
            this.IDCol.FillWeight = 62.12653F;
            this.IDCol.HeaderText = "Request ID";
            this.IDCol.Name = "IDCol";
            this.IDCol.ReadOnly = true;
            // 
            // RequestedDateCol
            // 
            this.RequestedDateCol.FillWeight = 62.12653F;
            this.RequestedDateCol.HeaderText = "Requested Date";
            this.RequestedDateCol.Name = "RequestedDateCol";
            this.RequestedDateCol.ReadOnly = true;
            // 
            // RequestedByCol
            // 
            this.RequestedByCol.FillWeight = 62.12653F;
            this.RequestedByCol.HeaderText = "Requested By";
            this.RequestedByCol.Name = "RequestedByCol";
            this.RequestedByCol.ReadOnly = true;
            // 
            // AssignedToCol
            // 
            this.AssignedToCol.FillWeight = 62.12653F;
            this.AssignedToCol.HeaderText = "Assigned To";
            this.AssignedToCol.Name = "AssignedToCol";
            this.AssignedToCol.ReadOnly = true;
            // 
            // SponsorCol
            // 
            this.SponsorCol.FillWeight = 62.12653F;
            this.SponsorCol.HeaderText = "Sponsor";
            this.SponsorCol.Name = "SponsorCol";
            this.SponsorCol.ReadOnly = true;
            // 
            // ProtocolNumberCountCol
            // 
            this.ProtocolNumberCountCol.FillWeight = 62.12653F;
            this.ProtocolNumberCountCol.HeaderText = "Protocol Numbers/Templates";
            this.ProtocolNumberCountCol.Name = "ProtocolNumberCountCol";
            this.ProtocolNumberCountCol.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 9);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(794, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.SlateGray;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(118, 22);
            this.toolStripLabel1.Text = "Protocol Requests";
            // 
            // DashboardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.RequestDataGridView);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DashboardView";
            this.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.Size = new System.Drawing.Size(794, 450);
            ((System.ComponentModel.ISupportInitialize)(this.RequestDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView RequestDataGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestedDateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestedByCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssignedToCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SponsorCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProtocolNumberCountCol;
    }
}
