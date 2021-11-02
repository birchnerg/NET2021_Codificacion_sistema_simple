using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Home : BaseABM
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsLoggedIn())
            {
                this.lblBienvenido.Text = "Bienvenido " + Session["Usuario"].ToString();
            }
            else
            {
                Page.Response.Redirect("~/Login.aspx");
            }
            
        }
    }
}