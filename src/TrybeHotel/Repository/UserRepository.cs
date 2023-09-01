using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly ITrybeHotelContext _context;
        public UserRepository(ITrybeHotelContext context)
        {
            _context = context;
        }
        public UserDto GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public UserDto Login(LoginDto login)
        {
            User? user = _context.Users.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);

            if (user == null)
            {
                return null!;
            }
            return new UserDto
            {
                UserId = user!.UserId,
                Name = user.Name,
                Email = user.Email,
                UserType = user.UserType
            };

        }


        public UserDto Add(UserDtoInsert user)
        {
            User newUser = new()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                UserType = "client",
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return new UserDto
            {
                UserId = newUser.UserId,
                Name = newUser.Name,
                Email = newUser.Email,
                UserType = newUser.UserType,

            };

        }

        public UserDto GetUserByEmail(string userEmail)
        {
            UserDto? user = _context.Users.Where(u => u.Email == userEmail).Select(u => new UserDto
            {
                UserId = u.UserId,
                Name = u.Name,
                Email = u.Email,
                UserType = u.UserType,
            }).FirstOrDefault(); ;

            if (user == null)
            {
                return null!;
            }
            return user;

        }

        public IEnumerable<UserDto> GetUsers()
        {
            List<UserDto>? usersList = _context.Users.Select(u => new UserDto
            {
                UserId = u.UserId,
                Name = u.Name,
                Email = u.Email,
                UserType = u.UserType,
            }).ToList();

            return usersList;
        }

    }
}