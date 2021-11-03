using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Planes : Form
    {
        public Planes()
        {
            InitializeComponent();
            this.dgvPlanes.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            EspecialidadLogic el = new EspecialidadLogic();
            try
            {
                List<Plan> planes = pl.GetAll();
                List<Especialidad> especialidades = el.GetAll();
                var consultaPlanes =
                    from p in planes
                    join e in especialidades
                    on p.IDEspecialidad equals e.ID
                    select new
                    {
                        ID = p.ID,
                        Descripcion = p.Descripcion,
                        Especialidad = e.Descripcion
                    };
                this.dgvPlanes.DataSource = consultaPlanes.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void Planes_Load(object sender, EventArgs e)
        {
            Listar();
            dgvPlanes.ClearSelection();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanDesktop formPlan = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            formPlan.ShowDialog();
            this.Listar();
            dgvPlanes.ClearSelection();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count != 0)
            {
                int ID = (int)this.dgvPlanes.SelectedRows[0].Cells["Id"].Value;
                PlanDesktop formPlan = new PlanDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formPlan.ShowDialog();
                this.Listar();
                dgvPlanes.ClearSelection();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una fila para realizar la modificación.");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count != 0)
            {
                int ID = (int)this.dgvPlanes.SelectedRows[0].Cells["Id"].Value;
                PlanDesktop formPlan = new PlanDesktop(ID, ApplicationForm.ModoForm.Baja);
                formPlan.ShowDialog();
                this.Listar();
                dgvPlanes.ClearSelection();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una fila para realizar la baja.");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PlanesReporte report = new PlanesReporte();
            report.ShowDialog();
        }
    }
}