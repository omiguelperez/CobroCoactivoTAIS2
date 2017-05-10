using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public partial class MunicipioDTO{
        public MunicipioDTO()
        {
            Personas = new List<PersonaDTO>();
        }
        public int MunicipioId { get; set; }
        public string Nombre { get; set; }
        public int DepartamentoId { get; set; }
        public virtual DepartamentoDTO Departamento { get; set; }
        public virtual List<PersonaDTO> Personas { get; set; }
    }
}
