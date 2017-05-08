﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class ObligacionBLLTests
    {
        [TestMethod()]
        public void FindObligacionByIdTest()
        {
            ObligacionBLL bll = new ObligacionBLL();
            var response = bll.FindObligacionById(1);
            //Assert.AreNotEqual(19, response.ExpedienteId );
            Assert.IsNotNull(response);
        }
        [TestMethod()]
        public void InsertarObligacionTest()
        {
            ObligacionDTO Obligacion = new ObligacionDTO
            {
                Cuantia = 525000,
                Dueda = 525000,
                Estado = "Por autorizar",
                FechaPreinscripcion = new DateTime(2017, 03, 09),
                TipoObligacionId = 1,
                Persona = new PersonaDTO()
                {
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
                    Municipio = "Pueblo Bello",
                    FechaNacimiento = new DateTime(1996, 07, 30),
                    TipoPersonaId = 1,
                    Telefono = "31868754"
                },
                Expediente = new ExpedienteDTO()
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
                }
            };
            // ExpedienteBLL bll = new ExpedienteBLL();
            ObligacionBLL bll = new ObligacionBLL();
            var response = bll.InsertarObligacion(Obligacion);
            Assert.AreEqual(false, response.Error);
        }

        [TestMethod()]
        public void GetObligacionesTest()
        {
            ObligacionBLL bll = new ObligacionBLL();
            var response = bll.GetObligaciones();
            //Assert.AreNotEqual(19, response.ExpedienteId );
            Assert.IsNotNull(response);
        }
    }
}