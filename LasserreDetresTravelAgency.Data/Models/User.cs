using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LasserreDetresTravelAgency.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
        public DateOnly Birthday { get; set; }
        public string? Description { get; set; }
        public ICollection<Rate> Rates { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Visit> Visits { get; set; }
        public ICollection<Favory> Favories { get; set; }
        public ICollection<Travels> Travelers { get; set; }
    }
}
