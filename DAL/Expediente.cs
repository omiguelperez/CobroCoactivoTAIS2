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
    public class Expediente
    {
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static Expediente Mapeo(ExpedienteDTO item)
        {
            Expediente obligacion = new Expediente();
            obligacion.ExpedienteId = item.ExpedienteId;
            obligacion.UpdateAt = item.UpdateAt;
            obligacion.CreatedAt = item.CreatedAt;
            obligacion.Cuantia = item.Cuantia;
            obligacion.Descripcion = item.Descripcion;
            obligacion.DireccionEjecutado = item.DireccionEjecutado;
            obligacion.DireccionTituloEjecutivo = item.DireccionTituloEjecutivo;
            obligacion.EntidadEncargada = item.EntidadEncargada;
            obligacion.FechaRadicacion = item.FechaRadicacion;
            obligacion.Identificacion = item.Identificacion;
            obligacion.NaturalezaObligacion = item.NaturalezaObligacion;
            obligacion.Nombre = item.Nombre;
            obligacion.Obligacion = Obligacion.Mapeo(item.Obligacion);
            obligacion.UbicacionExpediente = item.UbicacionExpediente;
            obligacion.ObligacionId = item.ObligacionId;
            return obligacion;
        }

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
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0); } }
        public int ObligacionId { get; set; }
        [Required]
        public virtual Obligacion Obligacion { get; set; }
        public virtual List<Documento> Documentos { get; set; }
    }
}
