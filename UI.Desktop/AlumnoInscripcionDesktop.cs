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
    public partial class AlumnoInscripcionDesktop : ApplicationForm
    {
        public AlumnoInscripcionDesktop()
        {
            InitializeComponent();
            CursoLogic c = new CursoLogic();
            try
            {
                List<Curso> curso = c.GetAll();
                DataTable cursos = new DataTable();
                cursos.Columns.Add("id_curso", typeof(int));
                foreach (var e in curso)
                {
                    cursos.Rows.Add(new object[] { e.ID});
                }
                this.boxCurso.DataSource = cursos;
                this.boxCurso.ValueMember = "id_curso";
                this.boxCurso.DisplayMember = "id_curso";
                this.boxCurso.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (PersonaLoggedIn.TipoPersonasString == "Alumno")
            { 
                this.txtIDAlumno.Text = PersonaLoggedIn.ID.ToString(); ;
                this.txtIDAlumno.ReadOnly = true;
                this.txtCondicion.Text = "Cursa";
                this.txtCondicion.Enabled = false;
                this.txtNota.Text = "0";
                this.txtNota.Enabled = false;
            }
        }

        public AlumnoInscripcionDesktop(ModoForm modo):this() 
        {
            Modo = modo;
        }

        public AlumnoInscripcionDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            AlumnoInscripcionLogic inscripcion = new AlumnoInscripcionLogic();
            try
            { 
                InscripcionActual = inscripcion.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Business.Entities.AlumnoInscripcion _inscripcionActual;
        public Business.Entities.AlumnoInscripcion InscripcionActual
        {
            get { return _inscripcionActual; }
            set { _inscripcionActual = value; }
        }
        
        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.InscripcionActual.ID.ToString();
            this.txtIDAlumno.Text = this.InscripcionActual.IDAlumno.ToString();
            this.txtCondicion.Text = this.InscripcionActual.Condicion.ToString();
            this.txtNota.Text = this.InscripcionActual.Nota.ToString();
            this.boxCurso.SelectedValue = this.InscripcionActual.IDCurso;
            switch (this.Modo)
            {
                case ModoForm.Alta:
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.txtIDAlumno.Enabled = false;
                    this.txtCondicion.Enabled = false;
                    this.txtNota.Enabled = false;
                    this.boxCurso.Enabled = false;
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
                    InscripcionActual = new Business.Entities.AlumnoInscripcion();
                    InscripcionActual.IDAlumno = Int32.Parse(this.txtIDAlumno.Text);
                    InscripcionActual.Condicion = this.txtCondicion.Text;
                    InscripcionActual.Nota = Int32.Parse(this.txtNota.Text);
                    InscripcionActual.IDCurso = Int32.Parse(this.boxCurso.SelectedValue.ToString());

                    InscripcionActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    InscripcionActual = new Business.Entities.AlumnoInscripcion();
                    InscripcionActual.IDAlumno = Int32.Parse(this.txtIDAlumno.Text);
                    InscripcionActual.Condicion = this.txtCondicion.Text;
                    InscripcionActual.Nota = Int32.Parse(this.txtNota.Text);
                    InscripcionActual.IDCurso = Int32.Parse(this.boxCurso.SelectedValue.ToString());
                    InscripcionActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }

        public override void GuardarCambios() 
        {
            MapearADatos();
            AlumnoInscripcionLogic a = new AlumnoInscripcionLogic();
            if (this.Modo == ModoForm.Baja)
            {
                var resultado = MessageBox.Show("¿Desea eliminar el registro?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        a.Delete(InscripcionActual.ID);
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
                    a.Save(InscripcionActual);
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
            if (string.IsNullOrEmpty(this.txtIDAlumno.Text) || string.IsNullOrEmpty(this.txtCondicion.Text) || string.IsNullOrEmpty(this.txtNota.Text))
            {
                Notificar("Error", "Campos vacíos. Por favor complételos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!int.TryParse(this.txtNota.Text, out i))
            {
                Notificar("Error", "Nota incorrecta. Por favor ingrese una nota válida.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!int.TryParse(this.txtIDAlumno.Text, out i))
            {
                Notificar("Error", "ID Alumno incorrecta. Por favor ingrese un ID válido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (this.boxCurso.SelectedIndex == -1)
            {
                Notificar("Error", "Curso no indicado. Por favor seleccione uno.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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