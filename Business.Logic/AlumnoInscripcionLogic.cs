using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic
    {
        private AlumnoInscripcionAdapter _InscripcionData;
        public AlumnoInscripcionLogic()
        {
            InscripcionData = new AlumnoInscripcionAdapter();
        }

        public AlumnoInscripcionAdapter InscripcionData
        {
            get { return _InscripcionData; }
            set { _InscripcionData = value; }
        }
        public List<AlumnoInscripcion> GetAll(int idAlumno)//ID alumno = ID persona
        {
            List<AlumnoInscripcion> listaAlumnoInscripcion = new List<AlumnoInscripcion>();
            try
            {
                listaAlumnoInscripcion = InscripcionData.GetAll(idAlumno);
            }
            catch (Exception)
            {
                throw;
            }
            return listaAlumnoInscripcion;
        }

        public List<AlumnoInscripcion> GetAll()//Abm para NoDocente
        {
            List<AlumnoInscripcion> listaAlumnoInscripcion = new List<AlumnoInscripcion>();
            try
            {
                listaAlumnoInscripcion = InscripcionData.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
            return listaAlumnoInscripcion;
        }

        public AlumnoInscripcion GetOne(int _id)
        {
            AlumnoInscripcion inscripcion = new AlumnoInscripcion();
            try
            {
                inscripcion = InscripcionData.GetOne(_id);
            }
            catch (Exception)
            {
                throw;
            }
            return inscripcion;
        }

        public void Save(AlumnoInscripcion _inscripcion)
        {
            try
            {
                InscripcionData.Save(_inscripcion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int _id)
        {
            try
            {
                InscripcionData.Delete(_id);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
