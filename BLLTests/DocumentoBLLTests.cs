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
    public class DocumentoBLLTests
    {
        [TestMethod()]
        public void GetDocumentsByExpedienteTest()
        {
            DocumentoBLL obj = new DocumentoBLL();
            var lista = obj.GetDocumentsByExpediente("localhost/api/documento/",1);
            Assert.IsNotNull(lista);
        }
    }
}