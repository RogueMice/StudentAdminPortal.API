using StudentAdminPortal.API.Data.Model;
using StudentAdminPortal.API.DTO;

namespace StudentAdminPortal.API.Service.Interface
{
    public interface IStudentService
    {
        Task<List<StudentDTO>> GetAsync();

        Task<StudentDTO> GetByIdAsync(Guid studentId);

        Task<StudentViewDTO> UpdateAsync(Guid studentId, StudentViewDTO dto);

        Task<Guid> DeleteAsync(Guid studentId);

        Task<StudentViewDTO> AddAsync(StudentViewDTO dto);
    }
}
