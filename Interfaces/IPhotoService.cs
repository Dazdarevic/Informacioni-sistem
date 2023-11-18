using CloudinaryDotNet.Actions;

namespace Informacioni_sistemi___Projekat.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

    }
}
