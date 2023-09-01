using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class CityRepository : ICityRepository
    {
        protected readonly ITrybeHotelContext _context;
        public CityRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        // 2. Desenvolva o endpoint GET /city
        public IEnumerable<CityDto> GetCities()
        {
            var returnCities = _context.Cities.Select(c => new CityDto
            {
                CityId = c.CityId,
                Name = c.Name,
                State = c.State,
            });
            return returnCities;
        }

        // 3. Desenvolva o endpoint POST /city
        public CityDto AddCity(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
            return new CityDto
            {
                CityId = city.CityId,
                Name = city.Name,
                State = city.State,
            };
        }

        // 3. Desenvolva o endpoint PUT /city
        public CityDto UpdateCity(City city)
        {
            var cityDB = _context.Cities.FirstOrDefault(c => c.CityId == city.CityId);

            if (cityDB == null)
            {
                return null!;
            }
            cityDB.State = city.State;
            cityDB.Name = city.Name;

            _context.Cities.Update(cityDB);
            _context.SaveChanges();

            return new CityDto
            {
                CityId = cityDB.CityId,
                Name = cityDB.Name,
                State = cityDB.State
            };
        }

    }
}