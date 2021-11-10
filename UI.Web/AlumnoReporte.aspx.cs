using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Microsoft.Reporting.WebForms;


namespace UI.Web
{
    public partial class AlumnoReporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                reporte.ProcessingMode = ProcessingMode.Local;
                reporte.LocalReport.ReportPath = Server.MapPath("~/materiasEstadoAlumno.rdlc");
                AlumnoReporte_Load();
            }
        }

        private void AlumnoReporte_Load()
        {
            List<ReportParameter> parametros = infoTxt();
            reporte.LocalReport.SetParameters(parametros);


            var consulta = ReportesLogic.EstadoAlumno((int)Session["IdPlan"], (int)Session["IdUsuario"]);
            reporte.LocalReport.DataSources.Clear();
            reporte.LocalReport.DataSources.Add(new ReportDataSource("materia", consulta));
        }

        private List<ReportParameter> infoTxt()
        {
            List<ReportParameter> parameters = new List<ReportParameter>();
            parameters.Add(new ReportParameter("apellido", (string)Session["Apellido"]));
            parameters.Add(new ReportParameter("nombre", (string)Session["Nombre"]));
            parameters.Add(new ReportParameter("legajo", (string)Session["Legajo"]));
            parameters.Add(new ReportParameter("carrera", EspecialidadLogic.DescripcionEspecialidad(PlanLogic.EspecialidadPlan((int)Session["IdPlan"]))));
            parameters.Add(new ReportParameter("plan", PlanLogic.DescripcionPlan((int)Session["IdPlan"])));
            return parameters;
        }

        protected void linkVolver_Click1(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/Default.aspx");
        }
    }
}