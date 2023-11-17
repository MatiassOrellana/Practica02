using Practica02Backend.Models.PerfilesAtributos;
using System.ComponentModel.DataAnnotations;

namespace Practica02Backend.Models
{
    public class Perfil
    {
        [Key]
        public int Id { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string correo { get; set; }

        public string ciudad { get; set; }

        public string pais { get; set; }

        public string descripcion { get; set; }

        public List<PerfilPasatiempos>? pasatiempos { get; set;}

        public List<PerfilFrameworks>? frameworks { get; set; }
    }
}
