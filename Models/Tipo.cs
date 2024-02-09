using System;
using System.Collections.Generic;

namespace PRUEBA_01.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipo { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
