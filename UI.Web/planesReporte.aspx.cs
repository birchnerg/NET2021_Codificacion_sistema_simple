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
    public partial class planesReporte : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                reporte.ProcessingMode = ProcessingMode.Local;
                reporte.LocalReport.ReportPath = Server.MapPath("~/PlanesReporte.rdlc");
                PlanesReporte_Load();                
            }
        }

        private void PlanesReporte_Load()
        {
            List<ReportePlanes> consultaPlanes = new List<ReportePlanes>();
            consultaPlanes = ReportesLogic.ObtenerPlanes();
            reporte.LocalReport.DataSources.Clear();
            reporte.LocalReport.DataSources.Add(new ReportDataSource("Planes", consultaPlanes));
        }

        protected void linkVolver_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/Planes.aspx");
        }
    }
}