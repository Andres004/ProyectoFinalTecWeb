namespace ProyectoFinal.Models
{
    public class Conductor
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string LicenciaConducir { get; set; }
        public string Telefono { get; set; }

        // 1:N Conductor -> Viajes
        public ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
    }
}
