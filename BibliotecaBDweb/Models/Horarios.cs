using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBDweb.Models
{
    public class Horarios
    {
        [Key]
        [Column(Order = 1)]
        public byte CodAsignatura { get; set; }
        [Key]
        [Column(Order = 2)]
        public byte Modificado { get; set; }
        public Nullable<byte> CodHora { get; set; }
        public Nullable<byte> Dia { get; set; }
        public Nullable<byte> CodSala { get; set; }
        public Nullable<int> RutProfesor { get; set; }
        public Nullable<System.DateTime> FechaModi { get; set; }
        public string Paralelo { get; set; }

        public virtual Asignaturas Asignaturas { get; set; }
        public virtual Hora Hora { get; set; }
        public virtual Salas Salas { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
