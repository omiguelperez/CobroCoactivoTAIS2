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
    public class TipoDocumentoBLLTests
    {
        [TestMethod()]
        public void GetTipoDocumentosTest()
        {
            TipoDocumentoBLL bll = new TipoDocumentoBLL();
            var response = bll.GetTipoDocumentos();
            Assert.IsNotNull(response);
        }
    }
}