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
    public partial class Personas : BaseABM
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack) // Verifica que no se una nueva visita (primera carga)
            {
                if (CheckPermission("NoDocente")) 
                { 
                    Array tipos = Enum.GetValues(typeof(Persona.TipoPersonas));
                    foreach (Persona.TipoPersonas tipo in tipos)
                    {
                        tipoPersonaList.Items.Add(new ListItem(tipo.ToString(), ((int)tipo).ToString()));
                    }
                    LoadGrid();
                }
                else
                {
                    Page.Response.Redirect("~/Default.aspx");
                }
            }
        }
        PersonaLogic _logic;
        private PersonaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PersonaLogic();
                }
                return _logic;
            }
        }
        private void LoadGrid()
        {
            List<Plan> planes = new PlanLogic().GetAll();
            var consulta =
                from p in this.Logic.GetAll()
                join pl in planes
                on p.IDPlan equals pl.ID
                select new
                {
                    ID = p.ID,
                    Nombre = p.Nombre,
                    Apellido = p.Apellido,
                    Email = p.Email,
                    Direccion = p.Direccion,
                    Telefono = p.Telefono,
                    FechaNacimiento = p.FechaNacimiento.Date,
                    Legajo = p.Legajo,
                    TipoPersona = p.TipoPersonasString,
                    Plan = pl.Descripcion
                };
            this.gridView.DataSource = consulta.ToList();
            this.gridView.DataBind();
        }
        private Persona Entity
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
            this.nombreTextBox.Text = this.Entity.Nombre;
            this.apellidoTextBox.Text = this.Entity.Apellido;
            this.emailTextBox.Text = this.Entity.Email;
            this.direccionTextBox.Text = this.Entity.Direccion;
            this.telefonoTextBox.Text = this.Entity.Telefono;
            this.fechaNacimientoTextBox.Text = this.Entity.FechaNacimiento.ToString("yyyy-MM-dd");
            this.legajoTextBox.Text = this.Entity.Legajo.ToString();
            this.tipoPersonaList.SelectedValue = this.Entity.TipoPersonasInt.ToString();
            List<Plan> planes = new PlanLogic().GetAll();
            DataTable dtPlan = new DataTable();
            dtPlan.Columns.Add("id_plan", typeof(int));
            dtPlan.Columns.Add("desc_plan", typeof(string));
            foreach (var p in planes)
            {
                dtPlan.Rows.Add(new object[] { p.ID, p.Descripcion });
            }
            planList.DataSource = dtPlan;
            planList.DataValueField = "id_plan";
            planList.DataTextField = "desc_plan";
            planList.DataBind();
            this.planList.SelectedValue = this.Entity.IDPlan.ToString();
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
        private void LoadEntity(Persona persona)
        {
            persona.Nombre = this.nombreTextBox.Text;
            persona.Apellido = this.apellidoTextBox.Text;
            persona.Email = this.emailTextBox.Text;
            persona.Direccion = this.direccionTextBox.Text;
            persona.Telefono = this.telefonoTextBox.Text;
            persona.FechaNacimiento = DateTime.Parse(this.fechaNacimientoTextBox.Text).Date;
            persona.Legajo = Int32.Parse(this.legajoTextBox.Text);
            persona.TipoPersonasInt = Int32.Parse(this.tipoPersonaList.SelectedIndex.ToString());
            persona.IDPlan = Int32.Parse(this.planList.SelectedValue);
        }
        private void SaveEntity(Persona persona)
        {
            if (Page.IsValid)
            {
                persona.ID = this.Logic.Save(persona);
                if (this.FormMode == FormModes.Alta)
                {
                    Response.Redirect("~/Usuarios.aspx?Nombre=" + persona.Nombre + "&Apellido=" + persona.Apellido + "&Email=" + persona.Email + "&IDPersona=" + persona.ID);
                }
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
                    this.Entity = new Persona();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Persona();
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
            this.nombreTextBox.Enabled = enable;
            this.apellidoTextBox.Enabled = enable;
            this.emailTextBox.Enabled = enable;
            this.direccionTextBox.Enabled = enable;
            this.telefonoTextBox.Enabled = enable;
            this.fechaNacimientoTextBox.Enabled = enable;
            this.legajoTextBox.Enabled = enable;
            this.tipoPersonaList.Enabled = enable;
            this.planList.Enabled = enable;
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
            List<Plan> planes = new PlanLogic().GetAll();
            DataTable dtPlan = new DataTable();
            dtPlan.Columns.Add("id_plan", typeof(int));
            dtPlan.Columns.Add("desc_plan", typeof(string));
            foreach (var p in planes)
            {
                dtPlan.Rows.Add(new object[] { p.ID, p.Descripcion });
            }
            planList.DataSource = dtPlan;
            planList.DataValueField = "id_plan";
            planList.DataTextField = "desc_plan";
            planList.DataBind();
        }
        private void ClearForm()
        {
            this.nombreTextBox.Text = string.Empty;
            this.apellidoTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.direccionTextBox.Text = string.Empty;
            this.telefonoTextBox.Text = string.Empty;
            this.legajoTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
            this.gridPanel.Visible = true;
        }
    }
}