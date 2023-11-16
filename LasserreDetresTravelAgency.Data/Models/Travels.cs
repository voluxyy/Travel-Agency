using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LasserreDetresTravelAgency.Data.Models
{
    public class Travels
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DestinationId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int TravelTypeId { get; set; }
    }
}
