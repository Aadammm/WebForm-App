using Newtonsoft.Json.Linq;
using ProjektProgramia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektProgramia.Pages
{
    public partial class EditAddress : System.Web.UI.Page
    {
        private ApplicationDbContext db = new ApplicationDbContext();
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

        private void LoadAdress(int value)
        {
            var address = db.Addresses.Find(value);
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
                address = db.Addresses.Find(adressId.Value);
            }
            else
            {
                address = new Address();
                db.Addresses.Add(address);
            }

            address.PostalCode = txtPostalCode.Text;
            address.City = txtCity.Text;
            address.Street = txtStreet.Text;
            address.HouseNumber = txtHouseNumber.Text;
            db.SaveChanges();

            Response.Write("Address added successfully!");
            Response.Redirect("AddressList.aspx");

        }
        protected void CancelButton_Click(object sender, EventArgs eventArgs)
        {
            Response.Redirect("AddressList.aspx");
        }

    }
}