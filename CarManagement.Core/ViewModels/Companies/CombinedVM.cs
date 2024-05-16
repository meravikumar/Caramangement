using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Core.ViewModels.Companies
{
	public class CombinedVM
	{
		public List<CompanyVM> companiesVM { get; set; }
		public List<CreateCompanyVM> createCompaniesVM { get; set; }
		
	}
}
