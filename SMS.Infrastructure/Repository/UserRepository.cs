using SMS.Domain.Entities;
using SMS.Domain.Interfaces;

namespace SMS.Infrastructure.Repository
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int Id)
        {
            return _context.Users.Find(Id);
        }

        public User Login(string email, string password)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
        }
    }
}
