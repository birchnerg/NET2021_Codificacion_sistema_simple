using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;

namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool Validar()
        {
            UsuarioLogic usuario = new UsuarioLogic();
            string usr = this.txtUsuario.Text;
            string clave = this.txtClave.Text;

            if (usuario.Auth(usr, clave))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {

                Page.Response.Redirect("~/Default.aspx");
            }
            else
            {
                Page.Response.Write("Usuario o Contraseña incorrecto");
            }
        }

        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            Page.Response.Write("Metodo de recupero de contraseña no desarrollado, comunicarse al 443323234");
        }
    }
}