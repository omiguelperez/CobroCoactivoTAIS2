using System;
using System.Collections.Generic;
    
namespace Entities
{
    public class TipoCobroDTO
    {
        public TipoCobroDTO()
        {
            Cobros = new List<CobroDTO>();
        }
        public int TipoCobroId { get; set; }
        public string Nombre { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(); } }
        public  List<CobroDTO> Cobros { get; set; }
    }
}
