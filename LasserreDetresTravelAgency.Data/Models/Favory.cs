namespace LasserreDetresTravelAgency.Data.Models
{
    public class Favory
    {
        public int Id { get; set; }
        public bool IsFavorite { get; set; }
        public int UserId { get; set; }
        public int DestinationId { get; set; }
    }
}
