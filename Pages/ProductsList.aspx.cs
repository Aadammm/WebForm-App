using ProjektProgramia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektProgramia.Pages
{
    public partial class ProductsList : System.Web.UI.Page
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProducts();
            }
        }

        private void BindProducts()
        {
            var products = db.Products.ToList();
            ProductsGridView.DataSource = products;
            ProductsGridView.DataBind();
        }

        protected void ProductsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditProduct")
            {
                int productId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"EditProduct.aspx?id={productId}");
            }
            else if (e.CommandName == "DeleteProduct")
            {
                int productId = Convert.ToInt32(e.CommandArgument);

                var product = db.Products.Find(productId);
                if (product != null)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                    BindProducts();
                }
            }
        }

        protected void AddNewProductButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditProduct.aspx");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            db.Dispose();
        }
    }
}
