using LasserreDetresTravelAgency.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LasserreDetresTravelAgency.Business.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }
        public string Description { get; set; }
        public ICollection<Destination>? Destinations { get; set; }
    }
}
