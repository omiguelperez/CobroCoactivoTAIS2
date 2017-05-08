using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class Persona
    {
        public Persona()
        {
            Obligaciones = new List<Obligacion>();
        }

        public int PersonaId { get; set; }


        // [Column("Fecha", TypeName = "datetime2", Order = 1)]
        [Required]
        [Index(IsUnique = true)]
        [StringLength(15)]
        //[Column(TypeName = "VARCHAR")]
        public string Identificacion { get; set; }
        [Required]
        [StringLength(35)]
        public string Nombres { get; set; }
        [Required]
        [StringLength(35)]
        public string Apellidos { get; set; }
        [Required]
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        [Required]
        public string Direccion { get; set; }
        public int TipoPersonaId { get; set; }
        public virtual TipoPersona TipoPersona { get; set; }
        public string Nacionalidad { get; set; }
        public string PaisNacimiento { get; set; }
        public string PaisCorrespondencia { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public virtual List<Obligacion> Obligaciones { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second); } }
    }
}
