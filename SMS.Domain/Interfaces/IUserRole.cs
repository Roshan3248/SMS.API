using SMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Domain.Interfaces
{
    public interface IUserRole
    {
        List<UserRole> GetAll();

        bool Add(UserRole userRole);

        UserRole GetById(int Id);
    }
}
