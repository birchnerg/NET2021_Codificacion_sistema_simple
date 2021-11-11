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
    public partial class Comisiones : BaseABM
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

        ComisionLogic _logic;
        private ComisionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new ComisionLogic();
                }
                return _logic;
            }
        }

        private void LoadGrid()
        {
            ComisionLogic cl = new ComisionLogic();
            PlanLogic pl = new PlanLogic();
            List<Comision> comisiones = cl.GetAll();
            List<Plan> planes = pl.GetAll();
            var consultaComisiones =
                from c in comisiones
                join p in planes
                on c.IDPlan equals p.ID
                select new
                {
                    ID = c.ID,
                    Descripcion = c.Descripcion,
                    AnioEspecialidad = c.AnioEspecialidad,
                    Plan = p.Descripcion
                };            
            this.gridView.DataSource = consultaComisiones.ToList();
            this.gridView.DataBind();
        }

        private Comision Entity
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
            List<Plan> planes = new PlanLogic().GetAll();
            DataTable dtPlanes = new DataTable();
            dtPlanes.Columns.Add("plan", typeof(string));
            dtPlanes.Columns.Add("id_plan", typeof(int));
            foreach (var p in planes)
            {
                dtPlanes.Rows.Add(new object[] {p.Descripcion, p.ID });
            }
            planList.DataSource = dtPlanes;
            planList.DataValueField = "id_plan";
            planList.DataTextField = "plan";
            planList.DataBind();
            this.planList.SelectedValue = this.Entity.IDPlan.ToString();
            this.anioTextBox.Text = this.Entity.AnioEspecialidad.ToString();
            this.descripcionTextBox.Text = this.Entity.Descripcion.ToString();
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

        private void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;
            this.anioTextBox.Enabled = enable;
            this.planList.Enabled = enable;
        }

        private void LoadEntity(Comision comision)
        {
            comision.Descripcion = (string)(this.descripcionTextBox.Text);
            comision.AnioEspecialidad = Int32.Parse(this.anioTextBox.Text);
            comision.IDPlan = Int32.Parse(this.planList.SelectedValue);
        }

        private void SaveEntity(Comision comision)
        {
            if (Page.IsValid)
            {
                this.Logic.Save(comision);
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
                    this.Entity = new Comision();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Comision();
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

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
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

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.gridPanel.Visible = false;
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
            List<Plan> planes = new PlanLogic().GetAll();
            DataTable dtPlanes = new DataTable();
            dtPlanes.Columns.Add("plan", typeof(string));
            dtPlanes.Columns.Add("id_plan", typeof(int));
            foreach (var p in planes)
            {
                dtPlanes.Rows.Add(new object[] { p.Descripcion, p.ID });
            }
            planList.DataSource = dtPlanes;
            planList.DataValueField = "id_plan";
            planList.DataTextField = "plan";
            planList.DataBind();
        }

        private void ClearForm()
        {
            this.anioTextBox.Text = string.Empty;
            this.descripcionTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
            this.gridPanel.Visible = true;
        }
    }
}