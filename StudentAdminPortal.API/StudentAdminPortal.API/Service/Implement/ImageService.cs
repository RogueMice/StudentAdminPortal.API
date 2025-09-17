using StudentAdminPortal.API.Service.Interface;

namespace StudentAdminPortal.API.Service.Implement
{
    public class ImageService : IImageService
    {
        public async Task<string> UploadAsync(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Resources/Images", fileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return GetServerRelativePath(fileName);
        }

        private string GetServerRelativePath(string fileName)
        {
            return $"/Resources/Images/{fileName}";
        }
    }
}
