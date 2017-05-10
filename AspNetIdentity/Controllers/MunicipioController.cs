using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AspNetIdentity.Controllers
{
    [RoutePrefix("api/municipios")]
    public class MunicipioController : ApiController
    {
        
        //[Authorize]
        [Route("{DepartamentoId}")]
        public List<MunicipioDTO> GetMunicipios(int DepartamentoId)
        {
            MunicipioBLL Municipioes = new MunicipioBLL();
            return Municipioes.GetMunicipiosByDepartamentoId(DepartamentoId);
        }
    }
}