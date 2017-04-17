using System;
using System.Collections.Generic;

namespace Entities
{
    public class CobroDTO
    {
        public int CobroId { get; set; }
        public string Nombre { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(); } }
        public int TipoCobroId { get; set; }
        public TipoCobroDTO TipoCobro { get; set; }
        public string UsuarioId { get; set; }
        public ApplicationUserDTO Usuario { set; get; }
        public List<ObligacionDTO> Obligaciones { get; set; }
    }
}
