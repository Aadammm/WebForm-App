using WebForms.DataAccess.InterfaceRepository;
using WebForms.Models;
using WebForms.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebForms.DataAccess
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext dbContext;
        public AddressRepository()
        {
            dbContext = new ApplicationDbContext();
        }
        public bool AddAddress(Address address)
        {
            if (address != null)
            {
                dbContext.Addresses.Add(address);
                return SaveChanges();
            }
            return false;
        }
        public Address FindAddress(int addressId)
        {
            if (addressId != 0)
            {
                return dbContext.Addresses.Find(addressId);
            }
            return null;
        }
        public IEnumerable<Address> GetAddresses()
        {
            return dbContext.Addresses;
        }

        public bool RemoveAddress(Address address)
        {
            try
            {
                dbContext.Addresses.Remove(address);
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