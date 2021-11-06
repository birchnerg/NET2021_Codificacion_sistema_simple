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
    public partial class Cursos : Form
    {
        public Cursos()
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            CursoLogic cu = new CursoLogic();
            ComisionLogic co = new ComisionLogic();
            MateriaLogic ma = new MateriaLogic();
            try
            {
                List<Curso> cursos = cu.GetAll();
                List<Comision> comisiones = co.GetAll();
                List<Materia> materias = ma.GetAll();
                var consultaCursos =
                    from c in cursos
                    join com in comisiones
                    on c.IDComision equals com.ID
                    join ma in materias
                    on c.IDMateria equals ma.ID
                    select new
                    {
                        ID = c.ID,
                        Materia = ma.Descripcion,
                        IDMateria = ma.IDMateria,
                        Comision = com.Descripcion,
                        IDComision = com.ID,
                        AnioCalendario = c.AnioCalendario,
                        Cupo = c.Cupo
                    };
                this.dgvCursos.DataSource = consultaCursos.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            Listar();
            dgvCursos.ClearSelection();
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
            CursoDesktop formCurso = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            formCurso.ShowDialog();
            this.Listar();
            dgvCursos.ClearSelection();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count != 0)
            {
                int ID = (int)this.dgvCursos.SelectedRows[0].Cells["Id"].Value;
                CursoDesktop formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formCurso.ShowDialog();
                this.Listar();
                dgvCursos.ClearSelection();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una fila para realizar la modificación.");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.SelectedRows.Count != 0)
            {
                int ID = (int)this.dgvCursos.SelectedRows[0].Cells["Id"].Value;
                CursoDesktop formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.Baja);
                formCurso.ShowDialog();
                this.Listar();
                dgvCursos.ClearSelection();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una fila para realizar la baja.");
            }
        }
    }
}
