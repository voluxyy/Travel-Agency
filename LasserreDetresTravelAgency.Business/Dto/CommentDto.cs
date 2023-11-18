namespace LasserreDetresTravelAgency.Business
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int DestinationId { get; set; }
    }
}
