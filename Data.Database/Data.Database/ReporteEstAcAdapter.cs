using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ReporteEstAcAdapter:Adapter
    {
        public List<ReporteEstadoAcademico> GetAllPlan(int idPlan, int idAlum)
        {
            List<ReporteEstadoAcademico> materias = new List<ReporteEstadoAcademico>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand("SELECT  comisiones.anio_especialidad, desc_materia, inscripciones.condicion, " +
                    "inscripciones.nota, comisiones.desc_comision, cursos.anio_calendario " +
                    "FROM    tp2_net.dbo.materias as materias " +
                    "LEFT JOIN   tp2_net.dbo.planes as planes " +
                    "ON materias.id_plan = planes.id_plan " +
                    "LEFT JOIN tp2_net.dbo.cursos as cursos " +
                    "ON materias.id_materia = cursos.id_materia " +
                    "LEFT JOIN tp2_net.dbo.comisiones as comisiones " +
                    "ON cursos.id_comision = comisiones.id_comision " +
                    "LEFT JOIN tp2_net.dbo.alumnos_inscripciones as inscripciones " +
                    "ON cursos.id_curso = inscripciones.id_curso " +
                    "where planes.id_plan = @id and inscripciones.id_alumno = @ida"
                    , sqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = idPlan;
                cmdMaterias.Parameters.Add("@ida", SqlDbType.Int).Value = idAlum;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())                
                {                    
                    ReporteEstadoAcademico mat = new ReporteEstadoAcademico();

                    mat.Condicion = drMaterias.IsDBNull(drMaterias.GetOrdinal("condicion")) ? "-" : (string)drMaterias["condicion"];
                    mat.Nota = drMaterias.IsDBNull(drMaterias.GetOrdinal("nota")) ? "-" : drMaterias["nota"].ToString();
                    mat.AnioCursado = drMaterias.IsDBNull(drMaterias.GetOrdinal("anio_calendario")) ? "-" : drMaterias["anio_calendario"].ToString();
                    mat.AnioMateria = drMaterias.IsDBNull(drMaterias.GetOrdinal("anio_especialidad")) ?  "-" : drMaterias["anio_especialidad"].ToString();
                    mat.NombreMateria = drMaterias.IsDBNull(drMaterias.GetOrdinal("desc_materia")) ? "-" : (string)drMaterias["desc_materia"];
                    mat.Comision = drMaterias.IsDBNull(drMaterias.GetOrdinal("desc_comision")) ? "-" : (string)drMaterias["desc_comision"];
                    materias.Add(mat);
                }
                drMaterias.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }

        public List<ReporteEstadoAcademico> MateriasPlan(int idPla)
        {
            List<ReporteEstadoAcademico> materias = new List<ReporteEstadoAcademico>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMaterias = new SqlCommand(
                    "Select  DISTINCT comisiones.anio_especialidad, materias.desc_materia " +
                    "from materias " +
                    "left join cursos "+
                    "on materias.id_materia = cursos.id_materia "+
                    "left join comisiones " +
                    "on cursos.id_comision = comisiones.id_comision " +
                    "where materias.id_plan = @id"
                    , sqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = idPla;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    //Creamos un obj Usuario de la capa de entidades para copiar los datos del DataReader
                    ReporteEstadoAcademico mat = new ReporteEstadoAcademico();

                    mat.Condicion = " - ";
                    mat.Nota = " - ";
                    mat.AnioCursado = " - ";
                    mat.AnioMateria = drMaterias.IsDBNull(drMaterias.GetOrdinal("anio_especialidad")) ? "-" : drMaterias["anio_especialidad"].ToString();
                    mat.NombreMateria = drMaterias.IsDBNull(drMaterias.GetOrdinal("desc_materia")) ? "-" : (string)drMaterias["desc_materia"];
                    mat.Comision = " - ";
                    materias.Add(mat);
                }
                drMaterias.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }
    }
}
