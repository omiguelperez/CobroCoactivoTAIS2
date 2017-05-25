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
    public class TipoObligacionBLLTests
    {
        TipoObligacionBLL servicio;
        Mock<DbSet<TipoObligacion>> mockSet;
        Mock<ApplicationDbContext> mockContext;
        public TipoObligacionBLLTests()
        {
            var lista = new List<TipoObligacion>
            {
            new TipoObligacion()
                {
                    TipoObligacionId=1,
                    Nombre = "Colombia",
                },
                new TipoObligacion()
                {
                    TipoObligacionId=2,
                    Nombre = "Venezuela",
                }
            };
            var data = lista.AsQueryable();

            mockSet = new Mock<DbSet<TipoObligacion>>();
            mockSet.As<IQueryable<TipoObligacion>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<TipoObligacion>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<TipoObligacion>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<TipoObligacion>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.TiposObligaciones).Returns(mockSet.Object);

            servicio = new TipoObligacionBLL(mockContext.Object);
        }

        [TestMethod()]
        public void GetTipoObligacionesTest()
        {
            var response = servicio.GetTipoObligaciones();
            Assert.IsNotNull(response);
        }
    }
}