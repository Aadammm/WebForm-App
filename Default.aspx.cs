using ProjektProgramia.Services;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektProgramia
{
    public partial class _Default : Page
    {
        ApplicationDbContext dbContext;

        public _Default()
        {
            dbContext = new ApplicationDbContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindClients();

            }
        }
        private void BindClients()
        {
            List<User> clients = dbContext.Users
                .Include("Address")
                .Include("Orders")
                .Where(c => c.Address.Id == c.AddressId)
                .ToList();

            ClientsGridView.DataSource = clients;
            ClientsGridView.DataBind();
        }
        protected void ClientsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int userId = Convert.ToInt32(e.CommandArgument); // Získanie ID z riadka
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
                var client = dbContext.Users.Find(userId);
                if (client != null)
                {
                    dbContext.Users.Remove(client);
                    dbContext.SaveChanges();
                    BindClients();
                }
            }

        }

        protected void AddNewClientButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pages/EditUser.aspx");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            dbContext.Dispose();
        }



    }
}