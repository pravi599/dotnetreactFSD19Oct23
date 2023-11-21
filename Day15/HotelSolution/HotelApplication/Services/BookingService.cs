using System.Net.Mail;
using System.Net;
using HotelApplication.Interfaces;
using HotelApplication.Models.DTOs;
using HotelApplication.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using HotelApplication.Exceptions;

namespace HotelApplication.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<int, Booking> _bookingRepository;
        private readonly IRepository<int, Room> _roomRepository;
        private readonly IRepository<int, Hotel> _hotelRepository;
        private readonly IRepository<string, User> _userRepository;

        public BookingService(IRepository<int, Booking> bookingRepository,
            IRepository<int, Room> roomRepository, 
            IRepository<int, Hotel> hotelRepository,
            IRepository<string, User> userRepository)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
            _hotelRepository = hotelRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Adds the booking details based on the provided bookingDTO
        /// </summary>
        /// <param name="bookingDTO">BookingDTO contains details of booking</param>
        /// <returns>returns the bookingDTo if the booking was succesfully added; otherwise returns a null value</returns>
        public BookingDTO AddBookingDetails(BookingDTO bookingDTO)
        {

            // Retrieve the room id based on the roomId from bookingDTO
            int roomId = bookingDTO.RoomId;
            var room = _roomRepository.GetById(roomId);
            var hotel = _hotelRepository.GetById(room.HotelId);

            //Calculate the amount for booking based on the price of the room and total number of room
            float amount = (bookingDTO.TotalRooms * room.Price);
            DateTime dateTime = DateTime.Now;

            //Create a new booking object with the details from bookingDTO
            Booking booking = new Booking()
            {
                UserEmail = bookingDTO.UserEmail,
                RoomId = bookingDTO.RoomId,
                TotalRooms = bookingDTO.TotalRooms,
                BookingDate = dateTime.ToString(),
                Price = amount

            };
            //Add the new booking to the repository
            var result = _bookingRepository.Add(booking);
            var user = _userRepository.GetById(bookingDTO.UserEmail);
            string message = $"Dear {user.Name},\nThank you for choosing {hotel.HotelName}! Your reservation is confirmed, and we are thrilled to welcome you for your upcoming stay." +
                $" Your booking reference number is {result.BookingId}. \nSafe travels!\nBest regards,\nThe {hotel.HotelName} Team\n{hotel.PhoneNo}";
            string subject = $"Booking Confirmation - {hotel.HotelName}";
            string body = $"Dear {user.Name},\nThank you for choosing {hotel.HotelName}! Your reservation is confirmed, and we are thrilled to welcome you for your upcoming stay.\n" +
                $"Booking Details:-\nBooking ID: {result.BookingId}\nTotal Price: {amount}\n\nWe look forward to making your stay at {hotel.HotelName} a memorable experience. Safe travels!\nBest regards,\n" +
                $"The {hotel.HotelName} Team\n{hotel.PhoneNo}";

            //Check if the booking was added successfully and return the bookingDTO
            if (result != null)
            {
                SendBookingConfirmationEmail(bookingDTO.UserEmail, subject, body);
                // SendBookingConfirmationSms("+91"+user.Phone,message);
                return bookingDTO;
            }
            //Returns null if booking was not added successfully
            return null;
        }

        /// <summary>
        /// Retrieve a list of booking object based on the unique hotel identifier
        /// </summary>
        /// <param name="hotelId">The unique identifier of a hotel</param>
        /// <returns>Returns the list of booking object for the provided hotel; Otherwise return null</returns>
        public List<Booking> GetBooking(int hotelId)
        {
            //use LINQ to join booking and room entities based on room id and filtered by hotel id and project the result into new booking
            var bookings = (from Booking in _bookingRepository.GetAll()
                            join room in _roomRepository.GetAll() on Booking.RoomId equals room.RoomId
                            where room.HotelId == hotelId
                            select new Booking
                            {
                                BookingId = Booking.BookingId,
                                BookingDate = Booking.BookingDate,
                                RoomId = Booking.RoomId,
                                TotalRooms = Booking.TotalRooms,
                                Price = Booking.Price,
                                UserEmail = Booking.UserEmail
                            })
                    .ToList();

            //Check if the booking was found  and return the booking list; Otherwise return null
            if (bookings.Count > 0)
            {
                return bookings;
            }
            return null;
        }

        /// <summary>
        /// Retrieve the list of booking details based on the unique id of a user
        /// </summary>
        /// <param name="userId">Unique id of a user</param>
        /// <returns>Returns the list of booking object from the provided user id</returns>
        /// <exception cref="NoBookingsAvailableException">Thrown when no bookings are available for the specified user</exception>
        public List<Booking> GetUserBooking(string userEmail)
        {
            //Retrieve the booking details for the specified user
            var user = _bookingRepository.GetAll().Where(u => u.UserEmail == userEmail).ToList();

            //Check if the booking was found and return the booking list; Otherwise thows a NoBookingsAvailableException
            if (user != null)
            {
                return user;
            }
            throw new NoBookingsAvailableException();
        }


        /// <summary>
        /// Sends booking confirmation Email to the user 
        /// </summary>
        /// <param name="recipientEmail">User's Email</param>
        /// <param name="subject">Subject of the email</param>
        /// <param name="body">Body text of thee email</param>
        public void SendBookingConfirmationEmail(string recipientEmail, string subject, string body)
        {

            string email = "happyhotelservices24.7@gmail.com";
            string password = "happyhotelservices";

            // Recipient email
            string toEmail = recipientEmail;

            // Create the email message
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(email);
            mail.To.Add(toEmail);
            mail.Subject = subject;
            mail.Body = body;

            // Set up SMTP client
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(email, password);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;

            // Send the email
            smtpClient.Send(mail);

        }
    }
}
