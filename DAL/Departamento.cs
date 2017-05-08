using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class Departamento{
        public Departamento()
        {
            Municipios = new List<Municipio>();
        }
        public int DepartamentoId { get; set; }
        public string Nombre { get; set; }
        public int PaisId { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual List<Municipio> Municipios { get; set; }
    }
}
