using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBDweb.Models
{
    public class Hora
    {
        public Hora()
        {
            this.Horarios = new HashSet<Horarios>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte CodHora { get; set; }
        public Nullable<int> HoraInicio { get; set; }
        public Nullable<int> HoraTermino { get; set; }

        public virtual ICollection<Horarios> Horarios { get; set; }
    }
}
