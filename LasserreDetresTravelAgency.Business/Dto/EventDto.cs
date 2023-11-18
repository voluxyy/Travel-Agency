namespace LasserreDetresTravelAgency.Business.Dto
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int DestinationId { get; set; }
    }
}
