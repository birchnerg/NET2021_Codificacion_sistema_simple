using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Master.FindControl("menu").Visible = false;
        }

        public bool Validar()
        {
            UsuarioLogic usuarioLogic = new UsuarioLogic();
            PersonaLogic personaLogic = new PersonaLogic();
            string usr = this.txtUsuario.Text;
            string clave = this.txtClave.Text;

            try
            {
                Usuario usuario = usuarioLogic.GetOne(usr, clave);
                if (usuario.ID == 0)
                {
                    throw new Exception("Usuario o Contraseña incorrecto");
                }
                Persona persona = personaLogic.GetOne(usuario.IdPersona);
                Session["IdUsuario"] = persona.ID;
                Session["TipoUsuario"] = persona.TipoPersonasString;
                Session["IdPlan"] = persona.IDPlan;
                Session["Apellido"] = persona.Apellido;
                Session["Nombre"] = persona.Nombre;
                Session["Legajo"] = persona.Legajo.ToString();

                return true;
            }
            catch
            {
                return false;
            }

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Session["Usuario"] = txtUsuario.Text;
                Page.Response.Redirect("~/Default.aspx");
            }
            else
            {
                //Page.Response.Write("Usuario o Contraseña incorrecto");
                loginError.InnerText = "Usuario o Contraseña incorrecto";
            }
        }

        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            Page.Response.Write("Metodo de recupero de contraseña no desarrollado, comunicarse al 443323234");
        }
    }
}