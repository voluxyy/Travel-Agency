using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LasserreDetresTravelAgency.Business.Dto
{
    public class FavoryDto
    {
        public int Id { get; set; }
        public bool IsFavorite { get; set; }
        public int UserId { get; set; }
        public int DestinationId { get; set; }
    }
}
