//using Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Http;

//namespace AspNetIdentity.Controllers
//{
//    [RoutePrefix("api/expedientes")]
//    public class ExpedienteController : ApiController
//    {
//        //[Authorize]
//        [Route("")]
//        public Respuesta PostProyecto(ExpedienteDTO ExpedienteDTO)
//        {
//            ExpedienteBLL expediente = new ExpedienteBLL();
//            return expediente.Insertar(ExpedienteDTO);
//        }
//        [Authorize]
//        [Route("")]
//        public List<ExpedienteDTO> GetProyectos()
//        {
//            ExpedienteBLL expediente = new ExpedienteBLL();
//            return expediente.GetRecords();
//        }
//        [Authorize]
//        [Route("")]
//        public Respuesta PutProyecto(ExpedienteDTO ExpedienteDTO)
//        {
//            ExpedienteBLL expediente = new ExpedienteBLL();
//            return expediente.PutProyecto(ExpedienteDTO);
//        }
//        [Authorize]
//        [Route("")]
//        public Respuesta DeleteProyecto(ExpedienteDTO ExpedienteDTO)
//        {
//            ExpedienteBLL expediente = new ExpedienteBLL();
//            return expediente.DeleteProyecto(ExpedienteDTO);
//        }
//    }
//}