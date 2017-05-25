using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Moq;
using DAL.Infrastructure;
using System.Data.Entity;

namespace BLL.Tests
{
    [TestClass()]
    public class MunicipioBLLTests
    {

        MunicipioBLL servicio;
        public MunicipioBLLTests()
        {
            var lista = new List<Municipio>
            {
            new Municipio()
                {
                    MunicipioId=1,
                    Nombre = "Valledupar",
                    DepartamentoId=20,
                },
                new Municipio()
                {
                    MunicipioId=2,
                    Nombre = "La paz",
                    DepartamentoId=20,
                },
                new Municipio()
                {
                    MunicipioId=3,
                    Nombre = "Otro",
                    DepartamentoId=20,
                },
            };
            var dbContext = new Mock<ApplicationDbContext>();
            var data = lista.AsQueryable();

            var mockSet = new Mock<DbSet<Municipio>>();
            mockSet.As<IQueryable<Municipio>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Municipio>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Municipio>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Municipio>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Municipios).Returns(mockSet.Object);

            servicio = new MunicipioBLL(mockContext.Object);
        }


        [TestMethod()]
        public void GetMunicipiosByDepartamentoIdTest()
        {
            var respuesta = servicio.GetMunicipiosByDepartamentoId(20001);
            Assert.IsNotNull(respuesta);
        }
    }
}