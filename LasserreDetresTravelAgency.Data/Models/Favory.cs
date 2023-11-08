namespace LasserreDetresTravelAgency.Data.Models
{
    public class Favory
    {
        public int Id { get; set; }
        public bool IsFavorite { get; set; }
        public ICollection<Destination>? Destinations { get; set; }
    }
}
