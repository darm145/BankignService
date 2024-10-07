namespace PersonService.Core.Models
{
    public class Cliente : Persona
    {
        private string _contraseña;
        public int ClienteId { get; set; }
        
        public string Contraseña
        {
            get => _contraseña;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("el cliente debe tener contraseña");
                _contraseña = value;
            }
        }
        public bool Estado { get; set; }

    }
}
