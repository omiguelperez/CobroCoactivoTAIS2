using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Moq;
using System.Data.Entity;
using DAL.Infrastructure;

namespace BLL.Tests
{
    [TestClass()]
    public class PaisBLLTests
    {
        PaisBLL servicio;
        Mock<DbSet<Pais>> mockSet;
        Mock<ApplicationDbContext> mockContext;
        public PaisBLLTests()
        {
            var lista = new List<Pais>
            {
            new Pais()
                {
                    PaisId=1,
                    Nombre = "Colombia",                    
                },
                new Pais()
                {
                    PaisId=2,
                    Nombre = "Venezuela",
                }
            };
            var data = lista.AsQueryable();

            mockSet = new Mock<DbSet<Pais>>();
            mockSet.As<IQueryable<Pais>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Pais>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Pais>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Pais>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Paises).Returns(mockSet.Object);

            servicio = new PaisBLL(mockContext.Object);
        }


        [TestMethod()]
        public void GetPaisesTest()
        {
            var respuesta = servicio.GetPaises();
            Assert.IsNotNull(respuesta);
        }
    }
}