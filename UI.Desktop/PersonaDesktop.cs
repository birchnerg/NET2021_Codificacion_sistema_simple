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
    public partial class PersonaDesktop : ApplicationForm
    {
        public PersonaDesktop()
        {
            InitializeComponent();
            foreach (var item in Enum.GetValues(typeof(Persona.TipoPersonas)))
            {
                this.cmboTipoPersona.Items.Add(item);
            }
            PlanLogic p = new PlanLogic();
            try
            {
                List<Plan> plan = p.GetAll();
                DataTable planes = new DataTable();
                planes.Columns.Add("id_plan", typeof(int));
                planes.Columns.Add("desc_plan", typeof(string));
                foreach (var e in plan)
                {
                    planes.Rows.Add(new object[] { e.ID, e.Descripcion });
                }
                this.cmboIDPaln.DataSource = planes;
                this.cmboIDPaln.ValueMember = "id_plan";
                this.cmboIDPaln.DisplayMember = "desc_plan";
                this.cmboIDPaln.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public PersonaDesktop(ModoForm modo):this() 
        {
            Modo = modo;
        }

        public PersonaDesktop(int ID, ModoForm modo):this() 
        {
            Modo = modo;
            PersonaLogic persona = new PersonaLogic();
            try
            {
                PersonaActual = persona.GetOne(ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MapearDeDatos();
        }

        private Persona _persona;
        public Persona PersonaActual
        {
            get { return _persona; }
            set { _persona = value; }
        }

        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.PersonaActual.ID.ToString();
            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtApellido.Text = this.PersonaActual.Apellido;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            this.txtTelefono.Text = this.PersonaActual.Telefono;
            this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
            this.dtpFechaNacimiento.Text = this.PersonaActual.FechaNacimiento.ToString();
            this.cmboIDPaln.SelectedValue = this.PersonaActual.IDPlan;
            this.cmboTipoPersona.Text = this.PersonaActual.TipoPersonasString.ToString();
            switch (this.Modo)
            {
                case ModoForm.Alta:
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.txtApellido.Enabled = false;
                    this.txtNombre.Enabled = false;
                    this.txtEmail.Enabled = false;
                    this.txtDireccion.Enabled = false;
                    this.txtTelefono.Enabled = false;
                    this.txtLegajo.Enabled = false;
                    this.dtpFechaNacimiento.Enabled = false;
                    this.cmboIDPaln.Enabled = false;
                    this.cmboTipoPersona.Enabled = false;
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
                    PersonaActual = new Persona();
                    PersonaActual.Nombre = this.txtNombre.Text;
                    PersonaActual.Apellido = this.txtApellido.Text;
                    PersonaActual.Email = this.txtEmail.Text;
                    PersonaActual.Direccion = this.txtDireccion.Text;
                    PersonaActual.Telefono = this.txtTelefono.Text;
                    PersonaActual.Legajo = Int32.Parse(this.txtLegajo.Text);
                    PersonaActual.FechaNacimiento = DateTime.Parse(this.dtpFechaNacimiento.Text);
                    PersonaActual.IDPlan = Int32.Parse(this.cmboIDPaln.SelectedValue.ToString());
                    PersonaActual.TipoPersonasInt = Int32.Parse(this.cmboTipoPersona.SelectedIndex.ToString());
                    PersonaActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    PersonaActual.Nombre = this.txtNombre.Text;
                    PersonaActual.Apellido = this.txtApellido.Text;
                    PersonaActual.Email = this.txtEmail.Text;
                    PersonaActual.Direccion = this.txtDireccion.Text;
                    PersonaActual.Telefono = this.txtTelefono.Text;
                    PersonaActual.Legajo = Int32.Parse(this.txtLegajo.Text);
                    PersonaActual.FechaNacimiento = DateTime.Parse(this.dtpFechaNacimiento.Text);
                    PersonaActual.IDPlan = Int32.Parse(this.cmboIDPaln.SelectedValue.ToString());
                    PersonaActual.TipoPersonasInt = Int32.Parse(this.cmboTipoPersona.SelectedIndex.ToString());
                    PersonaActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }

        public override void GuardarCambios() 
        {
            MapearADatos();
            PersonaLogic u = new PersonaLogic();
            if (this.Modo == ModoForm.Baja)
            {
                var resultado = MessageBox.Show("¿Desea eliminar el registro?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        u.Delete(PersonaActual.ID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                try
                {
                    u.Save(PersonaActual);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public override bool Validar() 
        {
            if (string.IsNullOrEmpty(this.txtNombre.Text) || string.IsNullOrEmpty(this.txtApellido.Text) || string.IsNullOrEmpty(this.txtDireccion.Text)
                || string.IsNullOrEmpty(this.txtEmail.Text) || string.IsNullOrEmpty(this.txtLegajo.Text) || string.IsNullOrEmpty(this.txtTelefono.Text)
                || string.IsNullOrEmpty(this.cmboIDPaln.Text) || string.IsNullOrEmpty(this.dtpFechaNacimiento.Text) || string.IsNullOrEmpty(this.cmboTipoPersona.Text))
            {
                Notificar("Error", "Campos vacíos. Por favor complételos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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