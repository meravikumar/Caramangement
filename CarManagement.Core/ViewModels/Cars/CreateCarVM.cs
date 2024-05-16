using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Core.ViewModels.Cars
{
    public class CreateCarVM
    {
        [MinLength(3)]
        public string CarName { get; set; }
        public decimal Price { get; set; }
        public string CarModel { get; set; }
        public bool Insurance { get; set; }
        [Required]
        public int CompanyId { get; set; }
    }
}
