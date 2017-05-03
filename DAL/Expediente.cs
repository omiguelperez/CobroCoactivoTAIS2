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
    public partial class Expediente
    {
        public Expediente()
        {
            Documentos = new List<Documento>();
        }
        public int ExpedienteId { get; set; }
        public string EntidadEncargada { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string DireccionEjecutado { get; set; }
        public float Cuantia { get; set; }
        public string NaturalezaObligacion { get; set; }
        public string DireccionTituloEjecutivo { get; set; }
        public string Descripcion { get; set; }
        public string UbicacionExpediente { get; set; }
        public DateTime FechaRadicacion { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second); } }
        //public int ObligacionId { get; set; }
        //[Required]
        //public virtual Obligacion Obligacion { get; set; }
        public virtual List<Documento> Documentos { get; set; }
    }
}
