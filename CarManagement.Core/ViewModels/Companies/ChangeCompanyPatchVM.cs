using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Core.ViewModels.Companies
{
    public class ChangeCompanyPatchVM
    {
        [Required]
        public string Name { get; set; }
    }
}
