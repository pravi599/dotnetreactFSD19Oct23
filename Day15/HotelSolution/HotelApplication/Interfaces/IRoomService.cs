using HotelApplication.Models.DTOs;
using HotelApplication.Models;

namespace HotelApplication.Interfaces
{
    public interface IRoomService
    {
        List<Room> GetRooms(int hotelid);
        RoomDTO AddRoom(RoomDTO room);
        RoomDTO UpdateRoom(int id, RoomDTO room);
        bool RemoveRoom(int id);
    }
}
