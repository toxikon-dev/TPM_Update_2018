﻿namespace Toxikon.ProtocolManager.Views
{
    partial class MainView
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.HomeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProtocolRequestMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HistoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminDepartmentsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DepartmentDirectorsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminRolesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminUsersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListNamesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListItemsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdminProtocolEventsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.TemplatesGroupsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TemplatesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateProtocolNumberButton = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateTemplateGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateTemplates = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateProtocolNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           
            this.MainPanel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HomeMenuItem,
            this.ProtocolRequestMenuItem,
            this.HistoryMenuItem,
            this.AdminMenuItem,
            this.UpdateMenuItem,
            this.ReportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 5, 0, 5);
            this.menuStrip1.Size = new System.Drawing.Size(1008, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // HomeMenuItem
            // 
            this.HomeMenuItem.ForeColor = System.Drawing.Color.White;
            this.HomeMenuItem.Name = "HomeMenuItem";
            this.HomeMenuItem.Size = new System.Drawing.Size(54, 19);
            this.HomeMenuItem.Text = "HOME";
            this.HomeMenuItem.Click += new System.EventHandler(this.DashboardMenuItem_Click);
            // 
            // ProtocolRequestMenuItem
            // 
            this.ProtocolRequestMenuItem.ForeColor = System.Drawing.Color.White;
            this.ProtocolRequestMenuItem.Name = "ProtocolRequestMenuItem";
            this.ProtocolRequestMenuItem.Size = new System.Drawing.Size(131, 19);
            this.ProtocolRequestMenuItem.Text = "PROTOCOL REQUEST";
            this.ProtocolRequestMenuItem.Click += new System.EventHandler(this.ProtocolRequestMenuItem_Click);
            // 
            // HistoryMenuItem
            // 
            this.HistoryMenuItem.ForeColor = System.Drawing.Color.White;
            this.HistoryMenuItem.Name = "HistoryMenuItem";
            this.HistoryMenuItem.Size = new System.Drawing.Size(66, 19);
            this.HistoryMenuItem.Text = "HISTORY";
            this.HistoryMenuItem.Click += new System.EventHandler(this.HistoryMenuItem_Click);
            // 
            // AdminMenuItem
            // 
            this.AdminMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AdminDepartmentsMenuItem,
            this.DepartmentDirectorsMenuItem,
            this.AdminRolesMenuItem,
            this.AdminUsersMenuItem,
            this.ListNamesMenuItem,
            this.ListItemsMenuItem,
            this.AdminProtocolEventsButton,
            this.TemplatesGroupsMenuItem,
            this.TemplatesMenuItem,
            this.UpdateProtocolNumberButton});
            this.AdminMenuItem.ForeColor = System.Drawing.Color.White;
            this.AdminMenuItem.Name = "AdminMenuItem";
            this.AdminMenuItem.Size = new System.Drawing.Size(58, 19);
            this.AdminMenuItem.Text = "ADMIN";
            // 
            // AdminDepartmentsMenuItem
            // 
            this.AdminDepartmentsMenuItem.Name = "AdminDepartmentsMenuItem";
            this.AdminDepartmentsMenuItem.Size = new System.Drawing.Size(207, 22);
            this.AdminDepartmentsMenuItem.Text = "Departments";
            this.AdminDepartmentsMenuItem.Click += new System.EventHandler(this.AdminDepartmentsMenuItem_Click);
            // 
            // DepartmentDirectorsMenuItem
            // 
            this.DepartmentDirectorsMenuItem.Name = "DepartmentDirectorsMenuItem";
            this.DepartmentDirectorsMenuItem.Size = new System.Drawing.Size(207, 22);
            this.DepartmentDirectorsMenuItem.Text = "Department Directors";
            this.DepartmentDirectorsMenuItem.Click += new System.EventHandler(this.DepartmentDirectorsMenuItem_Click);
            // 
            // AdminRolesMenuItem
            // 
            this.AdminRolesMenuItem.Name = "AdminRolesMenuItem";
            this.AdminRolesMenuItem.Size = new System.Drawing.Size(207, 22);
            this.AdminRolesMenuItem.Text = "Roles";
            this.AdminRolesMenuItem.Click += new System.EventHandler(this.AdminRolesMenuItem_Click);
            // 
            // AdminUsersMenuItem
            // 
            this.AdminUsersMenuItem.Name = "AdminUsersMenuItem";
            this.AdminUsersMenuItem.Size = new System.Drawing.Size(207, 22);
            this.AdminUsersMenuItem.Text = "Users";
            this.AdminUsersMenuItem.Click += new System.EventHandler(this.AdminUsersMenuItem_Click);
            // 
            // ListNamesMenuItem
            // 
            this.ListNamesMenuItem.Name = "ListNamesMenuItem";
            this.ListNamesMenuItem.Size = new System.Drawing.Size(207, 22);
            this.ListNamesMenuItem.Text = "List Names";
            this.ListNamesMenuItem.Click += new System.EventHandler(this.ListNamesMenuItem_Click);
            // 
            // ListItemsMenuItem
            // 
            this.ListItemsMenuItem.Name = "ListItemsMenuItem";
            this.ListItemsMenuItem.Size = new System.Drawing.Size(207, 22);
            this.ListItemsMenuItem.Text = "List Items";
            this.ListItemsMenuItem.Click += new System.EventHandler(this.ListItemsMenuItem_Click);
            // 
            // AdminProtocolEventsButton
            // 
            this.AdminProtocolEventsButton.Name = "AdminProtocolEventsButton";
            this.AdminProtocolEventsButton.Size = new System.Drawing.Size(207, 22);
            this.AdminProtocolEventsButton.Text = "Protocol Events";
            this.AdminProtocolEventsButton.Click += new System.EventHandler(this.AdminProtocolEventsButton_Click);
            // 
            // TemplatesGroupsMenuItem
            // 
            this.TemplatesGroupsMenuItem.Name = "TemplatesGroupsMenuItem";
            this.TemplatesGroupsMenuItem.Size = new System.Drawing.Size(207, 22);
            this.TemplatesGroupsMenuItem.Text = "Templates Groups";
            this.TemplatesGroupsMenuItem.Click += new System.EventHandler(this.TemplatesGroupsMenuItem_Click);
            // 
            // TemplatesMenuItem
            // 
            this.TemplatesMenuItem.Name = "TemplatesMenuItem";
            this.TemplatesMenuItem.Size = new System.Drawing.Size(207, 22);
            this.TemplatesMenuItem.Text = "Templates";
            this.TemplatesMenuItem.Click += new System.EventHandler(this.TemplatesMenuItem_Click);
            // 
            // UpdateProtocolNumberButton
            // 
            this.UpdateProtocolNumberButton.Name = "UpdateProtocolNumberButton";
            this.UpdateProtocolNumberButton.Size = new System.Drawing.Size(207, 22);
            this.UpdateProtocolNumberButton.Text = "Update Protocol Number";
            this.UpdateProtocolNumberButton.Click += new System.EventHandler(this.UpdateProtocolNumberButton_Click);
            // 
            // UpdateMenuItem
            // 
            this.UpdateMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateTemplateGroups,
            this.UpdateTemplates,
            this.UpdateProtocolNumber});
            this.UpdateMenuItem.ForeColor = System.Drawing.Color.White;
            this.UpdateMenuItem.Name = "UpdateMenuItem";
            this.UpdateMenuItem.Size = new System.Drawing.Size(62, 19);
            this.UpdateMenuItem.Text = "UPDATE";
            // 
            // UpdateTemplateGroups
            // 
            this.UpdateTemplateGroups.Name = "UpdateTemplateGroups";
            this.UpdateTemplateGroups.Size = new System.Drawing.Size(166, 22);
            this.UpdateTemplateGroups.Text = "Template Groups";
            this.UpdateTemplateGroups.Click += new System.EventHandler(this.TemplatesGroupsMenuItem_Click);
            // 
            // UpdateTemplates
            // 
            this.UpdateTemplates.Name = "UpdateTemplates";
            this.UpdateTemplates.Size = new System.Drawing.Size(166, 22);
            this.UpdateTemplates.Text = "Templates";
            this.UpdateTemplates.Click += new System.EventHandler(this.TemplatesMenuItem_Click);
            // 
            // UpdateProtocolNumber
            // 
            this.UpdateProtocolNumber.Name = "UpdateProtocolNumber";
            this.UpdateProtocolNumber.Size = new System.Drawing.Size(166, 22);
            this.UpdateProtocolNumber.Text = "Protocol Number";
            this.UpdateProtocolNumber.Click += new System.EventHandler(this.UpdateProtocolNumberButton_Click);
            // 
            // ReportToolStripMenuItem
            // 
            this.ReportToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem";
            this.ReportToolStripMenuItem.Size = new System.Drawing.Size(61, 19);
            this.ReportToolStripMenuItem.Text = "REPORT";
            this.ReportToolStripMenuItem.Click += new System.EventHandler(this.ReportToolStripMenuItem_Click);
            // 
    
            // 
            // MainPanel
            // 
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 29);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1008, 603);
            this.MainPanel.TabIndex = 1;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 632);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1024, 670);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TPM - Toxikon Protocol Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem HomeMenuItem;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.ToolStripMenuItem ProtocolRequestMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminDepartmentsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminRolesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminUsersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ListItemsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AdminProtocolEventsButton;
        private System.Windows.Forms.ToolStripMenuItem HistoryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ListNamesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TemplatesGroupsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TemplatesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateProtocolNumberButton;
        private System.Windows.Forms.ToolStripMenuItem DepartmentDirectorsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateTemplateGroups;
        private System.Windows.Forms.ToolStripMenuItem UpdateTemplates;
        private System.Windows.Forms.ToolStripMenuItem UpdateProtocolNumber;
        
        private System.Windows.Forms.ToolStripMenuItem ReportToolStripMenuItem;
    }
}

