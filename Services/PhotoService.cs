using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Informacioni_sistemi___Projekat.Interfaces;
using Informacioni_sistemi___Projekat.Models;
using Microsoft.Extensions.Options;


namespace Informacioni_sistemi___Projekat.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public PhotoService(IOptions<CloudinarySettings> config)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            var acc = new Account
            (
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face"),
                    Folder = "da-net7"
                };

                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            // Assign the additional metadata to the upload result

            return uploadResult;
        }

    }
}