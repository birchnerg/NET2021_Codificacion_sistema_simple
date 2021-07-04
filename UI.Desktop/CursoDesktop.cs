using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class CursoDesktop : ApplicationForm
    {
        public CursoDesktop()
        {
            InitializeComponent();
            /*---A agregar cuando exista ABM materia
            MateriaLogic ma = new MateriaLogic();
            try
            {
                List<Materias> materias = ma.GetAll();
                DataTable dtMaterias = new DataTable();
                dtMaterias.Columns.Add("id_materia", typeof(int));
                dtMaterias.Columns.Add("desc_materia", typeof(string));
                foreach (var e in materias)
                {
                    dtMaterias.Rows.Add(new object[] { e.ID, e.Descripcion });
                }
                this.boxMateria.DataSource = dtMaterias;
                this.boxMateria.ValueMember = "id_materia";
                this.boxMateria.DisplayMember = "desc_materia";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/

            ComisionLogic com = new ComisionLogic();
            try
            {
                List<Comision> comisiones = com.GetAll();
                DataTable dtComisiones = new DataTable();
                dtComisiones.Columns.Add("id_comision", typeof(int));
                dtComisiones.Columns.Add("desc_comision", typeof(string));
                foreach (var e in comisiones)
                {
                    dtComisiones.Rows.Add(new object[] { e.ID, e.Descripcion });
                }
                this.boxComision.DataSource = dtComisiones;
                this.boxComision.ValueMember = "id_comision";
                this.boxComision.DisplayMember = "desc_comision";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public CursoDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            CursoLogic curso = new CursoLogic();
            try
            {
                CursoActual = curso.GetOne(ID);
                MapearDeDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Curso _curso;
        public Curso CursoActual
        {
            get { return _curso; }
            set { _curso = value; }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.CursoActual.ID.ToString();
            this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            this.boxComision.SelectedItem = this.CursoActual.IDComision;
            this.boxMateria.Text = this.CursoActual.IDMateria.ToString();
            switch (this.Modo)
            {
                case ModoForm.Alta:
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    this.txtAnioCalendario.Enabled = false;
                    this.boxMateria.Enabled = false;
                    this.boxComision.Enabled = false;
                    this.txtCupo.Enabled = false;
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }
        public override void MapearADatos()
        {
            switch (this.Modo)
            {
                case ModoForm.Alta:
                    CursoActual = new Curso();
                    CursoActual.AnioCalendario = Int32.Parse(this.txtAnioCalendario.Text);
                    CursoActual.Cupo = Int32.Parse(this.txtCupo.Text);
                    CursoActual.IDComision = (int)this.boxComision.SelectedValue;
                    CursoActual.IDMateria = Int32.Parse(this.boxMateria.Text);
                    //Cambiar cuando exista ABM Materias por 
                    //CursoActual.IDMateria = (int)this.boxMateria.SelectedValue;
                    CursoActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    CursoActual.AnioCalendario = Int32.Parse(this.txtAnioCalendario.Text);
                    CursoActual.Cupo = Int32.Parse(this.txtCupo.Text);
                    CursoActual.IDComision = (int)this.boxComision.SelectedValue;
                    CursoActual.IDMateria = Int32.Parse(this.boxMateria.Text);
                    //Cambiar cuando exista ABM Materias por 
                    //CursoActual.IDMateria = (int)this.boxMateria.SelectedValue;
                    CursoActual.State = BusinessEntity.States.Modified;
                    break;
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            CursoLogic p = new CursoLogic();
            if (this.Modo == ModoForm.Baja)
            {
                var resultado = MessageBox.Show("¿Desea eliminar el registro?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        p.Delete(CursoActual.ID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                try
                {
                    p.Save(CursoActual);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public override bool Validar()
        {
            int i;
            if (string.IsNullOrEmpty(this.txtAnioCalendario.Text) || string.IsNullOrEmpty(this.txtCupo.Text))
            {
                Notificar("Error", "Campo vacío. Por favor complételo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (this.boxMateria.SelectedIndex == -1 )
            {
                Notificar("Error", "Materia no indicada. Por favor seleccione una.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if ( this.boxComision.SelectedIndex == -1)
            {
                Notificar("Error", "Comisión no indicada. Por favor seleccione una.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!int.TryParse(this.txtAnioCalendario.Text, out i))
            {
                Notificar("Error", "Año Calendario incorrecto. Por favor ingrese un año válido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!int.TryParse(this.txtCupo.Text, out i))
            {
                Notificar("Error", "Cupo incorrecto. Por favor ingrese un número válido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
