using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProgramacionPagoDTO
    {
        public ProgramacionPagoDTO()
        {
            // TODO
        }
        public int ProgramacionPagoId { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Valor { get; set; }
        public string Estado { get; set; }

        public int ProyectoId { get; set; }
        
        public int FacturaId { get; set; }
    }
}
