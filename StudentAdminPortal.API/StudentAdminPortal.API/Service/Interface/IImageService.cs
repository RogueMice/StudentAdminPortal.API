namespace StudentAdminPortal.API.Service.Interface
{
    public interface IImageService
    {
        Task<string> UploadAsync(IFormFile file, string fileName);
    }
}
