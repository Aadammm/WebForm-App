using WebForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebForms.DataAccess.InterfaceRepository
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAddresses();
        Address FindAddress(int addressId);
        bool RemoveAddress(Address address);
        bool SaveChanges();
        bool AddAddress(Address address);
    }
}
