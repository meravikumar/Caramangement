using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManagement.Data.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public string CarName { get; set; }
        public Decimal Price {  get; set; }
        public string CarModel { get; set; }
        public bool Insurance {  get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public CarDetails CarDetails { get; set; }
    }
}
