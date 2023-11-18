using System.ComponentModel.DataAnnotations;

namespace Informacioni_sistemi___Projekat.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthdayDate { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public string? UserRole { get; set; }
        public string? Gender { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<Company>? Companies { get; set; }


    }
}
