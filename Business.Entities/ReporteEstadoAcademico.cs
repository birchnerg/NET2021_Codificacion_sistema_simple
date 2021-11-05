using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class ReporteEstadoAcademico
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Condicion;
        public string Condicion
        {
            get { return _Condicion; }
            set { _Condicion = value; }
        }

        private string _Nota;
        public string Nota
        {
            get { return _Nota; }
            set { _Nota = value; }
        }

        private string _AnioCursado;
        public string AnioCursado
        {
            get { return _AnioCursado; }
            set { _AnioCursado = value; }
        }

        private string _AnioMateria;
        public string AnioMateria
        {
            get { return _AnioMateria; }
            set { _AnioMateria = value; }
        }

        private string _NombreMateria;
        public string NombreMateria
        {
            get { return _NombreMateria; }
            set { _NombreMateria = value; }
        }

        private string _Comision;
        public string Comision
        {
            get { return _Comision; }
            set { _Comision = value; }
        }
    }
}
