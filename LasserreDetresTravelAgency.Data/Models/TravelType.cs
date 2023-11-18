using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LasserreDetresTravelAgency.Data.Models
{
    public class TravelType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Travels>? Travels { get; set; }
    }
}
