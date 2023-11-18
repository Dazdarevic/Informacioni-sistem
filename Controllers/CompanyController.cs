 using Informacioni_sistemi___Projekat.Interfaces;
using Informacioni_sistemi___Projekat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Informacioni_sistemi___Projekat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IPhotoService _photoService;

        public CompanyController(DataContext dataContext, IPhotoService photoService)
        {
            _dataContext = dataContext;
            _photoService = photoService;
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

            var photo = new Company
            {
                Url = imageUrl,
                IsMain = false,
                PublicId = publicId,
            };

            //_userContext.Player.Add(photo);
            //await _userContext.SaveChangesAsync();

            // Perform further processing or save the photo object to the database

            return Ok(photo);
        }

        [Authorize]
        [HttpGet("mycompanies/{userId}")]
        public async Task<ActionResult<Company>> GetCompanies(int userId)
        {
            var companies = await _dataContext.Companies.Where(company => company.UserID == userId).ToListAsync();
            if(companies == null || companies.Count == 0)
            {
                return NotFound();
            }

            return Ok(companies);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            if (_dataContext.Companies == null)
            {
                return NotFound();
            }
            var company = await _dataContext.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return company;
        }

        [HttpGet("all-companies/{id}")]
        public async Task<ActionResult<Company>> GetAllCompanies(int id)
        {
            if (_dataContext.Companies == null)
            {
                return NotFound();
            }
            var company = await _dataContext.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return company;
        }

        [Authorize]
        [HttpGet("by-user-id/{userId}")]
        public async Task<ActionResult<List<Company>>> GetCompaniesByUserId(int userId)
        {
            if (_dataContext.Companies == null)
            {
                return NotFound();
            }

            var companies = await _dataContext.Companies.Where(c => c.UserID == userId).ToListAsync();
            if (companies == null || companies.Count == 0)
            {
                return NotFound();
            }

            return companies;
        }

        [Authorize]
        [HttpPost("add-company")]
        public async Task<ActionResult<Company>> PostPlayer(Company company)
        {
            _dataContext.Companies.Add(company);
            await _dataContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCompany), new { id = company.companyID }, company);
        }

        [HttpDelete("delete-company/{id}")]
        public async Task<ActionResult<Company>> DeleteCompany(int id)
        {
            var company = await _dataContext.Companies.FindAsync(id);
            if(company == null)
            {
                return NotFound();
            }
            _dataContext.Companies.Remove(company);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }

    }
}
