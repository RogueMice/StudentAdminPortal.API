using StudentAdminPortal.API.DTO;

namespace StudentAdminPortal.API.Service.Interface
{
    public interface IGenderService
    {
        Task<List<GenderDTO>> GetAllAsync();
    }
}
