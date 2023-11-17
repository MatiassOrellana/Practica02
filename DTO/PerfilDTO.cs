namespace Practica02Backend.DTO
{
    public class PerfilDTO
    {
        public string nombre { get; set; }

        public string apellido { get; set; }

        public string correo { get; set; }

        public string ciudad { get; set; }

        public string pais { get; set; }

        public string descripcion { get; set; }

        public List<FrameworksDTO> Frameworks { get; set; }

        public List<PasatiemposDTO> Pasatiempos { get; set; }

    }
}
