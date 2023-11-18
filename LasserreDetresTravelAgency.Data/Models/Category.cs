﻿namespace LasserreDetresTravelAgency.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Destination>? Destinations { get; set; }
    }
}
