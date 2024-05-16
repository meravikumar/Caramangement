using AutoMapper;
using CarManagement.Core.ViewModels.Companies;
using CarManagement.Data.Models;

namespace CarManagement.Core.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Company ,CreateCompanyVM>();
            CreateMap<CreateCompanyVM, Company>();
        }
    }
}
