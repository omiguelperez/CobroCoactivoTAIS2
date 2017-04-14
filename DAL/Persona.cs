using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Persona
    {
        public Persona()
        {
            Obligaciones = new List<Obligacion>();
        }

        public int PersonaId { get; set; }

        
        // [Column("Fecha", TypeName = "datetime2", Order = 1)]
        public string Identificacion { get; set; }
        [Required]
        [StringLength(35)]
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public virtual List<Obligacion> Obligaciones { get; set; }
    }
}
