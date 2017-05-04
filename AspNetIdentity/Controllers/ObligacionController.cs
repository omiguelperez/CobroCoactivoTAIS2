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
        [Route("")]
        public Respuesta PostObligacion(ObligacionDTO ObligacionDTO)
        {
            Respuesta response = new Respuesta();
            if (ObligacionDTO.Expediente.Identificacion.Equals(ObligacionDTO.Persona.Identificacion))
            {
                ObligacionBLL Obligacion = new ObligacionBLL();
                response = Obligacion.InsertarObligacion(ObligacionDTO);
            }
            else
            {
                response.Mensaje = "La Identificacion del expediente no Coincide con la Identificacion de la Persona.";
                response.Error = true;
                response.FilasAfectadas = 0;
            }
            return response;
        }
        //[Authorize]
        [Route("")]
        public List<ObligacionDTO> GetObligaciones()
        {
            ObligacionBLL Obligacion = new ObligacionBLL();
            return Obligacion.GetObligaciones();
        }
    }
}