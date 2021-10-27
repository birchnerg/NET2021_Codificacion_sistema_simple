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
    public partial class Planes : BaseABM
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) // Verifica que no se una nueva visita (primera carga)
            {
                if (Session["Usuario"] != null)
                {
                    LoadGrid();
                }
                else
                {
                    Page.Response.Redirect("~/Login.aspx");
                }
            }
        }
        PlanLogic _logic;
        private PlanLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PlanLogic();
                }
                return _logic;
            }
        }
        private void LoadGrid()
        {
            List<Especialidad> especialidades = new EspecialidadLogic().GetAll();
            var consulta =
                from p in this.Logic.GetAll()
                join e in especialidades
                on p.IDEspecialidad equals e.ID
                select new
                {
                    ID = p.ID,
                    Descripcion = p.Descripcion,
                    Especialidad = e.Descripcion
                };
            this.gridView.DataSource = consulta.ToList();
            this.gridView.DataBind();
        }
        private Plan Entity
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
            this.descTextBox.Text = this.Entity.Descripcion;
            List<Especialidad> especialidades = new EspecialidadLogic().GetAll();
            DataTable dtEspecialidad = new DataTable();
            dtEspecialidad.Columns.Add("id_especialidad", typeof(int));
            dtEspecialidad.Columns.Add("desc_especialidad", typeof(string));
            foreach (var e in especialidades)
            {
                dtEspecialidad.Rows.Add(new object[] { e.ID, e.Descripcion });
            }
            especialidadList.DataSource = dtEspecialidad;
            especialidadList.DataValueField = "id_especialidad";
            especialidadList.DataTextField = "desc_especialidad";
            especialidadList.DataBind();
            this.especialidadList.SelectedValue = this.Entity.IDEspecialidad.ToString(); 
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

        private void LoadEntity(Plan plan)
        {
            plan.Descripcion = this.descTextBox.Text;
            plan.IDEspecialidad = Int32.Parse(this.especialidadList.SelectedValue);
        }

        private void SaveEntity(Plan plan)
        {
            if (Page.IsValid)
            {
                this.Logic.Save(plan);
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
                    this.Entity = new Plan();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Plan();
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
            this.descTextBox.Enabled = enable;
            this.especialidadList.Enabled = enable;
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
            List<Especialidad> especialidades = new EspecialidadLogic().GetAll();
            DataTable dtEspecialidad = new DataTable();
            dtEspecialidad.Columns.Add("id_especialidad", typeof(int));
            dtEspecialidad.Columns.Add("desc_especialidad", typeof(string));
            foreach (var esp in especialidades)
            {
                dtEspecialidad.Rows.Add(new object[] { esp.ID, esp.Descripcion });
            }
            especialidadList.DataSource = dtEspecialidad;
            especialidadList.DataValueField = "id_especialidad";
            especialidadList.DataTextField = "desc_especialidad";
            especialidadList.DataBind();
        }

        private void ClearForm()
        {
            this.descTextBox.Text = string.Empty;            
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
            this.gridPanel.Visible = true;
        }
    }
}