using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AspNetIdentity.Controllers
{
    [RoutePrefix("api/tiposobligaciones")]
    public class TipoObligacionController : ApiController
    {
        
        //[Authorize]
        [Route("")]
        public List<TipoObligacionDTO> GetTipoObligaciones()
        {
            TipoObligacionBLL tipoobligaciones = new TipoObligacionBLL();
            return tipoobligaciones.GetTipoObligaciones();
        }
    }
}