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
    public partial class RegistroNotasDesktop : ApplicationForm
    {
        public RegistroNotasDesktop()
        {
            InitializeComponent();
            CursoLogic c = new CursoLogic();
            PersonaLogic p = new PersonaLogic();
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

                List<Persona> persona = p.GetAll();
                DataTable docentes = new DataTable();
                docentes.Columns.Add("id_persona", typeof(int));
                DataTable alumnos = new DataTable();
                alumnos.Columns.Add("id_persona", typeof(int));
                alumnos.Columns.Add("nombre", typeof(string));
                foreach (var e in persona)
                {
                    if (e.TipoPersonasString == "Docente") //Si el tipo de persona es Docente
                    {
                        docentes.Rows.Add(new object[] { e.ID }); //Agregar el id al box IDDocente
                    } else if (e.TipoPersonasString == "Alumno") //Si es alumno
                    {
                        alumnos.Rows.Add(new object[] { e.ID, e.Apellido + " " + e.Nombre});//a IDAlumno
                    }
                    
                }
                this.boxDocente.DataSource = docentes;
                this.boxDocente.ValueMember = "id_persona";
                this.boxDocente.DisplayMember = "id_persona";
                this.boxDocente.SelectedIndex = -1;

                this.boxAlumno.DataSource = alumnos;
                this.boxAlumno.ValueMember = "id_persona";
                this.boxAlumno.DisplayMember = "nombre";
                this.boxAlumno.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (PersonaLoggedIn.TipoPersonasString == "Docente")
            {
                
                this.boxDocente.Text = PersonaLoggedIn.ID.ToString();
                this.boxDocente.Visible = false;
                this.boxCurso.Visible = false;
                this.boxAlumno.Visible = true;
                this.txtCargo.Visible = false;
                this.txtID.Visible = false;
                this.txtIDInscripcion.Visible = false;
                this.label1.Visible = false;
                this.label2.Visible = true;
                this.label8.Visible = false;
                this.label6.Visible = false;
                this.label3.Visible = false;
                this.label7.Visible = false;
                this.label1.Visible = false;
            }
        }

        public RegistroNotasDesktop(ModoForm modo):this() 
        {
            Modo = modo;
            if (this.Modo == ModoForm.Alta)
            {
                this.boxAlumno.Enabled = false;
                this.txtCondicion.Enabled = false;
                this.txtNota.Enabled = false;
            }
        }

        public RegistroNotasDesktop(int IDDictado, int IDInscripcion, ModoForm modo) : this()
        {
            Modo = modo;
            AlumnoInscripcionLogic inscripcion = new AlumnoInscripcionLogic();
            DocenteCursoLogic docente = new DocenteCursoLogic();
            try
            {
                if (IDInscripcion != 0)
                {
                    InscripcionActual = inscripcion.GetOne(IDInscripcion);
                }
                DocenteCursoActual = docente.GetOne(IDDictado);
                MapearDeDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DocenteCurso _DocenteCursoActual;
        public DocenteCurso DocenteCursoActual
        {
            get { return _DocenteCursoActual; }
            set { _DocenteCursoActual = value; }
        }

        private Business.Entities.AlumnoInscripcion _inscripcionActual;
        public Business.Entities.AlumnoInscripcion InscripcionActual
        {
            get { return _inscripcionActual; }
            set { _inscripcionActual = value; }
        }

        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.DocenteCursoActual.ID.ToString();
            this.boxAlumno.SelectedValue = this.InscripcionActual.IDAlumno;
            this.txtIDInscripcion.Text = this.InscripcionActual.ID.ToString();
            this.txtCondicion.Text = this.InscripcionActual.Condicion.ToString();
            this.txtNota.Text = this.InscripcionActual.Nota.ToString();
            this.boxCurso.SelectedValue = this.InscripcionActual.IDCurso;
            this.boxDocente.SelectedValue = this.DocenteCursoActual.IDDocente;
            this.txtCargo.Text = this.DocenteCursoActual.Cargo.ToString();
            switch (this.Modo)
            {
                case ModoForm.Alta:
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.boxAlumno.Enabled = false;
                    this.txtCondicion.Enabled = false;
                    this.txtNota.Enabled = false;
                    this.boxCurso.Enabled = false;
                    this.txtCargo.Enabled = false;
                    this.boxDocente.Enabled = false;
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
                    //InscripcionActual = new Business.Entities.AlumnoInscripcion();

                    DocenteCursoActual = new Business.Entities.DocenteCurso();
                    DocenteCursoActual.IDDocente = Int32.Parse(this.boxDocente.SelectedValue.ToString());
                    DocenteCursoActual.IDCurso = Int32.Parse(this.boxCurso.SelectedValue.ToString());
                    DocenteCursoActual.Cargo = (DocenteCurso.TiposCargos)Enum.Parse(typeof(DocenteCurso.TiposCargos), this.txtCargo.Text.ToString());

                    DocenteCursoActual.State = BusinessEntity.States.New;
                    //InscripcionActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    InscripcionActual.IDAlumno = Int32.Parse(this.boxAlumno.SelectedValue.ToString());
                    InscripcionActual.Condicion = this.txtCondicion.Text;
                    InscripcionActual.Nota = Int32.Parse(this.txtNota.Text);
                    InscripcionActual.IDCurso = Int32.Parse(this.boxCurso.SelectedValue.ToString());

                    DocenteCursoActual.IDDocente = Int32.Parse(this.boxDocente.SelectedValue.ToString());
                    DocenteCursoActual.IDCurso = Int32.Parse(this.boxCurso.SelectedValue.ToString());
                    DocenteCursoActual.Cargo = (DocenteCurso.TiposCargos)Enum.Parse(typeof(DocenteCurso.TiposCargos),this.txtCargo.Text.ToString());

                    DocenteCursoActual.State = BusinessEntity.States.Modified;
                    InscripcionActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }

        public override void GuardarCambios() 
        {
            MapearADatos();
            AlumnoInscripcionLogic a = new AlumnoInscripcionLogic();
            DocenteCursoLogic d = new DocenteCursoLogic();
            if (this.Modo == ModoForm.Baja)
            {
                var resultado = MessageBox.Show("¿Desea eliminar el registro?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        d.Delete(DocenteCursoActual.ID);//Borra docente de un curso
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
                    d.Save(DocenteCursoActual);
                    if (this.Modo == ModoForm.Modificacion)
                    {
                        a.Save(InscripcionActual); //guarda la nota del curso
                    }
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
            if (string.IsNullOrEmpty(this.txtCargo.Text) || (string.IsNullOrEmpty(this.txtCondicion.Text) && this.txtCondicion.Enabled == true) || (string.IsNullOrEmpty(this.txtNota.Text) && this.txtNota.Enabled == true))
            {
                Notificar("Error", "Campos vacíos. Por favor complételos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!int.TryParse(this.txtNota.Text, out i) && this.txtNota.Enabled == true)
            {
                Notificar("Error", "Nota incorrecta. Por favor ingrese una nota válida.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (this.boxCurso.SelectedIndex == -1)
            {
                Notificar("Error", "Curso no indicado. Por favor seleccione uno.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (this.boxDocente.SelectedIndex == -1)
            {
                Notificar("Error", "Docente no indicado. Por favor seleccione uno.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (this.boxAlumno.SelectedIndex == -1 && this.boxAlumno.Enabled == true)
            {
                Notificar("Error", "Alumno no indicado. Por favor seleccione uno.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ProfesoresDesktop_Load(object sender, EventArgs e)
        {
 /*           // TODO: esta línea de código carga datos en la tabla 'tp2_netDataSet.planes' Puede moverla o quitarla según sea necesario.
            this.planesTableAdapter1.Fill(this.tp2_netDataSet.planes);
            // TODO: esta línea de código carga datos en la tabla 'tp2_netDataSet1.planes' Puede moverla o quitarla según sea necesario.
            this.planesTableAdapter.Fill(this.tp2_netDataSet1.planes);
 */
        }
    }
}