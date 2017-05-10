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
    public class TipoObligacionBLLTests
    {
        [TestMethod()]
        public void GetTipoObligacionesTest()
        {
            ObligacionBLL bll = new ObligacionBLL();
            var response = bll.GetObligaciones();
            Assert.IsNotNull(response);
        }
    }
}