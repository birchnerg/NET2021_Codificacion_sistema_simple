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
    public partial class RegistroNotas : ApplicationForm
    {
        public RegistroNotas()
        {
            InitializeComponent();
            this.dgvDocentesCursos.AutoGenerateColumns = false;   
        }

        public void Listar()
        {
            DocenteCursoLogic dl = new DocenteCursoLogic();
            CursoLogic cl = new CursoLogic();
            AlumnoInscripcionLogic alu = new AlumnoInscripcionLogic();
            MateriaLogic mat = new MateriaLogic();
            ComisionLogic com = new ComisionLogic();
            PersonaLogic per = new PersonaLogic();
            try
            {
                List<Curso> cursos = cl.GetAll();
                List<DocenteCurso> docentes = dl.GetAll();
                List<Business.Entities.AlumnoInscripcion> alumnos = alu.GetAll();
                List<Materia> materias = mat.GetAll();
                List<Comision> comisiones = com.GetAll();
                List<Persona> personas = per.GetAll();
                var consultaDocenteCursos =
                    from d in docentes
                    join c in cursos
                    on d.IDCurso equals c.ID
                    join a in alumnos
                    on c.ID equals a.IDCurso into docCurAl
                    join m in materias
                    on c.IDMateria equals m.ID
                    join co in comisiones
                    on c.IDComision equals co.ID
                    join al in alumnos
                    on c.ID equals al.IDCurso
                    join pe in personas
                    on al.IDAlumno equals pe.ID


                    from da in docCurAl.DefaultIfEmpty() //Left Join
                    select new
                    {
                        ID = d.ID,
                        IDDocente = d.IDDocente,
                        Cargo = d.Cargo,
                        //IDAlumno = a.IDAlumno,
                        IDAlumno = da?.IDAlumno ?? 0, //If empty show 0
                        DescAlumno = pe.Apellido + " " + pe.Nombre,
                        DescLegajo = pe.Legajo,
                        Materia = c.IDMateria, //Mostrar descripcion
                        DescMateria = m.Descripcion,
                        Curso = c.ID,
                        Comision = c.IDComision,
                        DescComision = co.Descripcion,
                        IDInscripcion = da?.ID ?? 0,
                        //Condicion = a.Condicion,
                        //Nota = a.Nota
                        Condicion = da?.Condicion ?? string.Empty,
                        Nota = da?.Nota ?? 0
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
            AlumnoInscripcionLogic alu = new AlumnoInscripcionLogic();
            MateriaLogic mat = new MateriaLogic();
            ComisionLogic com = new ComisionLogic();
            PersonaLogic per = new PersonaLogic();
            try
            {
                List<Curso> cursos = cl.GetAll();
                List<DocenteCurso> docentes = dl.GetAll(idDocente);
                List<Business.Entities.AlumnoInscripcion> alumnos = alu.GetAll();
                List<Materia> materias = mat.GetAll();
                List<Comision> comisiones = com.GetAll();
                List<Persona> personas = per.GetAll();
                var consultaDocenteCursos =
                    from d in docentes
                    join c in cursos
                    on d.IDCurso equals c.ID
                    join a in alumnos
                    on c.ID equals a.IDCurso into docCurAl
                    join m in materias
                    on c.IDMateria equals m.ID
                    join co in comisiones
                    on c.IDComision equals co.ID
                    join al in alumnos
                    on c.ID equals al.IDCurso
                    join pe in personas
                    on al.IDAlumno equals pe.ID


                    from da in docCurAl.DefaultIfEmpty() //Left Join
                    select new
                    {
                        ID = d.ID,
                        IDDocente = d.IDDocente,
                        Cargo = d.Cargo,
                        //IDAlumno = a.IDAlumno,
                        IDAlumno = da?.IDAlumno ?? 0, //If empty show 0
                        DescAlumno = pe.Apellido + " " + pe.Nombre,
                        DescLegajo = pe.Legajo,
                        Materia = c.IDMateria, //Mostrar descripcion
                        DescMateria = m.Descripcion,
                        Curso = c.ID,
                        Comision = c.IDComision,
                        DescComision = co.Descripcion,
                        IDInscripcion = da?.ID ?? 0,
                        //Condicion = a.Condicion,
                        //Nota = a.Nota
                        Condicion = da?.Condicion ?? string.Empty,
                        Nota = da?.Nota ?? 0
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
            switch (PersonaLoggedIn.TipoPersonasString)
            {
                case "Docente":
                    this.tsbEliminar.Visible = false;
                    this.tsbNuevo.Visible = false;
                    this.dgvDocentesCursos.Columns["ID"].Visible = false;
                    this.dgvDocentesCursos.Columns["id_docente"].Visible = false;
                    this.dgvDocentesCursos.Columns["IDInscripcion"].Visible = false;
                    this.dgvDocentesCursos.Columns["cargo"].Visible = false;
                    this.dgvDocentesCursos.Columns["curso"].Visible = false;
                    Listar(PersonaLoggedIn.ID);
                    break;
                case "NoDocente":
                    Listar();
                    break;
            }
            dgvDocentesCursos.ClearSelection();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            switch (PersonaLoggedIn.TipoPersonasString)
            {
                case "Docente":
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
            MessageBox.Show("Para agregar un nuevo registro, agregue un alumno al curso desde el menú Alumnos");
            dgvDocentesCursos.ClearSelection();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvDocentesCursos.SelectedRows.Count != 0)
            {
                int ID = (int)this.dgvDocentesCursos.SelectedRows[0].Cells["Id"].Value;
                int IDDictado = (int)this.dgvDocentesCursos.SelectedRows[0].Cells["IDInscripcion"].Value;
                RegistroNotasDesktop formProfesoresDesktop = new RegistroNotasDesktop(ID, IDDictado, ApplicationForm.ModoForm.Modificacion);
                formProfesoresDesktop.ShowDialog();
                switch (PersonaLoggedIn.TipoPersonasString)
                {
                    case "Docente":
                        Listar(PersonaLoggedIn.ID);
                        break;
                    case "NoDocente":
                        Listar();
                        break;
                }
                dgvDocentesCursos.ClearSelection();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una fila para realizar la modificación.");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para borrar un registro, elimine un alumno del curso desde el menú Alumnos");
        }

        private void tscUsuarios_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }
    }
}