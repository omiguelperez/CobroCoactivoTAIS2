using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TipoObligacion{
        public TipoObligacion()
        {
            Obligaciones = new List<Obligacion>();
        }
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static TipoObligacion MapeoDTOToDAL(TipoObligacionDTO DTO)
        {
            TipoObligacion c = new TipoObligacion();
            c.CreatedAt = DTO.CreatedAt;
            c.Nombre = DTO.Nombre;
            c.UpdateAt = DTO.UpdateAt;
            c.TipoObligacionId = DTO.TipoObligacionId;
            return c;
        }

        /// <summary>
        /// Este metodo convierte un DAL a DTO
        /// </summary>
        /// <param name="DAL">Parametro DAL</param>
        /// <returns>Objeto tipo DTO</returns>
        public static TipoObligacionDTO MapeoDALToDTO(TipoObligacion DAL)
        {
            TipoObligacionDTO c = new TipoObligacionDTO();
            c.CreatedAt = DAL.CreatedAt;
            c.Nombre = DAL.Nombre;
            c.UpdateAt = DAL.UpdateAt;
            c.TipoObligacionId = DAL.TipoObligacionId;
            return c;
        }
        public int TipoObligacionId { get; set; }
        public string Nombre { get; set; }
        public virtual List<Obligacion> Obligaciones { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second); } }
    }
}
