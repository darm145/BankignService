using PersonService.Core.Models.Enums;

namespace PersonService.Core.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Genero Genero { get; set; }
        public int Edad {  get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get;set; }

    }
}
