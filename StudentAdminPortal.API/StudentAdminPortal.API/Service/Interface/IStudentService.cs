using StudentAdminPortal.API.Data.Model;
using StudentAdminPortal.API.DTO;

namespace StudentAdminPortal.API.Service.Interface
{
    public interface IStudentService
    {
        Task<List<StudentDTO>> GetAsync();

        Task<StudentDTO> GetByIdAsync(Guid studentId);
    }
}
