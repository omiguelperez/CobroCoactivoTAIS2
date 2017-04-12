using DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Cobro
    {
        public int CobroId { get; set; }
        public string Nombre { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(); } }
        public virtual TipoCobro TipoCobro { get; set; }

        //[ForeignKey("UserId")]
        //[Required]
        public string UsuarioId { get; set; }
        //[ForeignKey("U")]
       // [ForeignKey("UserId")]
        public virtual ApplicationUser Usuario { set; get; }
    }
}
