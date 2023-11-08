namespace LasserreDetresTravelAgency.Business
{
    public class VisitDto
    {
        public int Id { get; set; }
        public bool IsVisited { get; set; }
        public DateTime DateVisited { get; set; }
        public int UserId { get; set; }
        public int DestinationId { get; set; }       
    }
}
