using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers.Reports;
using Toxikon.ProtocolManager.Interfaces.Reports;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Models.Reports;
using Toxikon.ProtocolManager.Queries;

namespace Toxikon.ProtocolManager.Views.Reports
{
    public partial class ReportView : UserControl, IReportView
    {
        ReportViewController controller;
        
        public ReportView()
        {
            InitializeComponent();
            for (int year = 2013; year < 2025; ++year)
            {
                 YearComboBox.Items.Add(year);
            }
            YearComboBox.SelectedIndex = 5;
            QuarterComboBox.Items.Add("All");
            QuarterComboBox.Items.Add("Quarter1");
            QuarterComboBox.Items.Add("Quarter2");
            QuarterComboBox.Items.Add("Quarter3");
            QuarterComboBox.Items.Add("Quarter4");

            InitialListViewColumn();
          
        }
        public void InitialListViewColumn()
        {
            ReportListView.Columns.Add("Sponsor Name", -2, HorizontalAlignment.Left);
            ReportListView.Columns.Add("Sponsor Code", -2, HorizontalAlignment.Left);
            ReportListView.Columns.Add("Protocol Number", -2, HorizontalAlignment.Left);
            ReportListView.Columns.Add("Protocol Document", -2, HorizontalAlignment.Left);
            ReportListView.Columns.Add("Department", -2, HorizontalAlignment.Left);
            ReportListView.Columns.Add("Requested By", -2, HorizontalAlignment.Left);
            ReportListView.Columns.Add("Requested Date", -2, HorizontalAlignment.Left);
            ReportListView.Columns.Add("Due Date", -2, HorizontalAlignment.Left);
            ReportListView.Columns.Add("Request Status", -2, HorizontalAlignment.Left);
            ReportListView.Columns.Add("Comment", -2, HorizontalAlignment.Left);
            ReportListView.Columns.Add("Event", -2, HorizontalAlignment.Left);
            ReportListView.Columns.Add("Event Created Date", -2, HorizontalAlignment.Left);
            ReportListView.Columns.Add("Created Year", -2, HorizontalAlignment.Left);
        }    


       public void SetController(ReportViewController controller)
       {
         this.controller = controller;
       }    

        private void ReportButton_Click(object sender, EventArgs e)
        {
            string year = YearComboBox.Text;
            int subYear = Convert.ToInt32(year.Substring(year.Length - 2, 2));
            string quarter = QuarterComboBox.Text;
            int startMonth;

            switch( quarter )
            {
             case "All":
                    startMonth =0;
                    break;
                
             case "Quarter1":
                   startMonth =1;
                      break;
             case "Quarter2":
                   startMonth =4;
                      break;
             case "Quarter3":
                   startMonth =7;
                     break;
             case "Quarter4":
                   startMonth =10;
                     break;
             
             default:
                   startMonth =0;
                     break;            
            }
           
            IList<ReportModel> reportList;

            ReportListView.Items.Clear(); 

            reportList = QReports.SelectItems(subYear, startMonth);

            foreach (var report in reportList)
             {
               ListViewItem item = new ListViewItem(report.ProtocolRequest.Contact.SponsorName);

                item.SubItems.Add(report.ProtocolRequest.Contact.SponsorCode);
                item.SubItems.Add(report.ProtocolNumber.FullCode);
                item.SubItems.Add(report.ProtocolTemplate.FileName);
                item.SubItems.Add(report.ProtocolTemplate.Department.Name);

                item.SubItems.Add(report.ProtocolRequest.RequestedBy);
                item.SubItems.Add((report.ProtocolRequest.RequestedDate).ToString());
                item.SubItems.Add((report.ProtocolRequest.DueDate).ToString());
                item.SubItems.Add(report.ProtocolRequest.RequestStatus);
                item.SubItems.Add(report.Comment.Content);
                item.SubItems.Add(report.ProtocolEvent.Description);
                item.SubItems.Add((report.ProtocolActivity.CreatedDate).ToString());
                item.SubItems.Add(report.Year);
               
                ReportListView.Items.Add(item);
 
             }
           
        }


        public void AddControlToMainPanel(Control control)
        {
            throw new NotImplementedException();
        }

        public Control ParentControl
        {
            get { throw new NotImplementedException(); }
        }

        private void ExportToExcel_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

           
            // changing the name of active sheet
            worksheet.Name = "Protocol Requests";
            worksheet.Columns.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            // storing header part in Excel 
            
            Range header;
            header = worksheet.get_Range("a1:z1");
            header.EntireRow.Font.Bold = true;
            header.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
           
            int i = 1;
            int j = 2;
            
            
            foreach (ColumnHeader ch in ReportListView.Columns)
              {               
                 worksheet.Cells[1, i] = ch.Text;
                 i++;
              }
       
            foreach (ListViewItem item in ReportListView.Items) {

                int n = 1;
                   
                    foreach (ListViewItem.ListViewSubItem sItem in item.SubItems){               
                        worksheet.Cells[j,n]= sItem.Text;
                        n++;
                    }
               j++;
            }
            
            worksheet.Columns.AutoFit();
        }
    }
}
        
      
