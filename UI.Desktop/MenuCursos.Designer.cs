﻿
namespace UI.Desktop
{
    partial class MenuCursos
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
            this.btnAlumno = new System.Windows.Forms.Button();
            this.btnProfesor = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInscribir = new System.Windows.Forms.Label();
            this.btnCursos = new System.Windows.Forms.Button();
            this.tlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlMenu
            // 
            this.tlMenu.ColumnCount = 3;
            this.tlMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlMenu.Controls.Add(this.btnAlumno, 1, 3);
            this.tlMenu.Controls.Add(this.btnProfesor, 1, 4);
            this.tlMenu.Controls.Add(this.btnSalir, 1, 5);
            this.tlMenu.Controls.Add(this.label1, 1, 0);
            this.tlMenu.Controls.Add(this.lblInscribir, 1, 2);
            this.tlMenu.Controls.Add(this.btnCursos, 1, 1);
            this.tlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlMenu.Location = new System.Drawing.Point(0, 0);
            this.tlMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tlMenu.Name = "tlMenu";
            this.tlMenu.RowCount = 6;
            this.tlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlMenu.Size = new System.Drawing.Size(477, 335);
            this.tlMenu.TabIndex = 1;
            // 
            // btnAlumno
            // 
            this.btnAlumno.Location = new System.Drawing.Point(153, 204);
            this.btnAlumno.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAlumno.Name = "btnAlumno";
            this.btnAlumno.Size = new System.Drawing.Size(133, 37);
            this.btnAlumno.TabIndex = 3;
            this.btnAlumno.Text = "Alumno";
            this.btnAlumno.UseVisualStyleBackColor = true;
            // 
            // btnProfesor
            // 
            this.btnProfesor.Location = new System.Drawing.Point(153, 249);
            this.btnProfesor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnProfesor.Name = "btnProfesor";
            this.btnProfesor.Size = new System.Drawing.Size(133, 38);
            this.btnProfesor.TabIndex = 4;
            this.btnProfesor.Text = "Profesor";
            this.btnProfesor.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(153, 295);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(133, 36);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 142);
            this.label1.TabIndex = 6;
            this.label1.Text = "Bienvenido a la Academia";
            // 
            // lblInscribir
            // 
            this.lblInscribir.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInscribir.AutoSize = true;
            this.lblInscribir.Location = new System.Drawing.Point(153, 183);
            this.lblInscribir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInscribir.Name = "lblInscribir";
            this.lblInscribir.Size = new System.Drawing.Size(171, 17);
            this.lblInscribir.TabIndex = 1;
            this.lblInscribir.Text = "Inscribir a curso";
            // 
            // btnCursos
            // 
            this.btnCursos.Location = new System.Drawing.Point(153, 146);
            this.btnCursos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCursos.Name = "btnCursos";
            this.btnCursos.Size = new System.Drawing.Size(133, 33);
            this.btnCursos.TabIndex = 2;
            this.btnCursos.Text = "Cursos";
            this.btnCursos.UseVisualStyleBackColor = true;
            this.btnCursos.Click += new System.EventHandler(this.btnCursos_Click);
            // 
            // MenuCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 335);
            this.Controls.Add(this.tlMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MenuCursos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuCursos";
            this.tlMenu.ResumeLayout(false);
            this.tlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlMenu;
        private System.Windows.Forms.Label lblInscribir;
        private System.Windows.Forms.Button btnCursos;
        private System.Windows.Forms.Button btnAlumno;
        private System.Windows.Forms.Button btnProfesor;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
    }
}