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
    public partial class Profesores : BaseABM
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) // Verifica que no se una nueva visita (primera carga)
            {
                if (CheckPermission("NoDocente"))
                {
                    LoadGrid();
                }
                else
                {
                    Page.Response.Redirect("~/Default.aspx");
                }
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
                    select new
                    {
                        ID = d.ID,
                        IDDocente = d.IDDocente,
                        Cargo = d.Cargo,
                        Materia = c.IDMateria, //Mostrar descripcion
                        IDCurso = c.ID,
                        Comision = c.IDComision,
                    };
            this.gridView.DataSource = consultaDocenteCursos.ToList();
            this.gridView.DataBind();
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

        private void LoadForm(int id)
        {
            this.EntityDocenteCurso = this.Logic.GetOne(id);
            this.iDDocenteTextBox.Text = this.EntityDocenteCurso.IDDocente.ToString();

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

        private void LoadEntity(DocenteCurso docente)
        {
            docente.IDDocente = Int32.Parse(this.iDDocenteTextBox.Text);
            docente.IDCurso = Int32.Parse(this.idCursoList.SelectedValue);
            docente.Cargo = (DocenteCurso.TiposCargos)Enum.Parse(typeof(DocenteCurso.TiposCargos), this.CargoTextBox.Text.ToString());
        }

        private void SaveEntity(DocenteCurso docente)
        {
            if (Page.IsValid)
            {
                this.Logic.Save(docente);
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
                    this.EntityDocenteCurso = new DocenteCurso();
                    this.EntityDocenteCurso.ID = this.SelectedID;
                    this.EntityDocenteCurso.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.EntityDocenteCurso);
                    this.SaveEntity(this.EntityDocenteCurso);
                    LoadGrid();
                    break;
                case FormModes.Alta:
                    this.EntityDocenteCurso = new DocenteCurso();
                    this.LoadEntity(this.EntityDocenteCurso);
                    this.SaveEntity(this.EntityDocenteCurso);
                    LoadGrid();
                    break;
                default:
                    break;
            }            
            this.formPanel.Visible = false;
            this.gridPanel.Visible = true;
        }

        private void EnableForm(bool enable)
        {
            this.iDDocenteTextBox.Enabled = enable;
            this.CargoTextBox.Enabled = enable;
            this.idCursoList.Enabled = enable;
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
            List<Curso> curso = CursoLogic.GetAll();
            DataTable cursos = new DataTable();
            cursos.Columns.Add("id_curso", typeof(int));
            foreach (var s in curso)
            {
                cursos.Rows.Add(new object[] { s.ID });
            }
            this.idCursoList.DataSource = cursos;
            this.idCursoList.DataValueField = "id_curso";
            this.idCursoList.DataTextField = "id_curso"; //materia y comision
            this.idCursoList.DataBind();
        }

        private void ClearForm()
        {
            this.iDDocenteTextBox.Text = string.Empty;
            this.CargoTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {           
            this.formPanel.Visible = false;
            this.gridPanel.Visible = true;
        }
    }
}