using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class TipoPersona
    {
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static TipoPersona MapeoDTOToDAL(TipoPersonaDTO DTO)
        {
            try
            {
                TipoPersona c = new TipoPersona();
                c.CreatedAt = DTO.CreatedAt;
                c.Nombre = DTO.Nombre;
                c.UpdateAt = DTO.UpdateAt;
                c.TipoPersonaId = DTO.TipoPersonaId;
                return c;

            }catch(Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Este metodo convierte un DAL a DTO
        /// </summary>
        /// <param name="DAL">Parametro DAL</param>
        /// <returns>Objeto tipo DTO</returns>
        public static TipoPersonaDTO MapeoDALToDTO(TipoPersona DAL)
        {
            try
            {
                TipoPersonaDTO c = new TipoPersonaDTO();
                c.CreatedAt = DAL.CreatedAt;
                c.Nombre = DAL.Nombre;
                c.UpdateAt = DAL.UpdateAt;
                c.TipoPersonaId = DAL.TipoPersonaId;
                return c;

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
