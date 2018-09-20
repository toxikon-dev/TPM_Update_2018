using Toxikon.ProtocolManager.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Models.Protocols;
using System.Windows.Forms;

namespace Toxikon.ProtocolManager.Queries
{
    public static class QMatrix
    {
        private static string CONNECTION_STRING = Utility.GetLIMSConnectionString();
        private const string ErrorFormName = "QMatrix";
        
        private const string SelectSponsorContactsQuery = @"
            SELECT Submitters.SubmitterCode AS SponsorCode,
	               Submitters.SubmitterName AS SponsorName,
	               ISNULL(Submitters.SubmitterAddress1, '') + 
	               ISNULL(Submitters.SubmitterAddress2, '') AS PostalAddress,
	               Submitters.SubmitterAddress4 AS City,
	               Submitters.SubmitterAddress5 AS State,
	               Submitters.SubmitterPostCode AS PostCode,
	               Submitters.SubmitterAddress3 AS Country,
	               Submitters.SubmitterTelephone AS PhoneNumber,
	               Submitters.SubmitterFax AS Fax                       
            FROM Submitters
            WHERE Submitters.SubmitterName LIKE @SponsorName
            AND Submitters.RecordStatus = 1
            AND Submitters.SubmitterClass = 'Sponsor'
            ORDER BY submitters.SubmitterName";

        private const string ContactInfoByContactCode = @"
            SELECT Submitters.SubmitterText1 AS SponsorCode,
		           Submitters.SubmitterCode AS ContactCode,
	               Submitters.SubmitterName AS SponsorName,
	               ISNULL(Submitters.SubmitterText2, '') + ' ' +
	               ISNULL(Submitters.SubmitterText3, '') AS ContactName,
	               ISNULL(Submitters.SubmitterAddress1, '') + 
	               ISNULL(Submitters.SubmitterAddress2, '') AS PostalAddress,
	               Submitters.SubmitterAddress4 AS City,
	               Submitters.SubmitterAddress5 AS State,
	               Submitters.SubmitterPostCode,
	               Submitters.SubmitterAddress3 AS Country,
	               Submitters.SubmitterTelephone AS PhoneNumber,
	               Submitters.SubmitterFax AS Fax,
                   ISNULL(Submitters.SubmitterTelex, Submitters.DeliveryAddress1) AS Email   
            FROM Submitters
            WHERE Submitters.SubmitterCode = @ContactCode
            AND Submitters.RecordStatus = 1
            AND Submitters.SubmitterClass = 'Contact'";

        private const string ContactInfoBySponsor = @"
            SELECT Submitters.SubmitterText1 AS SponsorCode,
		           Submitters.SubmitterCode AS ContactCode,
	               Submitters.SubmitterName AS SponsorName,
	               ISNULL(Submitters.SubmitterText2, '') + ' ' +
	               ISNULL(Submitters.SubmitterText3, '') AS ContactName,
	               ISNULL(Submitters.SubmitterAddress1, '') + 
	               ISNULL(Submitters.SubmitterAddress2, '') AS PostalAddress,
	               Submitters.SubmitterAddress4 AS City,
	               Submitters.SubmitterAddress5 AS State,
	               Submitters.SubmitterPostCode,
	               Submitters.SubmitterAddress3 AS Country,
	               Submitters.SubmitterTelephone AS PhoneNumber,
	               Submitters.SubmitterFax AS Fax,
                   ISNULL(Submitters.SubmitterTelex, Submitters.DeliveryAddress1) AS Email   
            FROM Submitters
            WHERE Submitters.SubmitterName = @SponsorName
            AND Submitters.RecordStatus = 1
            AND Submitters.SubmitterClass = 'Contact'
            ORDER BY SubmitterText2";

        private const string ContactInfoBySponsorCode = @"
            SELECT Submitters.SubmitterCode AS SpnsorCode,
	               Submitters.SubmitterName AS SponsorName,
	               ISNULL(Submitters.SubmitterAddress1, '') + 
	               ISNULL(Submitters.SubmitterAddress2, '') AS PostalAddress,
	               Submitters.SubmitterAddress4 AS City,
	               Submitters.SubmitterAddress5 AS State,
	               Submitters.SubmitterPostCode AS PostCode,
	               Submitters.SubmitterAddress3 AS Country,
	               Submitters.SubmitterTelephone AS PhoneNumber,
	               Submitters.SubmitterFax AS Fax         
            FROM Submitters
            WHERE Submitters.SubmitterCode = @SponsorCode
            AND Submitters.RecordStatus = 1
            AND Submitters.SubmitterClass = 'Sponsor'
            ";

        private const string ContactInfoBySponsorName = @"
            SELECT Submitters.SubmitterCode AS SponsorCode,
	               Submitters.SubmitterName AS SponsorName,
	               ISNULL(Submitters.SubmitterText2, '') + ' ' +
	               ISNULL(Submitters.SubmitterText3, '') AS ContactName,
	               ISNULL(Submitters.SubmitterAddress1, '') + 
	               ISNULL(Submitters.SubmitterAddress2, '') AS PostalAddress,
	               Submitters.SubmitterAddress4 AS City,
	               Submitters.SubmitterAddress5 AS State,
	               Submitters.SubmitterPostCode,
	               Submitters.SubmitterAddress3 AS Country,
	               Submitters.SubmitterTelephone AS PhoneNumber,
	               Submitters.SubmitterFax AS Fax,
                   ISNULL(Submitters.SubmitterTelex, Submitters.DeliveryAddress1) AS Email   
            FROM Submitters
            WHERE Submitters.SubmitterName = @SponsorName
            AND Submitters.RecordStatus = 1
            AND Submitters.SubmitterClass = 'Sponsor'
            ";

        private const string SelectSponsorNames = @"
            SELECT Submitters.SubmitterName AS SponsorName
            FROM Submitters
            WHERE Submitters.SubmitterCode = @SponsorCode
            AND Submitters.RecordStatus = 1
            AND Submitters.SubmitterClass = 'Sponsor'
            Order By Submitters.SubmitterName";

             
        public static IList GetSponsorContacts_NameAndCodeOnly(string sponsorName)
        {
           
            IList results = new ArrayList();
         
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                   // using (SqlCommand command = new SqlCommand(SelectSponsorContactsQueryNew, connection))
                    using (SqlCommand command = new SqlCommand(ContactInfoBySponsor, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@SponsorName", SqlDbType.NVarChar).Value = sponsorName;

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Item item = new Item();
                            item.Name = "Contact";
                            item.Value = reader[1].ToString();
                            item.Text = reader[3].ToString();
                            results.Add(item);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetSponsorContacts_NameAndCodeOnly", sqlEx);
            }
          
            return results;
        }

       public static SponsorContact GetContactBySponsorName(string sponsorName)
        {
            SponsorContact result = new SponsorContact();
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(ContactInfoBySponsorCode, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@SponsorName", SqlDbType.NVarChar).Value = sponsorName;

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            result = CreateNewSponsorWithoutContactName(reader);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetContactBySponsorName", sqlEx);
            }
            return result;
        }

       //update- Get certain sponsor info.
       public static SponsorContact GetContactBySponsorCode(string sponsorCode)
       {
           SponsorContact result = new SponsorContact();
           try
           {
               using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
               {
                   connection.Open();
                   using (SqlCommand command = new SqlCommand(ContactInfoBySponsorCode, connection))
                   {
                       command.CommandType = CommandType.Text;
                       command.Parameters.Add("@SponsorCode", SqlDbType.NVarChar).Value = sponsorCode;

                       SqlDataReader reader = command.ExecuteReader();
                       while (reader.Read())
                       {
                           result = CreateNewSponsorWithoutContactName(reader);
                       }
                   }
               }
           }
           catch (SqlException sqlEx)
           {
               ErrorHandler.CreateLogFile(ErrorFormName, "GetContactBySponsorName", sqlEx);
           }
           return result;
       }

       public static Item GetSponsorByContactCode(string contactCode)
        {   
            Item item = new Item();
         
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(ContactInfoByContactCode, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@ContactCode", SqlDbType.NVarChar).Value = contactCode;

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            
                            //item.Name = 'Contact';
                            item.Value = reader[3].ToString();
                            item.Text = reader[11].ToString();
                           
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetSponsorByContactCode", sqlEx);
            }
            return item;
        }

        //Update- Get sponsor list with searched sponsor name.
        public static IList GetSponsorContacts(string sponsorName)
        {
            IList results = new ArrayList();
            sponsorName += "%";
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(SelectSponsorContactsQuery, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("@SponsorName", SqlDbType.NVarChar).Value = sponsorName;

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            SponsorContact sponsor = CreateNewSponsorWithoutContactName(reader);
                            results.Add(sponsor);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetSponsorContacts", sqlEx);
            }

            return results;
        }

        //update- Get sponsor names.
        public static IList GetSponsorNames(IList sponsors)
        {
            IList<Item> results = new List<Item>();
            
            try
            {
                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    SqlDataReader reader;
                    using (SqlCommand command = new SqlCommand(SelectSponsorNames, connection))
                    {
                        command.CommandType = CommandType.Text;

                        

                        foreach (Item item in sponsors)
                        {
                            
                            command.Parameters.Clear();
                            command.Parameters.Add("@SponsorCode", SqlDbType.NVarChar).Value = item.Name;
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                item.Text = reader[0].ToString().Trim();
                                results.Add(item);
                            }
                           reader.Close();  
                        }
                      
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                ErrorHandler.CreateLogFile(ErrorFormName, "GetSponsorNames", sqlEx);
            }
            IEnumerable<Item> tmp = results.OrderBy(x => x.Text);

            IList sortedItems = tmp.ToList();

            return sortedItems;
        }
          
        
     public static string GetSponsorNameBySponsorCode(string sponsorCode)
        {
            
            string sponName = "";

                using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
                {
                    connection.Open();
                    SqlDataReader reader;
                    using (SqlCommand command = new SqlCommand(SelectSponsorNames, connection))
                    {
                            command.CommandType = CommandType.Text;
                            command.Parameters.Clear();
                            command.Parameters.Add("@SponsorCode", SqlDbType.NVarChar).Value = sponsorCode;
                            reader = command.ExecuteReader();
                            while (reader.Read()){
                            sponName = reader[0].ToString().Trim();}       
                            reader.Close();   
                        
                     }
                   
                } 
           return sponName;
            
        }

        /*    private static SponsorContact CreateNewSponsor(SqlDataReader reader)
        {
            SponsorContact sponsor = new SponsorContact();
            sponsor.SponsorCode = reader[0].ToString().Trim();
            sponsor.ContactCode = reader[1].ToString().Trim();
            sponsor.SponsorName = reader[2].ToString().Trim();
            sponsor.ContactName = reader[3].ToString().Trim();
            sponsor.Address = reader[4].ToString().Trim();
            sponsor.City = reader[5].ToString().Trim();
            sponsor.State = reader[6].ToString().Trim();
            sponsor.ZipCode = reader[7].ToString().Trim();
            sponsor.Country = reader[8].ToString().Trim();
            sponsor.PhoneNumber = reader[9].ToString().Trim();
            sponsor.FaxNumber = reader[10].ToString().Trim();
            sponsor.Email = reader[11].ToString().Trim();
            
            return sponsor;
        }*/

        private static SponsorContact CreateNewSponsorWithoutContactName(SqlDataReader reader)
        {
            SponsorContact sponsor = new SponsorContact();
            sponsor.SponsorCode = reader[0].ToString().Trim(); 
            sponsor.SponsorName = reader[1].ToString().Trim();  
            sponsor.Address = reader[2].ToString().Trim();
            sponsor.City = reader[3].ToString().Trim();
            sponsor.State = reader[4].ToString().Trim();
            sponsor.ZipCode = reader[5].ToString().Trim();
            sponsor.Country = reader[6].ToString().Trim();
            sponsor.PhoneNumber = reader[7].ToString().Trim();
            sponsor.FaxNumber = reader[8].ToString().Trim();
            return sponsor;
        }
    }
}
