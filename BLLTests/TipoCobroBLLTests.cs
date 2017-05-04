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
    public class TipoCobroBLLTests
    {
        [TestMethod()]
        public void GetTiposCobrosTest()
        {
            TipoCobroBLL bll = new TipoCobroBLL();
            var response = bll.GetTiposCobros();
            Assert.IsNotNull(response);
        }
    }
}