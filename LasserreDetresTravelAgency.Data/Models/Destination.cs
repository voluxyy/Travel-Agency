using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace LasserreDetresTravelAgency.Data.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string City { get; set; }
        public bool Capital { get; set; }
        public string ToDo { get; set; }
        public ICollection<Visit>? Visits { get; set; }
        public double? AverageRate { get; set; }
        public ICollection<Rate>? Rates { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public int? CategoryId { get; set; }
    }
}
