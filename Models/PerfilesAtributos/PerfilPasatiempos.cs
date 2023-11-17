using System.ComponentModel.DataAnnotations;

namespace Practica02Backend.Models.PerfilesAtributos
{
    public class PerfilPasatiempos
    {
        [Key]
        public int perfilId { get; set; }
        [Key]
        public string pasatiempo { get; set;}

        public string descripcion { get; set; }

    }
}
