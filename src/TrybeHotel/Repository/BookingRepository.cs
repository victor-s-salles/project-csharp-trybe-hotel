using TrybeHotel.Models;
using TrybeHotel.Dto;
using Microsoft.EntityFrameworkCore;

namespace TrybeHotel.Repository
{
    public class BookingRepository : IBookingRepository
    {
        protected readonly ITrybeHotelContext _context;
        public BookingRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public BookingResponse Add(BookingDtoInsert booking, string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            var bookingToInsert = new Booking
            {
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                GuestQuant = booking.GuestQuant,
                UserId = user.UserId,
                RoomId = booking.RoomId
            };
            var room = _context.Rooms.FirstOrDefault(r => r.RoomId == booking.RoomId);
            if (booking.GuestQuant > room.Capacity)
            {
                return null!;
            }
            _context.Bookings.Add(bookingToInsert);
            _context.SaveChanges();
            var queryResult = from b in _context.Bookings
                              join r in _context.Rooms on b.RoomId equals r.RoomId
                              join h in _context.Hotels on r.HotelId equals h.HotelId
                              join c in _context.Cities on h.CityId equals c.CityId
                              select new BookingResponse
                              {
                                  BookingId = b.BookingId,
                                  CheckIn = b.CheckIn,
                                  CheckOut = b.CheckOut,
                                  GuestQuant = b.GuestQuant,
                                  Room = new RoomDto
                                  {
                                      RoomId = r.RoomId,
                                      Name = r.Name,
                                      Capacity = r.Capacity,
                                      Image = r.Image,
                                      Hotel = new HotelDto
                                      {
                                          HotelId = r.Hotel.HotelId,
                                          Name = r.Hotel.Name,
                                          Address = r.Hotel.Address,
                                          CityId = h.CityId,
                                          CityName = c.Name,
                                          State = c.State
                                      }
                                  }
                              };
            return queryResult.Last();
        }

        public BookingResponse GetBooking(int bookingId, string email)
        {
            var queryResult = from b in _context.Bookings
                              join r in _context.Rooms on b.RoomId equals r.RoomId
                              join h in _context.Hotels on r.HotelId equals h.HotelId
                              join c in _context.Cities on h.CityId equals c.CityId
                              where b.BookingId == bookingId && b.User.Email == email
                              select new BookingResponse
                              {
                                  BookingId = b.BookingId,
                                  CheckIn = b.CheckIn,
                                  CheckOut = b.CheckOut,
                                  GuestQuant = b.GuestQuant,
                                  Room = new RoomDto
                                  {
                                      RoomId = r.RoomId,
                                      Name = r.Name,
                                      Capacity = r.Capacity,
                                      Image = r.Image,
                                      Hotel = new HotelDto
                                      {
                                          HotelId = r.Hotel.HotelId,
                                          Name = r.Hotel.Name,
                                          Address = r.Hotel.Address,
                                          CityId = h.CityId,
                                          CityName = c.Name,
                                          State = c.State
                                      }
                                  }
                              };
            if (queryResult.Count() == 0)
            {
                return null!;
            }
            return queryResult.Last();
        }

        public Room GetRoomById(int RoomId)
        {
            Room? room = _context.Rooms.Include(r => r.Hotel).FirstOrDefault(r => r.RoomId == RoomId);
            return room!;
        }

    }

}