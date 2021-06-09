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
    public partial class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo):this() 
        {
            Modo = modo;
        }

        public UsuarioDesktop(int ID, ModoForm modo):this() 
        {
            Modo = modo;
            UsuarioLogic usuario = new UsuarioLogic();
            UsuarioActual = usuario.GetOne(ID);
            MapearDeDatos();
        }

        private Usuario _usuario;
        public Usuario UsuarioActual
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
            switch (this.Modo)
            {
                case ModoForm.Alta:
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }
        public override void MapearADatos() 
        {
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    UsuarioActual = new Usuario();
                    UsuarioActual.Nombre = this.txtNombre.Text;
                    UsuarioActual.Apellido = this.txtApellido.Text;
                    UsuarioActual.Email = this.txtEmail.Text;
                    UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                    UsuarioActual.Clave = this.txtClave.Text;
                    UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                    UsuarioActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    UsuarioActual.Nombre = this.txtNombre.Text;
                    UsuarioActual.Apellido = this.txtApellido.Text;
                    UsuarioActual.Email = this.txtEmail.Text;
                    UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                    UsuarioActual.Clave = this.txtClave.Text;
                    UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                    UsuarioActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }
        public override void GuardarCambios() 
        {
            MapearADatos();
            UsuarioLogic u = new UsuarioLogic();
            if (this.Modo == ModoForm.Baja)
            {
                u.Delete(UsuarioActual.ID);
            }
            else
            {
                u.Save(UsuarioActual);
            }
        }
        public override bool Validar() 
        {
            if (string.IsNullOrEmpty(this.txtNombre.Text) || string.IsNullOrEmpty(this.txtApellido.Text) || string.IsNullOrEmpty(this.txtUsuario.Text) || string.IsNullOrEmpty(this.txtEmail.Text) || string.IsNullOrEmpty(this.txtClave.Text))
            {
                Notificar("Error", "Campos vacíos. Por favor complételos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (this.txtClave.Text != this.txtConfirmarClave.Text)
            {
                Notificar("Error", "Las claves no coinciden. Por favor ingrese de nuevo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (this.txtClave.Text.Length < 8)
            {
                Notificar("Error", "La clave es corta. Por favor ingrese una clave con al menos 8 caracteres.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!this.txtEmail.Text.Contains('@') || !this.txtEmail.Text.Substring(this.txtEmail.Text.IndexOf('@')).Contains(".com"))
            {
                Notificar("Error", "Formato de email inválido. Por favor ingrese un correo electrónico.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
