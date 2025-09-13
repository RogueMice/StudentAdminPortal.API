using AutoMapper;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using StudentAdminPortal.API.Data.Model;
using StudentAdminPortal.API.DTO;

namespace StudentAdminPortal.API.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();

            CreateMap<Student, StudentViewDTO>()
            .ForMember(dest => dest.PhysicalAddress,
                opt => opt.MapFrom(src => src.Address != null ? src.Address.PhysicalAddress : null))
            .ForMember(dest => dest.PostalAddress,
                opt => opt.MapFrom(src => src.Address != null ? src.Address.PostalAddress : null));

            CreateMap<Gender, GenderDTO>().ReverseMap();

            CreateMap<Address, Address>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();
        }
    }
}
