using LoginProyecto.Models; // 👈 importante
//using LoginProyecto.Models; // Importa tus modelos, necesario para el contexto
using Microsoft.EntityFrameworkCore; // Importa EF Core

var builder = WebApplication.CreateBuilder(args);// Crea el builder para configurar la app

// ✅ cadena de conexión MySQL
var connectionString = "server=localhost;database=login_1;user=root";

// ✅ Agregar contexto
// Agrega el contexto de base de datos usando MySQL y la cadena de conexión
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Agrega soporte para controladores y vistas (MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build();// Construye la aplicación

app.UseStaticFiles();// Permite servir archivos estáticos (css, js, imágenes)
app.UseRouting(); // Habilita el enrutamiento

// Define la ruta por defecto: controlador=Login, acción=Index, id=opcional 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

// ✅ Crear la base de datos si no existe
/*using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}*/

app.Run();// Inicia la aplicación

