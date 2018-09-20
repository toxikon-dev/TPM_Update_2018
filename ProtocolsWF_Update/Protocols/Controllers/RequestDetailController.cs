﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers;
using Toxikon.ProtocolManager.Controllers.Protocols;
using Toxikon.ProtocolManager.Interfaces;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Models.Admin;
using Toxikon.ProtocolManager.Models.Reports;
using Toxikon.ProtocolManager.Models.Templates;
using Toxikon.ProtocolManager.Queries;
using Toxikon.ProtocolManager.Views;
using Toxikon.ProtocolManager.Views.Protocols;

namespace Toxikon.ProtocolManager.Controllers
{
    public class RequestDetailController
    {
        private RequestDetailView view;
        private ProtocolRequest request;
        private IList templates;
        private SponsorContact contact;
        private LoginInfo loginInfo;
        private RequestFormController requestFormController;
        private string SelectOneMessage = "Please select one title and try it again.";
        private string requestFormType;

        public RequestDetailController(RequestDetailView view)
        {
            this.view = view;
            this.view.SetController(this);
            loginInfo = LoginInfo.GetInstance();
            this.templates = new ArrayList();
            this.requestFormController = new RequestFormController(this.view.RequestForm);
            this.requestFormType = RequestFormTypes.Edit;
        }

        public void LoadView(ProtocolRequest protocolRequest)
        {
            this.request = protocolRequest;
            this.contact = protocolRequest.Contact;
            this.requestFormController.LoadView(this.request);
            this.RefreshTemplateListView();
        }

        public void LoadView(ProtocolRequest protocolRequest, string requestFormType)
        {
            this.requestFormType = requestFormType;
            this.request = protocolRequest;
            this.contact = protocolRequest.Contact;
            this.requestFormController.LoadView(this.request);
            this.RefreshTemplateListView();
        }

        public void ClearListView()
        {
            this.templates.Clear();
            this.view.ClearListView();
        }

        public void ClearRequestForm()
        {
            this.requestFormController.ClearForm();
        }

        private void LoadRequestTemplates()
        {
            if(this.requestFormType == RequestFormTypes.ReadOnly)
            {
                this.templates = QProtocolRequestTemplates.SelectItems(this.request.ID);
            }
            else
            {
                if (loginInfo.Role.RoleID != UserRoles.DepartmentDirector)
                {
                    this.templates = QProtocolRequestTemplates.SelectItems(this.request.ID);
                }
                else
                {
                    this.templates = QProtocolRequestTemplates.SelectItemsByDirector(this.request.ID,
                                     this.loginInfo.UserName);
                }
            }
        }
        
        private void AddTemplatesToView()
        {
            foreach (ProtocolTemplate item in this.templates)
            {
                this.view.AddTemplateToListView(item);
            }
        }

        private void RefreshTemplateListView()
        {
            this.ClearListView();            
            LoadRequestTemplates();
            AddTemplatesToView();
            this.view.SetListViewAutoResizeColumns();
        }

        private ProtocolTemplate GetSelectedTemplateFromView()
        {
            int selectedIndex = Convert.ToInt32(this.view.ListViewSelectedIndexes[0]);
            ProtocolTemplate title = this.templates[selectedIndex] as ProtocolTemplate;
            return title;
        }

        public void AddTemplateButtonClicked()
        {
            ShowTemplateOptionsPopup();
            
        }

        private void ShowTemplateOptionsPopup()
        {
            TemplateOptionsForm form = new TemplateOptionsForm();
            TemplateOptionsController formController = new TemplateOptionsController(form);
            formController.SubmitSelectedItemDelegate = new
                TemplateOptionsController.SubmitSelectedItem(this.SubmitSelectedTemplate);
            formController.LoadView();
            DialogResult dialogResult = form.ShowDialog(this.view.ParentControl);
            form.Dispose();
        }

        private void SubmitSelectedTemplate(Template item)
        {
            QProtocolRequestTemplates.InsertItemNew(this.request.ID, item.ID, item.GroupID, loginInfo.UserName);
            ProtocolActivity protocolActivity = new ProtocolActivity(this.request.ID, item.ID, 1, loginInfo.UserName);
            QProtocolActivities.InsertItem(protocolActivity);
            RefreshTemplateListView();
        }

        public void RemoveTemplateButtonClicked()
        {
            if (this.view.ListViewSelectedIndexes.Count == 1)
            {
                RemoveSelectedTemplateWithConfirmation();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void RemoveSelectedTemplateWithConfirmation()
        {
            int selectedIndex = Convert.ToInt32(this.view.ListViewSelectedIndexes[0]);
            if (selectedIndex > -1 && selectedIndex < this.templates.Count)
            {
                ProtocolTemplate selectedTemplate = this.templates[selectedIndex] as ProtocolTemplate;
                DialogResult dialogResult = ShowConfirmation("Are you sure you want to remove this template?");
                if(dialogResult == DialogResult.Yes)
                {
                    RemoveSelectedTemplate(selectedTemplate);
                }
            }
        }

        private void RemoveSelectedTemplate(ProtocolTemplate selectedTemplate)
        {
            QProtocolRequestTemplates.SetIsActive(this.request.ID, selectedTemplate.TemplateID,
                                                          false, loginInfo.UserName);
            QProtocolNumbers.UpdateItem_IsActive(this.request.ID, selectedTemplate.TemplateID, 
                                                 false, loginInfo.UserName);
            AuditHandler.Insert_RemoveTitle_AuditItem(this.request.ID,
                         selectedTemplate.TemplateID, loginInfo.UserName);
            RefreshTemplateListView();
        }

        private DialogResult ShowConfirmation(string message)
        {
            DialogResult dialogResult = MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo);
            return dialogResult;
        }

        public void AddEventButtonClicked()
        {
            if (this.view.ListViewSelectedIndexes.Count != 0)
            {
                AddEventToSelectedTitle();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void AddEventToSelectedTitle()
        {
            ProtocolEvent popupResult = ShowProtocolEventAddView();
            if (popupResult.Description != "")
            {
                IList protocolActivities = CreateProtocolActivityList(popupResult.ID);
                QProtocolActivities.InsertItems(protocolActivities);
                RefreshTemplateListView();
            }
        }

        private ProtocolEvent ShowProtocolEventAddView()
        {
            ProtocolEvent result = new ProtocolEvent();
            ProtocolEventAddView popup = new ProtocolEventAddView();
            ProtocolEventAddController popupController = new ProtocolEventAddController(popup);
            popupController.LoadView();
            DialogResult dialogResult = popup.ShowDialog(this.view.ParentControl);
            if (dialogResult == DialogResult.OK)
            {
                result = popupController.SelectedProtocolEvent;
            }
            return result;
        }

        private IList CreateProtocolActivityList(int eventID)
        {
            IList protocolActivities = new List<ProtocolActivity>() { };
            foreach (int titleIndex in this.view.ListViewSelectedIndexes)
            {
                ProtocolTemplate title = this.templates[titleIndex] as ProtocolTemplate;
                ProtocolActivity protocolActivity = new ProtocolActivity(title, eventID, loginInfo.UserName);
                protocolActivities.Add(protocolActivity);
            }
            return protocolActivities;
        }

        public void ViewEventsButtonClicked()
        {
            if (this.view.ListViewSelectedIndexes.Count == 1)
            {
                ShowSelectedTitleEvents();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void ShowSelectedTitleEvents()
        {
            ProtocolTemplate title = GetSelectedTemplateFromView();
            IList events = QProtocolActivities.SelectItems(this.request.ID, title.TemplateID);
            IList columns = new ArrayList() { "Date", "User", "Event" };
            TemplatesController.ShowReadOnlyListViewForm(columns, events, view.ParentControl);
        }

        public void AddCommentsButtonClicked()
        {
            if (this.view.ListViewSelectedIndexes.Count == 1)
            {
                AddCommentsToSelectedTitle();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void AddCommentsToSelectedTitle()
        {
            string popupResult = TemplatesController.ShowOneTextBoxForm("Comments: ", "",
                                     this.view.ParentControl);
            if (popupResult != String.Empty)
            {
                ProtocolTemplate title = GetSelectedTemplateFromView();
                QProtocolComments.InsertItem(title, popupResult, loginInfo.UserName);
                RefreshTemplateListView();
            }
        }

        public void ViewCommentsButtonClicked()
        {
            if (this.view.ListViewSelectedIndexes.Count == 1)
            {
                ShowSelectedTitleComments();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void ShowSelectedTitleComments()
        {
            ProtocolTemplate title = GetSelectedTemplateFromView();
            IList comments = QProtocolComments.SelectItems(title);
            IList columns = new ArrayList() { "Date", "User", "Comments" };
            TemplatesController.ShowReadOnlyListViewForm(columns, comments, view.ParentControl);
        }

        public void AddProtocolNumberButtonClicked()
        {
            if (this.view.ListViewSelectedIndexes.Count == 1)
            {
                AssignProtocolNumberToSelectedTitle();
                InsertProtocolActivity(30);
                this.RefreshTemplateListView();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void AssignProtocolNumberToSelectedTitle()
        {
            ProtocolTemplate title = GetSelectedTemplateFromView();
            title.AddProtocolNumber(this.request.ProtocolType, this.contact.SponsorCode);
            AuditHandler.Insert_ProtocolNumber_AuditItem(title.ProtocolNumber, loginInfo.UserName);
        }

        private void InsertProtocolActivity(int eventID)
        {
            ProtocolTemplate title = GetSelectedTemplateFromView();
            ProtocolActivity protocolActivity = new ProtocolActivity(title, eventID, loginInfo.UserName);
            QProtocolActivities.InsertItem(protocolActivity);
        }

        public void ReviseProtocolButtonClicked()
        {
            if (this.view.ListViewSelectedIndexes.Count == 1)
            {
                ReviseSelectedTitleProtocolNumber();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void ReviseSelectedTitleProtocolNumber()
        {
            ProtocolTemplate title = GetSelectedTemplateFromView();
            if (title.ProtocolNumber.FullCode != String.Empty)
            {
                string oldValue = title.ProtocolNumber.FullCode;
                title.ProtocolNumber.Update();
                AuditHandler.Insert_ReviseProtocol_AuditItem(oldValue, title.ProtocolNumber, loginInfo.UserName);
                this.RefreshTemplateListView();
            }
            else
            {
                MessageBox.Show("Invalid Protocol Number.");
            }
        }

        public void CreateProtocolButtonClicked()
        {
            if (this.view.ListViewSelectedIndexes.Count == 1)
            {
                CreateProtocol();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void CreateProtocol()
        {
            ProtocolTemplate title = GetSelectedTemplateFromView();
            if(title.ProtocolNumber.FullCode != String.Empty)
            {
                CreateProtocolView popup = new CreateProtocolView();
                CreateProtocolController popupController = new CreateProtocolController(popup);
                if (popup.ShowDialog(this.view.ParentControl) == DialogResult.OK)
                {
                    Debug.WriteLine(popup.SourceFile, popup.DestFolder);
                    string destFile = popup.DestFolder + "\\" + title.ProtocolNumber.FullCode + "_v01"+".docx";
                    WordProtocol protocol = new WordProtocol(request, title.ProtocolNumber.FullCode);
                    protocol.Create(popup.SourceFile, destFile);
                }
                popup.Dispose();
            }
            else
            {
                MessageBox.Show("Invalid Protocol Number");
            }
        }

        public void UpdateFilePathButtonClicked(string filePath)
        {
            if (this.view.ListViewSelectedIndexes.Count == 1)
            {
                UpdateSelectedTitleFilePath(filePath);
                this.RefreshTemplateListView();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void UpdateSelectedTitleFilePath(string filePath)
        {
            ProtocolTemplate title = GetSelectedTemplateFromView();
            string oldValue = title.FilePath;
            title.UpdateFileInfo(filePath);
            AuditHandler.Insert_UpdateFilePath_AuditItem(oldValue, title, loginInfo.UserName);
        }

        public void OpenFileButtonClicked()
        {
            if (this.view.ListViewSelectedIndexes.Count == 1)
            {
                ProtocolTemplate title = GetSelectedTemplateFromView();
                title.OpenFile();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        public void UpdateProjectNumberButtonClicked()
        {
            if (this.view.ListViewSelectedIndexes.Count == 1)
            {
                UpdateSelectedTitleProjectNumber();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void UpdateSelectedTitleProjectNumber()
        {
            ProtocolTemplate title = GetSelectedTemplateFromView();
            string oldValue = title.ProjectNumber;
            string projectNumber = TemplatesController.ShowOneTextBoxForm("Project Number: ",
                                   title.ProjectNumber, this.view.ParentControl);
            if (projectNumber != String.Empty)
            {
                title.AddProjectNumber(projectNumber);
                AuditHandler.Insert_ProjectNumber_AuditItem(oldValue, title, loginInfo.UserName);
                this.RefreshTemplateListView();
            }
        }

        public void DepartmentButtonClicked()
        {
            if (this.view.ListViewSelectedIndexes.Count == 1)
            {
                UpdateSelectedTitleDepartment();
                this.RefreshTemplateListView();
            }
            else
            {
                MessageBox.Show(this.SelectOneMessage);
            }
        }

        private void UpdateSelectedTitleDepartment()
        {
            Item selectedItem = SelectDepartmentFromOptions();
            if (selectedItem.Value != "")
            {
                ProtocolTemplate title = GetSelectedTemplateFromView();
                string oldValue = title.Department.ID.ToString();
                title.UpdateDepartment(Convert.ToInt32(selectedItem.Value));
                AuditHandler.Insert_Department_AuditItem(oldValue, title, loginInfo.UserName);
            }
        }

        private Item SelectDepartmentFromOptions()
        {
            IList items = QDepartments.SelectItems2();
            Item selectedItem = TemplatesController.ShowListBoxOptionsForm(items, view.ParentControl);
            return selectedItem;
        }

        public void SaveChangedButtonClicked()
        {
            this.requestFormController.UpdateRequestWithViewValues();
            this.requestFormController.UpdateRequest();
            MessageBox.Show("Updated!");
        }

        public void CloseRequestButtonClicked()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to close this request?",
                                        "Close Protocol Request",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.request.CloseRequest();
                MainView mainView = (MainView)view.ParentControl;
                mainView.Invoke(mainView.LoadProtocolRequestViewDelegate, new object[] { this.request });
            }
        }

        public void DownloadRequestReportButtonClicked()
        {
            ProtocolRequestReport reportTemplate = new ProtocolRequestReport(this.request);

            reportTemplate.Create();

            MessageBox.Show("Download Complete!");
        }
    }
}
