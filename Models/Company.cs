using System.ComponentModel.DataAnnotations;

namespace Informacioni_sistemi___Projekat.Models
{
    public class Company
    {
        [Key]
        public int? companyID { get; set; }
        public string? companyPIB { get; set; }
        public string? companyName { get; set; }
        public string? companyAddress { get; set; }
        public string? companyOwner { get; set; }


        public string? companyEmail { get; set; }
        public string? companySector { get; set; }
        public string? companyLogo { get; set; }
        public string? companyTel { get; set; }
        public string? companyTel2 { get; set; } 

        public string? Url { get; set; }
        public bool IsMain { get; set; }
        public string? PublicId { get; set; }

        public int? UserID { get; set; }
        public User? User { get; set; }

    }
}
