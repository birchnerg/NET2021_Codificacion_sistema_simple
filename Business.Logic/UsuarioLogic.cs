using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        private Data.Database.UsuarioAdapter _UsuarioData;
        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }

        public Data.Database.UsuarioAdapter UsuarioData 
        {
            get { return _UsuarioData; }
            set { _UsuarioData = value; }
        }

        public List<Usuario> GetAll() 
        {
            return UsuarioData.GetAll();
        }
        public Business.Entities.Usuario GetOne(int _id) 
        {
            return UsuarioData.GetOne(_id);
        }
        public void Save(Business.Entities.Usuario _usuario) 
        {
            UsuarioData.Save(_usuario);
        }
        public void Delete(int _id)
        {
            UsuarioData.Delete(_id);
        }
        public bool Auth(string _usuario, string _clave)
        {
            return UsuarioData.Auth(_usuario, _clave);
        }
    }
}
