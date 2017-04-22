using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AspNetIdentity.Controllers
{
    [RoutePrefix("api/tiposcobros")]
    public class TipoCobroController : ApiController
    {
        
        //[Authorize]
        [Route("")]
        public List<TipoCobroDTO> GetTipoCobros()
        {
            TipoCobroBLL tipoCobroes = new TipoCobroBLL();
            return tipoCobroes.GetRecords();
        }
    }
}