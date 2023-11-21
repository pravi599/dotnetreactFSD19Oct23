using System.ComponentModel.DataAnnotations;

namespace HotelApplication.Models
{
    public class User
    {
        public string Name { get; set; }
        [Key]
        public string UserEmail { get; set; }

        public byte[] Password { get; set; }


        public string PhoneNo { get; set; }

        public string Address { get; set; }
      
        public string Role { get; set; }
        public byte[] Key { get; set; }

        public ICollection<Room> Rooms { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}