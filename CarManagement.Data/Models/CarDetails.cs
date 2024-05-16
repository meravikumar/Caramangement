using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManagement.Data.Models
{
    public class CarDetails
    {
        [Key]
        public int CarDetail_Id { get; set; }

        [Required]
        public int Engine { get; set; }
        public int NumberOfAirbags { get; set; }
        public string Weight { get; set; }
        public String Type { get; set; }
        public decimal SafetRating {  get; set; }

        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }

    }
}
