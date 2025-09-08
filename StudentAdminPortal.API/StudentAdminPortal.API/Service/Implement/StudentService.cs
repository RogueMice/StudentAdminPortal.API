using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.Data.Context;
using StudentAdminPortal.API.Data.Model;
using StudentAdminPortal.API.DTO;
using StudentAdminPortal.API.Service.Interface;

namespace StudentAdminPortal.API.Service.Implement
{
    public class StudentService : IStudentService
    {
        private readonly StudentAdminContext dbContext;
        private readonly IMapper mapper;

        public StudentService(StudentAdminContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<List<StudentDTO>> GetAsync()
        {
            var result = await dbContext.Students.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
            return mapper.Map<List<StudentDTO>>(result);
        }
    }
}
