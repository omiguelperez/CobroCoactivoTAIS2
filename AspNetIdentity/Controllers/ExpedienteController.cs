using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AspNetIdentity.Controllers
{
    [RoutePrefix("api/expedientes")]
    public class ExpedienteController : ApiController
    {
        //[Authorize] para cuestion de pruebas esta api puede ser accedida sin estar autenticado
        //[Route("")]
        //public Respuesta PostProyecto(ExpedienteDTO ExpedienteDTO)
        //{
        //    Respuesta response = new Respuesta();
        //    //if (ExpedienteDTO.Identificacion.Equals(ExpedienteDTO.Obligacion.Persona.Identificacion))
        //    //{
        //        ExpedienteBLL expediente = new ExpedienteBLL();
        //        response=expediente.Insertar(ExpedienteDTO);
        //    //}
        //    //else
        //    //{
        //    //    response.Mensaje = "La Identificacion del Expediente no Coincide con la Identificacion de la Persona.";
        //    //    response.Error = true;
        //   //     response.FilasAfectadas = 0;
        //   // }
        //    return response;
        //}
        //[Authorize]
        [Route("")]
        public List<ExpedienteDTO> GetExpedientes()
        {
            ExpedienteBLL expediente = new ExpedienteBLL();
            return expediente.GetExpedientes();
        }
        //[Authorize]
        //[Route("")]
        //public Respuesta PutProyecto(ExpedienteDTO ExpedienteDTO)
        //{
        //    ExpedienteBLL expediente = new ExpedienteBLL();
        //    return expediente.PutProyecto(ExpedienteDTO);
        //}
        //[Authorize]
        //[Route("")]
        //public Respuesta DeleteProyecto(ExpedienteDTO ExpedienteDTO)
        //{
        //    ExpedienteBLL expediente = new ExpedienteBLL();
        //    return expediente.DeleteProyecto(ExpedienteDTO);
        //}
    }
}