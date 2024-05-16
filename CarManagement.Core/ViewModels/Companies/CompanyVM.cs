using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CarManagement.Core.ViewModels.Cars;

namespace CarManagement.Core.ViewModels.Companies
{
    public class CompanyVM
    {
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string CEO { get; set; }
        public bool IsFinanceProvider { get; set; }
        public DateOnly EstablishedDate { get; set; }
        private List<CarVM> _cars = new List<CarVM>();
        public List<CarVM> Cars
        {
            get => _cars;
            set => _cars = value ?? new List<CarVM>();
        }
    }
}
