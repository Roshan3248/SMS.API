using SMS.Domain.Entities;
using SMS.Domain.Interfaces;

namespace SMS.Infrastructure.Repository
{
    public class DistrictRepository : IDistrict
    {
        private readonly ApplicationDbContext _context;
        public DistrictRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<District> GetAll()
        {
            return _context.Districts.ToList();
        }

        public bool Add(District district)
        {
            _context.Districts.Add(district);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            var Districts = _context.Districts.Find(Id);
            _context.Districts.Remove(Districts);
            _context.SaveChanges();
            return true;
        }


        public bool Update(District district)
        {
            _context.Districts.Update(district);
            _context.SaveChanges();
            return true;
        }

    }
}
