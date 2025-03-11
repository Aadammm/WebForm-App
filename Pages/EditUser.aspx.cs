using WebForms.Services;
using WebForms.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.DataAccess;
using WebForms.DataAccess.InterfaceRepository;

namespace WebForms.Pages
{
    public partial class EditUser : System.Web.UI.Page
    {
        private UserService userService;
        private int? userId = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                userId = Convert.ToInt32(Request.QueryString["id"]);
            }

            if (!IsPostBack)
            {
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
        protected void Page_Init(object sender, EventArgs e)
        {
            userService = new UserService(new UserRepository());
        }

        private void LoadUser(int id)
        {
            var user = userService.FindUser(id);
            if (user != null)
            {
                NameTextBox.Text = user.Name;
                PostalCodeTextBox.Text = user.Address.PostalCode.ToString();
                CityTextBox.Text = user.Address.City;
                StreetTextBox.Text = user.Address.Street;
                HouseNumberTextBox.Text = user.Address.HouseNumber.ToString();
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            User user;

            if (userId.HasValue)
            {
                user = userService.FindUser(userId.Value);                
                user.Address.PostalCode = int.Parse(PostalCodeTextBox.Text);
                user.Address.City = CityTextBox.Text;
                user.Address.Street = StreetTextBox.Text;
                user.Address.HouseNumber = int.Parse(HouseNumberTextBox.Text);
            }
            else
            {
                user = new User();
                user.Address = new Address
                {
                    PostalCode = int.Parse(PostalCodeTextBox.Text),
                    City = CityTextBox.Text,
                    Street = StreetTextBox.Text,
                    HouseNumber = int.Parse(HouseNumberTextBox.Text)
                };
                userService.AddUser(user);
            }
            user.Name = NameTextBox.Text;

            userService.SaveChanges();
            Response.Redirect("/Default.aspx");
        }
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }
    }
}