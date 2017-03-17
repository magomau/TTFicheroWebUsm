using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBDweb.Models
{
   public class UsuarioCarrera
    {
        [Key]
        [Column(Order = 1)]
        public int Rut { get; set; }
        [Key]
        [Column(Order = 2)]
        public byte IdCarrera { get; set; }
        public Nullable<byte> TipoProfesor { get; set; }

        public virtual Carreras Carreras { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
