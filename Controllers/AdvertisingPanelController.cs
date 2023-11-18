using Informacioni_sistemi___Projekat.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Informacioni_sistemi___Projekat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisingPanelController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public AdvertisingPanelController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AdvertisingPanel>> GetPanel(int id)
        {
            if (_dataContext.AdvertisingPanels == null)
            {
                return NotFound();
            }
            var panel = await _dataContext.AdvertisingPanels.FindAsync(id);
            if (panel == null)
            {
                return NotFound();
            }
            return panel;
        }

        [Authorize]
        [HttpGet("by-user-id/{id}")]
        public async Task<ActionResult<List<AdvertisingPanel>>> GetPanelsByUserId(int id)
        {
            if(_dataContext.AdvertisingPanels == null)
            {
                return NotFound();
            }

            var panels = await _dataContext.AdvertisingPanels.Where(panel => panel.UserID == id).ToListAsync();
            if(panels == null || panels.Count == 0)
            {
                return NotFound();
            }

            return panels;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdvertisingPanel>>> GetAllPanels()
        {
            var panels = await _dataContext.AdvertisingPanels.ToListAsync();

            return Ok(panels);
        }

        [HttpPost("add-advertisement")] 
        public async Task<ActionResult<AdvertisingPanel>> AddAdvertisement(AdvertisingPanel advertisingPanel)
        {
            _dataContext.AdvertisingPanels.Add(advertisingPanel);
            await _dataContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPanel), new { id = advertisingPanel.PanelID }, advertisingPanel);
        }

        [HttpDelete("delete-ad/{id}")]
        public async Task<ActionResult<AdvertisingPanel>> DeleteAd(int id)
        {
            var ad = await _dataContext.AdvertisingPanels.FindAsync(id);
            if (ad == null)
            {
                return NotFound();
            }
            _dataContext.AdvertisingPanels.Remove(ad);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }
    }
}
