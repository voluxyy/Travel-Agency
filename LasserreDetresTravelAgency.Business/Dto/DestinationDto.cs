using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Business
{
    public class DestinationDto
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public bool Capital { get; set; }
        public string[] ToDo { get; set; }
        public int NbVisited { get; set; }
        public double? AverageRate { get; set; }
        public CommentDisplayed[]? Commentaries { get; set; }
    }
    
    public class CommentDisplayed
    {
        public string UserName { get; set; }
        public string Comment { get; set; }
    }
}
