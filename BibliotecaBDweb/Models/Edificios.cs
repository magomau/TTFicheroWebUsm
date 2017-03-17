using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBDweb.Models
{
   public class Edificios
    {
        public Edificios()
        {
            this.Salas = new HashSet<Salas>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte CodEdificios { get; set; }
        public Nullable<int> CantidadSalas { get; set; }
        public Nullable<int> NumerosBaños { get; set; }
        public Nullable<int> Oficinas { get; set; }

        public virtual ICollection<Salas> Salas { get; set; }
    }
}
