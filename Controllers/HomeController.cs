using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRUEBA_01.Models;
using PRUEBA_01.Models.ViewModels;

namespace PRUEBA_01.Controllers
{
	public class HomeController : Controller
	{
		private readonly prueba_1Context _DBContext;

		public HomeController(prueba_1Context context)
		{
			_DBContext = context;
		}
        //mostrar los usuarios
        public IActionResult Index()
		{
			List<Usuario> lista = _DBContext.Usuarios.Include(c => c.oTipo).ToList();
			return View(lista);
		}
        //listar el tipo 
		[HttpGet]
        public IActionResult Usuario_Detalle(int idUsuario)
        {
            UsuarioVM oUsuarioVM = new UsuarioVM()
            {
                oUsuario = new Usuario(),
                oListaTipo = _DBContext.Tipos.Select(tipo => new SelectListItem()
                {
                    Text = tipo.Descripcion,
                    Value = tipo.IdTipo.ToString()
                }).ToList()
            };
            if (idUsuario != 0)
            {
                oUsuarioVM.oUsuario = _DBContext.Usuarios.Find(idUsuario);
            }
            return View(oUsuarioVM);

        }
        //agregar y actualizar usuarios
        [HttpPost]
        public IActionResult Usuario_Detalle(UsuarioVM oUsuarioVM)
        {
            if (oUsuarioVM.oUsuario.IdUsuario == 0)
            {
                _DBContext.Usuarios.Add(oUsuarioVM.oUsuario);
            }
            else
            {
                _DBContext.Usuarios.Update(oUsuarioVM.oUsuario);
            }


            _DBContext.SaveChanges();

            return RedirectToAction("Index","Home");

        }

        [HttpGet]
        public IActionResult Eliminar(int idUsuario)
        {
            Usuario oUsuario = _DBContext.Usuarios.Include(c => c.oTipo).Where(e => e.IdUsuario == idUsuario).FirstOrDefault();
            return View(oUsuario);
        }

        [HttpPost]
        public IActionResult Eliminar(Usuario oUsuario)
        {
            _DBContext.Usuarios.Remove(oUsuario);
            _DBContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}