using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class formLogin : ApplicationForm
    {
        public formLogin()
        {
            InitializeComponent();
        }

        public override bool Validar()
        {
            UsuarioLogic usuarioLogic = new UsuarioLogic();
            PersonaLogic personaLogic = new PersonaLogic();
            string usr = this.txtUsuario.Text;
            string clave = this.txtPassword.Text;
            try
            {
                Usuario usuario = usuarioLogic.GetOne(usr, clave) ?? throw new Exception("Usuario o Contraseña incorrecto");
                /*Usuario usuario = usuarioLogic.GetOne(usr, clave);
                if (usuario.ID == 0)
                {
                    throw new Exception("Usuario o Contraseña incorrecto");
                }*/
                PersonaLoggedIn = personaLogic.GetOne(usuario.IdPersona);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

  
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            /*
            int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            dgvUsuarios.ClearSelection();
            */
            
            if (Validar())
            {
                MessageBox.Show("Usted ha ingresado al sistema correctamente."
                , "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrecto", "Login"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
