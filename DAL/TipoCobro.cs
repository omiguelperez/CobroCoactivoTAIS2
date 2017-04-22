using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace DAL
{
    public class TipoCobro
    {
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static TipoCobro MapeoDTOToDAL(TipoCobroDTO DTO)
        {
            TipoCobro c = new TipoCobro();
            c.CreatedAt = DTO.CreatedAt;
            c.Nombre = DTO.Nombre;
            c.TipoCobroId = DTO.TipoCobroId;
            c.UpdateAt = DTO.UpdateAt;
            
            //No mapeo los cobros porque despues Habria un Bucle
            return c;
        }
        public TipoCobro()
        {
            Cobros = new List<Cobro>();
        }
        public int TipoCobroId { get; set; }
        public string Nombre { get; set; }
        public virtual List<Cobro> Cobros { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second); } }
    }
}
