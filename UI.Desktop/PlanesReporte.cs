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
using Microsoft.Reporting.WinForms;

namespace UI.Desktop
{
    public partial class PlanesReporte : Form
    {
       

        public PlanesReporte()
        {
            InitializeComponent();
        }

        private void PlanesReporte_Load(object sender, EventArgs e)
        {
            List<ReportePlanes> consultaPlanes = new List<ReportePlanes>();
            consultaPlanes = ReportesLogic.ObtenerPlanes(); 
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Planes", consultaPlanes));
            reportViewer1.RefreshReport();

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
