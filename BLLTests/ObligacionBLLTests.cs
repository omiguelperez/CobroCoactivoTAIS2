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
    public class ObligacionBLLTests
    {
        ObligacionBLL servicio;
        Mock<DbSet<Obligacion>> mockSet;
        Mock<ApplicationDbContext> mockContext;
        public ObligacionBLLTests()
        {
            var lista = new List<Obligacion>
            {
            new Obligacion()
                {
                ObligacionId=1,
                Cuantia = 525000,
                Dueda = 525000,
                Estado = "Por autorizar",
                FechaPreinscripcion = new DateTime(2017, 03, 09),
                TipoObligacionId = 1,
                Persona = new Persona()
                {
                    PersonaId=1,
                    Apellidos = "Mindiola",
                    Direccion = "Carrera 13 # 36 - 111",
                    Identificacion = "1065824563",
                    Nombres = "Maira mindiola",
                    Sexo = "F",
                    Email = "anibaljose.14@hotmail.com",
                    Nacionalidad = "Colombia",
                    PaisNacimiento = "Colombia",
                    PaisCorrespondencia = "Colombia",
                    Departamento = "Cesar",
                    MunicipioId=20001,
                    PaisId=1,
                    FechaNacimiento = new DateTime(1996, 07, 30),
                    TipoPersonaId = 1,
                    Telefono = "31868754"
                },
                Expediente = new Expediente()
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
                }
                },
                new Obligacion()
                {
                ObligacionId=2,
                Cuantia = 525000,
                Dueda = 525000,
                Estado = "Por autorizar",
                FechaPreinscripcion = new DateTime(2017, 03, 09),
                TipoObligacionId = 1,
                Persona = new Persona()
                {
                    PersonaId=2,
                    Apellidos = "Mindiola",
                    Direccion = "Carrera 13 # 36 - 111",
                    Identificacion = "1065824563",
                    Nombres = "Maira mindiola",
                    Sexo = "F",
                    Email = "anibaljose.14@hotmail.com",
                    Nacionalidad = "Colombia",
                    PaisNacimiento = "Colombia",
                    PaisCorrespondencia = "Colombia",
                    Departamento = "Cesar",
                    MunicipioId=20001,
                    PaisId=1,
                    FechaNacimiento = new DateTime(1996, 07, 30),
                    TipoPersonaId = 1,
                    Telefono = "31868754"
                },
                Expediente = new Expediente()
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
                }
                },
               new Obligacion()
                {
                ObligacionId=3,
                Cuantia = 525000,
                Dueda = 525000,
                Estado = "Por autorizar",
                FechaPreinscripcion = new DateTime(2017, 03, 09),
                TipoObligacionId = 1,
                Persona = new Persona()
                {
                    PersonaId=3,
                    Apellidos = "Mindiola",
                    Direccion = "Carrera 13 # 36 - 111",
                    Identificacion = "1065824563",
                    Nombres = "Maira mindiola",
                    Sexo = "F",
                    Email = "anibaljose.14@hotmail.com",
                    Nacionalidad = "Colombia",
                    PaisNacimiento = "Colombia",
                    PaisCorrespondencia = "Colombia",
                    Departamento = "Cesar",
                    MunicipioId=20001,
                    PaisId=1,
                    FechaNacimiento = new DateTime(1996, 07, 30),
                    TipoPersonaId = 1,
                    Telefono = "31868754"
                },
                Expediente = new Expediente()
                {
                    ExpedienteId=3,
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
                }
                },
            };
            var data = lista.AsQueryable();

            mockSet = new Mock<DbSet<Obligacion>>();
            mockSet.As<IQueryable<Obligacion>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Obligacion>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Obligacion>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Obligacion>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Obligaciones).Returns(mockSet.Object);

            servicio = new ObligacionBLL(mockContext.Object);
        }


        [TestMethod()]
        public void FindObligacionByIdTest()
        {
            var response = servicio.FindObligacionById(1);
            Assert.IsNotNull(response);
        }

        //[TestMethod()]
        //public void InsertarObligacionTest()
        //{
        //    ObligacionDTO Obligacion = new ObligacionDTO
        //    {
        //        Cuantia = 525000,
        //        Dueda = 525000,
        //        Estado = "Por autorizar",
        //        FechaPreinscripcion = new DateTime(2017, 03, 09),
        //        TipoObligacionId = 1,
        //        Persona = new PersonaDTO()
        //        {
        //            Apellidos = "Mindiola",
        //            Direccion = "Carrera 13 # 36 - 111",
        //            Identificacion = "1065824523",
        //            Nombres = "Maira mindiola",
        //            Sexo = "F",
        //            Email = "anibaljose.14@hotmail.com",
        //            Nacionalidad = "Colombia",
        //            PaisNacimiento = "Colombia",
        //            PaisCorrespondencia = "Colombia",
        //            Departamento = "Cesar",
        //            MunicipioId=20001,
        //            PaisId=1,
        //            FechaNacimiento = new DateTime(1996, 07, 30),
        //            TipoPersonaId = 1,
        //            Telefono = "31868754"
        //        },
        //        Expediente = new ExpedienteDTO()
        //        {
        //            Cuantia = 525000,
        //            Descripcion = "Esto es una descripcion",
        //            DireccionEjecutado = "Esto es una direccion",
        //            DireccionTituloEjecutivo = "Esto es una direcciond e titulo ejecutivo",
        //            EntidadEncargada = "Entidad encargada es maira",
        //            FechaRadicacion = new DateTime(2017, 03, 19),
        //            Identificacion = "1065824563",
        //            NaturalezaObligacion = "Naturaleza es algo",
        //            Nombre = "Maira mindiola",
        //            UbicacionExpediente = "Esta en el lote tal",
        //        }
        //    };
        //    var response = servicio.InsertarObligacion(Obligacion);
        //    Assert.AreEqual(false, response.Error);
        //}

        [TestMethod()]
        public void GetObligacionesTest()
        {
            var response = servicio.GetObligaciones();
            //Assert.AreNotEqual(19, response.ExpedienteId );
            Assert.IsNotNull(response);
        }
    }
}