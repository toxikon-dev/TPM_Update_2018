﻿using Toxikon.ProtocolManager.Queries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Models.Protocols;

namespace Toxikon.ProtocolManager.Models
{
    public class ProtocolRequest
    {
        public int ID { get; set; }
        public string RequestedBy { get; set; }
        public DateTime RequestedDate { get; set; }
        public SponsorContact Contact { get; private set; }
        public Sponsor Sponsor { get; private set; }
        public string Guidelines { get; set; }
        public string Compliance { get; set; }
        public string ProtocolType { get; set; }
        public DateTime DueDate { get; set; }
        public string SendVia { get; set; }
        public string BillTo { get; set; }
        public string Cost { get; set; }
        public string Comments { get; set; }
        public User AssignedTo { get; set; }
        public string PO { get; set; }

        public string RequestStatus { get; set; }
        public bool IsActive { get; set; }

        public int AssignedPNCount { get; set; }
        public int TemplateCount { get; set; }

        public ProtocolRequest()
        {
            Refresh();
        }

        public void Refresh()
        {
            this.ID = 0;
            this.RequestedBy = "";
            this.RequestedDate = DateTime.Now;           
            this.Contact = new Models.SponsorContact();
            this.Guidelines = "";
            this.Compliance = "";
            this.ProtocolType = "";
            this.DueDate = DateTime.Now;
            this.SendVia = "";
            this.BillTo = "Toxikon";
            this.Cost = "";
            this.Comments = "";
            this.AssignedTo = new User();
            this.PO = "";
            this.IsActive = true;
        }

        public void SetContact(SponsorContact contact)
        {
            this.Contact.SponsorCode = contact.SponsorCode;
            this.Contact.ContactCode = contact.ContactCode;
            this.Contact.SponsorName = contact.SponsorName;
            this.Contact.ContactName = contact.ContactName;
            this.Contact.Address = contact.Address;
            this.Contact.City = contact.City;
            this.Contact.State = contact.State;
            this.Contact.ZipCode = contact.ZipCode;
            this.Contact.PhoneNumber = contact.PhoneNumber;
            this.Contact.FaxNumber = contact.FaxNumber;
            this.Contact.Email = contact.Email;
            //add country to contact info
            this.Contact.Country = contact.Country;
            System.Diagnostics.Debug.WriteLine("Successful sponsor assignment");
        }

        public void SetContact(string contactCode)
        {
            this.Contact.ContactCode = contactCode;
            Item item = QMatrix.GetSponsorByContactCode(contactCode);
            this.Contact.ContactName = item.Value;
            this.Contact.Email = item.Text;
           

        }
        public void SetContactNew(string sponsorCode)
        {
            this.Contact.SponsorCode = sponsorCode;
            this.Contact = QMatrix.GetContactBySponsorCode(sponsorCode);
           
        }
       
        public void CloseRequest()
        {
            this.RequestStatus = RequestStatuses.Closed;
            this.IsActive = false;
            LoginInfo loginInfo = LoginInfo.GetInstance();
            QProtocolRequests.UpdateRequestStatus(this, loginInfo.UserName);
        }
    }
}
