namespace Informacioni_sistemi___Projekat.Models
{
    public class City
    {
        public int? CityID { get; set; }
        public string? NameOfCity { get; set; }
        public ICollection<AdvertisingPanel>? AdvertisingPanels { get; set; }
        
        public ICollection<CityArea>? CityAreas { get; set; }

    }
}
