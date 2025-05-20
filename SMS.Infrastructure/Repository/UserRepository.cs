using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public User Login(string email, string password)
        {
            return _context.Users.FirstOrDefault(x=>x.Email==email && x.Password==password);

        }
    }
}
