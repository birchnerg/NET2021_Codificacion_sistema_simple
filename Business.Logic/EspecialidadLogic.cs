using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        private Data.Database.EspecialidadAdapter _EspecialidadData;
        public EspecialidadLogic()
        {
            EspecialidadData = new EspecialidadAdapter();
        }

        public Data.Database.EspecialidadAdapter EspecialidadData
        {
            get { return _EspecialidadData; }
            set { _EspecialidadData = value; }
        }

        public List<Especialidad> GetAll()
        {
            return EspecialidadData.GetAll();
        }
        public Business.Entities.Especialidad GetOne(int _id)
        {
            return EspecialidadData.GetOne(_id);
        }
        public void Save(Business.Entities.Especialidad _especialidad)
        {
            EspecialidadData.Save(_especialidad);
        }
        public void Delete(int _id)
        {
            EspecialidadData.Delete(_id);
        }
    }
}
