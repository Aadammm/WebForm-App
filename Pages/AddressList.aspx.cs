using ProjektProgramia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektProgramia.Pages
{
	public partial class AddressList : System.Web.UI.Page
	{
        private ApplicationDbContext db = new ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAddresses();
            }
        }

        private void BindAddresses()
        {
            var addresses = db.Addresses.ToList();
            AddressesGridView.DataSource = addresses;
            AddressesGridView.DataBind();
        }

        protected void AddressesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditAddress")
            {
                int addressId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"EditAddress.aspx?id={addressId}");
            }
            else if (e.CommandName == "DeleteAddress")
            {
                int addressId = Convert.ToInt32(e.CommandArgument);

                var address = db.Addresses.Find(addressId);
                if (address != null)
                {
                    db.Addresses.Remove(address);
                    db.SaveChanges();
                    BindAddresses();
                }
            }
        }

        protected void AddNewAddressButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditAddress.aspx");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            db.Dispose();
        }
    }
}