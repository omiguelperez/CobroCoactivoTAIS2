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
    public class RegistrarPersonasSteps
    {
        IWebDriver chrome;
        BrowserDriverHelper helper;

        Random rnd = new Random(DateTime.Now.Millisecond);

        [Given(@"ya logueado en el sistema")]
        public void GivenYaLogueadoEnElSistema()
        {
            IWebElement inputIdentificacion;
            IWebElement inputPassword;
            IWebElement buttonIngresar;

            chrome = new ChromeDriver();
            chrome.Url = "http://localhost:9999";

            helper = new BrowserDriverHelper(chrome);

            inputIdentificacion = helper.GetElementById("textIdentificacion");
            inputPassword = helper.GetElementById("textPass");
            buttonIngresar = helper.GetElementById("btningresar");

            inputIdentificacion.SendKeys("lider");
            inputPassword.SendKeys("lider1*");
            buttonIngresar.Click();

            System.Threading.Thread.Sleep(2000);
        }
        
        [Given(@"estando en el modulo de registro")]
        public void GivenEstandoEnElModuloDeRegistro()
        {
            chrome.FindElement(By.XPath("((//a[contains(text(),'Registrar Usuarios')])[2])")).Click();
        }
        
        [Given(@"registro la persona")]
        public void GivenRegistroLaPersona()
        {
            int random = rnd.Next(1, 99999);
            System.Threading.Thread.Sleep(7000);
            chrome.FindElement(By.XPath("//label[text()='Natural']")).Click();

            SelectElement selectRol = new SelectElement(helper.GetElementById("cmbRol"));
            selectRol.SelectByText("Deudor");

            helper.GetElementByName("identificacion").SendKeys("12"+random);
            helper.GetElementByName("nombres").SendKeys("juana");
            helper.GetElementByName("pApellido").SendKeys("la loca");
            SelectElement selectSexo = new SelectElement(helper.GetElementById("cmbSexo"));
            selectSexo.SelectByText("Masculino");

            helper.GetElementByName("fechaNac").SendKeys("18 -08-1994");
            SelectElement selectPaisNac = new SelectElement(helper.GetElementById("cmbPaisNacimiento"));
            selectPaisNac.SelectByText("Colombia");

            System.Threading.Thread.Sleep(2000);

            SelectElement selectDpto = new SelectElement(helper.GetElementById("cmbDepartamento"));
            selectDpto.SelectByText("Cesar");

            System.Threading.Thread.Sleep(2000);

            SelectElement selectMuni = new SelectElement(helper.GetElementById("cmbMunicipio"));
            selectMuni.SelectByText("Valledupar");

            helper.GetElementByName("direccion").SendKeys("calle 32");
            SelectElement selectPaisCorr = new SelectElement(helper.GetElementById("cmbPaisCorrespondencia"));
            selectPaisCorr.SelectByText("Colombia");
            helper.GetElementByName("telefono").SendKeys("34243234");
            helper.GetElementById("inputEmailCorr").SendKeys("prueba"+random+"@hotmail.com");

            helper.GetElementByName("usuario").SendKeys("juanita"+random);
            helper.GetElementByName("password").SendKeys("Pendejuela1*");
            helper.GetElementByName("confirmpassword").SendKeys("Pendejuela1*");
        }
        
        [When(@"al dar clic en el boton registrar")]
        public void WhenAlDarClicEnElBotonRegistrar()
        {
            var buttonRegistrar = helper.GetElementById("btnreg");
            buttonRegistrar.Click();
        }

        [Then(@"el sistema me mostrara un mensaje de ""(.*)""")]
        public void ThenElSistemaMeMostraraUnMensajeDe(string msgEsperado)
        {
            var msgRespuesta = helper.GetElementById("msgRta");
            string mensaje = msgRespuesta.Text;
            
            Assert.AreEqual(msgEsperado, mensaje);

            System.Threading.Thread.Sleep(1000);
            chrome.Quit();
        }

    }
}
