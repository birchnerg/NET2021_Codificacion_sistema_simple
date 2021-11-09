using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class DocenteCursoLogic
    {
        private DocenteCursoAdapter _DocenteCursoData;
        public DocenteCursoLogic()
        {
            DocenteCursoData = new DocenteCursoAdapter();
        }

        public DocenteCursoAdapter DocenteCursoData
        {
            get { return _DocenteCursoData; }
            set { _DocenteCursoData = value; }
        }
        public List<DocenteCurso> GetAll(int idDocente)
        {
            List<DocenteCurso> listaDocenteCursos = new List<DocenteCurso>();
            try
            {
                listaDocenteCursos = DocenteCursoData.GetAll(idDocente);
            }
            catch (Exception)
            {
                throw;
            }
            return listaDocenteCursos;
        }

        public List<DocenteCurso> GetAll()//Abm para NoDocente
        {
            List<DocenteCurso> listaDocenteCursos = new List<DocenteCurso>();
            try
            {
                listaDocenteCursos = DocenteCursoData.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
            return listaDocenteCursos;
        }

        public DocenteCurso GetOne(int _id)
        {
            DocenteCurso docenteCurso = new DocenteCurso();
            try
            {
                docenteCurso = DocenteCursoData.GetOne(_id);
            }
            catch (Exception)
            {
                throw;
            }
            return docenteCurso;
        }

        public void Save(DocenteCurso _docenteCurso)
        {
            try
            {
                DocenteCursoData.Save(_docenteCurso);
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
                DocenteCursoData.Delete(_id);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
