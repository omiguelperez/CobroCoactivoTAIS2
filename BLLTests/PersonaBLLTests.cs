using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL.Tests
{
    [TestClass()]
    public class PersonaBLLTests
    {
        [TestMethod()]
        public void FindPersonaByIdentificacionTest()
        {
            PersonaBLL bllpersona = new PersonaBLL();
            Assert.IsNotNull(bllpersona.FindPersonaByIdentificacion("1065824563"));
        }

        [TestMethod()]
        public void InsertarPersonaTest()
        {
            PersonaDTO persona = new PersonaDTO()
            {
                Apellidos = "Lider Proyecto",
                Direccion = "Carrera 13 # 36 - 111",
                Identificacion = "10253652141",
                Nombres = "Soy",
                Sexo = "F",
                Email = "soyellider.14@hotmail.com",
                Nacionalidad = "Colombia",
                PaisNacimiento = "Colombia",
                PaisCorrespondencia = "Colombia",
                Departamento = "Cesar",
                MunicipioId = 68020,
                PaisId = 1,
                FechaNacimiento = new DateTime(1996, 07, 30),
                TipoPersonaId = 1,
                Telefono = "31868754",
            };
            PersonaBLL personbll = new PersonaBLL();
            Assert.AreEqual(false, personbll.InsertarPersona(persona).Error);
        }

        [TestMethod()]
        public void FindPersonaByIdTest()
        {
            PersonaBLL bllpersona = new PersonaBLL();
            var respuesta = bllpersona.FindPersonaById(1);
            Assert.IsNotNull(respuesta);
        }
    }
}