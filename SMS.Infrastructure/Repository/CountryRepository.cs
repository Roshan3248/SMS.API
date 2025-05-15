using SMS.Domain.Entities;
using SMS.Domain.Interfaces;

namespace SMS.Infrastructure.Repository
{
    public class CountryRepository : ICountry
    {
        private readonly ApplicationDbContext _context;
        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Country> GetAll()
        {
            return _context.Countries.ToList();
        }

        public bool Add(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int Id)
        {
            var countries = _context.Countries.Find(Id);
            _context.Countries.Remove(countries);
            _context.SaveChanges();
            return true;
        }

       
        public bool Update(Country country)
        {
            _context.Countries.Update(country);
            _context.SaveChanges();
            return true;
        }

    }
}
