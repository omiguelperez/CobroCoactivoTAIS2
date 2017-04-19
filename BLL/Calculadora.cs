using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Calculadora
    {
        public int PrimerNumero { get; set; }
        public int SegundoNumero { get; set; }
        public int Resultado { get; set; }

        public void Sumar()
        {
            Resultado = PrimerNumero + SegundoNumero;
        }
    }
}
