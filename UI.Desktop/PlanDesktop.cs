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
    public partial class PlanDesktop : ApplicationForm
    {
        public PlanDesktop()
        {
            InitializeComponent();
            EspecialidadLogic el = new EspecialidadLogic();
            try
            {
                List<Especialidad> especialidades = el.GetAll();
                DataTable dtEspecialidad = new DataTable();
                dtEspecialidad.Columns.Add("id_especialidad", typeof(int));
                dtEspecialidad.Columns.Add("desc_especialidad", typeof(string));
                foreach (var e in especialidades)
                {
                    dtEspecialidad.Rows.Add(new object[] { e.ID, e.Descripcion });
                }
                this.boxEspecialidad.DataSource = dtEspecialidad;
                this.boxEspecialidad.ValueMember = "id_especialidad";
                this.boxEspecialidad.DisplayMember = "desc_especialidad";
                this.boxEspecialidad.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        public PlanDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            PlanLogic plan = new PlanLogic();
            try
            {
                PlanActual = plan.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Plan _plan;
        public Plan PlanActual
        {
            get { return _plan; }
            set { _plan = value; }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
            this.boxEspecialidad.SelectedValue = this.PlanActual.IDEspecialidad;
            switch (this.Modo)
            {
                case ModoForm.Alta:
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.txtDescripcion.Enabled = false;
                    this.boxEspecialidad.Enabled = false;
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
                    PlanActual = new Plan();
                    PlanActual.Descripcion = this.txtDescripcion.Text;
                    PlanActual.IDEspecialidad = Int32.Parse(this.boxEspecialidad.SelectedValue.ToString());
                    PlanActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    PlanActual.Descripcion = this.txtDescripcion.Text;
                    PlanActual.IDEspecialidad = Int32.Parse(this.boxEspecialidad.SelectedValue.ToString());
                    PlanActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            PlanLogic p = new PlanLogic();
            if (this.Modo == ModoForm.Baja)
            {
                var resultado = MessageBox.Show("¿Desea eliminar el registro?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        p.Delete(PlanActual.ID);
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
                    p.Save(PlanActual);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.txtDescripcion.Text))
            {
                Notificar("Error", "Campo vacío. Por favor complételo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (this.boxEspecialidad.SelectedIndex == -1)
            {
                Notificar("Error", "Especialidad no indicada. Por favor seleccione una.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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