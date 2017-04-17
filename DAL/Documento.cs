using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Documento
    {
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static Documento Mapeo(DocumentoDTO item)
        {
            Documento documento = new Documento();
            documento.DocumentoId = item.DocumentoId;
            documento.UpdateAt = item.UpdateAt;
            documento.CreatedAt = item.CreatedAt;
            if (item.Expediente != null)
            {
                documento.Expediente = Expediente.Mapeo(item.Expediente);
            }
            documento.ExpedienteId = item.ExpedienteId;
            documento.FechaDocumento = item.FechaDocumento;
            documento.FechaEntrega = item.FechaEntrega;
            documento.FechaRadicacion = item.FechaRadicacion;
            documento.FechaRecepcion = item.FechaRecepcion;
            documento.FuncionarioEntrega = item.FuncionarioEntrega;
            documento.FuncionarioRecibe = item.FuncionarioRecibe;
            documento.OficinaOrigen = item.OficinaOrigen;
            documento.Remitente = item.Remitente;
            documento.RutaDocumento = item.RutaDocumento;
            documento.TipoArchivo = item.TipoArchivo;
            if (item.TipoDocumento != null)
            {
                documento.TipoDocumento = TipoDocumento.Mapeo(item.TipoDocumento);
            }
            documento.TipoDocumentoId = item.TipoDocumentoId;
            return documento;
        }

        /// <summary>
        /// Este metodo Convierte una Lista DTO de Cobros a DAL, Recuerde que Para Mapear Una SubLista desde el controlador lo puede hacer
        /// </summary>
        /// <param name="ListaDTO">Lista De tipo DTO</param>
        /// <returns>Lista de Tipo DAL</returns>
        public static List<Documento> ConvertList(List<DocumentoDTO> ListaDTO)
        {
            List<Documento> Obligaciones = new List<Documento>();
            foreach (DocumentoDTO item in ListaDTO)
            {
                Obligaciones.Add(Mapeo(item));
            }
            return Obligaciones;
        }
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
        public virtual TipoDocumento TipoDocumento { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0); } }
        public int ExpedienteId { get; set; }
        public virtual Expediente Expediente { get; set; }
    }
}
