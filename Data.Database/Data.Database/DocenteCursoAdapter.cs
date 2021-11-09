using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Data.Database
{
    public class DocenteCursoAdapter:Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docenteCursos = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();

                //Objeto SqlCommand para la sentencia SQL que se va a ejecutar
                SqlCommand cmdDocenteCurso = new SqlCommand("SELECT * FROM docentes_cursos", sqlConn);

                //DataReader para recuperar los datos de la DB
                SqlDataReader drDocenteCurso = cmdDocenteCurso.ExecuteReader();

                //Read() lee una fila de las devueltas por el commandSql, devuelve true mientras pueda leer datos y avanza 
                //a la siguiente fila
                while (drDocenteCurso.Read())
                {
                    //Creamos un obj Usuario de la capa de entidades para copiar los datos del DataReader
                    DocenteCurso doc = new DocenteCurso();

                    doc.ID = (int)drDocenteCurso["id_dictado"];
                    doc.IDDocente = (int)drDocenteCurso["id_docente"];
                    doc.IDCurso = (int)drDocenteCurso["id_curso"];
                    doc.Cargo = (DocenteCurso.TiposCargos)(int)drDocenteCurso["cargo"];
                    docenteCursos.Add(doc);
                }
                drDocenteCurso.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de docentes", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return docenteCursos;
        }

        public List<DocenteCurso> GetAll(int idDocente)
        {
            List<DocenteCurso> docenteCursos = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();

                //Objeto SqlCommand para la sentencia SQL que se va a ejecutar
                SqlCommand cmdDocenteCurso = new SqlCommand("SELECT * FROM docentes_cursos WHERE id_docente = @id_docente", sqlConn);
                cmdDocenteCurso.Parameters.Add("@id_docente", SqlDbType.Int).Value = idDocente;
                //DataReader para recuperar los datos de la DB
                SqlDataReader drDocenteCurso = cmdDocenteCurso.ExecuteReader();

                //Read() lee una fila de las devueltas por el commandSql, devuelve true mientras pueda leer datos y avanza 
                //a la siguiente fila
                while (drDocenteCurso.Read())
                {
                    //Creamos un obj Usuario de la capa de entidades para copiar los datos del DataReader
                    DocenteCurso doc = new DocenteCurso();

                    doc.ID = (int)drDocenteCurso["id_dictado"];
                    doc.IDDocente = (int)drDocenteCurso["id_docente"];
                    doc.IDCurso = (int)drDocenteCurso["id_curso"];
                    doc.Cargo = (DocenteCurso.TiposCargos)(int)drDocenteCurso["cargo"];
                    docenteCursos.Add(doc);

                }
                drDocenteCurso.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista cursos del docente", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return docenteCursos;
        }


        public DocenteCurso GetOne(int ID)
        {
            DocenteCurso doc = new DocenteCurso();
            try
            {
                this.OpenConnection();

                //Objeto SqlCommand para la sentencia SQL que se va a ejecutar
                SqlCommand cmdDocenteCurso = new SqlCommand("SELECT * FROM docentes_cursos WHERE id_dictado=@id_dictado", sqlConn);
                cmdDocenteCurso.Parameters.Add("@id_dictado", SqlDbType.Int).Value = ID;

                //DataReader para recuperar los datos de la DB
                SqlDataReader drDocenteCurso = cmdDocenteCurso.ExecuteReader();

                //Read() lee una fila de las devueltas por el commandSql, devuelve true mientras pueda leer datos
                if (drDocenteCurso.Read())
                {
                    doc.ID = (int)drDocenteCurso["id_dictado"];
                    doc.IDDocente = (int)drDocenteCurso["id_docente"];
                    doc.IDCurso = (int)drDocenteCurso["id_curso"];
                    doc.Cargo = (DocenteCurso.TiposCargos)(int)drDocenteCurso["cargo"];
                }
                drDocenteCurso.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos del curso del docente", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return doc;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                //Objeto SqlCommand para la sentencia SQL que se va a ejecutar
                SqlCommand cmdDelete = new SqlCommand("DELETE docentes_cursos WHERE id_dictado=@id_dictado", sqlConn);
                cmdDelete.Parameters.Add("@id_dictado", SqlDbType.Int).Value = ID;
                //Ejecutamos la sentencia
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el curso del docente", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(DocenteCurso _docenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE docentes_cursos SET id_docente = @id_docente," +
                    "id_curso = @id_curso, cargo = @cargo WHERE id_dictado  = @id_dictado", sqlConn);

                cmdSave.Parameters.Add("@id_dictado", SqlDbType.Int).Value = _docenteCurso.ID;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = _docenteCurso.IDDocente;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = _docenteCurso.IDCurso;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = _docenteCurso.Cargo;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del curso del docente", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(DocenteCurso _docenteCurso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("INSERT INTO docentes_cursos (id_docente,id_curso,cargo) VALUES" +
                    "(@id_docente,@id_curso," +
                    "@cargo)" +
                    "SELECT @@identity", //Recupera el ID que asigno el SQL automaticamente
                    sqlConn);

                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = _docenteCurso.IDDocente;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = _docenteCurso.IDCurso;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = _docenteCurso.Cargo;
                //asi se obtiene el id que se asigno al DB automaticamente

                _docenteCurso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                //asi se obtiene el id que se asigno al DB automaticamente
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear curso del docente", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(DocenteCurso inscripcion)
        {
            if (inscripcion.State == BusinessEntity.States.Deleted)
            {
                this.Delete(inscripcion.ID);
            }
            else if (inscripcion.State == BusinessEntity.States.New)
            {
                this.Insert(inscripcion);
            }
            else if (inscripcion.State == BusinessEntity.States.Modified)
            {
                this.Update(inscripcion);
            }
            inscripcion.State = BusinessEntity.States.Unmodified;
        }
    }
}
