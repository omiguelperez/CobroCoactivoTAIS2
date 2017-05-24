using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Data.Entity;
using Moq;
using DAL;
using DAL.Infrastructure;

namespace BLL.Tests
{
    [TestClass()]
    public class ExpedienteBLLTests
    {
        [TestMethod()]
        public void GetExpedientesTest()
        {
            var dbContext = new Mock<ApplicationDbContext>();
            var data = new List<Expediente>
            {
            new Expediente()
                {
                    Cuantia = 525000,
                    Descripcion = "Esto es una descripcion",
                    DireccionEjecutado = "Esto es una direccion",
                    DireccionTituloEjecutivo = "Esto es una direcciond e titulo ejecutivo",
                    EntidadEncargada = "Entidad encargada es maira",
                    FechaRadicacion = new DateTime(2017, 03, 19),
                    Identificacion = "1065824563",
                    NaturalezaObligacion = "Naturaleza es algo",
                    Nombre = "Maira mindiola",
                    UbicacionExpediente = "Esta en el lote tal",
                },
                new Expediente()
                {
                    Cuantia = 525000,
                    Descripcion = "Esto es una descripcion",
                    DireccionEjecutado = "Esto es una direccion",
                    DireccionTituloEjecutivo = "Esto es una direcciond e titulo ejecutivo",
                    EntidadEncargada = "Entidad encargada es maira",
                    FechaRadicacion = new DateTime(2017, 03, 19),
                    Identificacion = "1065824563",
                    NaturalezaObligacion = "Naturaleza es algo",
                    Nombre = "Maira mindiola",
                    UbicacionExpediente = "Esta en el lote tal",
                },
                new Expediente()
                {
                    Cuantia = 555000,
                    Descripcion = "Esto es una descripcion",
                    DireccionEjecutado = "Esto es una direccion",
                    DireccionTituloEjecutivo = "Esto es una direcciond e titulo ejecutivo",
                    EntidadEncargada = "Entidad encargada es maira",
                    FechaRadicacion = new DateTime(2017, 03, 19),
                    Identificacion = "1065824563",
                    NaturalezaObligacion = "Naturaleza es algo",
                    Nombre = "Maira mindiola",
                    UbicacionExpediente = "Esta en el lote tal",
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Expediente>>();
            mockSet.As<IQueryable<Expediente>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Expediente>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Expediente>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Expediente>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Expedientes).Returns(mockSet.Object);

            var service = new ExpedienteBLL(mockContext.Object);

            //Assert.AreEqual(3, blogs.Count);
            //Assert.AreEqual("AAA", blogs[0].Name);
            //Assert.AreEqual("BBB", blogs[1].Name);
            //Assert.AreEqual("ZZZ", blogs[2].Name);
            //ExpedienteBLL bll = new ExpedienteBLL();
            var response = service.GetExpedientes();
            Assert.IsNotNull(response);
        }

        [TestMethod()]
        public void FindExpedienteByIdTest()
        {
            ExpedienteBLL bll = new ExpedienteBLL();
            var response = bll.FindExpedienteById(1);
            Assert.IsNotNull(response);
        }
    }
}