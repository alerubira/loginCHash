using System.ComponentModel.DataAnnotations;

namespace LoginProyecto.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string NombreUsuario { get; set; } 

        [Required]
        public required string Contraseña { get; set; } 
    }
}
