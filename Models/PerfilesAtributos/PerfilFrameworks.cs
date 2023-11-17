using System.ComponentModel.DataAnnotations;

namespace Practica02Backend.Models.PerfilesAtributos
{
    public class PerfilFrameworks
    {
        [Key]
        public int perfilId { get; set; }

        [Key]
        public string framework { get; set; }

        public int nivelId { get; set; }

        public int anio { get; set; }
    }
}
