
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
            this.tlMenu = new System.Windows.Forms.TableLayoutPanel();
            this.btnCursos = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnPersonas = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnAcademia = new System.Windows.Forms.Button();
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
            this.tlMenu.Controls.Add(this.btnCursos, 1, 1);
            this.tlMenu.Controls.Add(this.lblTitulo, 1, 0);
            this.tlMenu.Controls.Add(this.btnPersonas, 1, 2);
            this.tlMenu.Controls.Add(this.btnUsuarios, 1, 3);
            this.tlMenu.Controls.Add(this.btnAcademia, 1, 4);
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
            this.tlMenu.Size = new System.Drawing.Size(272, 239);
            this.tlMenu.TabIndex = 0;
            // 
            // btnCursos
            // 
            this.btnCursos.Location = new System.Drawing.Point(71, 69);
            this.btnCursos.Name = "btnCursos";
            this.btnCursos.Size = new System.Drawing.Size(100, 26);
            this.btnCursos.TabIndex = 0;
            this.btnCursos.Text = "Cursos";
            this.btnCursos.UseVisualStyleBackColor = true;
            this.btnCursos.Click += new System.EventHandler(this.btnCursos_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(71, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(130, 66);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Bienvenido a la Academia";
            // 
            // btnPersonas
            // 
            this.btnPersonas.Location = new System.Drawing.Point(71, 101);
            this.btnPersonas.Name = "btnPersonas";
            this.btnPersonas.Size = new System.Drawing.Size(100, 27);
            this.btnPersonas.TabIndex = 2;
            this.btnPersonas.Text = "Personas";
            this.btnPersonas.UseVisualStyleBackColor = true;
            this.btnPersonas.Click += new System.EventHandler(this.btnPersonas_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(71, 134);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(100, 30);
            this.btnUsuarios.TabIndex = 3;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnAcademia
            // 
            this.btnAcademia.Location = new System.Drawing.Point(71, 170);
            this.btnAcademia.Name = "btnAcademia";
            this.btnAcademia.Size = new System.Drawing.Size(100, 31);
            this.btnAcademia.TabIndex = 4;
            this.btnAcademia.Text = "Academia";
            this.btnAcademia.UseVisualStyleBackColor = true;
            this.btnAcademia.Click += new System.EventHandler(this.btnAcademia_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(71, 207);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 29);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // MenuPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 239);
            this.Controls.Add(this.tlMenu);
            this.IsMdiContainer = true;
            this.Name = "MenuPpal";
            this.Text = "Menu";
            this.Shown += new System.EventHandler(this.MenuPpal_Shown);
            this.tlMenu.ResumeLayout(false);
            this.tlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlMenu;
        private System.Windows.Forms.Button btnCursos;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnPersonas;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnAcademia;
        private System.Windows.Forms.Button btnSalir;
    }
}