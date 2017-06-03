using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace BDD
{
    [Binding]
    public class RegistrarPersonasSteps
    {
        IWebDriver chrome;
        [Given(@"ya logueado en el sistema")]
        public void GivenYaLogueadoEnElSistema()
        {
            chrome = new ChromeDriver();
            chrome.Url = "http://localhost:9000";
            chrome.FindElement(By.Id("textIdentificacion")).SendKeys("lider");
            chrome.FindElement(By.Id("textPass")).SendKeys("lider1*");
            chrome.FindElement(By.Id("btningresar")).Click();
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
            chrome.FindElement(By.XPath("//label[text()='Natural']")).Click();
            System.Threading.Thread.Sleep(2000);
            //rol
            SelectElement selectRol = new SelectElement(chrome.FindElement(By.Id("cmbRol")));
            selectRol.SelectByText("Deudor");
            //datos personales
            chrome.FindElement(By.Name("identificacion")).SendKeys("12334567");
            chrome.FindElement(By.Name("nombres")).SendKeys("juana");
            chrome.FindElement(By.Name("pApellido")).SendKeys("la loca");
            SelectElement selectSexo = new SelectElement(chrome.FindElement(By.Id("cmbSexo")));
            selectSexo.SelectByText("Masculino");
            //fecha y lugar de nacimiento
            chrome.FindElement(By.Name("fechaNac")).SendKeys("18-08-1994");
            SelectElement selectPaisNac = new SelectElement(chrome.FindElement(By.Id("cmbPaisNacimiento")));
            selectPaisNac.SelectByText("Colombia");
            System.Threading.Thread.Sleep(1000);
            SelectElement selectDpto = new SelectElement(chrome.FindElement(By.Id("cmbDepartamento")));
            selectDpto.SelectByText("Cesar");
            System.Threading.Thread.Sleep(1000);
            SelectElement selectMuni = new SelectElement(chrome.FindElement(By.Id("cmbMunicipio")));
            selectMuni.SelectByText("Valledupar");
            //direccion de correspondencia
            chrome.FindElement(By.Name("direccion")).SendKeys("calle 32");
            SelectElement selectPaisCorr = new SelectElement(chrome.FindElement(By.Id("cmbPaisCorrespondencia")));
            selectPaisCorr.SelectByText("Colombia");
            chrome.FindElement(By.Name("telefono")).SendKeys("34243234");
            chrome.FindElement(By.Id("inputEmailCorr")).SendKeys("samiranda@hotmail.com");
            //datos de usuario
            chrome.FindElement(By.Name("usuario")).SendKeys("juanita");
            chrome.FindElement(By.Name("password")).SendKeys("pendejuela1*");
            chrome.FindElement(By.Name("confirmpassword")).SendKeys("pendejuela1*");
        }
        
        [When(@"al dar clic en el boton registrar")]
        public void WhenAlDarClicEnElBotonRegistrar()
        {
            //chrome.FindElement(By.Id("btnreg")).Click();
            ScenarioContext.Current.Pending();
        }

        [Then(@"el sistema me mostrara un mensaje")]
        public void ThenElSistemaMeMostraraUnMensaje()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
