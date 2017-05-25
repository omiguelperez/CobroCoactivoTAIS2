using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Data.Entity;
using DAL;
using DAL.Infrastructure;

namespace BLL.Tests
{
    [TestClass()]
    public class TipoCobroBLLTests
    {

        TipoCobroBLL servicio;
        Mock<DbSet<TipoCobro>> mockSet;
        Mock<ApplicationDbContext> mockContext;
        public TipoCobroBLLTests()
        {
            var lista = new List<TipoCobro>
            {
            new TipoCobro()
                {
                    TipoCobroId=1,
                    Nombre = "Colombia",
                },
                new TipoCobro()
                {
                    TipoCobroId=2,
                    Nombre = "Venezuela",
                }
            };
            var data = lista.AsQueryable();

            mockSet = new Mock<DbSet<TipoCobro>>();
            mockSet.As<IQueryable<TipoCobro>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<TipoCobro>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<TipoCobro>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<TipoCobro>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.TiposCobros).Returns(mockSet.Object);

            servicio = new TipoCobroBLL(mockContext.Object);
        }

        [TestMethod()]
        public void GetTiposCobrosTest()
        {
            var response = servicio.GetTiposCobros();
            Assert.IsNotNull(response);
        }
    }
}