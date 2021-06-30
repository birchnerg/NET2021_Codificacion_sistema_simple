using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class MenuPpal : Form
    {
        public MenuPpal()
        {
            InitializeComponent();
        }
        private void btnCursos_Click(object sender, EventArgs e)
        {
            MenuCursos formCursos = new MenuCursos();
            formCursos.ShowDialog();
        }

        private void btnAcademia_Click(object sender, EventArgs e)
        {
            MenuAcademia formAcademia = new MenuAcademia();
            formAcademia.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios formUsuarios = new Usuarios();
            formUsuarios.ShowDialog();
        }

        private void MenuPpal_Shown(object sender, EventArgs e)
        {
            formLogin login = new formLogin();
            
            if (login.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void btnPersonas_Click(object sender, EventArgs e)
        {
            Personas formPersonas = new Personas();
            formPersonas.ShowDialog();
        }
    }
}
