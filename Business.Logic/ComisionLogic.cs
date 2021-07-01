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
            return ComisionData.GetAll();
        }
        public Business.Entities.Comision GetOne(int _id) 
        {
            return ComisionData.GetOne(_id);
        }
        public void Save(Business.Entities.Comision _comision) 
        {
            ComisionData.Save(_comision);
        }
        public void Delete(int _id)
        {
            ComisionData.Delete(_id);
        }
        //public bool Auth(string _usuario, string _clave)
        //{
        //    return ComisionData.Auth(_usuario, _clave);
        //}
    }
}
