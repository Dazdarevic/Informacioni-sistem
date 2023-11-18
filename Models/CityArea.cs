using System.ComponentModel.DataAnnotations;

namespace Informacioni_sistemi___Projekat.Models
{
    public class CityArea
    {
        [Key]
        public int? CityAreaID { get; set; }
        public string? NameOfArea { get; set; }
        public int? CityID { get; set; } 
        public City? City { get; set; } 

    }
}
