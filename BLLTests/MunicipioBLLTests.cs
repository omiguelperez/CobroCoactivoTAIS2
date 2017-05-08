using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tests
{
    [TestClass()]
    public class MunicipioBLLTests
    {
        [TestMethod()]
        public void GetMunicipiosByDepartamentoIdTest()
        {
            MunicipioBLL bllmiunicipio = new MunicipioBLL();
            var respuesta = bllmiunicipio.GetMunicipiosByDepartamentoId(20001);
            Assert.IsNotNull(respuesta);
        }
    }
}