using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarManagement.Data.Models
{
    public class Company
    {

        [Key]
        public int CompanyId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string CEO {  get; set; }
        public bool IsFinanceProvider { get; set; }
        
        public DateOnly EstablishedDate { get; set; }
        public List<Car> Cars { get; set; }



    }
}
