using ProjektProgramia.DataAccess;
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
        AddressService addressService;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAddresses();
            }
        }
        protected void Page_Init(object sender, EventArgs eventArgs)
        {
            addressService = new AddressService(new AddressRepository());
        }

        private void BindAddresses()
        {
            var addresses = addressService.GetAddresses().ToList();
            AddressesGridView.DataSource = addresses;
            AddressesGridView.DataBind();
        }

        protected void AddressesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int addressId = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "EditAddress")
            {
                Response.Redirect($"EditAddress.aspx?id={addressId}");
            }
            else if (e.CommandName == "DeleteAddress")
            {
                bool success = addressService.RemoveAddress(addressId);
                if (success)
                {
                    alertBox.InnerText = "You can not remove address belongs user";
                    alertBox.Visible = true;
                    BindAddresses();
                }
            }
        }


        protected void AddNewAddressButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditAddress.aspx");
        }
    }
}