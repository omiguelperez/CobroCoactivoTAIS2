using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class TipoObligacion
    {
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static TipoObligacion MapeoDTOToDAL(TipoObligacionDTO DTO)
        {
            try
            {
                TipoObligacion c = new TipoObligacion();
                c.CreatedAt = DTO.CreatedAt;
                c.Nombre = DTO.Nombre;
                c.UpdateAt = DTO.UpdateAt;
                c.TipoObligacionId = DTO.TipoObligacionId;
                return c;

            }catch(Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Este metodo convierte un DAL a DTO
        /// </summary>
        /// <param name="DAL">Parametro DAL</param>
        /// <returns>Objeto tipo DTO</returns>
        public static TipoObligacionDTO MapeoDALToDTO(TipoObligacion DAL)
        {
            try
            {
                TipoObligacionDTO c = new TipoObligacionDTO();
                c.CreatedAt = DAL.CreatedAt;
                c.Nombre = DAL.Nombre;
                c.UpdateAt = DAL.UpdateAt;
                c.TipoObligacionId = DAL.TipoObligacionId;
                return c;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
