using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LasserreDetresTravelAgency.Data.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public bool Capital { get; set; }
        public string ToDo { get; set; }
        public ICollection<Visit>? Visits { get; set; }
        public double? AverageRate { get; set; }
        public ICollection<Rate>? Rates { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
