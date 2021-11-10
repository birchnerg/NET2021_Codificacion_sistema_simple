using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class MenuPpal : ApplicationForm
    {
        public MenuPpal()
        {
            InitializeComponent();
            PersonaLoggedIn = new Business.Entities.Persona();
        }

        private void MenuPpal_Shown(object sender, EventArgs e)
        {
            formLogin login = new formLogin();
            
            if (login.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
            
            switch (PersonaLoggedIn.TipoPersonasString)
            {
                case "Alumno":
                    this.tsmAlumno.Visible = true;
                    this.tsmReporteAcademico.Visible = true;
                    break;
                case "Docente":
                    this.tsmDocente.Visible = true;
                    this.ProfesoresToolStripMenuItem.Visible = false;
                    break;
                case "NoDocente":
                    this.tsmAlumno.Visible = true;
                    this.tsmComisiones.Visible = true;
                    this.tsmCursos.Visible = true;
                    this.tsmDocente.Visible = true;
                    this.tsmEspecialidades.Visible = true;
                    this.tsmMaterias.Visible = true;
                    this.tsmPlanes.Visible = true;
                    this.tsmUsuarios.Visible = true;
                    break;
            }
        }

        private void btnPersonas_Click(object sender, EventArgs e)
        {
            Personas formPersonas = new Personas();
            formPersonas.ShowDialog();
        }

        private void verPlanesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Planes formPlanes = new Planes();
            formPlanes.ShowDialog();
        }

        private void verEspecialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Especialidades formEspecialidades = new Especialidades();
            formEspecialidades.ShowDialog();
        }

        private void verUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios formUsuarios = new Usuarios();
            formUsuarios.ShowDialog();
        }

        private void verPersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personas formPersonas = new Personas();
            formPersonas.ShowDialog();
        }

        private void verComisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comisiones formComisiones = new Comisiones();
            formComisiones.ShowDialog();
        }

        private void verCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursos formCursos = new Cursos();
            formCursos.ShowDialog();
        }

        private void verMateriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Materias formMaterias = new Materias();
            formMaterias.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuPpal formMenu = new MenuPpal();
            formMenu.Show();
            this.Dispose(false);
        }

        private void misDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlumnoInscripcion formAlumnoInscripcion = new AlumnoInscripcion();
            formAlumnoInscripcion.ShowDialog();
        }

        private void salirDocente_Click(object sender, EventArgs e)
        {
            MenuPpal formMenu = new MenuPpal();
            formMenu.Show();
            this.Dispose(false);
        }

        private void NotasDeCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroNotas formRegistroNotas = new RegistroNotas();
            formRegistroNotas.ShowDialog();
        }

        private void ProfesoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profesor formProfesores = new Profesor();
            formProfesores.ShowDialog();
        }

        private void reporteAcademicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            materiasEstadoAlumno report = new materiasEstadoAlumno(PersonaLoggedIn);
            report.ShowDialog();
        }
    }
}
