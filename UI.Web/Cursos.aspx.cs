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
    public partial class Cursos : BaseABM
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
        CursoLogic _logic;
        private CursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new CursoLogic();
                }
                return _logic;
            }
        }
        private void LoadGrid()
        {
            List<Curso> cursos = new CursoLogic().GetAll();
            List<Comision> comisiones = new ComisionLogic().GetAll();
            List<Materia> materias = new MateriaLogic().GetAll();
            var consulta =
                from cur in this.Logic.GetAll()
                join com in comisiones
                on cur.IDComision equals com.ID
                join m in materias
                on cur.IDMateria equals m.ID
                select new
                {
                    ID = cur.ID,
                    Materia = m.Descripcion,
                    Comision = com.Descripcion,
                    AnioCalendario = cur.AnioCalendario,
                    Cupo = cur.Cupo
                };
            this.gridView.DataSource = consulta.ToList();
            this.gridView.DataBind();
        }
        private Curso Entity
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
            List<Materia> materias = new MateriaLogic().GetAll();
            DataTable dtMateria = new DataTable();
            dtMateria.Columns.Add("id_materia", typeof(int));
            dtMateria.Columns.Add("desc_materia", typeof(string));
            foreach (var m in materias)
            {
                dtMateria.Rows.Add(new object[] { m.ID, m.Descripcion });
            }
            materiaList.DataSource = dtMateria;
            materiaList.DataValueField = "id_materia";
            materiaList.DataTextField = "desc_materia";
            materiaList.DataBind();
            this.materiaList.SelectedValue = this.Entity.IDMateria.ToString();
            List<Comision> comisiones = new ComisionLogic().GetAll();
            DataTable dtComision = new DataTable();
            dtComision.Columns.Add("id_comision", typeof(int));
            dtComision.Columns.Add("desc_comision", typeof(string));
            foreach (var com in comisiones)
            {
                dtComision.Rows.Add(new object[] { com.ID, com.Descripcion });
            }
            comisionList.DataSource = dtComision;
            comisionList.DataValueField = "id_comision";
            comisionList.DataTextField = "desc_comision";
            comisionList.DataBind();
            this.comisionList.SelectedValue = this.Entity.IDComision.ToString();
            this.anioTextBox.Text = this.Entity.AnioCalendario.ToString();
            this.cupoTextBox.Text = this.Entity.Cupo.ToString();
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

        private void LoadEntity(Curso curso)
        {
            curso.IDMateria = Int32.Parse(this.materiaList.SelectedValue);
            curso.IDComision = Int32.Parse(this.comisionList.SelectedValue);
            curso.AnioCalendario = Int32.Parse(this.anioTextBox.Text);
            curso.Cupo = Int32.Parse(this.cupoTextBox.Text);
        }

        private void SaveEntity(Curso curso)
        {
            if (Page.IsValid)
            {
                this.Logic.Save(curso);
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
                    this.Entity = new Curso();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Curso();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                default:
                    break;
            }
            this.formPanel.Visible = false;
            this.gridPanel.Visible = true;
        }

        private void EnableForm(bool enable)
        {
            this.materiaList.Enabled = enable;
            this.comisionList.Enabled = enable;
            this.anioTextBox.Enabled = enable;
            this.cupoTextBox.Enabled = enable;
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
            List<Materia> materias = new MateriaLogic().GetAll();
            DataTable dtMateria = new DataTable();
            dtMateria.Columns.Add("id_materia", typeof(int));
            dtMateria.Columns.Add("desc_materia", typeof(string));
            foreach (var m in materias)
            {
                dtMateria.Rows.Add(new object[] { m.ID, m.Descripcion });
            }
            materiaList.DataSource = dtMateria;
            materiaList.DataValueField = "id_materia";
            materiaList.DataTextField = "desc_materia";
            materiaList.DataBind();
            List<Comision> comisiones = new ComisionLogic().GetAll();
            DataTable dtComision = new DataTable();
            dtComision.Columns.Add("id_comision", typeof(int));
            dtComision.Columns.Add("desc_comision", typeof(string));
            foreach (var com in comisiones)
            {
                dtComision.Rows.Add(new object[] { com.ID, com.Descripcion });
            }
            comisionList.DataSource = dtComision;
            comisionList.DataValueField = "id_comision";
            comisionList.DataTextField = "desc_comision";
            comisionList.DataBind();
        }

        private void ClearForm()
        {
            this.anioTextBox.Text = string.Empty;
            this.cupoTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
            this.gridPanel.Visible = true;
        }

        protected void linkReporte_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/cursosReporte.aspx");
        }
    }
}