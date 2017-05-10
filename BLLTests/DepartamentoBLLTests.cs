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
    public class DepartamentoBLLTests
    {
        [TestMethod()]
        public void GetDepartamentosByPaisIdTest()
        {
            DepartamentoBLL blldepartamento = new DepartamentoBLL();
            var respuesta = blldepartamento.GetDepartamentosByPaisId(1);
            Assert.IsNotNull(respuesta);
        }
    }
}