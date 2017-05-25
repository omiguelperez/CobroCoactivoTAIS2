using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;
using DAL.Infrastructure;
using Moq;
using System.Data.Entity;

namespace BLL.Tests
{
    [TestClass()]
    public class DocumentoBLLTests
    {
        DocumentoBLL servicio;
        public DocumentoBLLTests()
        {
            var lista = new List<Documento>
            {
            new Documento()
                {
                    DocumentoId=1,
                    Estado="Pendiente",
                    ExpedienteId=1,
                    FechaDocumento = new DateTime(2017, 03, 19),
                    FechaEntrega = new DateTime(2017, 03, 19),
                    FechaRadicacion = new DateTime(2017, 03, 19),
                    FechaRecepcion = new DateTime(2017, 03, 19),
                    FuncionarioEntrega="Anibal",
                    FuncionarioRecibe="Edro",
                    OficinaOrigen="Nose",
                    Remitente="alguiqn",
                    RutaDocumento="Images/df",
                    TipoArchivo=".jpbg",
                    TipoDocumentoId=1,
                },
                 new Documento()
                {
                    DocumentoId=2,
                    Estado="Pendiente",
                    ExpedienteId=1,
                    FechaDocumento = new DateTime(2017, 03, 19),
                    FechaEntrega = new DateTime(2017, 03, 19),
                    FechaRadicacion = new DateTime(2017, 03, 19),
                    FechaRecepcion = new DateTime(2017, 03, 19),
                    FuncionarioEntrega="Anibal",
                    FuncionarioRecibe="Edro",
                    OficinaOrigen="Nose",
                    Remitente="alguiqn",
                    RutaDocumento="Images/df",
                    TipoArchivo=".jpbg",
                    TipoDocumentoId=1,
                },
                new Documento()
                {
                    DocumentoId=3,
                    Estado="Pendiente",
                    ExpedienteId=1,
                    FechaDocumento = new DateTime(2017, 03, 19),
                    FechaEntrega = new DateTime(2017, 03, 19),
                    FechaRadicacion = new DateTime(2017, 03, 19),
                    FechaRecepcion = new DateTime(2017, 03, 19),
                    FuncionarioEntrega="Anibal",
                    FuncionarioRecibe="Edro",
                    OficinaOrigen="Nose",
                    Remitente="alguiqn",
                    RutaDocumento="Images/df",
                    TipoArchivo=".jpbg",
                    TipoDocumentoId=1,
                },
            };
            var dbContext = new Mock<ApplicationDbContext>();
            var data = lista.AsQueryable();

            var mockSet = new Mock<DbSet<Documento>>();
            mockSet.As<IQueryable<Documento>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Documento>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Documento>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Documento>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Documentos).Returns(mockSet.Object);

            servicio = new DocumentoBLL(mockContext.Object);
        }

        [TestMethod()]
        public void GetDocumentsByExpedienteTest()
        {
            var lista = servicio.GetDocumentsByExpediente("localhost/api/documento/", 1);
            
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