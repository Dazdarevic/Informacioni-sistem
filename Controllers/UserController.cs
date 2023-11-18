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
    public class UserController : ControllerBase
    {
#pragma warning disable IDE0052 // Remove unread private members
        private readonly DataContext _dataContext;
#pragma warning restore IDE0052 // Remove unread private members
#pragma warning disable IDE0052 // Remove unread private members
        private readonly IConfiguration _configuration;
#pragma warning restore IDE0052 // Remove unread private members
#pragma warning disable IDE0052 // Remove unread private members
        private readonly IEmailSender _emailSender;
#pragma warning restore IDE0052 // Remove unread private members

        public UserController(DataContext dataContext, IConfiguration configuration, IEmailSender emailSender)
        {
            _dataContext = dataContext;
            _configuration = configuration;
            _emailSender = emailSender;

        }

        [HttpGet]
        public IActionResult GetUsers(string? role)
        {
            IQueryable<User> users = _dataContext.Users;

            if (!string.IsNullOrEmpty(role))
            {
                users = users.Where(u => u.UserRole == role);
            }

            var userList = users.ToList();

            return Ok(userList);
        }

        [Authorize]
        [HttpGet("role")]
        public IActionResult GetUsersByRole(string? role)
        {
            IQueryable<User> users = _dataContext.Users;

            if (!string.IsNullOrEmpty(role))
            {
                users = users.Where(u => u.UserRole == "client");
            }

            var userList = users.ToList();

            return Ok(userList);
        }


        [HttpPost("SendEmail")]
        public async Task<IActionResult> Index([FromBody] EmailModel emailModel)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            await _emailSender.SendEmailAsync(emailModel.Email, emailModel.Subject, emailModel.Message);
#pragma warning restore CS8604 // Possible null reference argument.
            return Ok();
        }

        [HttpPost("CheckEmailExists")]
        public async Task<ActionResult<bool>> CheckEmailExists(UserEmailModel userEmailModel)
        {
            var exists = await _dataContext.Users.AnyAsync(u => u.UserEmail == userEmailModel.UserEmail);
            return Ok(new { exists });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            if (_dataContext.Users == null)
            {
                return NotFound();
            }
            var user = await _dataContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.ID }, user);
        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult<User>> PutUser(int id, User user)
        {
            if (id != user.ID)
            {
                return BadRequest();
            }
            _dataContext.Entry(user).State = EntityState.Modified;
            try
            {
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }

        [Authorize]
        [HttpPut("updateUser/{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, UpdateUserModel user)
        {
            var existingUser = await _dataContext.Users.FindAsync(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            // Djelomično ažuriranje: Postavite samo odabrane polja iz updatedUser na postojećeg korisnika
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.UserName = user.UserName;

            try
            {
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Obrada izuzetka
                throw;
            }

            return Ok(existingUser);
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _dataContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _dataContext.Users.Remove(user);
            await _dataContext.SaveChangesAsync();

            return Ok();
        }

    }
}
