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
    public partial class ComisionDesktop : ApplicationForm
    {
        public ComisionDesktop()
        {
            InitializeComponent();
        }

        public ComisionDesktop(ModoForm modo):this() 
        {
            Modo = modo;
        }

        public ComisionDesktop(int ID, ModoForm modo):this() 
        {
            Modo = modo;
            ComisionLogic comision = new ComisionLogic();
            ComisionActual = comision.GetOne(ID);
            MapearDeDatos();
        }

        private Comision _comision;
        public Comision ComisionActual
        {
            get { return _comision; }
            set { _comision = value; }
        }

        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.txtAnioEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.txtIdPlan.Text = this.ComisionActual.IDPlan.ToString();
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
                    ComisionActual = new Comision();
                    ComisionActual.Descripcion = this.txtDescripcion.Text;
                    ComisionActual.AnioEspecialidad = Int32.Parse(this.txtAnioEspecialidad.Text);
                    ComisionActual.IDPlan = Int32.Parse(this.txtIdPlan.Text);
           
                    ComisionActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    ComisionActual.Descripcion = this.txtDescripcion.Text;
                    ComisionActual.AnioEspecialidad = Int32.Parse(this.txtAnioEspecialidad.Text);
                    ComisionActual.IDPlan = Int32.Parse(this.txtIdPlan.Text);
                    ComisionActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }
        public override void GuardarCambios() 
        {
            MapearADatos();
            ComisionLogic c = new ComisionLogic();
            if (this.Modo == ModoForm.Baja)
            {
                c.Delete(ComisionActual.ID);
            }
            else
            {
                c.Save(ComisionActual);
            }
        }
        public override bool Validar() 
        {
            if (string.IsNullOrEmpty(this.txtDescripcion.Text) || string.IsNullOrEmpty(this.txtAnioEspecialidad.Text) || string.IsNullOrEmpty(this.txtIdPlan.Text))
            {
                Notificar("Error", "Campos vacíos. Por favor complételos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
