using ProjektProgramia.DataAccess.InterfaceRepository;
using ProjektProgramia.Models;
using ProjektProgramia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektProgramia.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;
        public UserRepository()
        {
            dbContext = new ApplicationDbContext();
        }

        public bool AddUser(User user)
        {
            if (user != null)
            {
                dbContext.Users.Add(user);
                return SaveChanges();
            }
            return false;
        }

        public User FindUser(int userId)
        {
            if (userId != 0)
            {
                return dbContext.Users.Include("Address").FirstOrDefault(u => u.Id == userId);
            }
            return null;
        }

        public IEnumerable<User> GetUsers()
        {
            return dbContext.Users
                .Include("Address")
                .Include("Orders")
                .Where(c => c.Address.Id == c.AddressId);
        }

        public bool RemoveUser(User user)
        {
            try
            {
                dbContext.Users.Remove(user);
                return SaveChanges();
            }
            catch
            {
                return false;
            }
        }
        public bool SaveChanges()
        {
            return dbContext.SaveChanges() > 0;
        }
    }
}