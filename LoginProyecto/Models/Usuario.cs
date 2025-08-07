using System.ComponentModel.DataAnnotations;

namespace LoginProyecto.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required]
        public string Contraseña { get; set; } = string.Empty;
    }
}
