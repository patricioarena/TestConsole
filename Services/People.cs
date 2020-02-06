using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.Services
{
    public class Persona
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }
        public int Legajo { get; set; }
        public string TipoDocumento { get; set; }
        public int NroDocumento { get; set; }
    }
    public interface IPeople
    {
        Persona GetPersonByKey(int index);
        Persona GetPersonByLegajo(int index);
        Dictionary<int, Persona> Dictionary();
    }
    public class People : IPeople
    {
        private readonly new Dictionary<int, Persona> Personas = new Dictionary<int, Persona>()
        {
            [100] = new Persona { Id = Guid.NewGuid(), Nombre = "Alice", Apellido = "Cooper", Cargo = "Cantante", Legajo = 100, TipoDocumento = "DNI", NroDocumento = 33688100 },
            [101] = new Persona { Id = Guid.NewGuid(), Nombre = "Maria Sasha", Apellido = "Reyes", Cargo = "Secretaria", Legajo = 101, TipoDocumento = "DNI", NroDocumento = 33688101 },
            [102] = new Persona { Id = Guid.NewGuid(), Nombre = "Pedro", Apellido = "Palmeira", Cargo = "Develop", Legajo = 102, TipoDocumento = "DNI", NroDocumento = 33688102 },
            [103] = new Persona { Id = Guid.NewGuid(), Nombre = "Pablo", Apellido = "Sanchez", Cargo = "Abogado", Legajo = 103, TipoDocumento = "DNI", NroDocumento = 33688103 },
            [104] = new Persona { Id = Guid.NewGuid(), Nombre = "Ricardo", Apellido = "Aguilar", Cargo = "Chofer", Legajo = 104, TipoDocumento = "DNI", NroDocumento = 33688104 },
            [105] = new Persona { Id = Guid.NewGuid(), Nombre = "Angel", Apellido = "Diaz", Cargo = "Chofer", Legajo = 105, TipoDocumento = "DNI", NroDocumento = 33688105 },
            [106] = new Persona { Id = Guid.NewGuid(), Nombre = "Leonardo", Apellido = "Romero", Cargo = "Abogado", Legajo = 106, TipoDocumento = "DNI", NroDocumento = 33688106 },
            [107] = new Persona { Id = Guid.NewGuid(), Nombre = "Romina Laura Isabel", Apellido = "Sanchez", Cargo = "Abogada", Legajo = 107, TipoDocumento = "DNI", NroDocumento = 33688107 },
            [108] = new Persona { Id = Guid.NewGuid(), Nombre = "Hector", Apellido = "Garcia", Cargo = "Chofer", Legajo = 108, TipoDocumento = "DNI", NroDocumento = 33688108 },
            [109] = new Persona { Id = Guid.NewGuid(), Nombre = "Mariana", Apellido = "Cosi", Cargo = "Develop", Legajo = 109, TipoDocumento = "DNI", NroDocumento = 33688109 },
            [110] = new Persona { Id = Guid.NewGuid(), Nombre = "Juan Manuel", Apellido = "Rojas", Cargo = "Develop", Legajo = 110, TipoDocumento = "DNI", NroDocumento = 33688110 },
        };

        public People() { }

        public Persona GetPersonByKey(int index)
        {
            return Personas[index];
        }

        public Persona GetPersonByLegajo(int legajo)
        {
            return Personas.Where(e => e.Value.Legajo == legajo).FirstOrDefault().Value;
        }

        public Dictionary<int, Persona> Dictionary()
        {
            return Personas;
        }
    }
}
