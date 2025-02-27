using ProjektProgramia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektProgramia.Pages
{
    public partial class EditUser : System.Web.UI.Page
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private int? userId = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                userId = Convert.ToInt32(Request.QueryString["id"]);
            }

            if (!IsPostBack)
            {
                LoadAddresses();
                LoadProducts();

                if (userId.HasValue)
                {
                    LoadClient(userId.Value);
                    FormTitle.Text = "Edit User";
                }
                else
                {
                    FormTitle.Text = "New User";
                }
            }
        }

        private void LoadAddresses()
        {
            AddressDropDown.DataSource = db.Addresses.Select(a => new
            {
                a.Id,
                FullAddress = a.City + ", " + a.Street + " " + a.HouseNumber
            }).ToList();
            AddressDropDown.DataTextField = "FullAddress";
            AddressDropDown.DataValueField = "Id";
            AddressDropDown.DataBind();
        }

        private void LoadProducts()
        {
            ProductDropDown.DataSource = db.Products.ToList();
            ProductDropDown.DataTextField = "Title";
            ProductDropDown.DataValueField = "Id";
            ProductDropDown.DataBind();
        }

        private void LoadClient(int id)
        {
            var client = db.Users.Find(id);
            if (client != null)
            {
                NameTextBox.Text = client.Name;
                AddressDropDown.SelectedValue = client.AddressId.ToString();
                ProductDropDown.SelectedValue = client.ProductId.ToString();
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            User user;

            if (userId.HasValue)
            {
                user = db.Users.Find(userId.Value);
            }
            else
            {
                user = new User();
                db.Users.Add(user);
            }

            user.Name = NameTextBox.Text;
            user.AddressId = Convert.ToInt32(AddressDropDown.SelectedValue);
            user.ProductId = Convert.ToInt32(ProductDropDown.SelectedValue);

            db.SaveChanges();
            Response.Redirect("/Default.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            db.Dispose();
        }
        protected void AddressDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(AddressDropDown.SelectedValue))
            {
                int id = Convert.ToInt32(AddressDropDown.SelectedValue);
                Address address = db.Addresses.Find(id);
                PostalCodeTextBox.Text = address.PostalCode;
                CityTextBox.Text = address.City;
                StreetTextBox.Text = address.Street;
                HouseNumberTextBox.Text = address.HouseNumber;
            }
        }
    }
}