using ProjektProgramia.Services;
using ProjektProgramia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjektProgramia.DataAccess.InterfaceRepository;
using ProjektProgramia.DataAccess;

namespace ProjektProgramia.Pages
{
    public partial class ProductsList : System.Web.UI.Page
    {
        private ProductService productService;
        private int userId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductsGridView.Columns[3].Visible = false;
            ProductsGridView.Columns[4].Visible = true;
            if (Request.QueryString["id"] != null)
            {
                userId = Convert.ToInt32(Request.QueryString["id"]);
                NewProductButton.Visible = false;
                ProductsGridView.Columns[3].Visible = true;
                ProductsGridView.Columns[4].Visible = false;
            }
            if (!IsPostBack)
            {
                BindProducts();
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            productService = new ProductService(new ProductRepository(), new OrderRepository());
        }
        private void BindProducts()
        {
            var products = productService.GetProducts().ToList();
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
                bool success = productService.MakeOrder(userId, productId);
                if (success)
                {
                    alertBoxSuccess.InnerText = "Product added successfully!";
                    alertBoxSuccess.Visible = true;
                }
            }
            else if (e.CommandName == "DeleteProduct")
            {
                bool success = productService.RemoveProduct(productId);
                if (!success)
                {
                    alertBoxRemove.InnerText = "You can not remove product which is in order";
                    alertBoxRemove.Visible = true;
                }
                BindProducts();
            }
        }

        protected void AddNewProductButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditProduct.aspx");
        }
    }
}
