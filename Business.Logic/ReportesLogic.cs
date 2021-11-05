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

        public static List<ReporteEstadoAcademico> ObtenerEstadoAcademico()
        {
            List<ReporteEstadoAcademico> ea = new List<ReporteEstadoAcademico>();
            ReporteEstadoAcademico uno = new ReporteEstadoAcademico();
            ReporteEstadoAcademico dos = new ReporteEstadoAcademico();
            ReporteEstadoAcademico tres = new ReporteEstadoAcademico();
            ReporteEstadoAcademico cuatro = new ReporteEstadoAcademico();
            uno.AnioCursado = "2020";
            uno.AnioMateria = "1";
            uno.Condicion = "Aprobada";
            uno.Comision = "1k2";
            uno.NombreMateria = "Ingenieria y sociedad";
            uno.Nota = "7";
            ea.Add(uno);
            dos.AnioCursado = "2021";
            dos.AnioMateria = "2";
            dos.Condicion = "Inscripto";
            dos.Comision = "2k2";
            dos.NombreMateria = "Sistemas Operativos";
            ea.Add(dos);
            tres.AnioMateria = "3";
            tres.NombreMateria = "Gestion de datos";
            ea.Add(tres);
            cuatro.AnioCursado = "-";
            cuatro.AnioMateria = "3";
            cuatro.Condicion = "-";
            cuatro.Comision = "-";
            cuatro.NombreMateria = "Economia";
            cuatro.Nota = "-";
            ea.Add(cuatro);
            return ea;
        }
    }
}
