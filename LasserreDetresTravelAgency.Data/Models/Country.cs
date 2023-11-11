using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace LasserreDetresTravelAgency.Data.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Destination> destinations { get; set; }
        public int ContinentId { get; set; }
    }
}
