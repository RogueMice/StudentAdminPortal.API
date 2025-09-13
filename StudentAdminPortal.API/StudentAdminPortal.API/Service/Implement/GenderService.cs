using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.Data.Context;
using StudentAdminPortal.API.DTO;
using StudentAdminPortal.API.Service.Interface;

namespace StudentAdminPortal.API.Service.Implement
{
    public class GenderService : IGenderService
    {
        private readonly StudentAdminContext dbContext;
        private readonly IMapper mapper;

        public GenderService(StudentAdminContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<List<GenderDTO>> GetAllAsync()
        {
            var genders = await dbContext.Genders.ToListAsync();
            return mapper.Map<List<GenderDTO>>(genders);
        }
    }
}
