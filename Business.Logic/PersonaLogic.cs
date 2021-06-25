using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        private Data.Database.PersonaAdapter _PersonaData;
        public PersonaLogic()
        {
            PersonaData = new PersonaAdapter();
        }

        public Data.Database.PersonaAdapter PersonaData 
        {
            get { return _PersonaData; }
            set { _PersonaData = value; }
        }

        public List<Persona> GetAll() 
        {
            return PersonaData.GetAll();
        }
        public Business.Entities.Persona GetOne(int _id) 
        {
            return PersonaData.GetOne(_id);
        }
        public void Save(Business.Entities.Persona _persona) 
        {
            PersonaData.Save(_persona);
        }
        public void Delete(int _id)
        {
            PersonaData.Delete(_id);
        }
    }
}
