using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class BaseABM: System.Web.UI.Page 
    {
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }
        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }
        protected int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }
        protected bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        protected bool IsLoggedIn()
        {
            if (Session["Usuario"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected bool CheckPermission(string tipoUsuario)
        {
            if (IsLoggedIn())
            {
                if (tipoUsuario == Session["TipoUsuario"].ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } 
            else
            {
                Page.Response.Redirect("~/Login.aspx");
                return false;
            }          
            
        }


    }
}