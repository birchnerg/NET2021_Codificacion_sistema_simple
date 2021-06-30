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
    public partial class MenuAcademia : Form
    {
        public MenuAcademia()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComisiones_Click(object sender, EventArgs e)
        {
            Comisiones formComisiones = new Comisiones();
            formComisiones.ShowDialog();
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            Planes formPlanes = new Planes();
            formPlanes.ShowDialog();
        }

        private void btnEspecialidad_Click(object sender, EventArgs e)
        {
            Especialidades formEspecialidades = new Especialidades();
            formEspecialidades.ShowDialog();
        }
    }
}
