using Dapper;
using ProjektProgramia.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektProgramia.Pages
{
    public partial class OrdersList : System.Web.UI.Page
    {
        private int userId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                userId = Convert.ToInt32(Request.QueryString["id"]);
            }
            if (!IsPostBack)
            {
                LoadOrders(userId);
            }
        }

        private void LoadOrders(int userId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var orders = db.Orders.Where(o => o.UserId == userId).ToList();

            TotalAmountLabel.InnerText = $"Total amount: {orders.Sum(o => o.Product.Price):C} ";
            OrdersListView.DataSource = orders;
            OrdersListView.DataBind();
        }



    }
}