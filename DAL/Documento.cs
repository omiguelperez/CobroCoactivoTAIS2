using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class Documento
    {
        public int DocumentoId { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public DateTime FechaDocumento { get; set; }
        public string OficinaOrigen { get; set; }
        public string Remitente { get; set; }
        public string FuncionarioEntrega { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string FuncionarioRecibe { get; set; }
        public DateTime FechaRadicacion { get; set; }
        public string RutaDocumento { get; set; }
        public string TipoArchivo { get; set; }
        public string Estado { get; set; }
        public int TipoDocumentoId { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second); } }
        public int ExpedienteId { get; set; }
        public virtual Expediente Expediente { get; set; }
    }
}
