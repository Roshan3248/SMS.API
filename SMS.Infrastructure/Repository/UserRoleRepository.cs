using SMS.Domain.Entities;
using SMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repository
{
    public class UserRoleRepository : IUserRole
    {
        private readonly ApplicationDbContext _context;

        public UserRoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(UserRole userrole)
        {
            _context.UserRoles.Add(userrole);
            _context.SaveChanges();
            return true;
        }

        public List<UserRole> GetAll()
        {
            return _context.UserRoles.ToList();
        }
    }
}
