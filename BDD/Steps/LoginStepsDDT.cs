using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace BDD
{
    [Binding]
    public class LoginStepsDDT
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
            chrome.Url = "http://localhost:9999";
        }

        [Given(@"ingreso mis credenciales (.*) and (.*)")]
        public void GivenIngresoMisCredencialesAnd(string usuario, string clave) //para exitoso
        {
            IWebElement inputIdentificacion;
            IWebElement inputPassword;

            while (true)
            {
                try
                {
                    inputIdentificacion = chrome.FindElement(By.Id("textIdentificacion"));
                    inputPassword = chrome.FindElement(By.Id("textPass"));
                    break;
                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }

            inputIdentificacion.SendKeys(usuario);
            inputPassword.SendKeys(clave);
        }
        
        [Given(@"ingreso mi usuario ""(.*)"" y mi clave ""(.*)""")]
        public void GivenIngresoMiUsuarioYMiClave(string usuario, string clave) //para erroneo
        {
            chrome.FindElement(By.Id("textIdentificacion")).SendKeys(usuario);
            chrome.FindElement(By.Id("textPass")).SendKeys(clave);
        }
        
        [When(@"presione el boton ingresar")]
        public void WhenPresioneElBotonIngresar()
        {
            chrome.FindElement(By.Id("btningresar")).Click();
        }
        
        [Then(@"mi url cambiara de acuerdo a mi rol (.*)")]
        public void ThenMiUrlCambiaraDeAcuerdoAMiRol(string url) //para exitoso
        {
            System.Threading.Thread.Sleep(7000);
            Assert.AreEqual(url, chrome.Url);
            System.Threading.Thread.Sleep(1000);
            chrome.Quit();
        }
        
        [Then(@"mi url sera ""(.*)""")]
        public void ThenMiUrlSera(string url) //para erroneo
        {
            System.Threading.Thread.Sleep(3000);
            Assert.AreEqual(url, chrome.Url);
            System.Threading.Thread.Sleep(1000);
            chrome.Quit();
        }
    }
}
