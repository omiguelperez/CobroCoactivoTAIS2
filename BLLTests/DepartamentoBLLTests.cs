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
    public class DepartamentoBLLTests
    {

        DepartamentoBLL servicio;
        public DepartamentoBLLTests()
        {
            var lista = new List<Departamento>
            {
            new Departamento()
                {
                    DepartamentoId=1,
                    Nombre = "Cesar",
                    PaisId=1,
                },
                new Departamento()
                {
                    DepartamentoId=2,
                    Nombre = "Atlantico",
                    PaisId=1,
                },
                new Departamento()
                {
                    DepartamentoId=3,
                    Nombre = "Otro",
                    PaisId=1,
                },
            };
            var dbContext = new Mock<ApplicationDbContext>();
            var data = lista.AsQueryable();

            var mockSet = new Mock<DbSet<Departamento>>();
            mockSet.As<IQueryable<Departamento>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Departamento>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Departamento>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Departamento>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Departamentos).Returns(mockSet.Object);

            servicio = new DepartamentoBLL(mockContext.Object);
        }

        [TestMethod()]
        public void GetDepartamentosByPaisIdTest()
        {
            var respuesta = servicio.GetDepartamentosByPaisId(1);
            Assert.IsNotNull(respuesta);
        }
    }
}