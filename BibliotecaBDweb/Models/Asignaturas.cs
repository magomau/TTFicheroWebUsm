using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBDweb.Models
{
    public class Asignaturas
    {

        public Asignaturas()
        {
            
            this.Horarios = new HashSet<Horarios>();
            this.UsuarioAsignatura = new HashSet<UsuarioAsignatura>();
        }
        [Key]
        public byte CodAsig { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Horarios> Horarios { get; set; }
        public virtual ICollection<UsuarioAsignatura> UsuarioAsignatura { get; set; }
    }
}
