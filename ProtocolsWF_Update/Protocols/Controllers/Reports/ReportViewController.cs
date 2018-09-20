using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toxikon.ProtocolManager.Interfaces.Reports;
using Toxikon.ProtocolManager.Views.Reports;
using Toxikon.ProtocolManager.Queries;
using Toxikon.ProtocolManager.Models.Reports;
using System.Windows.Forms;


namespace Toxikon.ProtocolManager.Controllers.Reports
{
       
   public class ReportViewController
   {
       IReportView view;

       public ReportViewController (IReportView view)       
       {
            this.view = view;
            this.view.SetController(this);
       
       }

   }
       
}
