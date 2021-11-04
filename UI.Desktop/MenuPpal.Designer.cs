
namespace UI.Desktop
{
    partial class MenuPpal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmAlumno = new System.Windows.Forms.ToolStripMenuItem();
            this.misDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.verCursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.verMateriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmPlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.verPlanesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.verEspecialidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.verUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verPersonasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmComisiones = new System.Windows.Forms.ToolStripMenuItem();
            this.verComisionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDocente = new System.Windows.Forms.ToolStripMenuItem();
            this.NotasDeCursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirDocente = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAlumno,
            this.tsmCursos,
            this.tsmMaterias,
            this.tsmPlanes,
            this.tsmEspecialidades,
            this.tsmUsuarios,
            this.tsmComisiones,
            this.tsmDocente});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(756, 30);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmAlumno
            // 
            this.tsmAlumno.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.misDatosToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.tsmAlumno.Name = "tsmAlumno";
            this.tsmAlumno.Size = new System.Drawing.Size(75, 26);
            this.tsmAlumno.Text = "Alumno";
            this.tsmAlumno.Visible = false;
            // 
            // misDatosToolStripMenuItem
            // 
            this.misDatosToolStripMenuItem.Name = "misDatosToolStripMenuItem";
            this.misDatosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.misDatosToolStripMenuItem.Text = "Incripción a curso";
            this.misDatosToolStripMenuItem.Click += new System.EventHandler(this.misDatosToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // tsmCursos
            // 
            this.tsmCursos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verCursosToolStripMenuItem});
            this.tsmCursos.Name = "tsmCursos";
            this.tsmCursos.Size = new System.Drawing.Size(66, 26);
            this.tsmCursos.Text = "Cursos";
            this.tsmCursos.Visible = false;
            // 
            // verCursosToolStripMenuItem
            // 
            this.verCursosToolStripMenuItem.Name = "verCursosToolStripMenuItem";
            this.verCursosToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.verCursosToolStripMenuItem.Text = "Ver Cursos";
            this.verCursosToolStripMenuItem.Click += new System.EventHandler(this.verCursosToolStripMenuItem_Click);
            // 
            // tsmMaterias
            // 
            this.tsmMaterias.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verMateriasToolStripMenuItem});
            this.tsmMaterias.Name = "tsmMaterias";
            this.tsmMaterias.Size = new System.Drawing.Size(80, 26);
            this.tsmMaterias.Text = "Materias";
            this.tsmMaterias.Visible = false;
            // 
            // verMateriasToolStripMenuItem
            // 
            this.verMateriasToolStripMenuItem.Name = "verMateriasToolStripMenuItem";
            this.verMateriasToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.verMateriasToolStripMenuItem.Text = "Ver Materias";
            // 
            // tsmPlanes
            // 
            this.tsmPlanes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verPlanesToolStripMenuItem});
            this.tsmPlanes.Name = "tsmPlanes";
            this.tsmPlanes.Size = new System.Drawing.Size(65, 26);
            this.tsmPlanes.Text = "Planes";
            this.tsmPlanes.Visible = false;
            // 
            // verPlanesToolStripMenuItem
            // 
            this.verPlanesToolStripMenuItem.Name = "verPlanesToolStripMenuItem";
            this.verPlanesToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.verPlanesToolStripMenuItem.Text = "Ver Planes";
            this.verPlanesToolStripMenuItem.Click += new System.EventHandler(this.verPlanesToolStripMenuItem_Click);
            // 
            // tsmEspecialidades
            // 
            this.tsmEspecialidades.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verEspecialidadesToolStripMenuItem});
            this.tsmEspecialidades.Name = "tsmEspecialidades";
            this.tsmEspecialidades.Size = new System.Drawing.Size(121, 26);
            this.tsmEspecialidades.Text = "Especialidades";
            this.tsmEspecialidades.Visible = false;
            // 
            // verEspecialidadesToolStripMenuItem
            // 
            this.verEspecialidadesToolStripMenuItem.Name = "verEspecialidadesToolStripMenuItem";
            this.verEspecialidadesToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.verEspecialidadesToolStripMenuItem.Text = "Ver Especialidades";
            this.verEspecialidadesToolStripMenuItem.Click += new System.EventHandler(this.verEspecialidadesToolStripMenuItem_Click);
            // 
            // tsmUsuarios
            // 
            this.tsmUsuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verUsuariosToolStripMenuItem,
            this.verPersonasToolStripMenuItem});
            this.tsmUsuarios.Name = "tsmUsuarios";
            this.tsmUsuarios.Size = new System.Drawing.Size(79, 26);
            this.tsmUsuarios.Text = "Usuarios";
            this.tsmUsuarios.Visible = false;
            // 
            // verUsuariosToolStripMenuItem
            // 
            this.verUsuariosToolStripMenuItem.Name = "verUsuariosToolStripMenuItem";
            this.verUsuariosToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.verUsuariosToolStripMenuItem.Text = "Ver Usuarios";
            this.verUsuariosToolStripMenuItem.Click += new System.EventHandler(this.verUsuariosToolStripMenuItem_Click);
            // 
            // verPersonasToolStripMenuItem
            // 
            this.verPersonasToolStripMenuItem.Name = "verPersonasToolStripMenuItem";
            this.verPersonasToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.verPersonasToolStripMenuItem.Text = "Ver Personas";
            this.verPersonasToolStripMenuItem.Click += new System.EventHandler(this.verPersonasToolStripMenuItem_Click);
            // 
            // tsmComisiones
            // 
            this.tsmComisiones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verComisionesToolStripMenuItem});
            this.tsmComisiones.Name = "tsmComisiones";
            this.tsmComisiones.Size = new System.Drawing.Size(99, 26);
            this.tsmComisiones.Text = "Comisiones";
            this.tsmComisiones.Visible = false;
            // 
            // verComisionesToolStripMenuItem
            // 
            this.verComisionesToolStripMenuItem.Name = "verComisionesToolStripMenuItem";
            this.verComisionesToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.verComisionesToolStripMenuItem.Text = "Ver Comisiones";
            this.verComisionesToolStripMenuItem.Click += new System.EventHandler(this.verComisionesToolStripMenuItem_Click);
            // 
            // tsmDocente
            // 
            this.tsmDocente.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NotasDeCursosToolStripMenuItem,
            this.salirDocente});
            this.tsmDocente.Name = "tsmDocente";
            this.tsmDocente.Size = new System.Drawing.Size(79, 26);
            this.tsmDocente.Text = "Docente";
            this.tsmDocente.Visible = false;
            // 
            // NotasDeCursosToolStripMenuItem
            // 
            this.NotasDeCursosToolStripMenuItem.Name = "NotasDeCursosToolStripMenuItem";
            this.NotasDeCursosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.NotasDeCursosToolStripMenuItem.Text = "Notas de cursos";
            // 
            // salirDocente
            // 
            this.salirDocente.Name = "salirDocente";
            this.salirDocente.Size = new System.Drawing.Size(224, 26);
            this.salirDocente.Text = "Salir";
            this.salirDocente.Click += new System.EventHandler(this.salirDocente_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(756, 270);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(750, 270);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido a la Academia";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 294);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuPpal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Shown += new System.EventHandler(this.MenuPpal_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmAlumno;
        private System.Windows.Forms.ToolStripMenuItem tsmCursos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem misDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verCursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmMaterias;
        private System.Windows.Forms.ToolStripMenuItem verMateriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmPlanes;
        private System.Windows.Forms.ToolStripMenuItem verPlanesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem verEspecialidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmUsuarios;
        private System.Windows.Forms.ToolStripMenuItem verUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verPersonasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmComisiones;
        private System.Windows.Forms.ToolStripMenuItem verComisionesToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem tsmDocente;
        private System.Windows.Forms.ToolStripMenuItem NotasDeCursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirDocente;
    }
}