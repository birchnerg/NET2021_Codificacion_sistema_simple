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
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                usuarios = UsuarioData.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
            return usuarios;
        }
        public Business.Entities.Usuario GetOne(int _id) 
        {
            Usuario usu = new Usuario();
            try
            {
                usu = UsuarioData.GetOne(_id);
            }
            catch (Exception)
            {
                throw;
            }
            return usu;
        }
        public void Save(Business.Entities.Usuario _usuario) 
        {
            try
            {
                UsuarioData.Save(_usuario);
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
                UsuarioData.Delete(_id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool Auth(string _usuario, string _clave)
        {
            bool exito;
            try
            {
                exito = UsuarioData.Auth(_usuario, _clave);
            }
            catch (Exception)
            {
                throw;
            }
            return exito;
        }
    }
}
