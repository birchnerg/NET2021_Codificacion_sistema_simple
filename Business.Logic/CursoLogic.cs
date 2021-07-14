using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        private Data.Database.CursoAdapter _CursoData;
        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }

        public Data.Database.CursoAdapter CursoData 
        {
            get { return _CursoData; }
            set { _CursoData = value; }
        }

        public List<Curso> GetAll() 
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                cursos = CursoData.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
            return cursos;
        }
        public Business.Entities.Curso GetOne(int _id) 
        {
            Curso cur = new Curso();
            try
            {
                cur = CursoData.GetOne(_id);
            }
            catch (Exception)
            {
                throw;
            }
            return cur;
        }
        public void Save(Business.Entities.Curso _curso) 
        {
            try
            {
                CursoData.Save(_curso);
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
                CursoData.Delete(_id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
