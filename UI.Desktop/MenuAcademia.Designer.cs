
namespace UI.Desktop
{
    partial class MenuAcademia
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
            this.tlMenu = new System.Windows.Forms.TableLayoutPanel();
            this.btnComisiones = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMaterias = new System.Windows.Forms.Button();
            this.btnPlanes = new System.Windows.Forms.Button();
            this.btnEspecialidad = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlMenu
            // 
            this.tlMenu.ColumnCount = 3;
            this.tlMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlMenu.Controls.Add(this.btnComisiones, 1, 1);
            this.tlMenu.Controls.Add(this.lblTitulo, 1, 0);
            this.tlMenu.Controls.Add(this.btnMaterias, 1, 2);
            this.tlMenu.Controls.Add(this.btnPlanes, 1, 3);
            this.tlMenu.Controls.Add(this.btnEspecialidad, 1, 4);
            this.tlMenu.Controls.Add(this.btnSalir, 1, 5);
            this.tlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlMenu.Location = new System.Drawing.Point(0, 0);
            this.tlMenu.Name = "tlMenu";
            this.tlMenu.RowCount = 6;
            this.tlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMenu.Size = new System.Drawing.Size(263, 254);
            this.tlMenu.TabIndex = 1;
            // 
            // btnComisiones
            // 
            this.btnComisiones.Location = new System.Drawing.Point(66, 84);
            this.btnComisiones.Name = "btnComisiones";
            this.btnComisiones.Size = new System.Drawing.Size(100, 26);
            this.btnComisiones.TabIndex = 0;
            this.btnComisiones.Text = "Comisiones";
            this.btnComisiones.UseVisualStyleBackColor = true;
            this.btnComisiones.Click += new System.EventHandler(this.btnComisiones_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(66, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(130, 81);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Bienvenido a la Academia";
            // 
            // btnMaterias
            // 
            this.btnMaterias.Location = new System.Drawing.Point(66, 116);
            this.btnMaterias.Name = "btnMaterias";
            this.btnMaterias.Size = new System.Drawing.Size(100, 27);
            this.btnMaterias.TabIndex = 2;
            this.btnMaterias.Text = "Materias";
            this.btnMaterias.UseVisualStyleBackColor = true;
            // 
            // btnPlanes
            // 
            this.btnPlanes.Location = new System.Drawing.Point(66, 149);
            this.btnPlanes.Name = "btnPlanes";
            this.btnPlanes.Size = new System.Drawing.Size(100, 30);
            this.btnPlanes.TabIndex = 3;
            this.btnPlanes.Text = "Planes";
            this.btnPlanes.UseVisualStyleBackColor = true;
            this.btnPlanes.Click += new System.EventHandler(this.btnPlanes_Click);
            // 
            // btnEspecialidad
            // 
            this.btnEspecialidad.Location = new System.Drawing.Point(66, 185);
            this.btnEspecialidad.Name = "btnEspecialidad";
            this.btnEspecialidad.Size = new System.Drawing.Size(100, 31);
            this.btnEspecialidad.TabIndex = 4;
            this.btnEspecialidad.Text = "Especialidad";
            this.btnEspecialidad.UseVisualStyleBackColor = true;
            this.btnEspecialidad.Click += new System.EventHandler(this.btnEspecialidad_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(66, 222);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 29);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // MenuAcademia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 254);
            this.Controls.Add(this.tlMenu);
            this.Name = "MenuAcademia";
            this.Text = "MenuAcademia";
            this.tlMenu.ResumeLayout(false);
            this.tlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlMenu;
        private System.Windows.Forms.Button btnComisiones;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnMaterias;
        private System.Windows.Forms.Button btnPlanes;
        private System.Windows.Forms.Button btnEspecialidad;
        private System.Windows.Forms.Button btnSalir;
    }
}