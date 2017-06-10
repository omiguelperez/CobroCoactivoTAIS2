using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using BDD.Helpers;

namespace BDD.Steps
{
    [Binding]
    public class RegistrarExpedienteSteps
    {
        IWebDriver driver;
        BrowserDriverHelper helper;
        [Given(@"logueado en el sistema")]
        public void GivenLogueadoEnElSistema()
        {
            driver = new ChromeDriver();
            driver.Url = "http://localhost:9000";
            helper = new BrowserDriverHelper(driver);

            helper.GetElementById("textIdentificacion").SendKeys("Secretaria");
            helper.GetElementById("textPass").SendKeys("secretaria1*");
            helper.GetElementById("btningresar").Click();

            System.Threading.Thread.Sleep(5000);
        }
        
        [Given(@"luego de haber consultado las carteras")]
        public void GivenLuegoDeHaberConsultadoLasCarteras()
        {
            helper.GetElementByXPath("(//a[contains(text(),'Registrar Cartera')])[2]").Click();
        }
        
        [Given(@"selecciono una cartera")]
        public void GivenSeleccionoUnaCartera()
        {
            helper.GetElementByXPath("(//i[contains(text(),'mode_edit')])[6]").Click();
            System.Threading.Thread.Sleep(1500);
        }
        
        [Given(@"relleno la informacion requerida")]
        public void GivenRellenoLaInformacionRequerida()
        {
            string fechaHoy = DateTime.Today.Day+"/" +  DateTime.Today.Month+"/"+ DateTime.Today.Year;
            driver.SwitchTo().Frame("iframeDoc");
            driver.FindElement(By.Id("date1")).SendKeys(fechaHoy);
            driver.FindElement(By.Id("date2")).SendKeys(fechaHoy);
            driver.FindElement(By.Id("date3")).SendKeys(fechaHoy);
            driver.FindElement(By.Id("txt1")).SendKeys("Secretaria de Hacienda");
            driver.FindElement(By.Id("txt2")).SendKeys("Boris Gonzalez");
            driver.FindElement(By.Id("txt3")).SendKeys("Lider");
        }
        
        [Given(@"subo el documento con(.*)")]
        public void GivenSuboElDocumentoCon(string rutaArch)
        {
            driver.FindElement(By.Id("input-700")).SendKeys(rutaArch);
        }

        [When(@"presione el boton subir archivo")]
        public void WhenPresioneElBotonSubirArchivo()
        {
            driver.FindElement(By.XPath("//a/i")).Click();
        }
        
        [Then(@"el sistema me responde ""(.*)""")]
        public void ThenElSistemaMeResponde(string p0)
        {
            System.Threading.Thread.Sleep(2000);
            string txt =  driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/div")).Text;
            Assert.AreEqual(p0,txt);
            System.Threading.Thread.Sleep(500);
            driver.Quit();
        }
    }
}
