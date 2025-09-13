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
            var result = await dbContext.Students
                .Include(nameof(Gender))
                .Include(nameof(Address))
                .ToListAsync();
            return mapper.Map<List<StudentDTO>>(result);
        }

        public async Task<StudentDTO> GetByIdAsync(Guid studentId)
        {
            var result = await dbContext.Students
                .Include(nameof(Gender))
                .Include(nameof(Address))
                .FirstOrDefaultAsync(x => x.Id == studentId);
            return mapper.Map<StudentDTO>(result);
        }

        public async Task<UpdateStudentDTO> UpdateAsync(Guid studentId, UpdateStudentDTO dto)
        {
            var existingStudent = await dbContext.Students
                .Include(s => s.Address)
                .FirstOrDefaultAsync(x => x.Id == studentId)
                ?? throw new Exception($"Not found studentId {studentId}!");
            var genderExisting = await dbContext.Genders.FindAsync(dto.GenderId)
                ?? throw new Exception($"Not found genderId {dto.GenderId}");

            existingStudent.FirstName = dto.FirstName;
            existingStudent.LastName = dto.LastName;
            existingStudent.DateOfBirth = dto.DateOfBirth;
            existingStudent.Email = dto.Email;
            existingStudent.Mobile = dto.Mobile;
            existingStudent.GenderId = dto.GenderId;
            existingStudent.Address.PhysicalAddress = dto.PhysicalAddress;
            existingStudent.Address.PostalAddress = dto.PostalAddress;
            await dbContext.SaveChangesAsync();
            return mapper.Map<UpdateStudentDTO>(existingStudent);
        }

        public async Task<Guid> DeleteAsync(Guid studentId)
        {
            var existingStudent = await dbContext.Students.FirstOrDefaultAsync(x => x.Id == studentId)
                ?? throw new Exception($"Not found studentId {studentId}!");

            dbContext.Students.Remove(existingStudent);
            await dbContext.SaveChangesAsync();
            return existingStudent.Id;
        }
    }
}
