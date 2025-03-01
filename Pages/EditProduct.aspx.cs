using ProjektProgramia.Services;
using ProjektProgramia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjektProgramia.DataAccess;
using ProjektProgramia.DataAccess.InterfaceRepository;
using Newtonsoft.Json.Linq;

namespace ProjektProgramia.Pages
{
    public partial class EditProduct : System.Web.UI.Page
    {
        private int? productId = null;
        private ProductService productService;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                productId = Convert.ToInt32(Request.QueryString["id"]);
            }

            if (!IsPostBack)
            {
                if (productId.HasValue)
                {
                    LoadProducts(productId.Value);
                    FormTitle.Text = "Edit product";
                    Title = "Edit product";
                }
                else
                {
                    FormTitle.Text = "New product";
                    Title = "New product";
                }
            }
        }
        protected void Page_Init(object sender, EventArgs eventArgs)
        {
            productService = new ProductService(new ProductRepository(),
                                                new OrderRepository());
        }

        private void LoadProducts(int productId)
        {
            var product = productService.FindProduct(productId);
            if (product != null)
            {
                txtTitle.Text = product.Title;
                txtDescription.Text = product.Description;
                txtPrice.Text = product.Price.ToString();
            }
        }

        protected void AddProductButton_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {

                Response.Write("Must write number in correct format");
                return;
            }
            Product product;
            if (productId.HasValue)
            {
                product = productService.FindProduct(productId.Value);
            }
            else
            {
                product = new Product();
                productService.AddProducts(product);
            }

            product.Title = txtTitle.Text;
            product.Price = price;
            bool success = productService.SaveChanges();
            if (success)
            {
                Response.Write("Product added successfully!");
            }
            Response.Redirect("ProductsList.aspx");
        }
        protected void CancelButton_Click(object sender, EventArgs eventArgs)
        {
            Response.Redirect("ProductsList.aspx");
        }
    }
}