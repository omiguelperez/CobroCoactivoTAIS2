using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace BDD
{
    [Binding]
    public class LoginSteps
    {
        IWebDriver chrome;
        [Given(@"abrir el navegador")]
        public void GivenAbrirElNavegador()
        {
            chrome = new ChromeDriver();
        }
        
        [Given(@"ingreso la url del sistema")]
        public void GivenIngresoLaUrlDelSistema()
        {
            chrome.Url = "http://localhost:9000";
        }
        
        [Given(@"ingreso mi usuario ""(.*)"" y mi clave ""(.*)""")]
        public void GivenIngresoMiUsuarioYMiClave(string usuario, string clave)
        {
            chrome.FindElement(By.Id("textIdentificacion")).SendKeys(usuario);
            chrome.FindElement(By.Id("textPass")).SendKeys(clave);
        }
        
        [When(@"presione el boton ingresar")]
        public void WhenPresioneElBotonIngresar()
        {
            chrome.FindElement(By.Id("btningresar")).Click();
        }
        
        [Then(@"mi url sera ""(.*)""")]
        public void ThenMiUrlSera(string urlEsperada)
        {
            Assert.AreEqual(urlEsperada, chrome.Url);
        }
    }
}
