using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TipoPersona{
        public TipoPersona()
        {
            Personas = new List<Persona>();
        }
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static TipoPersona MapeoDTOToDAL(TipoPersonaDTO DTO)
        {
            TipoPersona c = new TipoPersona();
            c.CreatedAt = DTO.CreatedAt;
            c.Nombre = DTO.Nombre;
            c.UpdateAt = DTO.UpdateAt;
            c.TipoPersonaId = DTO.TipoPersonaId;
            return c;
        }

        /// <summary>
        /// Este metodo convierte un DAL a DTO
        /// </summary>
        /// <param name="DAL">Parametro DAL</param>
        /// <returns>Objeto tipo DTO</returns>
        public static TipoPersonaDTO MapeoDALToDTO(TipoPersona DAL)
        {
            TipoPersonaDTO c = new TipoPersonaDTO();
            c.CreatedAt = DAL.CreatedAt;
            c.Nombre = DAL.Nombre;
            c.UpdateAt = DAL.UpdateAt;
            c.TipoPersonaId = DAL.TipoPersonaId;
            return c;
        }
        public int TipoPersonaId { get; set; }
        public string Nombre { get; set; }
        public virtual List<Persona> Personas { get; set; }
        private DateTime _updateAt;
        public DateTime UpdateAt { get { return _updateAt; } set { _updateAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second); } }
        private DateTime _createdAt;
        public DateTime CreatedAt { get { return _createdAt; } set { _createdAt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Hour, DateTime.Today.Minute, DateTime.Today.Second); } }
    }
}
