using System;
namespace Entities
{
    public class DocumentoDTO
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
        public int TipoDocumentoId { get; set; }
        public TipoDocumentoDTO TipoDocumento { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(); } }
        public int ExpedienteId { get; set; }
        public ExpedienteDTO Expediente { get; set; }
    }
}
