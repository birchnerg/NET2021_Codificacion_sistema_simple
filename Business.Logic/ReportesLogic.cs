using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;


namespace Business.Logic
{
    public class ReportesLogic
    {
        public static List<ReportePlanes> ObtenerPlanes()
        {
            List<ReportePlanes> listaPlanes = new List<ReportePlanes>();
            PlanLogic pl = new PlanLogic();
            EspecialidadLogic el = new EspecialidadLogic();
            List<Plan> planes = pl.GetAll();
            List<Especialidad> especialidades = el.GetAll();
            var consultaPlanes =
                from p in planes
                join es in especialidades
                on p.IDEspecialidad equals es.ID
                select new ReportePlanes
                {
                    ID = p.ID,
                    Descripcion = p.Descripcion,
                    Especialidad = es.Descripcion
                };
            listaPlanes = consultaPlanes.ToList();
            return listaPlanes;
        }
    }
}
