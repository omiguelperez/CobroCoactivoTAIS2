using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AspNetIdentity.Controllers
{
    [RoutePrefix("api/departamentos")]
    public class DepartamentoController : ApiController
    {
        
        //[Authorize]
        [Route("{PaisId}")]
        public List<DepartamentoDTO> GetDepartamentos(int PaisId)
        {
            DepartamentoBLL Departamentoes = new DepartamentoBLL();
            return Departamentoes.GetDepartamentosByPaisId(PaisId);
        }
    }
}