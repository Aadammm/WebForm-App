using Newtonsoft.Json.Linq;
using ProjektProgramia.Services;
using ProjektProgramia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjektProgramia.DataAccess.InterfaceRepository;
using ProjektProgramia.DataAccess;

namespace ProjektProgramia.Pages
{
    public partial class EditAddress : System.Web.UI.Page
    {
        private AddressService addressService;
        private int? adressId = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                adressId = Convert.ToInt32(Request.QueryString["id"]);
            }

            if (!IsPostBack)
            {
                if (adressId.HasValue)
                {
                    LoadAdress(adressId.Value);
                    FormTitle.Text = "Edit Address";
                    Title = "Edit Address";
                }
                else
                {
                    FormTitle.Text = "New Address";
                    Title = "New Address";
                }
            }
        }
        protected void Page_Init(object sender, EventArgs eventArgs)
        {
            addressService = new AddressService(new AddressRepository());
        }

        private void LoadAdress(int value)
        {
            var address = addressService.FindAddress(value);
            if (address != null)
            {
                txtPostalCode.Text = address.PostalCode;
                txtCity.Text = address.City;
                txtStreet.Text = address.Street;
                txtHouseNumber.Text = address.HouseNumber;
            }
        }

        protected void AddAddressButton_Click(object sender, EventArgs e)
        {
            Address address;
            if (adressId.HasValue)
            {
                address = addressService.FindAddress(adressId.Value);
            }
            else
            {
                address = new Address();
                addressService.AddAddress(address);
            }
            address.PostalCode = txtPostalCode.Text;
            address.City = txtCity.Text;
            address.Street = txtStreet.Text;
            address.HouseNumber = txtHouseNumber.Text;
            bool succes = addressService.SaveChanges();
            if (succes)
            {
            Response.Write("Address added successfully!");
            }
            Response.Redirect("AddressList.aspx");

        }
        protected void CancelButton_Click(object sender, EventArgs eventArgs)
        {
            Response.Redirect("AddressList.aspx");
        }

    }
}