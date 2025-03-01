using ProjektProgramia.DataAccess;
using ProjektProgramia.DataAccess.InterfaceRepository;
using ProjektProgramia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ProjektProgramia.Services
{
	public class AddressService
	{
		private readonly IAddressRepository addressReopository;
        public AddressService(IAddressRepository addressReopository)
        {
            this.addressReopository = addressReopository;
        }
        public IEnumerable<Address> GetAddresses()
        {
            return addressReopository.GetAddresses();
        }
        public bool RemoveAddress(int addressId)
        {
            var address = addressReopository.FindAddress(addressId);
            if (address != null)
            {
                return addressReopository.RemoveAddress(address);
            }
            return false;
        }
        public Address FindAddress(int addressId)
        {
            return addressReopository.FindAddress(addressId);
        }
        public bool SaveChanges()
        {
            return addressReopository.SaveChanges();
        }

        public bool AddAddress(Address address)
        {
            return addressReopository.AddAddress(address);
        }
    }
}