using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        private Data.Database.MateriaAdapter _MateriaData;
        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }

        public Data.Database.MateriaAdapter MateriaData
        {
            get { return _MateriaData; }
            set { _MateriaData = value; }
        }

        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                materias = MateriaData.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
            return materias;
        }
        public Business.Entities.Materia GetOne(int _id)
        {
            Materia mat = new Materia();
            try
            {
                mat = MateriaData.GetOne(_id);
            }
            catch (Exception)
            {
                throw;
            }
            return mat;
        }
        public void Save(Business.Entities.Materia _materia)
        {
            try
            {
                MateriaData.Save(_materia);
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
                MateriaData.Delete(_id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
