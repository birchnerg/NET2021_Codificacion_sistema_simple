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
    public partial class Materias : Form
    {
        public Materias()
        {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            MateriaLogic ml = new MateriaLogic();
            PlanLogic pl = new PlanLogic();
            try
            {
                List<Materia> materias = ml.GetAll();
                List<Plan> planes = pl.GetAll();
                var consultaMaterias =
                    from m in materias
                    join p in planes
                    on m.IDPlan equals p.ID
                    select new
                    {
                        ID = m.ID,
                        Descripcion = m.Descripcion,
                        HSSemanales = m.HSSemanales,
                        HSTotales = m.HSTotales,
                        Plan = p.Descripcion
                    };
                this.dgvMaterias.DataSource = consultaMaterias.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            Listar();
            dgvMaterias.ClearSelection();
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
            MateriaDesktop formMateria = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            formMateria.ShowDialog();
            this.Listar();
            dgvMaterias.ClearSelection();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows.Count != 0)
            {
                int ID = (int)this.dgvMaterias.SelectedRows[0].Cells["Id"].Value;
                MateriaDesktop formMaterias = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formMaterias.ShowDialog();
                this.Listar();
                dgvMaterias.ClearSelection();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una fila para realizar la modificación.");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows.Count != 0)
            {
                int ID = (int)this.dgvMaterias.SelectedRows[0].Cells["Id"].Value;
                MateriaDesktop formComision = new MateriaDesktop(ID, ApplicationForm.ModoForm.Baja);
                formComision.ShowDialog();
                this.Listar();
                dgvMaterias.ClearSelection();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una fila para realizar la baja.");
            }
        }
    }
}