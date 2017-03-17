using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBDweb.Models
{
   public class Noticias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNoticias { get; set; }
        public string ContenidoNoticia { get; set; }
        public Nullable<byte> CodAsignatura { get; set; }
        public Nullable<byte> IdCarrera { get; set; }
        public Nullable<int> RutAutor { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
