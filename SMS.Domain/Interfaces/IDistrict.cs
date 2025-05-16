using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Interfaces
{
    public interface IDistrict
    {
        List<District> GetAll();

        bool Add(District district);

        bool Delete(int Id);

        bool Update(District district);

    }
}
