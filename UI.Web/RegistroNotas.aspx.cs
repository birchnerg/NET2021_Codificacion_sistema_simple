using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;
using System.Data;

namespace UI.Web
{
    public partial class RegistroNotas : BaseABM
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) // Verifica que no se una nueva visita (primera carga)
            {
                if (CheckPermission("NoDocente"))
                {
                    LoadGrid();
                }
                else if (CheckPermission("Docente"))
                {
                    LoadGridDocente();
                }
                else
                {
                    Page.Response.Redirect("~/Default.aspx");
                }
                this.eliminarLinkButton.Visible = false;
                this.nuevoLinkButton.Visible = false;
            }
        }
        DocenteCursoLogic _logic;
        private DocenteCursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new DocenteCursoLogic();
                }
                return _logic;
            }
        }
        AlumnoInscripcionLogic _Inscripcionlogic;
        private AlumnoInscripcionLogic Inscripcionlogic
        {
            get
            {
                if (_Inscripcionlogic == null)
                {
                    _Inscripcionlogic = new AlumnoInscripcionLogic();
                }
                return _Inscripcionlogic;
            }
        }
        CursoLogic _Cursologic;
        private CursoLogic CursoLogic
        {
            get
            {
                if (_Cursologic == null)
                {
                    _Cursologic = new CursoLogic();
                }
                return _Cursologic;
            }
        }
        private void LoadGrid()
        {
            var consultaDocenteCursos =
                    from d in this.Logic.GetAll()
                    join c in this.CursoLogic.GetAll()
                    on d.IDCurso equals c.ID
                    join a in Inscripcionlogic.GetAll()
                    on c.ID equals a.IDCurso into docCurAl
                    from da in docCurAl.DefaultIfEmpty() //Left Join
                    select new
                    {
                        ID = d.ID,
                        IDDocente = d.IDDocente,
                        Cargo = d.Cargo,
                        //IDAlumno = a.IDAlumno,
                        IDAlumno = da?.IDAlumno ?? 0, //If empty show 0
                        Materia = c.IDMateria, //Mostrar descripcion
                        IDCurso = c.ID,
                        Comision = c.IDComision,
                        IDInscripcion = da?.ID ?? 0,
                        //Condicion = a.Condicion,
                        //Nota = a.Nota
                        Condicion = da?.Condicion ?? string.Empty,
                        Nota = da?.Nota ?? 0
                    };
            this.gridView.DataSource = consultaDocenteCursos.ToList();
            this.gridView.DataBind();
        }
        private void LoadGridDocente()
        {
            var consultaDocenteCursos =
                    from d in this.Logic.GetAll(Int32.Parse(Session["IdUsuario"].ToString()))
                    join c in this.CursoLogic.GetAll()
                    on d.IDCurso equals c.ID
                    join a in Inscripcionlogic.GetAll()
                    on c.ID equals a.IDCurso into docCurAl
                    from da in docCurAl.DefaultIfEmpty() //Left Join
                    select new
                    {
                        ID = d.ID,
                        IDDocente = d.IDDocente,
                        Cargo = d.Cargo,
                        //IDAlumno = a.IDAlumno,
                        IDAlumno = da?.IDAlumno ?? 0, //If empty show 0
                        Materia = c.IDMateria, //Mostrar descripcion
                        IDCurso = c.ID,
                        Comision = c.IDComision,
                        IDInscripcion = da?.ID ?? 0,
                        //Condicion = a.Condicion,
                        //Nota = a.Nota
                        Condicion = da?.Condicion ?? string.Empty,
                        Nota = da?.Nota ?? 0
                    };
            this.gridView.DataSource = consultaDocenteCursos.ToList();
            this.gridView.DataBind();
        }
        private AlumnoInscripcion EntityInscripcion
        {
            get;
            set;
        }
        private DocenteCurso EntityDocenteCurso
        {
            get;
            set;
        }
        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id,int IdCurso)
        {
            this.EntityDocenteCurso = this.Logic.GetOne(id);
            this.iDDocenteTextBox.Text = this.EntityDocenteCurso.IDDocente.ToString();

            this.EntityInscripcion = this.Inscripcionlogic.GetOne(IdCurso);
            this.iDAlumnoTextBox.Text = this.EntityInscripcion.IDAlumno.ToString();

            this.CargoTextBox.Text = this.EntityDocenteCurso.Cargo.ToString();

            List<Curso> curso = CursoLogic.GetAll();
            DataTable cursos = new DataTable();
            cursos.Columns.Add("id_curso", typeof(int));
            foreach (var e in curso)
            {
                cursos.Rows.Add(new object[] { e.ID });
            }
            this.idCursoList.DataSource = cursos;
            this.idCursoList.DataValueField = "id_curso";
            this.idCursoList.DataTextField = "id_curso"; //materia y comision
            this.idCursoList.DataBind();
            this.idCursoList.SelectedValue = this.EntityDocenteCurso.IDCurso.ToString();
            

            this.condicionTextBox.Text = this.EntityInscripcion.Condicion;
            this.notaTextBox.Text = this.EntityInscripcion.Nota.ToString();
        }

        protected void editarLinkButrron_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.gridPanel.Visible = false;
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.EnableForm(true);
                this.LoadForm(this.SelectedID,Int32.Parse(this.gridView.SelectedRow.Cells[4].Text));
            }
        }

        private void LoadEntity(AlumnoInscripcion alumno)
        {
            alumno.IDAlumno = Int32.Parse(this.iDAlumnoTextBox.Text);
            alumno.IDCurso = Int32.Parse(this.idCursoList.SelectedValue);
            alumno.Condicion = this.condicionTextBox.Text;
            alumno.Nota = Int32.Parse(this.notaTextBox.Text);
        }

        private void SaveEntity(AlumnoInscripcion alumno)
        {
            if (Page.IsValid)
            {
                this.Inscripcionlogic.Save(alumno);
            }            
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Modificacion:
                    this.EntityInscripcion = new AlumnoInscripcion();
                    this.EntityInscripcion.ID = Int32.Parse(this.gridView.SelectedRow.Cells[4].Text);
                    this.EntityInscripcion.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.EntityInscripcion);
                    this.SaveEntity(this.EntityInscripcion);
                    if (CheckPermission("NoDocente"))
                    {
                        LoadGrid();
                    }
                    else if (CheckPermission("Docente"))
                    {
                        LoadGridDocente();
                    }
                    break;
                default:
                    break;
            }            
            this.formPanel.Visible = false;
            this.gridPanel.Visible = true;
        }

        private void EnableForm(bool enable)
        {
            if (CheckPermission("Docente"))
            {
                this.iDDocenteTextBox.Enabled = false;
                this.iDAlumnoTextBox.Enabled = false;
                this.CargoTextBox.Enabled = false;
                this.idCursoList.Enabled = false;
                this.condicionTextBox.Enabled = enable;
                this.notaTextBox.Enabled = enable;
            }
            else if (CheckPermission("NoDocente"))
            {
                this.iDDocenteTextBox.Enabled = enable;
                this.iDAlumnoTextBox.Enabled = enable;
                this.CargoTextBox.Enabled = enable;
                this.idCursoList.Enabled = enable;
                this.condicionTextBox.Enabled = enable;
                this.notaTextBox.Enabled = enable;
            }
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {

        }

        private void ClearForm()
        {

        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {           
            this.formPanel.Visible = false;
            this.gridPanel.Visible = true;
        }
    }
}