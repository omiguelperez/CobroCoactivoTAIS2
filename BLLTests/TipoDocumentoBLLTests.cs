using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data.Entity;
using Moq;
using DAL.Infrastructure;

namespace BLL.Tests
{
    [TestClass()]
    public class TipoDocumentoBLLTests
    {
        TipoDocumentoBLL servicio;
        Mock<DbSet<TipoDocumento>> mockSet;
        Mock<ApplicationDbContext> mockContext;
        public TipoDocumentoBLLTests()
        {
            var lista = new List<TipoDocumento>
            {
            new TipoDocumento()
                {
                    TipoDocumentoId=1,
                    Nombre = "Colombia",
                },
                new TipoDocumento()
                {
                    TipoDocumentoId=2,
                    Nombre = "Venezuela",
                }
            };
            var data = lista.AsQueryable();

            mockSet = new Mock<DbSet<TipoDocumento>>();
            mockSet.As<IQueryable<TipoDocumento>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<TipoDocumento>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<TipoDocumento>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<TipoDocumento>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.TiposDocumentos).Returns(mockSet.Object);

            servicio = new TipoDocumentoBLL(mockContext.Object);
        }


        [TestMethod()]
        public void GetTipoDocumentosTest()
        {
            var response = servicio.GetTipoDocumentos();
            Assert.IsNotNull(response);
        }
    }
}