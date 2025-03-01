using ProjektProgramia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProgramia.DataAccess.InterfaceRepository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User FindUser(int userId);
        bool RemoveUser(User user);
        bool SaveChanges();
        bool AddUser(User user);
    }
}
