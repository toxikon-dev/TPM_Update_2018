using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Models;
using Toxikon.ProtocolManager.Models.Reports;
using Toxikon.ProtocolManager.Queries;

namespace Toxikon.ProtocolManager.Queries
{
    public class QReports
    {
        private static string CONNECTION_STRING = Utility.GetTPMConnectionString();
        private const string ErrorFormName = "QReports";
        
        public static IList<ReportModel> SelectItems(int year, int startMonth)
        {   
            IList<ReportModel> results = new List<ReportModel>();
           
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                    {
                      connection.Open(); 
 
                      if (startMonth ==0)                 
                         { 
                          using (SqlCommand command = new SqlCommand("rp_select_allByYear", connection))                     
                             {
                              command.CommandType = CommandType.StoredProcedure;                      
                              command.Parameters.Add("@Year", SqlDbType.Int).Value = year;
                        
                              SqlDataReader reader = command.ExecuteReader();
                            
                                while (reader.Read())
                                {
                                    ReportModel item = new ReportModel();
                            
                                    //item.ProtocolRequest.Contact.SponsorName = reader["SponsorName"].ToString();
                            
                                    item.ProtocolRequest.Contact.SponsorCode = reader["SponsorCode"].ToString(); 
                                    item.ProtocolRequest.Contact.SponsorName = QMatrix.GetSponsorNameBySponsorCode(item.ProtocolRequest.Contact.SponsorCode);
                                    item.ProtocolNumber.FullCode = reader["ProtocolNumber"].ToString();
                                    item.ProtocolTemplate.FileName = reader["ProtocolDocument"].ToString();
                                    item.ProtocolTemplate.Department.Name = reader["Department"].ToString();
                                    item.ProtocolRequest.RequestedBy = reader["RequestedBy"].ToString();
                                    item.ProtocolRequest.RequestedDate = Convert.ToDateTime(reader["RequestedDate"].ToString());
                                    item.ProtocolRequest.DueDate = Convert.ToDateTime(reader["DueDate"].ToString());
                                    item.ProtocolRequest.RequestStatus = reader["RequestStatus"].ToString();
                                    item.Comment.Content = reader["Comment"].ToString();
                                    item.ProtocolEvent.Description = reader["Event"].ToString();
                                    item.ProtocolActivity.CreatedDate = Convert.ToDateTime(reader["EventCreatedDate"].ToString());
                                    item.Year = reader["Year"].ToString();
                   
                                    results.Add(item);
                                }
                             
                                 reader.Close();
                             } 
                         }

                      else if (startMonth != 0)                 
                         { 
                          using (SqlCommand command = new SqlCommand("rp_select_ByQuarter", connection))  
                   //SqlCommand command = new SqlCommand("Select * from View_2018Q1", connection)) 
                             {
                              command.CommandType = CommandType.StoredProcedure; 
                                // command.CommandType = CommandType.Text; 
                              command.Parameters.Add("@Year", SqlDbType.Int).Value = year;
                              command.Parameters.Add("@StartMonth", SqlDbType.Int).Value = startMonth;
                              SqlDataReader reader = command.ExecuteReader();
                            
                              while (reader.Read())
                                 {
                                    ReportModel item = new ReportModel();

                                    item.ProtocolRequest.Contact.SponsorName = QMatrix.GetSponsorNameBySponsorCode(reader["SponsorCode"].ToString());
                                    item.ProtocolRequest.Contact.SponsorCode = reader["SponsorCode"].ToString();
                                    item.ProtocolNumber.FullCode = reader["ProtocolNumber"].ToString();
                                    item.ProtocolTemplate.FileName = reader["ProtocolDocument"].ToString();
                                    item.ProtocolTemplate.Department.Name = reader["Department"].ToString();
                                    item.ProtocolRequest.RequestedBy = reader["RequestedBy"].ToString();
                                    item.ProtocolRequest.RequestedDate = Convert.ToDateTime(reader["RequestedDate"].ToString());
                                    item.ProtocolRequest.DueDate = Convert.ToDateTime(reader["DueDate"].ToString());
                                    item.ProtocolRequest.RequestStatus = reader["RequestStatus"].ToString();
                                    item.Comment.Content = reader["Comment"].ToString();
                                    item.ProtocolEvent.Description = reader["Event"].ToString();
                                    item.ProtocolActivity.CreatedDate = Convert.ToDateTime(reader["EventCreatedDate"].ToString());
                                    item.Year = reader["Year"].ToString();
                      
                                    results.Add(item);
                                  }
                              reader.Close();
                             } 
                         }
                    }
             }
         
            catch (SqlException ex)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "SelectReportAllData", ex);
            }

            return results;
         } 
    }
}

