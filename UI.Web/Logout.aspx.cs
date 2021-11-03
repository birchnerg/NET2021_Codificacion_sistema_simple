using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Logout : BaseABM
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsLoggedIn())
            {
                Page.Response.Redirect("~/Login.aspx");
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Page.Response.Redirect("~/Login.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/Default.aspx");
        }
    }
}