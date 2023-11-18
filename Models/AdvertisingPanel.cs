using System.ComponentModel.DataAnnotations;

namespace Informacioni_sistemi___Projekat.Models
{
    public class AdvertisingPanel
    {
        [Key]
        public int? PanelID { get; set; }
        public string? Address { get; set; }
        public string? Dimension { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public string? AdvertisementPhoto { get; set; }

        public string? NumberOfDays { get; set; }
        public string? Price { get; set; }
        public string? Lights { get; set; }
        public string? CityArea { get; set; }
        public string? SelectedCompany { get; set; }
        public int? CityID { get; set; }
        public City? City { get; set; }

        public string? Url { get; set; }
        public bool IsMain { get; set; }
        public string? PublicId { get; set; }

        public int? UserID { get; set; }
        public User? User { get; set; }
    }
}
