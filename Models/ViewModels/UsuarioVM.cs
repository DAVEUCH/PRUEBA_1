using Microsoft.AspNetCore.Mvc.Rendering;

namespace PRUEBA_01.Models.ViewModels
{
    public class UsuarioVM
    {
        public Usuario oUsuario { get; set; }

        public List<SelectListItem> oListaTipo { get; set; }
    }
}
