namespace ProyectoFinal.Models.DTOS
{
    public class UpdateConductorDto
    {
        public string Nombre { get; set; }
        public string Licencia { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
