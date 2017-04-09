using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Threading.Tasks;

namespace AspNetIdentity.Controllers
{
    [RoutePrefix("api/facturas")]
    public class FacturaController : ApiController
    {
        [Route("")]
        public Respuesta PostFactura(FacturaDTO facturaDTO)
        {
            FacturaBLL factura = new FacturaBLL();
            return factura.Insertar(facturaDTO);
        }

        [Route("")]
        public List<FacturaDTO> GetFacturas()
        {
            FacturaBLL factura = new FacturaBLL();
            return factura.GetRecords();
        }

        [Route("")]
        public Respuesta PutFactura(FacturaDTO facturaDTO)
        {
            FacturaBLL factura = new FacturaBLL();
            return factura.UpdateFactura(facturaDTO);
        }

        [Route("")]
        public Respuesta DeleteFactura(FacturaDTO facturaDTO)
        {
            FacturaBLL factura = new FacturaBLL();
            return factura.DeleteFactura(facturaDTO);
        }
    }
}