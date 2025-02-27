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
                .Include("Product")
                .Where(c=>c.Address.Id==c.AddressId)
                .ToList();

            ClientsGridView.DataSource = clients;
            ClientsGridView.DataBind();
        }
        protected void ClientsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditUser")
            {
                int clientId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"Pages/EditUser.aspx?id={clientId}");
            }
            else if (e.CommandName == "DeleteClient")
            {
                int clientId = Convert.ToInt32(e.CommandArgument);

                var client = dbContext.Users.Find(clientId);
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