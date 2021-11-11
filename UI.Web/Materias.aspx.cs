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
    public partial class Materias : BaseABM
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
        MateriaLogic _logic;
        private MateriaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new MateriaLogic();
                }
                return _logic;
            }
        }
        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }
        private Materia Entity
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
            this.HSSemanalesTextBox.Text = this.Entity.HSSemanales.ToString();
            this.HSTotalesTextBox.Text = this.Entity.HSTotales.ToString();
            PlanLogic pl = new PlanLogic();          
            List<Business.Entities.Plan> planes = pl.GetAll();
            DataTable dtPlan = new DataTable();
            dtPlan.Columns.Add("id_plan", typeof(int));
            dtPlan.Columns.Add("desc_plan", typeof(string));
            foreach (var e in planes)
            {
                dtPlan.Rows.Add(new object[] { e.ID, e.Descripcion });
            }
            planesList.DataSource = dtPlan;
            planesList.DataValueField = "id_plan";
            planesList.DataTextField = "desc_plan";
            planesList.DataBind();
            this.planesList.SelectedValue = this.Entity.IDPlan.ToString();
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

        private void LoadEntity(Materia mat)
        {
            mat.Descripcion = this.descTextBox.Text;
            mat.HSSemanales = Int32.Parse(this.HSSemanalesTextBox.Text);
            mat.HSTotales = Int32.Parse(this.HSTotalesTextBox.Text);
            mat.IDPlan = Int32.Parse(this.planesList.SelectedValue);
        }

        private void SaveEntity(Materia mat)
        {
            if (Page.IsValid)
            {
                this.Logic.Save(mat);
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
                    this.Entity = new Materia();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Materia();
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
            this.HSSemanalesTextBox.Enabled = enable;
            this.HSTotalesTextBox.Enabled = enable;
            this.planesList.Enabled = enable;
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
            PlanLogic pl = new PlanLogic();
            List<Business.Entities.Plan> planes = pl.GetAll();
            DataTable dtPlan = new DataTable();
            dtPlan.Columns.Add("id_plan", typeof(int));
            dtPlan.Columns.Add("desc_plan", typeof(string));
            foreach (var p in planes)
            {
                dtPlan.Rows.Add(new object[] { p.ID, p.Descripcion });
            }
            planesList.DataSource = dtPlan;
            planesList.DataValueField = "id_plan";
            planesList.DataTextField = "desc_plan";
            planesList.DataBind();            
        }

        private void ClearForm()
        {
            this.descTextBox.Text = string.Empty;
            this.HSSemanalesTextBox.Text = string.Empty;
            this.HSTotalesTextBox.Text = string.Empty;
            
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
            this.gridPanel.Visible = true;
        }
    }
}