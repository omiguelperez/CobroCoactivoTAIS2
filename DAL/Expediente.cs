using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Expediente
    {
        public Expediente()
        {
            Documentos = new List<Documento>();
        }
        [ForeignKey("Obligacion")]
        public int ExpedienteId { get; set; }
        public string EntidadEncargada { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string DireccionEjecutado { get; set; }
        public float Cuantia { get; set; }
        public string NaturalezaObligacion { get; set; }
        public string DireccionTituloEjecutivo { get; set; }
        public DateTime FechaRadicacion { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(); } }
        public virtual Obligacion Obligacion { get; set; }
        public virtual List<Documento> Documentos { get; set; }
    }
}
