using SMS.Domain.Entities;

namespace SMS.Domain.Interfaces
{
    public interface ICountry
    {
        List<Country> GetAll();

        bool Add(Country country);

        bool Delete(int Id);

        bool Update(Country country);
    }
}
