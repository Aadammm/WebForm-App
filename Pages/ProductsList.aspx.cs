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
        private List<Product> products;
        private int userId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ProductsGridView.Columns[3].Visible = false;
            if (Request.QueryString["id"] != null)
            {
                userId = Convert.ToInt32(Request.QueryString["id"]);
                NewProductButton.Visible = false;
                ProductsGridView.Columns[3].Visible = true;

            }
            if (!IsPostBack)
            {

                BindProducts();
            }
        }

        private void BindProducts()
        {
            products = db.Products.ToList();
            ProductsGridView.DataSource = products;
            ProductsGridView.DataBind();
        }

        protected void ProductsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int productId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditProduct")
            {
                Response.Redirect($"EditProduct.aspx?id={productId}");
            }
            else if (e.CommandName == "MakeOrder" && userId != 0)
            {

                Product product = db.Products.Find(productId);
                Order newOrder = new Order()
                {
                    Product = product,
                    UserId = userId
                };
                db.Orders.Add(newOrder);
                db.SaveChanges();
                alertBox.InnerText = "Product added successfully!";
                alertBox.Visible = true;
            }
            else if (e.CommandName == "DeleteProduct")
            {
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
