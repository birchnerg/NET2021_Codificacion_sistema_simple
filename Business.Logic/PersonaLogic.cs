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
            List<Persona> personas = new List<Persona>();
            try
            {
                personas = PersonaData.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
            return personas;
        }
        public Business.Entities.Persona GetOne(int _id) 
        {
            Persona per = new Persona();
            try
            {
                per = PersonaData.GetOne(_id);
            }
            catch (Exception)
            {
                throw;
            }
            return per;
        }
        public int Save(Business.Entities.Persona _persona) 
        {
            try
            {
                return PersonaData.Save(_persona);
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
                PersonaData.Delete(_id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
