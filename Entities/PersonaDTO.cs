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
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public virtual List<ObligacionDTO> Obligaciones { get; set; }
    }
}
