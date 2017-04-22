using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AspNetIdentity.Controllers
{
    [RoutePrefix("api/tiposdocumentos")]
    public class TipoDocumentoController : ApiController
    {
        
        //[Authorize]
        [Route("")]
        public List<TipoDocumentoDTO> GetTipoDocumentos()
        {
            TipoDocumentoBLL tipodocumento = new TipoDocumentoBLL();
            return tipodocumento.GetRecords();
        }
    }
}