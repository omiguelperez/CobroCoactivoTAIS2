using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TipoCobro
    {
        public TipoCobro()
        {
            Cobros = new List<Cobro>();
        }
        public int TipoCobroId { get; set; }
        public string Nombre { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(); } }
        public virtual List<Cobro> Cobros { get; set; }
    }
}
