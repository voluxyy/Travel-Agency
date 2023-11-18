using LasserreDetresTravelAgency.Data.Models;

namespace LasserreDetresTravelAgency.Business
{
    public class UserDto
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
        public DateOnly Birthday { get; set; }
        public string? Description { get; set; }
    }
}
