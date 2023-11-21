using HotelApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApplication.Models
{
    public class Hotel
    {

        [Key]
        public int HotelId { get; set; }


        public string UserEmail { get; set; }
        [ForeignKey("UserEmail")]
        public User user { get; set; }

        public string HotelName { get; set; }


        public string Address { get; set; }

        public string PhoneNo { get; set; }


        public string? Description { get; set; }

        public ICollection<Room> Rooms { get; set; }


    }
}