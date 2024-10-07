using PersonService.Core.Models;
using PersonService.Core.Models.Enums;

namespace PersonService.Tests
{
    public class PersonTests
    {
        [Fact]
        public void Cliente_Hereda_Propiedades_De_Persona()
        {
            var cliente = new Cliente
            {
                Id = 1,
                Nombre = "Daniel Ramirez",
                Genero = Genero.Masculino,
                Contraseña = "1234",
                Direccion = "cr 83 145 Bogota",
                Edad = 25,
                Estado = true,
                Identificacion = "1111111",
                Telefono = "222222",
                ClienteId = 1
            };
            Assert.Equal(1, cliente.Id);
            Assert.Equal("Daniel Ramirez", cliente.Nombre);
            Assert.Equal(Genero.Masculino, cliente.Genero);
            Assert.Equal(25, cliente.Edad);
            Assert.Equal("1111111", cliente.Identificacion);
            Assert.Equal("cr 83 145 Bogota", cliente.Direccion);
            Assert.Equal("222222", cliente.Telefono);
        }


        [Fact]
        public void Cliente_Debe_Validar_Existencia_De_Contraseña()
        {
            var cliente = new Cliente
            {
                Id = 1,
                Nombre = "Daniel Ramirez",
                Genero = Genero.Masculino,
                Direccion = "cr 83 145 Bogota",
                Edad = 25,
                Estado = true,
                Identificacion = "1111111",
                Telefono = "222222",
                ClienteId = 1
            };

            var exception = Assert.Throws<ArgumentException>(() => cliente.Contraseña = null);
            Assert.Equal("el cliente debe tener contraseña", exception.Message);
        }

    }

}