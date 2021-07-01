using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        private Data.Database.ComisionAdapter _ComisionData;
        public ComisionLogic()
        {
            ComisionData = new ComisionAdapter();
        }

        public Data.Database.ComisionAdapter ComisionData 
        {
            get { return _ComisionData; }
            set { _ComisionData = value; }
        }

        public List<Comision> GetAll() 
        {
            List<Comision> comisiones = new List<Comision>();
            try
            {
                comisiones = ComisionData.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
            return comisiones;
        }
        public Business.Entities.Comision GetOne(int _id) 
        {
            Comision com = new Comision();
            try
            {
                com = ComisionData.GetOne(_id);
            }
            catch (Exception)
            {
                throw;
            }
            return com;
        }
        public void Save(Business.Entities.Comision _comision) 
        {
            try
            {
                ComisionData.Save(_comision);
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
                ComisionData.Delete(_id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //public bool Auth(string _usuario, string _clave)
        //{
        //    return ComisionData.Auth(_usuario, _clave);
        //}
    }
}
