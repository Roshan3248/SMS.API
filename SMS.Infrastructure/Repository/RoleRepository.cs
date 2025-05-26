using Microsoft.EntityFrameworkCore;
using SMS.Domain.Entities;
using SMS.Domain.Interfaces;

namespace SMS.Infrastructure.Repository
{
    public class RoleRepository : IRole
    {
        private readonly ApplicationDbContext _contex;
        public RoleRepository(ApplicationDbContext contex)
        {
            _contex = contex;
        }

        public bool Add(Role role)
        {
            _contex.Roles.Add(role);
            _contex.SaveChanges();
            return true;
        }

        public List<Role> GetAll() 
        {
            return _contex.Roles.ToList();
        }

        public Role GetById(int Id)
        {
            return _contex.Roles.Find(Id);
        }
    }
}
