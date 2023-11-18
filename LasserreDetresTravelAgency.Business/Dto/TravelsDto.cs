namespace LasserreDetresTravelAgency.Business.Dto
{
    public class TravelsDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DestinationId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int TravelTypeId { get; set; }
    }
}
