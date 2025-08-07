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
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string usuario, string clave)
        {
            var user = _context.Logins.FirstOrDefault(u => u.Usuario == usuario && u.Clave == clave);

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

