using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Business
{
    public class DestinationDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int? CategoryId { get; set; }
        public string City { get; set; }
        public bool Capital { get; set; }
        public string[] ToDo { get; set; }
    }
}
