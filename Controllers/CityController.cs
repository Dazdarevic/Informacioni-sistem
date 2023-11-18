using Informacioni_sistemi___Projekat.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Informacioni_sistemi___Projekat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public CityController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetAllCities()
        {
            var cities = await _dataContext.Cities.ToListAsync();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCityName(int id)
        {
            if (_dataContext.Cities == null)
            {
                return NotFound();
            }
            var city = await _dataContext.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return city;
        }

    }
}
