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
            PersonaLogic u1 = new PersonaLogic();
            this.dgvPersonas.DataSource = u1.GetAll();
        }

        private void Usuarios_Load(object sender, EventArgs e)
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
            UsuarioDesktop formUsuario = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            formUsuario.ShowDialog();
            this.Listar();
            dgvPersonas.ClearSelection();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.Usuario)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formUsuario.ShowDialog();
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
                int ID = ((Business.Entities.Usuario)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop formUsuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
                formUsuario.ShowDialog();
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
