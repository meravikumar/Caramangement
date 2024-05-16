using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Core.ViewModels.Companies
{
    public class CreateCompanyVM
    {
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string CEO { get; set; }
        public bool IsFinanceProvider { get; set; }
        public DateTime? EstablishedDate { get; set; }
    }
}
