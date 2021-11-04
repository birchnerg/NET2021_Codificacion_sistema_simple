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

            try
            {
                List<Curso> cursos = cl.GetAll();
                List<Business.Entities.AlumnoInscripcion> inscripciones = al.GetAll();
                var consultaInscripciones =
                    from i in inscripciones
                    join c in cursos
                    on i.IDCurso equals c.ID
                    select new
                    {
                        ID = i.ID,
                        IDAlumno = i.IDAlumno,
                        Curso = c.ID,
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

        private void Comisiones_Load(object sender, EventArgs e)
        {
            Listar();
            dgvInscripciones.ClearSelection();
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
            ComisionDesktop formComision = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            formComision.ShowDialog();
            this.Listar();
            dgvInscripciones.ClearSelection();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvInscripciones.SelectedRows.Count != 0)
            {
                int ID = (int)this.dgvInscripciones.SelectedRows[0].Cells["Id"].Value;
                ComisionDesktop formComision = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formComision.ShowDialog();
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
                int ID = (int)this.dgvInscripciones.SelectedRows[0].Cells["Id"].Value;
                ComisionDesktop formComision = new ComisionDesktop(ID, ApplicationForm.ModoForm.Baja);
                formComision.ShowDialog();
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