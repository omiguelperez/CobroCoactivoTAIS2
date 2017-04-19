using BLL;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BDD
{
    [Binding]
    public class CalculadoraSteps
    {
        Calculadora calculadora = new Calculadora();

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int primerNumero)
        {
            calculadora.PrimerNumero = primerNumero;
        }

        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int segundoNumero)
        {
            calculadora.SegundoNumero = segundoNumero;
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            calculadora.Sumar();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int suma)
        {
            Assert.AreEqual(suma, calculadora.Resultado);
        }
    }
}
