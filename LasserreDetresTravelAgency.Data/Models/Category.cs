namespace LasserreDetresTravelAgency.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }
        public string Description { get; set; }
        public ICollection<Destination>? Destinations { get; set; }
    }
}
