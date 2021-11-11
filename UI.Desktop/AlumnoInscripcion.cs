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
    public partial class AlumnoInscripcion : ApplicationForm
    {
        public AlumnoInscripcion()
        {
            InitializeComponent();
            this.dgvInscripciones.AutoGenerateColumns = false;   
        }

        public void Listar()
        {   
            AlumnoInscripcionLogic al = new AlumnoInscripcionLogic();
            CursoLogic cl = new CursoLogic();
            MateriaLogic mat = new MateriaLogic();
            ComisionLogic com = new ComisionLogic();

            try
            {
                List<Curso> cursos = cl.GetAll();
                List<Business.Entities.AlumnoInscripcion> inscripciones = al.GetAll();
                List<Business.Entities.Materia> materias = mat.GetAll();
                List<Business.Entities.Comision> comisiones = com.GetAll();
                var consultaInscripciones =
                    from i in inscripciones
                    join c in cursos
                    on i.IDCurso equals c.ID
                    join m in materias
                    on c.IDMateria equals m.ID
                    join co in comisiones
                    on c.IDComision equals co.ID
                    select new
                    {
                        ID = i.ID,
                        IDAlumno = i.IDAlumno,
                        Materia = c.IDMateria, //Mostrar descripcion
                        DescMateria = m.Descripcion,
                        Curso = c.ID,
                        Comision = c.IDComision,
                        DescComision = co.Descripcion,
                        Condicion = i.Condicion,
                        Nota = i.Nota
                    };
                this.dgvInscripciones.DataSource = consultaInscripciones.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Listar(int idAlumno)
        {
            AlumnoInscripcionLogic al = new AlumnoInscripcionLogic();
            CursoLogic cl = new CursoLogic();
            MateriaLogic mat = new MateriaLogic();
            ComisionLogic com = new ComisionLogic();

            try
            {
                List<Curso> cursos = cl.GetAll();
                List<Business.Entities.AlumnoInscripcion> inscripciones = al.GetAll(idAlumno);
                List<Business.Entities.Materia> materias = mat.GetAll();
                List<Business.Entities.Comision> comisiones = com.GetAll();
                var consultaInscripciones =
                    from i in inscripciones
                    join c in cursos
                    on i.IDCurso equals c.ID
                    join m in materias
                    on c.IDMateria equals m.ID
                    join co in comisiones
                    on c.IDComision equals co.ID
                    select new
                    {
                        ID = i.ID,
                        IDAlumno = i.IDAlumno,
                        Materia = c.IDMateria, //Mostrar descripcion
                        DescMateria = m.Descripcion,
                        Curso = c.ID,
                        Comision = c.IDComision,
                        DescComision = co.Descripcion,
                        Condicion = i.Condicion,
                        Nota = i.Nota
                    };
                this.dgvInscripciones.DataSource = consultaInscripciones.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AlumnoInscripcion_Load(object sender, EventArgs e)
        {
            switch (PersonaLoggedIn.TipoPersonasString)
            {
                case "Alumno":
                    this.tsbEliminar.Visible = false;
                    this.tsbEditar.Visible = false;
                    this.dgvInscripciones.Columns["ID"].Visible = false;
                    this.dgvInscripciones.Columns["Curso"].Visible = false;
                    Listar(PersonaLoggedIn.ID);
                    break;
                case "NoDocente":
                    Listar();
                    break;
            }
            dgvInscripciones.ClearSelection();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            switch (PersonaLoggedIn.TipoPersonasString)
            {
                case "Alumno":
                    Listar(PersonaLoggedIn.ID);
                    break;
                case "NoDocente":
                    Listar();
                    break;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            AlumnoInscripcionDesktop formInscripcionDesktop = new AlumnoInscripcionDesktop(ApplicationForm.ModoForm.Alta);
            formInscripcionDesktop.ShowDialog();
            switch (PersonaLoggedIn.TipoPersonasString)
            {
                case "Alumno":
                    Listar(PersonaLoggedIn.ID);
                    break;
                case "NoDocente":
                    Listar();
                    break;
            }
            dgvInscripciones.ClearSelection();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvInscripciones.SelectedRows.Count != 0)
            {
                int ID = (int)this.dgvInscripciones.SelectedRows[0].Cells["Id"].Value;
                AlumnoInscripcionDesktop formInscripcionDesktop = new AlumnoInscripcionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formInscripcionDesktop.ShowDialog();
                this.Listar();
                dgvInscripciones.ClearSelection();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una fila para realizar la modificación.");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvInscripciones.SelectedRows.Count != 0)
            {
                int ID = (int)this.dgvInscripciones.SelectedRows[0].Cells["ID"].Value;
                AlumnoInscripcionDesktop formInscripcionDesktop = new AlumnoInscripcionDesktop(ID, ApplicationForm.ModoForm.Baja);
                formInscripcionDesktop.ShowDialog();
                this.Listar();
                dgvInscripciones.ClearSelection();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una fila para realizar la baja.");
            }
        }
    }
}