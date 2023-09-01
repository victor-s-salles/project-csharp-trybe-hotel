using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ITrybeHotelContext _context;
        public RoomRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 6. Desenvolva o endpoint GET /room/:hotelId
        public IEnumerable<RoomDto> GetRooms(int HotelId)
        {
            var returnRooms = from r in _context.Rooms
                              join h in _context.Hotels on r.HotelId equals h.HotelId
                              join c in _context.Cities on h.CityId equals c.CityId
                              where h.HotelId == HotelId
                              select new RoomDto
                              {
                                  RoomId = r.RoomId,
                                  Name = r.Name,
                                  Capacity = r.Capacity,
                                  Image = r.Image,
                                  Hotel = new HotelDto
                                  {
                                      HotelId = h.HotelId,
                                      Name = h.Name,
                                      Address = h.Address,
                                      CityId = c.CityId,
                                      CityName = c.Name,
                                      State = c.State
                                  }
                              };
            return returnRooms;

        }

        // 7. Desenvolva o endpoint POST /room
        public RoomDto AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();

            var returnRoom = from r in _context.Rooms
                             join h in _context.Hotels on r.HotelId equals h.HotelId
                             join c in _context.Cities on h.CityId equals c.CityId
                             where r.RoomId == room.RoomId
                             orderby r.RoomId
                             select new RoomDto
                             {
                                 RoomId = r.RoomId,
                                 Name = r.Name,
                                 Capacity = r.Capacity,
                                 Image = r.Image,
                                 Hotel = new HotelDto
                                 {
                                     HotelId = h.HotelId,
                                     Name = h.Name,
                                     Address = h.Address,
                                     CityId = c.CityId,
                                     CityName = c.Name,
                                     State = c.State
                                 }
                             };

            return returnRoom.Last();
        }


        // 8. Desenvolva o endpoint DELETE /room/:roomId
        public void DeleteRoom(int RoomId)
        {
            var room = _context.Rooms.Find(RoomId);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
        }
    }
}