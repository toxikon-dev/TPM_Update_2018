using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toxikon.ProtocolManager.Controllers.Reports;
using Toxikon.ProtocolManager.Views.Reports;
using Toxikon.ProtocolManager.Models.Reports;

namespace Toxikon.ProtocolManager.Interfaces.Reports
{
    public interface IReportView
    {      
       void SetController(ReportViewController controller);

       void AddControlToMainPanel(Control control);
        
      Control ParentControl { get; }
    }
}
