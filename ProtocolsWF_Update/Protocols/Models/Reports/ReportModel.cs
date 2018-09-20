using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toxikon.ProtocolManager.Models.Reports
{
    public class ReportModel
    {
        public ProtocolRequest ProtocolRequest { get; set; }
        public ProtocolNumber ProtocolNumber { get; set; }
        public ProtocolEvent ProtocolEvent { get; set; }
        public ProtocolActivity ProtocolActivity { get; set; }
        public ProtocolTemplate ProtocolTemplate { get; set; }
        public Comment Comment { get; set; }
        public string Year { get; set; }
        public string QNumber { get; set; }
     
           
        public ReportModel()
        {
            this.ProtocolRequest = new ProtocolRequest();
            this.ProtocolNumber = new ProtocolNumber();
            this.ProtocolEvent = new ProtocolEvent();
            this.ProtocolActivity = new ProtocolActivity();
            this.ProtocolTemplate =new ProtocolTemplate();
            this.Comment = new Comment();       
                        
            this.Year = "";
            this.QNumber = "";
        }

    }
}
