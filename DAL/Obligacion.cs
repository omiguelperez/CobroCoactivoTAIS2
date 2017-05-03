using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL.Infrastructure;

namespace DAL
{
    public partial class Obligacion
    {
        public int ObligacionId { get; set; }
        public float Cuantia { get; set; }
        public float Dueda { get; set; }
        public DateTime FechaPreinscripcion { get; set; }
        public string Estado { get; set; }

        public virtual List<Cobro> Cobros { get; set; }


        public int ExpedienteId { get; set; }
        public virtual Expediente Expediente { get; set; }


        public int TipoObligacionId { get; set; }
        public virtual TipoObligacion TipoObligacion { get; set; }
        public int PersonaId { get; set; }
        public virtual Persona Persona { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt =new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second); } }
    }
}
