using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Core.ViewModels.Cars
{
    public class CarListVM
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public decimal Price { get; set; }
        public string CarModel { get; set; }
        public bool Insurance { get; set; }
        public string Company { get; set; }
    }
}
