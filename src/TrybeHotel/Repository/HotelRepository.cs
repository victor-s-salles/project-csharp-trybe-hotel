using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class HotelRepository : IHotelRepository
    {
        protected readonly ITrybeHotelContext _context;
        public HotelRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 4. Desenvolva o endpoint GET /hotel
        public IEnumerable<HotelDto> GetHotels()
        {


            var returnHotels = from h in _context.Hotels
                               join c in _context.Cities on h.CityId equals c.CityId
                               select new HotelDto
                               {
                                   HotelId = h.HotelId,
                                   Name = h.Name,
                                   Address = h.Address,
                                   CityId = c.CityId,
                                   CityName = c.Name,
                                   State = c.State,
                               };
            return returnHotels;
        }

        // 5. Desenvolva o endpoint POST /hotel
        public HotelDto AddHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
            return GetHotels().Last();
        }
    }
}