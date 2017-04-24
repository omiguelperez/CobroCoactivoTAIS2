using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TipoPersonaDTO{
        public TipoPersonaDTO()
        {
            Personas = new List<PersonaDTO>();
        }

        public int TipoPersonaId { get; set; }
        public string Nombre { get; set; }
        public virtual List<PersonaDTO> Personas { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(); } }
    }
}
