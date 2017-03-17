using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBDweb.Models
{
   public class UsuarioAsignatura
    {
        [Key]
        [Column(Order = 1)]
        public int RutUsuario { get; set; }
        [Key]
        [Column(Order = 2)]
        public byte CodAsignatura { get; set; }
        public Nullable<int> Año { get; set; }
        public Nullable<byte> Semestre { get; set; }
        public string Estado { get; set; }
        public Nullable<int> Nota1 { get; set; }
        public Nullable<int> Nota2 { get; set; }
        public Nullable<int> Nota3 { get; set; }
        public Nullable<int> Nota4 { get; set; }
        public Nullable<int> Nota5 { get; set; }
        public string Paralelo { get; set; }

        public virtual Asignaturas Asignaturas { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
