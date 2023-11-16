using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Business.Dto
{
    public class TravelTypeDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Travels>? Travels { get; set; }
    }
}
