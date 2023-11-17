using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace LasserreDetresTravelAgency.Data.Models
{
    public class Continent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Country> countries { get; set; }
    }
}
