using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AspNetIdentity.Controllers
{
    [RoutePrefix("api/obligaciones")]
    public class ObligacionController : ApiController
    {
        //[Authorize] para cuestion de pruebas esta api puede ser accedida sin estar autenticado
        //[Route("")]
        //public Respuesta PostProyecto(ObligacionDTO ObligacionDTO)
        //{
        //    Respuesta response = new Respuesta();
        //    if (ObligacionDTO.Identificacion.Equals(ObligacionDTO.Obligacion.Persona.Identificacion))
        //    {
        //        ObligacionBLL Obligacion = new ObligacionBLL();
        //        response=Obligacion.Insertar(ObligacionDTO);
        //    }
        //    else
        //    {
        //        response.Mensaje = "La Identificacion del Obligacion no Coincide con la Identificacion de la Persona.";
        //        response.Error = true;
        //        response.FilasAfectadas = 0;
        //    }
        //    return response;
        //}
        //[Authorize]
        [Route("")]
        public List<ObligacionDTO> GetObligaciones()
        {
            ObligacionBLL Obligacion = new ObligacionBLL();
            return Obligacion.GetRecords();
        }
        //[Authorize]
        //[Route("")]
        //public Respuesta PutProyecto(ObligacionDTO ObligacionDTO)
        //{
        //    ObligacionBLL Obligacion = new ObligacionBLL();
        //    return Obligacion.PutProyecto(ObligacionDTO);
        //}
        //[Authorize]
        //[Route("")]
        //public Respuesta DeleteProyecto(ObligacionDTO ObligacionDTO)
        //{
        //    ObligacionBLL Obligacion = new ObligacionBLL();
        //    return Obligacion.DeleteProyecto(ObligacionDTO);
        //}
    }
}