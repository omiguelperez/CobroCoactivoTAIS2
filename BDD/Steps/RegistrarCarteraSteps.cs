using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using BDD.Helpers;

namespace BDD
{
    [Binding]
    public class RegistrarCarteraSteps
    {
        Random rnd = new Random(DateTime.Now.Millisecond);

        IWebDriver driver;
        BrowserDriverHelper helper;

        [Given(@"ya logueada dentro del sistema")]
        public void GivenYaLogueadaDentroDelSistema()
        {
            driver = new ChromeDriver();
            driver.Url = "http://localhost:9999";

            helper = new BrowserDriverHelper(driver);

            helper.GetElementById("textIdentificacion").SendKeys("Secretaria");
            helper.GetElementById("textPass").SendKeys("secretaria1*");
            helper.GetElementById("btningresar").Click();

            System.Threading.Thread.Sleep(5000);
        }
        
        [Given(@"presiono la opcion registar cartera")]
        public void GivenPresionoLaOpcionRegistarCartera()
        {
            helper.GetElementByXPath("(//a[contains(text(),'Registrar Cartera')])[2]").Click();
        }

        [Given(@"luego clic en agregar nueva deuda")]
        public void GivenLuegoClicEnAgregarNuevaDeuda()
        {
            helper.GetElementByXPath("//div[3]/a/i").Click();
        }
        
        [Given(@"relleno el formulario")]
        public void GivenRellenoElFormulario()
        {
            int random = rnd.Next(1, 99999);

            System.Threading.Thread.Sleep(5000);

            helper.GetElementByXPath("//label[@for='radioNatural']").Click();
            helper.GetElementById("inputidentificacion").SendKeys("133456"+ random+"");
            helper.GetElementById("inputNombres").SendKeys("julio");
            helper.GetElementById("inputpApellido").SendKeys("monsalvo");

            SelectElement selectSexo = new SelectElement(helper.GetElementById("cmbSexo"));
            selectSexo.SelectByText("Femenino");

            SelectElement selectNacionalidad = new SelectElement(helper.GetElementById("cmbNacionalidad"));
            selectNacionalidad.SelectByText("Venezuela");
            
            driver.FindElement(By.Name("fechaNac")).SendKeys("18-08-1994");
            SelectElement selectPaisNac = new SelectElement(helper.GetElementById("cmbPaisNacimiento"));
            selectPaisNac.SelectByText("Colombia");

            System.Threading.Thread.Sleep(2000);

            SelectElement selectDpto = new SelectElement(helper.GetElementById("cmbDepartamento"));
            selectDpto.SelectByText("Cesar");

            System.Threading.Thread.Sleep(2000);

            SelectElement selectMuni = new SelectElement(helper.GetElementById("cmbMunicipio"));
            selectMuni.SelectByText("Valledupar");
            
            helper.GetElementById("inputDireccion").SendKeys("aqui vivo yo");
            helper.GetElementById("inputTelefonoCorr").SendKeys("987654567");
            helper.GetElementById("inputEmailCorr").SendKeys("correo"+ random+"@gmail.com");
            
            helper.GetElementById("textarea1").SendKeys("una descripcion");            
            helper.GetElementById("inputDirEjecutado").SendKeys("direccion de algo");
            helper.GetElementById("inputDirTitEje").SendKeys("otra direccion");
            helper.GetElementById("inputEntEncar").SendKeys("coomeva");
            helper.GetElementById("inputFechaRadi").SendKeys("18-08-1994");
            helper.GetElementById("inputNatObliga").SendKeys("impuesto");
            helper.GetElementById("inputUbicaExped").SendKeys("por alla lejos");
            
            helper.GetElementById("inputDeuda").SendKeys("5903922");
            helper.GetElementById("inputFechaPreins").SendKeys("18-08-1994");
            SelectElement selectTipoObli = new SelectElement(helper.GetElementById("cmbTipoObligacion"));
            selectTipoObli.SelectByText("Tipo Obligacion 2");
        }
        
        [When(@"presione el boton registrar")]
        public void WhenPresioneElBotonRegistrar()
        {
            driver.FindElement(By.Id("btnreg")).Click();
        }
        
        [Then(@"el sistema me arroja el mensaje ""(.*)""")]
        public void ThenElSistemaMeArrojaElMensaje(string msgEsperado)
        {
            var msgRta = helper.GetElementById("msgRta");
            string mensaje = msgRta.Text;

            Assert.AreEqual(msgEsperado, mensaje);

            System.Threading.Thread.Sleep(1000);
            driver.Quit();
        }
    }
}
