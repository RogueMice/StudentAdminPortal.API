using AutoMapper;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using StudentAdminPortal.API.Data.Model;
using StudentAdminPortal.API.DTO;

namespace StudentAdminPortal.API.Mapper
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();

            CreateMap<Gender, Gender>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();

            CreateMap<Address, Address>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();
        }
    }
}
