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
        ExpedienteBLL servicio;
        public ExpedienteBLLTests()
        {
            var lista = new List<Expediente>
            {
            new Expediente()
                {
                    ExpedienteId=1,
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
                    ExpedienteId=2,
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
                    ExpedienteId=3,
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
            };
            var dbContext = new Mock<ApplicationDbContext>();
            var data = lista.AsQueryable();

            var mockSet = new Mock<DbSet<Expediente>>();
            mockSet.As<IQueryable<Expediente>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Expediente>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Expediente>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Expediente>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Expedientes).Returns(mockSet.Object);

            servicio = new ExpedienteBLL(mockContext.Object);
        }

        [TestMethod()]
        public void GetExpedientesTest()
        {
            var response = servicio.GetExpedientes();
            Assert.IsNotNull(response);
        }

        [TestMethod()]
        public void FindExpedienteByIdTest()
        {
            var response = servicio.FindExpedienteById(1);
            Assert.IsNotNull(response);
        }
    }
}