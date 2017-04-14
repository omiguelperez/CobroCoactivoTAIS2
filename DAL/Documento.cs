using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Documento
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
        public virtual TipoDocumento TipoDocumento { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(); } }
        public virtual Expediente Expediente { get; set; }
    }
}
