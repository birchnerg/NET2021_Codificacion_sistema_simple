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
    public partial class Profesor : ApplicationForm
    {
        public Profesor()
        {
            InitializeComponent();
            this.dgvDocentesCursos.AutoGenerateColumns = false;   
        }

        public void Listar()
        {   
            DocenteCursoLogic dl = new DocenteCursoLogic();
            CursoLogic cl = new CursoLogic();
            try
            {
                List<Curso> cursos = cl.GetAll();
                List<DocenteCurso> docentes = dl.GetAll();
                var consultaDocenteCursos =
                    from d in docentes
                    join c in cursos
                    on d.IDCurso equals c.ID
                    select new
                    {
                        ID = d.ID,
                        IDDocente = d.IDDocente,
                        Cargo = d.Cargo,
                        Materia = c.IDMateria, //Mostrar descripcion
                        Curso = c.ID,
                        Comision = c.IDComision,
                    };
                this.dgvDocentesCursos.DataSource = consultaDocenteCursos.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Listar(int idDocente)
        {
            DocenteCursoLogic dl = new DocenteCursoLogic();
            CursoLogic cl = new CursoLogic();
            try
            {
                List<Curso> cursos = cl.GetAll();
                List<DocenteCurso> docentes = dl.GetAll(idDocente);
                var consultaDocenteCursos =
                    from d in docentes
                    join c in cursos
                    on d.IDCurso equals c.ID
                    select new
                    {
                        ID = d.ID,
                        IDDocente = d.IDDocente,
                        Cargo = d.Cargo,
                        Materia = c.IDMateria, //Mostrar descripcion
                        Curso = c.ID,
                        Comision = c.IDComision,
                    };
                this.dgvDocentesCursos.DataSource = consultaDocenteCursos.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Profesores_Load(object sender, EventArgs e)
        {
            Listar();
            dgvDocentesCursos.ClearSelection();
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
            ProfesorDesktop formProfesoresDesktop = new ProfesorDesktop(ApplicationForm.ModoForm.Alta);
            formProfesoresDesktop.ShowDialog();
            Listar();
            dgvDocentesCursos.ClearSelection();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvDocentesCursos.SelectedRows.Count != 0)
            {
                int ID = (int)this.dgvDocentesCursos.SelectedRows[0].Cells["Id"].Value;
                ProfesorDesktop formProfesoresDesktop = new ProfesorDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formProfesoresDesktop.ShowDialog();
                Listar();
                dgvDocentesCursos.ClearSelection();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una fila para realizar la modificación.");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvDocentesCursos.SelectedRows.Count != 0)
            {
                int ID = (int)this.dgvDocentesCursos.SelectedRows[0].Cells["Id"].Value;
                ProfesorDesktop formProfesoresDesktop = new ProfesorDesktop(ID, ApplicationForm.ModoForm.Baja);
                formProfesoresDesktop.ShowDialog();
                this.Listar();
                dgvDocentesCursos.ClearSelection();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una fila para realizar la baja.");
            }
        }
    }
}