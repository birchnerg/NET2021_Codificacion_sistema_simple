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
    public partial class Alumnos : BaseABM
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) // Verifica que no se una nueva visita (primera carga)
            {
                if (CheckPermission("NoDocente"))
                {
                    LoadGrid();
                }
                else if (CheckPermission("Alumno"))
                {
                    LoadGridAlumno();
                    this.eliminarLinkButton.Visible = false;
                    this.editarLinkButrron.Visible = false;
                }
                else
                {
                    Page.Response.Redirect("~/Default.aspx");
                }
            }
        }
        AlumnoInscripcionLogic _logic;
        private AlumnoInscripcionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new AlumnoInscripcionLogic();
                }
                return _logic;
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
        MateriaLogic _MateriaLogic;
        private MateriaLogic MateriaLogic
        {
            get
            {
                if (_MateriaLogic == null)
                {
                    _MateriaLogic = new MateriaLogic();
                }
                return _MateriaLogic;
            }
        }
        ComisionLogic _ComisionLogic;
        private ComisionLogic ComisionLogic
        {
            get
            {
                if (_ComisionLogic == null)
                {
                    _ComisionLogic = new ComisionLogic();
                }
                return _ComisionLogic;
            }
        }

        private void LoadGrid()
        {
            var consultaInscripciones =
                    from i in this.Logic.GetAll()
                    join c in this.CursoLogic.GetAll()
                    on i.IDCurso equals c.ID
                    select new
                    {
                        ID = i.ID,
                        IDAlumno = i.IDAlumno,
                        Materia = c.IDMateria, //Mostrar descripcion
                        IDCurso = c.ID,
                        Comision = c.IDComision,
                        Condicion = i.Condicion,
                        Nota = i.Nota
                    };
            this.gridView.DataSource = consultaInscripciones.ToList();
            this.gridView.DataBind();
        }
        private void LoadGridAlumno()
        {
            var consultaInscripciones =
                    from i in this.Logic.GetAll(Int32.Parse(Session["IdUsuario"].ToString()))
                    join c in this.CursoLogic.GetAll()
                    on i.IDCurso equals c.ID
                    join m in this.MateriaLogic.GetAll()
                    on c.IDMateria equals m.ID
                    join com in this.ComisionLogic.GetAll()
                    on c.IDComision equals com.ID
                    select new
                    {
                        ID = i.ID,
                        IDAlumno = Session["Apellido"].ToString() + " "+Session["Nombre"].ToString(),
                        Materia = m.Descripcion, //Mostrar descripcion
                        IDCurso = c.ID,
                        Comision = com.Descripcion,
                        Condicion = i.Condicion,
                        Nota = i.Nota
                    };
            this.gridView.DataSource = consultaInscripciones.ToList();
            this.gridView.DataBind();
        }
        private AlumnoInscripcion Entity
        {
            get;
            set;
        }
        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.iDAlumnoTextBox.Text = this.Entity.IDAlumno.ToString();
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
            this.idCursoList.SelectedValue = this.Entity.IDCurso.ToString();
            

            this.condicionTextBox.Text = this.Entity.Condicion;
            this.notaTextBox.Text = this.Entity.Nota.ToString();
        }

        protected void editarLinkButrron_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.gridPanel.Visible = false;
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.EnableForm(true);
                this.LoadForm(this.SelectedID);
            }
        }

        private void LoadEntity(AlumnoInscripcion alumno)
        {
            alumno.IDAlumno = Int32.Parse(Session["IdUsuario"].ToString());
            alumno.IDCurso = Int32.Parse(this.idCursoList.SelectedValue);
            alumno.Condicion = this.condicionTextBox.Text;
            alumno.Nota = Int32.Parse(this.notaTextBox.Text);
        }

        private void SaveEntity(AlumnoInscripcion alumno)
        {
            if (Page.IsValid)
            {
                this.Logic.Save(alumno);
            }            
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new AlumnoInscripcion();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new AlumnoInscripcion();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    if (CheckPermission("NoDocente"))
                    {
                        LoadGrid();
                    }
                    else if (CheckPermission("Alumno"))
                    {
                        LoadGridAlumno();
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
            if (CheckPermission("Alumno"))
            {
                this.iDAlumnoTextBox.Enabled = false;
                this.iDAlumnoTextBox.Text = Session["IdUsuario"].ToString();
                this.idCursoList.Enabled = enable;
                this.condicionTextBox.Enabled = false;
                this.condicionTextBox.Text = "Cursa";
                this.notaTextBox.Enabled = false;
                this.notaTextBox.Text = "0";
            }
            else if (CheckPermission("NoDente"))
            {
                this.iDAlumnoTextBox.Enabled = enable;
                this.idCursoList.Enabled = enable;
                this.condicionTextBox.Enabled = enable;
                this.notaTextBox.Enabled = enable;
            }
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.gridPanel.Visible = false;
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.gridPanel.Visible = false;
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
            this.condicionTextBox.Visible = false;
            this.notaTextBox.Visible = false;
            this.CondicionLabel.Visible = false;
            this.NotaLabel.Visible = false;
            this.iDAlumnoTextBox.Text = Session["Apellido"].ToString() + " " + Session["Nombre"].ToString();


            var materias =
                    from i in this.Logic.GetAll(Int32.Parse(Session["IdUsuario"].ToString()))
                    join c in this.CursoLogic.GetAll()
                    on i.IDCurso equals c.ID
                    join m in this.MateriaLogic.GetAll()
                    on c.IDMateria equals m.ID
                    join com in this.ComisionLogic.GetAll()
                    on c.IDComision equals com.ID
                    select new
                    {
                        id_curso = i.IDCurso,
                        desc_curso = com.Descripcion + " - " + m.Descripcion 
                    };
            DataTable cursos = new DataTable();
            cursos.Columns.Add("id_curso", typeof(int));
            cursos.Columns.Add("descripcion", typeof(string));
            foreach (var s in materias)
            {
                cursos.Rows.Add(new object[] { s.id_curso, s.desc_curso });
            }
            this.idCursoList.DataSource = cursos;
            this.idCursoList.DataValueField = "id_curso";
            this.idCursoList.DataTextField = "descripcion"; //materia y comision
            this.idCursoList.DataBind();

        }

        private void ClearForm()
        {
            this.iDAlumnoTextBox.Text = string.Empty;
            this.condicionTextBox.Text = string.Empty;
            this.notaTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {           
            this.formPanel.Visible = false;
            this.gridPanel.Visible = true;
        }
    }
}