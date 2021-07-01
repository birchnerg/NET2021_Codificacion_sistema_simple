using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;


namespace Data.Database
{
    public class EspecialidadAdapter:Adapter
    {
        public List<Especialidad> GetAll()
        {
            //return new List<Especialidad>(Especialidades);
            List<Especialidad> Especialidades = new List<Especialidad>();
            try
            {
                this.OpenConnection();

                //Objeto SqlCommand para la sentencia SQL que se va a ejecutar
                SqlCommand cmdEspecialidad = new SqlCommand("SELECT * FROM especialidades", sqlConn);

                //DataReader para recuperar los datos de la DB
                SqlDataReader drEspecialidad = cmdEspecialidad.ExecuteReader();

                //Read() lee una fila de las devueltas por el commandSql, devuelve true mientras pueda leer datos y avanza 
                //a la siguiente fila
                while (drEspecialidad.Read())
                {
                    //Creamos un obj especialidad de la capa de entidades para copiar los datos del DataReader
                    Especialidad esp = new Especialidad();

                    esp.ID = (int)drEspecialidad["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidad["desc_especialidad"];

                    Especialidades.Add(esp);
                }
                drEspecialidad.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de especialidades", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return Especialidades;
        }

        public Business.Entities.Especialidad GetOne(int ID)
        {
            Especialidad esp = new Especialidad();
            try
            {
                this.OpenConnection();

                //Objeto SqlCommand para la sentencia SQL que se va a ejecutar
                SqlCommand cmdEspecialidades = new SqlCommand("SELECT * FROM especialidades WHERE id_especialidad=@id", sqlConn);
                cmdEspecialidades.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                //DataReader para recuperar los datos de la DB
                SqlDataReader drEspecialidad = cmdEspecialidades.ExecuteReader();

                //Read() lee una fila de las devueltas por el commandSql, devuelve true mientras pueda leer datos
                if (drEspecialidad.Read())
                {
                    esp.ID = (int)drEspecialidad["id_especialidad"];
                    esp.Descripcion = (string)drEspecialidad["desc_especialidad"];
                }
                drEspecialidad.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de especialidades", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return esp;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                //Objeto SqlCommand para la sentencia SQL que se va a ejecutar
                SqlCommand cmdDelete = new SqlCommand("DELETE especialidades WHERE id_especialidad=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                //Ejecutamos la sentencia
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar especialidad", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE especialidades SET desc_especialidad = @descripcion " +
                            "WHERE id_especialidad  = @id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = especialidad.ID;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de especialidad", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Especialidad especialidad)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO especialidades (desc_especialidad)" +
                    "VALUES(@descripcion)" +
                    "SELECT @@identity", //Recupera el ID que asigno el SQL automaticamente
                    sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = especialidad.ID;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                especialidad.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //asi se obtiene el id que se asigno al DB automaticamente
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear especialidad", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Especialidad especialidad)
        {
            if (especialidad.State == BusinessEntity.States.Deleted)
            {
                this.Delete(especialidad.ID);
            }
            else if (especialidad.State == BusinessEntity.States.New)
            {
                this.Insert(especialidad);
            }
            else if (especialidad.State == BusinessEntity.States.Modified)
            {
                this.Update(especialidad);
            }
            especialidad.State = BusinessEntity.States.Unmodified;
        }
    }
}
