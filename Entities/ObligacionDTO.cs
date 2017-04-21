using System;
using System.Collections.Generic;

namespace Entities
{
    public class ObligacionDTO
    {
        public ObligacionDTO()
        {
            Cobros = new List<CobroDTO>();
        }
        public int ObligacionId { get; set; }
        public float Cuantia { get; set; }
        public float Dueda { get; set; }
        public DateTime FechaPreinscripcion { get; set; }
        public string Estado { get; set; }
        public List<CobroDTO> Cobros { get; set; }
        public int ExpedienteId { get; set; }
        public ExpedienteDTO Expediente { get; set; }
        public int TipoObligacionId { get; set; }
        public TipoObligacionDTO TipoObligacion { get; set; }
        public int PersonaId { get; set; }
        public PersonaDTO Persona { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(); } }
    }
}
