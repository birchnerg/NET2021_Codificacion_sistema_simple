using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PersonaAdapter:Adapter
    {
        public List<Persona> GetAll()
        {
            //return new List<Persona>(Personas);
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();

                //Objeto SqlCommand para la sentencia SQL que se va a ejecutar
                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM personas", sqlConn);

                //DataReader para recuperar los datos de la DB
                SqlDataReader drPersona = cmdPersonas.ExecuteReader();

                //Read() lee una fila de las devueltas por el commandSql, devuelve true mientras pueda leer datos y avanza 
                //a la siguiente fila
                while (drPersona.Read())
                {
                    //Creamos un obj Persona de la capa de entidades para copiar los datos del DataReader
                    Persona per = new Persona();

                    per.ID = (int)drPersona["id_persona"];
                    per.Nombre = (string)drPersona["nombre"];
                    per.Apellido = (string)drPersona["apellido"];
                    per.Email = (string)drPersona["email"];
                    per.Direccion = (string)drPersona["direccion"];
                    per.Telefono = (string)drPersona["Telefono"];
                    per.FechaNacimiento = (DateTime)drPersona["fecha_nac"];
                    per.Legajo = (int)drPersona["legajo"];
                    per.IDPlan = (int)drPersona["id_plan"];
                    per.TipoPersonasString = Enum.GetName(typeof(Persona.TipoPersonas),drPersona["tipo_persona"]);
                    personas.Add(per);
                }
                drPersona.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return personas;
        }

        public Business.Entities.Persona GetOne(int ID)
        {
            //return Personas.Find(delegate(Persona u) { return u.ID == ID; });
            Persona per = new Persona();
            try
            {
                this.OpenConnection();

                //Objeto SqlCommand para la sentencia SQL que se va a ejecutar
                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM personas WHERE id_persona=@id", sqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                //DataReader para recuperar los datos de la DB
                SqlDataReader drPersona = cmdPersonas.ExecuteReader();

                //Read() lee una fila de las devueltas por el commandSql, devuelve true mientras pueda leer datos
                if (drPersona.Read())
                {
                    per.ID = (int)drPersona["id_persona"];
                    per.Nombre = (string)drPersona["nombre"];
                    per.Apellido = (string)drPersona["apellido"];
                    per.Email = (string)drPersona["email"];
                    per.Direccion = (string)drPersona["direccion"];
                    per.Telefono = (string)drPersona["Telefono"];
                    per.FechaNacimiento = (DateTime)drPersona["fecha_nac"];
                    per.Legajo = (int)drPersona["legajo"];
                    per.IDPlan = (int)drPersona["id_plan"];
                    per.TipoPersonasInt = (int)drPersona["tipo_persona"];

                }
                drPersona.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la persona", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return per;
        }

        public void Delete(int ID)
        {
            //Personas.Remove(this.GetOne(ID));
            try
            {
                this.OpenConnection();

                //Objeto SqlCommand para la sentencia SQL que se va a ejecutar
                SqlCommand cmdDelete = new SqlCommand("DELETE personas WHERE id_persona=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                //Ejecutamos la sentencia
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar persona", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE personas SET nombre = @nombre, apellido = @apellido," +
                    "email = @email, direccion = @direccion, telefono = @telefono, fecha_nac = @fecha_nac," +
                    "legajo = @legajo, id_plan = @id_plan, tipo_persona = @tipo_persona" +
                    " WHERE id_persona  = @id",sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersonasInt;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la persona", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected int Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO personas (nombre," +
                    "apellido,email,direccion,telefono,fecha_nac,legajo,id_plan,tipo_persona) VALUES(@nombre," +
                    "@apellido,@email,@direccion,@telefono,@fecha_nac,@legajo,@id_plan,@tipo_persona)" +
                    "SELECT @@identity", //Recupera el ID que asigno el SQL automaticamente
                    sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersonasInt;

                persona.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //asi se obtiene el id que se asigno al DB automaticamente
                return persona.ID;
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear Persona", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public int Save(Persona persona)
        {
            int id=0;
            if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.New)
            {
                id = this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;
            return id;
        }
    }
}
