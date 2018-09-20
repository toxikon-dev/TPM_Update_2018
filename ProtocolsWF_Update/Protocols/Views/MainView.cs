﻿using Toxikon.ProtocolManager.Controllers;
using Toxikon.ProtocolManager.Interfaces;
using Toxikon.ProtocolManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Toxikon.ProtocolManager.Views
{
    public partial class MainView : Form, IMainView
    {
        MainViewController controller;
        public delegate void LoadProtocolRequestEditView(ProtocolRequest request);
        public LoadProtocolRequestEditView LoadProtocolRequestViewDelegate;

        public MainView()
        {
            InitializeComponent();
            this.menuStrip1.Renderer = new MyRenderer();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }

        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.Gray; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.DarkGray; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.Gray; }
            }
            public override Color MenuItemBorder
            {
                get { return Color.Gray; }
            }
            public override Color MenuItemPressedGradientBegin
            {
                get { return Color.DarkGray; }
            }
            public override Color MenuItemPressedGradientEnd
            {
                get { return Color.Gray; }
            }
        }

        public void SetMenuStripItemVisibleByUserRole(int roleID)
        {
            switch(roleID)
            {
                case UserRoles.IT:
                    this.ProtocolRequestMenuItem.Visible = true;
                    this.AdminMenuItem.Visible = true;
                    this.UpdateMenuItem.Visible = true;
                    break;
                case UserRoles.CSR:
                    this.ProtocolRequestMenuItem.Visible = true;
                    this.AdminMenuItem.Visible = true;
                    this.UpdateMenuItem.Visible = false;
                    break;
                case UserRoles.DocControl:
                    this.ProtocolRequestMenuItem.Visible = true;
                    this.AdminMenuItem.Visible = true;
                    this.UpdateMenuItem.Visible = true;
                    break;
                default:
                    this.ProtocolRequestMenuItem.Visible = false;
                    this.AdminMenuItem.Visible = true;
                    this.UpdateMenuItem.Visible = false;
                    break;
            }
        }

        public void SetController(MainViewController controller)
        {
            this.controller = controller;
            this.LoadProtocolRequestViewDelegate = new LoadProtocolRequestEditView(
                this.controller.LoadProtocolRequestDetailView);
        }

        public void AddControlToMainPanel(Control control)
        {
            this.MainPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            this.MainPanel.Controls.Add(control);
        }

        private void AdminDepartmentsMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.LoadDepartmentListView();
        }

        private void AdminRolesMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.LoadRoleListView();
        }

        private void AdminUsersMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.LoadUserListView();
        }

        private void ListItemsMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.LoadListItemsView();
        }

        private void DashboardMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.LoadDashboardView();
        }

        private void ProtocolRequestMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.LoadProtocolRequestAddView();
        }

        private void AdminProtocolEventsButton_Click(object sender, EventArgs e)
        {
            this.controller.LoadProtocolEventsView();
        }

        private void HistoryMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.LoadHistoryView();
        }

        private void ListNamesMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.LoadListNameView();
        }

        private void TemplatesGroupsMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.LoadTemplateGroupsView();
        }

        private void TemplatesMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.LoadTemplatesView();
        }

        private void UpdateProtocolNumberButton_Click(object sender, EventArgs e)
        {
            this.controller.LoadProtocolNumberUpdateView();
        }
        
        private void DepartmentDirectorsMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.LoadDepartmentDirectorsView();
        }

        private void ReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.LoadProtocolRequestReportView();
        }

      

       
    }
}
