using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BDD.Helpers
{
    public class BrowserDriverHelper
    {
        private IWebDriver driver;

        public BrowserDriverHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement GetElementById(string id)
        {
            IWebElement element = null;
            int maxAttemps = 10;
            int attemp = 0;

            do
            {
                try
                {
                    element = this.driver.FindElement(By.Id(id));
                    break;
                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(1000);
                    attemp++;
                }
            } while (attemp < maxAttemps);

            return element;
        }

        public IWebElement GetElementByName(string name)
        {
            IWebElement element = null;
            int maxAttemps = 10;
            int attemp = 0;

            do
            {
                try
                {
                    element = this.driver.FindElement(By.Name(name));
                    break;
                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(1000);
                    attemp++;
                }
            } while (attemp < maxAttemps);

            return element;
        }

        public IWebElement GetElementByXPath(string xpath)
        {
            IWebElement element = null;
            int maxAttemps = 10;
            int attemp = 0;

            do
            {
                try
                {
                    element = this.driver.FindElement(By.XPath(xpath));
                    break;
                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(1000);
                    attemp++;
                }
            } while (attemp < maxAttemps);

            return element;
        }
    }
}