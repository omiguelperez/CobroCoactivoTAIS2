using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace BDD
{
    [Binding]
    public class RegistrarCarteraSteps
    {
        Random rnd = new Random(DateTime.Now.Millisecond);

        IWebDriver driver;

        [Given(@"ya logueada dentro del sistema")]
        public void GivenYaLogueadaDentroDelSistema()
        {
            driver = new ChromeDriver();
            driver.Url = "http://localhost:9999";
            driver.FindElement(By.Id("textIdentificacion")).SendKeys("Secretaria");
            driver.FindElement(By.Id("textPass")).SendKeys("secretaria1*");
            driver.FindElement(By.Id("btningresar")).Click();
            System.Threading.Thread.Sleep(5000);
        }
        
        [Given(@"presiono la opcion registar cartera")]
        public void GivenPresionoLaOpcionRegistarCartera()
        {
            while (true)
            {
                try
                {
                    driver.FindElement(By.XPath("(//a[contains(text(),'Registrar Cartera')])[2]")).Click();
                    break;
                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        [Given(@"luego clic en agregar nueva deuda")]
        public void GivenLuegoClicEnAgregarNuevaDeuda()
        {
            while (true)
            {
                try
                {
                    driver.FindElement(By.XPath("//div[3]/a/i")).Click();
                    break;
                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
        
        [Given(@"relleno el formulario")]
        public void GivenRellenoElFormulario()
        {
            //datos personales
            int random = rnd.Next(1, 99999);
            System.Threading.Thread.Sleep(5000);
            driver.FindElement(By.XPath("//label[@for='radioNatural']")).Click();
            driver.FindElement(By.Id("inputidentificacion")).SendKeys("133456"+ random+"");
            driver.FindElement(By.Id("inputNombres")).SendKeys("julio");
            driver.FindElement(By.Id("inputpApellido")).SendKeys("monsalvo");
            SelectElement selectSexo = new SelectElement(driver.FindElement(By.Id("cmbSexo")));
            selectSexo.SelectByText("Femenino");
            SelectElement selectNacionalidad = new SelectElement(driver.FindElement(By.Id("cmbNacionalidad")));
            selectNacionalidad.SelectByText("Venezuela");
            //fecha y lugar de nacimiento
            driver.FindElement(By.Name("fechaNac")).SendKeys("18-08-1994");
            SelectElement selectPaisNac = new SelectElement(driver.FindElement(By.Id("cmbPaisNacimiento")));
            selectPaisNac.SelectByText("Colombia");
            System.Threading.Thread.Sleep(2000);
            SelectElement selectDpto = new SelectElement(driver.FindElement(By.Id("cmbDepartamento")));
            selectDpto.SelectByText("Cesar");
            System.Threading.Thread.Sleep(2000);
            SelectElement selectMuni = new SelectElement(driver.FindElement(By.Id("cmbMunicipio")));
            selectMuni.SelectByText("Valledupar");
            //direccion de correspondencia
            driver.FindElement(By.Id("inputDireccion")).SendKeys("aqui vivo yo");
            driver.FindElement(By.Id("inputTelefonoCorr")).SendKeys("987654567");
            driver.FindElement(By.Id("inputEmailCorr")).SendKeys("correo"+ random+"@gmail.com");
            //informacion adicional
            driver.FindElement(By.Id("textarea1")).SendKeys("una descripcion");            
            driver.FindElement(By.Id("inputDirEjecutado")).SendKeys("direccion de algo");
            driver.FindElement(By.Id("inputDirTitEje")).SendKeys("otra direccion");
            driver.FindElement(By.Id("inputEntEncar")).SendKeys("coomeva");
            driver.FindElement(By.Id("inputFechaRadi")).SendKeys("18-08-1994");
            driver.FindElement(By.Id("inputNatObliga")).SendKeys("impuesto");
            driver.FindElement(By.Id("inputUbicaExped")).SendKeys("por alla lejos");
            //obligacion
            driver.FindElement(By.Id("inputDeuda")).SendKeys("5903922");
            driver.FindElement(By.Id("inputFechaPreins")).SendKeys("18-08-1994");
            SelectElement selectTipoObli = new SelectElement(driver.FindElement(By.Id("cmbTipoObligacion")));
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
            string mensaje = null;

            while (true)
            {
                try
                {
                    mensaje = driver.FindElement(By.Id("msgRta")).Text;
                    break;
                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }
            
            Assert.AreEqual(msgEsperado, mensaje);

            System.Threading.Thread.Sleep(1000);
            driver.Quit();
        }
    }
}
