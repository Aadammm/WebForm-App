using WebForms.Services;
using WebForms.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebForms.DataAccess;

namespace WebForms
{
    public partial class _Default : Page
    {
        private UserService userService;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindClients();
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            userService = new UserService(new UserRepository());
        }
        private void BindClients()
        {
            List<User> clients = userService.GetUsers().ToList();

            UsersGridView.DataSource = clients;
            UsersGridView.DataBind();
        }
        protected void UsersGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int userId = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "ShowOrders")
            {
                Response.Redirect($"Pages/OrdersList.aspx?id={userId}");
            }
            else if (e.CommandName == "EditUser")
            {
                Response.Redirect($"Pages/EditUser.aspx?id={userId}");
            }
            else if (e.CommandName == "AddOrders")
            {
                Response.Redirect($"Pages/ProductsList.aspx?id={userId}");
            }
            else if (e.CommandName == "DeleteClient")
            {
                bool success = userService.RemoveUser(userId);
                if (!success)
                {
                    alertBoxRemove.InnerText = "You can remove product which is in order";
                    alertBoxRemove.Visible = true;
                }
                BindClients();
            }
        }

        protected void AddNewClientButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pages/EditUser.aspx");
        }
    }
}