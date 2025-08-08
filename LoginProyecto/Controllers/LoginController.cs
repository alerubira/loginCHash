/*using Microsoft.AspNetCore.Mvc;
using LoginProyecto.Models;

namespace LoginProyecto.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // 🔐 Simulamos validación (usá una BD real en producción)
            if (model.Username == "admin" && model.Password == "123")
            {
                TempData["Mensaje"] = "Login exitoso.";
                return RedirectToAction("Bienvenido");
            }

            ModelState.AddModelError(string.Empty, "Credenciales inválidas.");
            return View(model);
        }

        public IActionResult Bienvenido()
        {
            return View();
        }
    }
}*/
using Microsoft.AspNetCore.Mvc;
using LoginProyecto.Models;
using System.Linq;

namespace LoginProyecto.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;// Contexto para acceder a la base de datos

        public LoginController(AppDbContext context)
        {
            _context = context; // Se inyecta el contexto por dependencia
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();// Muestra el formulario de login
        }

        [HttpPost]
        public IActionResult Index(string usuario, string clave)
        {
             // Busca un usuario en la base de datos con el nombre y contraseña recibidos
            var user = _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == usuario && u.Contraseña == clave);

            if (user != null)
            {
                // Redirige al home si las credenciales son correctas
                return RedirectToAction("Index", "Home");
            }

            // Si son incorrectas, mostrar un mensaje
            ViewBag.Mensaje = "Usuario o contraseña incorrectos.";
            return View();
        }
    }
}

