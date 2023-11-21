using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApplication.Models.DTOs
{
    public class BookingDTO
    {

        [Required(ErrorMessage = "User ID cannot be empty")]
        public String UserEmail { get; set; }

        [Required(ErrorMessage = "Room ID cannot be empty")]
        public int RoomId { get; set; }

        /// <summary>
        /// Gets or sets the total number of rooms for a reservation.
        /// </summary>
        [Required(ErrorMessage = "Total rooms cannot be empty")]
        public int TotalRooms { get; set; }

    }
}