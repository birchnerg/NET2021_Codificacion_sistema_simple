using Microsoft.Reporting.WinForms;
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
    public partial class materiasEstadoAlumno : Form
    {
        public materiasEstadoAlumno(Persona alumno)
        {
            InitializeComponent();
            // ENCABEZADO
            List<ReportParameter> parametros = infoTxt(alumno);
            reporte.LocalReport.SetParameters(parametros);

            //TABLA
            // List<ReporteEstadoAcademico> consulta = ReportesLogic.EstadoAlumno(alumno.IDPlan, alumno.ID);
     //       List<ReporteEstadoAcademico> consultaAlumno = ReportesLogic.ObtenerEstadoAcademico(alumno.IDPlan, alumno.ID );
     //       List<ReporteEstadoAcademico> consultaMaterias = ReportesLogic.MateriasPlan(alumno.IDPlan);
     //       var consulta = consultaAlumno.Union(consultaMaterias, new ReportesLogic.MateriasComparer());
            var consulta = ReportesLogic.EstadoAlumno(alumno.IDPlan, alumno.ID);
            reporte.LocalReport.DataSources.Clear();
            reporte.LocalReport.DataSources.Add(new ReportDataSource("materia", consulta));
            reporte.RefreshReport();
        }

        private void materiasEstadoAlumno_Load(object sender, EventArgs e)
        {
            this.reporte.RefreshReport();
        }

        private List<ReportParameter> infoTxt(Persona alumno)
        {
            List<ReportParameter> parameters = new List<ReportParameter>();
            parameters.Add(new ReportParameter("apellido", alumno.Apellido ));
            parameters.Add(new ReportParameter("nombre", alumno.Nombre));
            parameters.Add(new ReportParameter("legajo", alumno.Legajo.ToString()));
            parameters.Add(new ReportParameter("carrera", EspecialidadLogic.DescripcionEspecialidad(PlanLogic.EspecialidadPlan(alumno.IDPlan))));
            parameters.Add(new ReportParameter("plan", PlanLogic.DescripcionPlan(alumno.IDPlan)));
            return parameters;
        }

        
    }
}
