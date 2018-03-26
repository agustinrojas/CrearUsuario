using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario
{
    public class ClaseAlumno
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDOS { get; set; }
        public string DNI { get; set; }

        public ClaseAlumno(int pId, string pNombre, string pApellidos, string pDNI)
        {
            this.ID = pId;
            this.NOMBRE = pNombre;
            this.APELLIDOS = pApellidos;
            this.DNI = pDNI;
        }

        public override bool Equals(object obj)
        {
            var alumno = obj as ClaseAlumno;
            return alumno != null &&
                   ID == alumno.ID &&
                   NOMBRE == alumno.NOMBRE &&
                   APELLIDOS == alumno.APELLIDOS &&
                   DNI == alumno.DNI;
        }

        public override int GetHashCode()
        {
            var hashCode = -1910929195;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NOMBRE);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(APELLIDOS);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DNI);
            return hashCode;
        }
    }
}
