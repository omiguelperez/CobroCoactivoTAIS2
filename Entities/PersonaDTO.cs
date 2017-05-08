using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PersonaDTO
    {
        public PersonaDTO()
        {
            Obligaciones = new List<ObligacionDTO>();
        }
        public int PersonaId { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int TipoPersonaId { get; set; }
        public virtual TipoPersonaDTO TipoPersona { get; set; }
        public string Nacionalidad { get; set; }
        public string PaisNacimiento { get; set; }
        public int PaisId { get; set; }
        public virtual PaisDTO Pais { get; set; }
        public string PaisCorrespondencia { get; set; }
        public string Departamento { get; set; }
        public int MunicipioId { get; set; }
        public virtual MunicipioDTO Municipio { get; set; }
        //public string Municipio { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public virtual List<ObligacionDTO> Obligaciones { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second); } }
    }
}
