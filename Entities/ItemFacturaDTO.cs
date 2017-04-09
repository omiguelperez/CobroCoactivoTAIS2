using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ItemFacturaDTO
    {
        public ItemFacturaDTO()
        {
            // TODO
        }

        public int ItemFacturaId { get; set; }
        public string Descripcion { get; set; }
        public decimal Valor { get; set; }
        public int Cantidad { get; set; }
        public decimal Iva { get; set; }

        public int FacturaId { get; set; }
        public FacturaDTO Factura { get; set; }
    }
}
