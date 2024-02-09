using System;
using System.Collections.Generic;

namespace PRUEBA_01.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Edad { get; set; }
        public int? IdTipo { get; set; }

        public virtual Tipo? oTipo { get; set; }
    }
}
