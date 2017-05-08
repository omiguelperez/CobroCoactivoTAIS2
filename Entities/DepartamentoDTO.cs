using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public partial class DepartamentoDTO{
        public DepartamentoDTO()
        {
            Municipios = new List<MunicipioDTO>();
        }
        public int DepartamentoId { get; set; }
        public string Nombre { get; set; }
        public int PaisId { get; set; }
        public virtual PaisDTO Pais { get; set; }
        public virtual List<MunicipioDTO> Municipios { get; set; }
    }
}
