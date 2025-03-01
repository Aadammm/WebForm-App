using ProjektProgramia.DataAccess;
using ProjektProgramia.DataAccess.InterfaceRepository;
using ProjektProgramia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace ProjektProgramia.Services
{
    public class UserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetUsers();
        }
        public bool RemoveUser(int userId)
        {
            var user = userRepository.FindUser(userId);
            if (user != null)
            {
                userRepository.RemoveUser(user);
                return userRepository.SaveChanges();
            }
            return false;
        }
        public User FindUser(int userId)
        {
            return userRepository.FindUser(userId);
        }
        public bool SaveChanges()
        {
            return userRepository.SaveChanges();
        }
        public bool AddUser(User user)
        {
            return userRepository.AddUser(user);
        }
    }
}