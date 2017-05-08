using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class Pais{
        public Pais()
        {
            Departamentos = new List<Departamento>();
        }
        public int PaisId { get; set; }
        public string Nombre { get; set; }
        public virtual List<Departamento> Departamentos { get; set; }
    }
}
