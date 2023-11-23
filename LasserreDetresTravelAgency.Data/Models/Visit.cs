namespace LasserreDetresTravelAgency.Data.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime DateVisited { get; set; }
        public int UserId { get; set; }
        public int DestinationId { get; set; }
    }
}
