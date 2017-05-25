using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL.Tests
{
    [TestClass()]
    public class DocumentoBLLTests
    {
        [DeploymentItem("Recursos")]
        [TestMethod()]
        public void GetDocumentsByExpedienteTest()
        {
            DocumentoBLL obj = new DocumentoBLL();
            var lista = obj.GetDocumentsByExpediente("localhost/api/documento/", 1);
            Assert.IsNotNull(lista);
        }

        //[TestMethod()]
        //public void InsertarDocumentoTest()
        //{
        //    DocumentoDTO documento = new DocumentoDTO
        //    {
        //        Estado = "Pendiente",
        //        ExpedienteId = 1,
        //        FechaDocumento = new DateTime(2011, 07, 30),
        //        FechaEntrega= new DateTime(1996, 07, 30),
        //        FechaRadicacion= new DateTime(1996, 07, 30),
        //        FechaRecepcion= new DateTime(1996, 07, 30),
        //        FuncionarioEntrega= "Anibal",
        //        FuncionarioRecibe="Miguel",
        //        OficinaOrigen="UPC",
        //        Remitente="Anibal",
        //        RutaDocumento="Files/Images/algunaimagen.jpg",
        //        TipoArchivo="Imagen",
        //        TipoDocumentoId=1,
        //    };
        //    // ExpedienteBLL bll = new ExpedienteBLL();
        //    DocumentoBLL bll = new DocumentoBLL();
        //    var response = bll.InsertarDocumento(documento);
        //    Assert.AreEqual(false, response.Error);
        //}
    }
}