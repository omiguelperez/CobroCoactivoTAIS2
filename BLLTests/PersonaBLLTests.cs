using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.Entity;
using Moq;
using DAL.Infrastructure;
using DAL;

namespace BLL.Tests
{
    [TestClass()]
    public class PersonaBLLTests
    {
        PersonaBLL servicio;
        Mock<DbSet<Persona>> mockSet;
        Mock<ApplicationDbContext> mockContext;
        public PersonaBLLTests()
        {
            var lista = new List<Persona>
            {
            new Persona()
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
                    MunicipioId = 20001,
                    PaisId = 1,
                    FechaNacimiento = new DateTime(1996, 07, 30),
                    TipoPersonaId = 1,
                    Telefono = "31868754",
                    Pais=new Pais()
                    {
                        PaisId=1,
                        Nombre="Colombia",
                    },
                    Municipio=new Municipio()
                    {
                        MunicipioId=1,
                        Nombre="Valledupar",
                    },
                    TipoPersona=new TipoPersona()
                    {
                        TipoPersonaId=1,
                        Nombre="pedro"
                    },
                },
                new Persona()
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
                    MunicipioId = 20001,
                    PaisId = 1,
                    FechaNacimiento = new DateTime(1996, 07, 30),
                    TipoPersonaId = 1,
                    Telefono = "31868754",
                    Pais=new Pais()
                    {
                        PaisId=1,
                        Nombre="Colombia",
                    },
                    Municipio=new Municipio()
                    {
                        MunicipioId=1,
                        Nombre="Valledupar",
                    },
                    TipoPersona=new TipoPersona()
                    {
                        TipoPersonaId=1,
                        Nombre="pedro"
                    },
                }
            };
            var data = lista.AsQueryable();

            mockSet = new Mock<DbSet<Persona>>();
            mockSet.As<IQueryable<Persona>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Persona>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Persona>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Persona>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Personas).Returns(mockSet.Object);

            servicio = new PersonaBLL(mockContext.Object);
        }

        [TestMethod()]
        public void FindPersonaByIdentificacionTest()
        {
            Assert.IsNotNull(servicio.FindPersonaByIdentificacion("1065824563"));
        }

        [TestMethod()]
        public void InsertarPersonaTest()
        {
            PersonaDTO persona = new PersonaDTO()
            {
                Apellidos = "Mindiola",
                Direccion = "Carrera 13 # 36 - 111",
                Identificacion = "1005824563",
                Nombres = "Maira mindiola",
                Sexo = "F",
                Email = "anibaljose.14@hotmail.com",
                Nacionalidad = "Colombia",
                PaisNacimiento = "Colombia",
                PaisCorrespondencia = "Colombia",
                Departamento = "Cesar",
                MunicipioId = 20001,
                PaisId = 1,
                FechaNacimiento = new DateTime(1996, 07, 30),
                TipoPersonaId = 1,
                Telefono = "31868754",
                Pais=new PaisDTO()
                {
                    PaisId=1,
                    Nombre="Colombia",
                },
                Municipio=new MunicipioDTO()
                {
                    MunicipioId=1,
                    Nombre="Valledupar",
                },
                TipoPersona=new TipoPersonaDTO()
                {
                    TipoPersonaId=1,
                    Nombre="pedro"
                }
            };
            Assert.AreEqual(false, servicio.InsertarPersona(persona).Error);
        }

        [TestMethod()]
        public void FindPersonaByIdTest()
        {
            var respuesta = servicio.FindPersonaById(1);
            Assert.IsNotNull(respuesta);
        }
    }
}