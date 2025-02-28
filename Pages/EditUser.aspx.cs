using ProjektProgramia.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
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
                LoadProducts();

                if (userId.HasValue)
                {
                    LoadUser(userId.Value);

                    FormTitle.Text = "Edit User";
                    Title = "Edit User";
                }
                else
                {
                    FormTitle.Text = "New User";
                    Title = "New User";
                }
            }
        }

        private void LoadAddress(int id)
        {
            var address = db.Addresses.Find(id);

            if (address != null)
            {
                PostalCodeTextBox.Text = address.PostalCode;
                CityTextBox.Text = address.City;
                StreetTextBox.Text = address.Street;
                HouseNumberTextBox.Text = address.HouseNumber;
            }
        }


        private void LoadProducts()
        {
            ProductDropDown.DataSource = db.Products.ToList();
            ProductDropDown.DataTextField = "Title";
            ProductDropDown.DataValueField = "Id";
            ProductDropDown.DataBind();
        }

        private void LoadUser(int id)
        {
            var user = db.Users.Find(id);
            if (user != null)
            {
                NameTextBox.Text = user.Name;
                LoadAddress(user.AddressId);
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            User user;
            Address address;

            if (userId.HasValue)
            {
                user = db.Users.Find(userId.Value);
                address = db.Addresses.Find(user.AddressId);
                address.PostalCode = PostalCodeTextBox.Text;
                address.City = CityTextBox.Text;
                address.Street = StreetTextBox.Text;
                address.HouseNumber = HouseNumberTextBox.Text;
            }
            else
            {
                user = new User();
                address = new Address()
                {
                    PostalCode = PostalCodeTextBox.Text,
                    City = CityTextBox.Text,
                    Street = StreetTextBox.Text,
                    HouseNumber = HouseNumberTextBox.Text
                };
                db.Addresses.Add(address);
                db.SaveChanges();
                db.Users.Add(user);
            }
            user.Name = NameTextBox.Text;
            user.AddressId = address.Id;

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


    }
}