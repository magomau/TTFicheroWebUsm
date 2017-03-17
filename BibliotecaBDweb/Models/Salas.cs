using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBDweb.Models
{
   public class Salas
    {
        public Salas()
        {
            this.Horarios = new HashSet<Horarios>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte CodSala { get; set; }
        public Nullable<byte> CodEdificio { get; set; }
        public Nullable<int> MaxAlumnos { get; set; }

        public virtual Edificios Edificios { get; set; }
        public virtual ICollection<Horarios> Horarios { get; set; }
    }
}
