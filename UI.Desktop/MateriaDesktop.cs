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
    public partial class MateriaDesktop : ApplicationForm
    {
        public MateriaDesktop()
        {
            InitializeComponent();
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
                this.boxPlan.DataSource = planes;
                this.boxPlan.ValueMember = "id_plan";
                this.boxPlan.DisplayMember = "desc_plan";
                this.boxPlan.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public MateriaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public MateriaDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            MateriaLogic materia = new MateriaLogic();
            try
            {
                MateriaActual = materia.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Materia _materia;
        public Materia MateriaActual
        {
            get { return _materia; }
            set { _materia = value; }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            this.txtHorasSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHorasTotales.Text = this.MateriaActual.HSTotales.ToString();
            this.boxPlan.SelectedValue = this.MateriaActual.IDPlan;
            switch (this.Modo)
            {
                case ModoForm.Alta:
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.txtDescripcion.Enabled = false;
                    this.txtHorasSemanales.Enabled = false;
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
                    MateriaActual = new Materia();
                    MateriaActual.Descripcion = this.txtDescripcion.Text;
                    MateriaActual.HSSemanales = Int32.Parse(this.txtHorasSemanales.Text);
                    MateriaActual.HSTotales = Int32.Parse(this.txtHorasTotales.Text);
                    MateriaActual.IDPlan = Int32.Parse(this.boxPlan.SelectedValue.ToString());
                    MateriaActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    MateriaActual.Descripcion = this.txtDescripcion.Text;
                    MateriaActual.HSSemanales = Int32.Parse(this.txtHorasSemanales.Text);
                    MateriaActual.HSTotales = Int32.Parse(this.txtHorasTotales.Text);
                    MateriaActual.IDPlan = Int32.Parse(this.boxPlan.SelectedValue.ToString());
                    MateriaActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            MateriaLogic m = new MateriaLogic();
            if (this.Modo == ModoForm.Baja)
            {
                var resultado = MessageBox.Show("¿Desea eliminar el registro?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        m.Delete(MateriaActual.ID);
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
                    m.Save(MateriaActual);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public override bool Validar()
        {
            int i;
            if (string.IsNullOrEmpty(this.txtDescripcion.Text) || string.IsNullOrEmpty(this.txtHorasSemanales.Text))
            {
                Notificar("Error", "Campos vacíos. Por favor complételos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!int.TryParse(this.txtHorasSemanales.Text, out i))
            {
                Notificar("Error", "Cantidad de Horas Semanales Incorrectas. Por favor ingrese una cantidad válida.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!int.TryParse(this.txtHorasTotales.Text, out i))
            {
                Notificar("Error", "Cantidad de Horas Totales Incorrectas. Por favor ingrese una cantidad válida.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void MateriaDesktop_Load(object sender, EventArgs e)
        {
            /*           // TODO: esta línea de código carga datos en la tabla 'tp2_netDataSet.planes' Puede moverla o quitarla según sea necesario.
                       this.planesTableAdapter1.Fill(this.tp2_netDataSet.planes);
                       // TODO: esta línea de código carga datos en la tabla 'tp2_netDataSet1.planes' Puede moverla o quitarla según sea necesario.
                       this.planesTableAdapter.Fill(this.tp2_netDataSet1.planes);
            */
        }
    }
}