using System;
using System.Collections.Generic;

namespace Entities
{
    public class ExpedienteDTO
    {
        public ExpedienteDTO()
        {
            Documentos = new List<DocumentoDTO>();
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
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(); } }
        public int ObligacionId { get; set; }
        public ObligacionDTO Obligacion { get; set; }
        public List<DocumentoDTO> Documentos { get; set; }
    }
}
