using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Personas : Form
    {
        public Personas()
        {
            InitializeComponent();
            this.dgvPersonas.AutoGenerateColumns = false;   
        }

        public void Listar()
        {
            PersonaLogic p = new PersonaLogic();
            PlanLogic pl = new PlanLogic();
            try
            {
                List<Persona> personas = p.GetAll();
                List<Plan> planes = pl.GetAll();
                var consultaPersonas =
                    from per in personas
                    join pla in planes
                    on per.IDPlan equals pla.ID
                    select new
                    {
                        ID = per.ID,
                        TipoPersonasString = per.TipoPersonasString,
                        Legajo = per.Legajo,
                        Nombre = per.Nombre,
                        Apellido = per.Apellido,
                        FechaNacimiento = per.FechaNacimiento,
                        Email = per.Email,
                        Direccion = per.Direccion,
                        Telefono = per.Telefono,
                        Plan = pla.Descripcion
                    };
                this.dgvPersonas.DataSource = consultaPersonas.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void Personas_Load(object sender, EventArgs e)
        {
            Listar();
            dgvPersonas.ClearSelection();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PersonaDesktop formPersona = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            formPersona.ShowDialog();
            this.Listar();
            dgvPersonas.ClearSelection();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count != 0)
            {
                int ID = (int)this.dgvPersonas.SelectedRows[0].Cells["Id"].Value;
                PersonaDesktop formPersona = new PersonaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formPersona.ShowDialog();
                this.Listar();
                dgvPersonas.ClearSelection();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una fila para realizar la modificación.");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count != 0)
            {
                int ID = (int)this.dgvPersonas.SelectedRows[0].Cells["Id"].Value;
                PersonaDesktop formPersona = new PersonaDesktop(ID, ApplicationForm.ModoForm.Baja);
                formPersona.ShowDialog();
                this.Listar();
                dgvPersonas.ClearSelection();
            }
            else
            {
                MessageBox.Show("Debes seleccionar una fila para realizar la baja.");
            }
        }
    }
}