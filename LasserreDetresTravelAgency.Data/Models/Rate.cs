namespace LasserreDetresTravelAgency.Data.Models
{
    public class Rate
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int UserId { get; set; }
        public int DestinationId { get; set; }
    }
}
