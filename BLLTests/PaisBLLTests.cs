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
    public class PaisBLLTests
    {
        [TestMethod()]
        public void GetPaisesTest()
        {
            PaisBLL blldepais = new PaisBLL();
            var respuesta = blldepais.GetPaises();
            Assert.IsNotNull(respuesta);
        }
    }
}