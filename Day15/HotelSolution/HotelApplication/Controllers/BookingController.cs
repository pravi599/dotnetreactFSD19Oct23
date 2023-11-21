using HotelApplication.Controllers;
using HotelApplication.Interfaces;
using HotelApplication.Models.DTOs;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly ILogger<UserController> _logger;

        public BookingController(IBookingService bookingService, ILogger<UserController> logger)
        {
            _bookingService = bookingService;
            _logger = logger;
        }
        /// <summary>
        /// Add the booking details
        /// </summary>
        /// <param name="bookingDTO">Details of booking to be added</param>
        /// <returns>The booking details</returns>
        [HttpPost("addBooking")]
        [Authorize(Roles = "User")]
        public ActionResult AddBooking(BookingDTO bookingDTO)
        {
            var booking = _bookingService.AddBookingDetails(bookingDTO);
            if (booking != null)
            {
                _logger.LogInformation("Booked successfully");
                return Ok(booking);
            }
            _logger.LogError("Could not book rooms");
            return BadRequest("Could not book");
        }
        /// <summary>
        /// Retrieve the booking of hotel
        /// </summary>
        /// <param name="id">id of hotel to retrieve</param>
        /// <returns>All the booking details of a hotel</returns>
        [HttpGet("adminBooking")]
        [Authorize(Roles = "Admin")]
        public ActionResult GetAdminBooking(int id)
        {
            var booking = _bookingService.GetBooking(id);
            if (booking != null)
            {
                _logger.LogInformation("Admin booking details displayed");
                return Ok(booking);
            }
            _logger.LogError("Could not display admin bookings");
            return BadRequest("No bookings found");
        }
        /// <summary>
        /// Retrieve the user booking
        /// </summary>
        /// <param name="id">id of a user</param>
        /// <returns>bookiong dteails of a user</returns>
        [HttpGet("userBooking")]
        [Authorize(Roles = "User")]
        public ActionResult GetUserBooking(string id)
        {
            var booking = _bookingService.GetUserBooking(id);
            if (booking != null)
            {
                _logger.LogInformation("User booking details displayed");
                return Ok(booking);
            }
            _logger.LogError("Could not display user bookings");
            return BadRequest("No bookings found");
        }

    }
}
