using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class Municipio{
        public Municipio()
        {
            Personas = new List<Persona>();
        }
        public int MunicipioId { get; set; }
        public string Nombre { get; set; }
        public int DepartamentoId { get; set; }
        public virtual Departamento Departamento { get; set; }
        public virtual List<Persona> Personas { get; set; }
    }
}
