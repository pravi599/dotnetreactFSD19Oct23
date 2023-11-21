using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApplication.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public string UserEmail { get; set; }
        [ForeignKey("UserEmail")]
        public User User { get; set; }
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        public string BookingDate { get; set; }
        public int TotalRooms { get; set; }
        public float Price { get; set; }
        //public ICollection<Room> Rooms { get; set; }

    }
}
