using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Core.ViewModels.CarDetails
{
    public class CarDetailVM
    {
        public int CarDetail_Id { get; set; }

        [Required]
        public int Engine { get; set; }
        public int NumberOfAirbags { get; set; }
        public string Weight { get; set; }
        public string Type { get; set; }
        public decimal SafetRating { get; set; }
    }
}
