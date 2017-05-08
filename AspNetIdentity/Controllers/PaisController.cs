using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AspNetIdentity.Controllers
{
    [RoutePrefix("api/paises")]
    public class PaisController : ApiController
    {
        
        //[Authorize]
        [Route("")]
        public List<PaisDTO> GetPaises()
        {
            PaisBLL Paises = new PaisBLL();
            return Paises.GetPaises();
        }
    }
}