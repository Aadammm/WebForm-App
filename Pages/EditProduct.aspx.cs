using ProjektProgramia.Services;
using ProjektProgramia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjektProgramia.Pages
{
    public partial class EditProduct : System.Web.UI.Page
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private int? productId = null;
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

        private void LoadProducts(int value)
        {
            var product = db.Products.Find(value);
            if (product != null)
            {
                txtTitle.Text = product.Title;
                txtDescription.Text = product.Description;
                txtPrice.Text = product.Price.ToString();
            }
        }

        protected void AddProductButton_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtPrice.Text,out decimal price))
            {
                
                Response.Write("Must write number in correct format");
                return;
            }
            Product product;
            if (productId.HasValue)
            {
                product = db.Products.Find(productId.Value);
            }
            else
            {
                product = new Product();
                db.Products.Add(product);
            }

            product.Title = txtTitle.Text;
            product.Price = price;
            db.SaveChanges();

            Response.Write("Product added successfully!");
            Response.Redirect("ProductsList.aspx");
        }
        protected void CancelButton_Click(object sender, EventArgs eventArgs)
        {
            Response.Redirect("ProductsList.aspx");
        }
    }
}