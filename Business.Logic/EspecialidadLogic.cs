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
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                especialidades = EspecialidadData.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
            return especialidades;
        }
        public Business.Entities.Especialidad GetOne(int _id)
        {
            Especialidad esp = new Especialidad();
            try
            {
                esp = EspecialidadData.GetOne(_id);
            }
            catch (Exception)
            {
                throw;
            }
            return esp;
        }
        public void Save(Business.Entities.Especialidad _especialidad)
        {
            try
            {
                EspecialidadData.Save(_especialidad);
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
                EspecialidadData.Delete(_id);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public static string DescripcionEspecialidad(int id)
        {
            EspecialidadLogic esp = new EspecialidadLogic();
            Especialidad espec = esp.GetOne(id);
            return espec.Descripcion;
        }
    }
}
