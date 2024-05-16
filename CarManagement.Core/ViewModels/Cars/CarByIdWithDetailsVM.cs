using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManagement.Core.ViewModels.CarDetails;
using CarManagement.Data.Models;

namespace CarManagement.Core.ViewModels.Cars
{
    public class CarByIdWithDetailsVM
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public decimal Price { get; set; }
        public string CarModel { get; set; }
        public bool Insurance { get; set; }
        public CarDetailVM CarDetail { get; set; }
    }
}
