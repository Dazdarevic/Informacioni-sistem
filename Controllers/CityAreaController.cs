using Informacioni_sistemi___Projekat.Interfaces;
using Informacioni_sistemi___Projekat.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Informacioni_sistemi___Projekat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityAreaController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IPhotoService _photoService;

        public CityAreaController(DataContext dataContext, IPhotoService photoService)
        {
            _dataContext = dataContext;
            _photoService = photoService;
        }

        [HttpGet("by-city-id/{id}")]
        public async Task<ActionResult> GetAreas(int id)
        {
            var nameOfAreas = await _dataContext.CityAreas
                                .Where(area => area.CityID == id)
                                .Select(areas => areas.NameOfArea)
                                .Distinct()
                                .ToListAsync();

            var cityAreas = await _dataContext.AdvertisingPanels
                            .Select(panel => panel.CityArea)
                            .Distinct()
                            .ToListAsync();


            var filteredNameOfAreas = nameOfAreas.Except(cityAreas).ToList();
            var matchingCityAreas = await _dataContext.CityAreas
            .Where(area => filteredNameOfAreas.Contains(area.NameOfArea))
            .ToListAsync();

            if (matchingCityAreas == null || matchingCityAreas.Count == 0)
            {
                return NotFound();
            }

            return Ok(matchingCityAreas);
        }

        [HttpPost("add-photo")]
        public async Task<IActionResult> UploadPhotoNew(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var uploadResult = await _photoService.AddPhotoAsync(file);

            if (uploadResult.Error != null)
            {
                // Handling error case
                return BadRequest(uploadResult.Error.Message);
            }

            // The photo was successfully uploaded
            var imageUrl = uploadResult.SecureUrl.ToString();
            var publicId = uploadResult.PublicId;

            var photo = new AdvertisingPanel
            {
                Url = imageUrl,
                IsMain = false,
                PublicId = publicId,
            };

            return Ok(photo);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityArea>>> GetAllCityAreas()
        {
            var areas = await _dataContext.CityAreas.ToListAsync();
            return Ok(areas);
        }
    }
}
