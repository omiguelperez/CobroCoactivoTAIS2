using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace BDD
{
    [Binding]
    public class RegistrarCarteraSteps
    {
        IWebDriver driver;

        [Given(@"ya logueada dentro del sistema")]
        public void GivenYaLogueadaDentroDelSistema()
        {
            driver = new ChromeDriver();
            driver.Url = "http://localhost:9000";
            driver.FindElement(By.Id("textIdentificacion")).SendKeys("Secretaria");
            driver.FindElement(By.Id("textPass")).SendKeys("Secretaria");
            driver.FindElement(By.Id("btningresar")).Click();
        }
        
        [Given(@"presiono la opcion registar cartera")]
        public void GivenPresionoLaOpcionRegistarCartera()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'Registrar Carteras')]")).Click();
        }

        [Given(@"luego clic en agregar nueva deuda")]
        public void GivenLuegoClicEnAgregarNuevaDeuda()
        {
            driver.FindElement(By.XPath("//div[3]/a/i")).Click();
        }
        
        [Given(@"relleno el formulario")]
        public void GivenRellenoElFormulario()
        {
            //datos personales
            driver.FindElement(By.XPath("//label[@for='radioNatural']")).Click();
            driver.FindElement(By.Id("inputidentificacion")).SendKeys("133456");
            driver.FindElement(By.Id("inputNombres")).SendKeys("julio");
            driver.FindElement(By.Id("inputpApellido")).SendKeys("monsalvo");
            driver.FindElement(By.Id("inputNac")).SendKeys("Colombia");
            //fecha y lugar de nacimiento
            driver.FindElement(By.Id("inputPaisNaci")).SendKeys("Estados Unidos");            
            driver.FindElement(By.Id("inputDepartamentoNaci")).SendKeys("Washinton");
            driver.FindElement(By.Id("inputMunicipioNaci")).SendKeys("brooklin");
            //direccion de correspondencia
            driver.FindElement(By.Id("inputDireccion")).SendKeys("aqui vivo yo");
            driver.FindElement(By.Id("inputPaisCorr")).SendKeys("Colombia");
            driver.FindElement(By.Id("inputTelefonoCorr")).SendKeys("987654567");
            driver.FindElement(By.Id("inputEmailCorr")).SendKeys("correo@gmail.com");
            //informacion adicional
            driver.FindElement(By.Id("textarea1")).SendKeys("una descripcion");            
            driver.FindElement(By.Id("inputDirEjecutado")).SendKeys("direccion de algo");
            driver.FindElement(By.Id("inputDirTitEje")).SendKeys("otra direccion");
            driver.FindElement(By.Id("inputEntEncar")).SendKeys("coomeva");
            driver.FindElement(By.Id("inputNatObliga")).SendKeys("impuesto");
            driver.FindElement(By.Id("inputUbicaExped")).SendKeys("por alla lejos");
            //obligacion
            driver.FindElement(By.Id("inputDeuda")).SendKeys("5903922");
        }
        
        [When(@"presione el boton registrar")]
        public void WhenPresioneElBotonRegistrar()
        {
            driver.FindElement(By.Id("btnreg")).Click();
        }
        
        [Then(@"el sistema me arroja el mensaje ""(.*)""")]
        public void ThenElSistemaMeArrojaElMensaje(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
