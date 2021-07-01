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
            PlanLogic p = new PlanLogic();
            List<Plan> plan = p.GetAll();
            DataTable planes = new DataTable();
            planes.Columns.Add("id_plan", typeof(int));
            planes.Columns.Add("desc_plan", typeof(string));
            foreach (var e in plan)
            {
                planes.Rows.Add(new object[] { e.ID, e.Descripcion });
            }
            this.boxPlan.DataSource = planes;
            this.boxPlan.ValueMember = "id_plan";
            this.boxPlan.DisplayMember = "id_plan";
            this.boxPlan.SelectedIndex = -1;
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
            //this.boxPlan.SelectedIndex = this.ComisionActual.IDPlan - 1;
            this.boxPlan.Text = this.ComisionActual.IDPlan.ToString();
            switch (this.Modo)
            {
                case ModoForm.Alta:
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.txtDescripcion.Enabled = false;
                    this.txtAnioEspecialidad.Enabled = false;
                    this.boxPlan.Enabled = false;
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
                    ComisionActual.IDPlan = this.boxPlan.SelectedIndex + 1;
           
                    ComisionActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    ComisionActual.Descripcion = this.txtDescripcion.Text;
                    ComisionActual.AnioEspecialidad = Int32.Parse(this.txtAnioEspecialidad.Text);
                    ComisionActual.IDPlan = this.boxPlan.SelectedIndex + 1;
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
            int i;
            if (string.IsNullOrEmpty(this.txtDescripcion.Text) || string.IsNullOrEmpty(this.txtAnioEspecialidad.Text))
            {
                Notificar("Error", "Campos vacíos. Por favor complételos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!int.TryParse(this.txtAnioEspecialidad.Text, out i))
            {
                Notificar("Error", "Año especialidad incorrecto. Por favor ingrese un año válido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (this.boxPlan.SelectedIndex == -1)
            {
                Notificar("Error", "Plan no indicado. Por favor seleccione una.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ComisionDesktop_Load(object sender, EventArgs e)
        {
 /*           // TODO: esta línea de código carga datos en la tabla 'tp2_netDataSet.planes' Puede moverla o quitarla según sea necesario.
            this.planesTableAdapter1.Fill(this.tp2_netDataSet.planes);
            // TODO: esta línea de código carga datos en la tabla 'tp2_netDataSet1.planes' Puede moverla o quitarla según sea necesario.
            this.planesTableAdapter.Fill(this.tp2_netDataSet1.planes);
 */
        }
    }
}
