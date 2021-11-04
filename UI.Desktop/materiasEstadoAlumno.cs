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

namespace UI.Desktop
{
    public partial class materiasEstadoAlumno : Form
    {
        public materiasEstadoAlumno()
        {
            InitializeComponent();
            List<ReportParameter> parametros = infoTxt();
            reporte.LocalReport.SetParameters(parametros);
            this.reporte.RefreshReport();
        }

        private void materiasEstadoAlumno_Load(object sender, EventArgs e)
        {
            this.reporte.RefreshReport();
        }

        private List<ReportParameter> infoTxt()
        {
            List<ReportParameter> parameters = new List<ReportParameter>();
            parameters.Add(new ReportParameter("nombre", "Julio Lopez"));
            parameters.Add(new ReportParameter("legajo", "44356"));
            parameters.Add(new ReportParameter("carrera", "Ingenieria en sistemas"));
            parameters.Add(new ReportParameter("plan", "2008"));
            return parameters;
        }
    }
}
