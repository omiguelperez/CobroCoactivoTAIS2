using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public partial class PaisDTO{
        public PaisDTO()
        {
            Departamentos = new List<DepartamentoDTO>();
        }
        public int PaisId { get; set; }
        public string Nombre { get; set; }
        public virtual List<DepartamentoDTO> Departamentos { get; set; }
    }
}
