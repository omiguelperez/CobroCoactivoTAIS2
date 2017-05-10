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
    public class ExpedienteBLLTests
    {
        [TestMethod()]
        public void GetExpedientesTest()
        {
            ExpedienteBLL bll = new ExpedienteBLL();
            var response = bll.GetExpedientes();
            Assert.IsNotNull(response);
        }

        [TestMethod()]
        public void FindExpedienteByIdTest()
        {
            ExpedienteBLL bll = new ExpedienteBLL();
            var response = bll.FindExpedienteById(1);
            Assert.IsNotNull(response);
        }
    }
}