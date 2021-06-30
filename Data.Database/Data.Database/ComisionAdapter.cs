using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ComisionAdapter:Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Usuario> _Usuarios;

        private static List<Usuario> Usuarios
        {
            get
            {
                if (_Usuarios == null)
                {
                    _Usuarios = new List<Business.Entities.Usuario>();
                    Business.Entities.Usuario usr;
                    usr = new Business.Entities.Usuario();
                    usr.ID = 1;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Casimiro";
                    usr.Apellido = "Cegado";
                    usr.NombreUsuario = "casicegado";
                    usr.Clave = "mirocegado";
                    usr.Email = "casimirocegado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 2;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Armando Esteban";
                    usr.Apellido = "Quito";
                    usr.NombreUsuario = "aequito";
                    usr.Clave = "carpintero";
                    usr.Email = "armandoquito@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.ID = 3;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Alan";
                    usr.Apellido = "Brado";
                    usr.NombreUsuario = "alanbrado";
                    usr.Clave = "abrete sesamo";
                    usr.Email = "alanbrado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                }
                return _Usuarios;
            }
        }
        #endregion

        public List<Comision> GetAll()
        {
            //return new List<Comision>(Comisiones);
            List<Comision> comisiones = new List<Comision>();
            try
            {
                this.OpenConnection();

                //Objeto SqlCommand para la sentencia SQL que se va a ejecutar
                SqlCommand cmdComisiones = new SqlCommand("SELECT * FROM comisiones", sqlConn);

                //DataReader para recuperar los datos de la DB
                SqlDataReader drComision = cmdComisiones.ExecuteReader();

                //Read() lee una fila de las devueltas por el commandSql, devuelve true mientras pueda leer datos y avanza 
                //a la siguiente fila
                while (drComision.Read())
                {
                    //Creamos un obj Usuario de la capa de entidades para copiar los datos del DataReader
                    Comision com = new Comision();

                    com.ID = (int)drComision["id_comision"];
                    com.Descripcion = (string)drComision["desc_comision"];
                    com.AnioEspecialidad = (int)drComision["anio_especialidad"];
                    com.IDPlan = (int)drComision["id_plan"];
                    //usr.NombreUsuario = (string)drUsuario["nombre_usuario"];
                    //usr.Clave = (string)drUsuario["clave"];
                    //usr.Habilitado = (bool)drUsuario["habilitado"];
                    //usr.Nombre = (string)drUsuario["nombre"];
                    //usr.Apellido = (string)drUsuario["apellido"];
                    //usr.Email = (string)drUsuario["email"];

                    comisiones.Add(com);
                }
                drComision.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return comisiones;
        }

        public Business.Entities.Comision GetOne(int ID)
        {
            //return Usuarios.Find(delegate(Usuario u) { return u.ID == ID; });
            Comision com = new Comision();
            try
            {
                this.OpenConnection();

                //Objeto SqlCommand para la sentencia SQL que se va a ejecutar
                SqlCommand cmdComisiones = new SqlCommand("SELECT * FROM comisiones WHERE id_comision=@id_comision", sqlConn);
                cmdComisiones.Parameters.Add("@id_comision", SqlDbType.Int).Value = ID;

                //DataReader para recuperar los datos de la DB
                SqlDataReader drComision = cmdComisiones.ExecuteReader();

                //Read() lee una fila de las devueltas por el commandSql, devuelve true mientras pueda leer datos
                if (drComision.Read())
                {
                    com.ID = (int)drComision["id_comision"];
                    //usr.NombreComision = (string)drComision["nombre_comision"];
                    //usr.Clave = (string)drUsuario["clave"];
                    //usr.Habilitado = (bool)drUsuario["habilitado"];
                    //usr.Nombre = (string)drUsuario["nombre"];
                    //usr.Apellido = (string)drUsuario["apellido"];
                    //usr.Email = (string)drUsuario["email"];

                }
                drComision.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la comisión", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return com;
        }

        public void Delete(int ID)
        {
            //Usuarios.Remove(this.GetOne(ID));
            try
            {
                this.OpenConnection();

                //Objeto SqlCommand para la sentencia SQL que se va a ejecutar
                SqlCommand cmdDelete = new SqlCommand("DELETE comisiones WHERE id_comision=@id_comision", sqlConn);
                cmdDelete.Parameters.Add("@id_comision", SqlDbType.Int).Value = ID;
                //Ejecutamos la sentencia
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la comisión", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones SET desc_comision = @desc_comision," +
                    "anio_especialidad = @anio_especialidad, id_plan = @id_plan WHERE id_comision  = @id",sqlConn);

                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = comision.ID;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la comisión", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Comision comision)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO comisiones (desc_comision,anio_especialidad,id_plan) +" +
                    " VALUES(@desc_comision,@anio_especialidad," +
                    "@id_plan)" +
                    "SELECT @@identity", //Recupera el ID que asigno el SQL automaticamente
                    sqlConn);

                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = comision.ID;
                cmdSave.Parameters.Add("@desc_comision", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmdSave.Parameters.Add("@anio_especialidad", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                //asi se obtiene el id que se asigno al DB automaticamente
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear comisión", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Comision comision)
        {
            if (comision.State == BusinessEntity.States.Deleted)
            {
                this.Delete(comision.ID);
            }
            else if (comision.State == BusinessEntity.States.New)
            {
                this.Insert(comision);
            }
            else if (comision.State == BusinessEntity.States.Modified)
            {
                this.Update(comision);
            }
            comision.State = BusinessEntity.States.Unmodified;            
        }
        //public bool Auth(string comision, string clave)
        //{
        //    bool auth = false;
        //    try
        //    {
        //        this.OpenConnection();

        //        //Objeto SqlCommand para la sentencia SQL que se va a ejecutar
        //        SqlCommand cmdUsuarios = new SqlCommand("SELECT * FROM usuarios WHERE nombre_usuario=@usuario AND clave=@clave", sqlConn);
        //        cmdUsuarios.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = usuario;
        //        cmdUsuarios.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = clave;
        //        //DataReader para recuperar los datos de la DB
        //        SqlDataReader drUsuario = cmdUsuarios.ExecuteReader();

        //        //Read() lee una fila de las devueltas por el commandSql, devuelve true mientras pueda leer datos
        //        if (drUsuario.Read())
        //        {
        //            auth = true;

        //        }
        //        drUsuario.Close();
        //    }
        //    catch (Exception Ex)
        //    {
        //        Exception ExcepcionManejada = new Exception("Error al loguear usuario", Ex);
        //        throw ExcepcionManejada;
        //    }
        //    finally
        //    {
        //        this.CloseConnection();
        //    }
        //    return auth;
        //}
    }
}
