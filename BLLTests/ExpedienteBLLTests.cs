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
    public class ExpedienteBLLTests
    {
        [TestMethod()]
        public void GetRecordsTest()
        {
            ExpedienteBLL bll = new ExpedienteBLL();
            var response = bll.FindById(20);
            Assert.AreNotEqual(19, response.ExpedienteId );
        }
        [TestMethod()]
        public void InsertarTest()
        {

            ExpedienteDTO obj = new ExpedienteDTO();
            obj.Cuantia=525000;
            obj.Descripcion = "Esto es una descripcion";
            obj.DireccionEjecutado = "Esto es una direccion";
            obj.DireccionTituloEjecutivo = "Esto es una direcciond e titulo ejecutivo";
            obj.EntidadEncargada = "Entidad encargada es maira";
            obj.FechaRadicacion = new DateTime(2017, 03, 19);
            obj.Identificacion = "1065824563";
            obj.NaturalezaObligacion = "Naturaleza es algo";
            obj.Nombre = "Maira mindiola";
            obj.UbicacionExpediente = "Esta en el lote tal";
            obj.Obligacion = new ObligacionDTO
            {
                Cuantia = 525000,
                Dueda = 525000,
                Estado = "Por autorizar",
                FechaPreinscripcion = new DateTime(2017, 03, 09),
                TipoObligacionId = 1,
                Persona=new PersonaDTO(){
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
                    FechaNacimiento = new DateTime(1996,07,30),
                    TipoPersonaId =1,
                    Telefono = 31868754
                    }
            };
            ExpedienteBLL bll = new ExpedienteBLL();
            var response = bll.Insertar(obj);
            Assert.AreEqual(false, response.Error);
        }
    }
}