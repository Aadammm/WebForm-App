using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace ProjektProgramia.Pages
{
    public partial class Helper : System.Web.UI.Page
    {
        public string PropertyName;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
            if (!IsPostBack)
            {
                BindData();
            }
        }
        public void Test()
        {

        }

        void BindData()
        {
            LabelBind.Text = "LabelBind";
            LiteralBind.Text = "LiteralBind";
            PropertyName = "bindovanie cez property";
            var zoznam = new List<object>
            {
                new { Id = 1, Row1 = "Column1", Row2 = "Column2" },
                new { Id = 2, Row1 = "Column1", Row2 = "Column2" },
                new { Id = 3, Row1 = "Column1", Row2 = "Column2" }
            };
            GridView.DataSource = zoznam;
            GridView.DataBind();
        }
        void LoadData()
        {
            string text = TextBox.Text;
        }

    }
}