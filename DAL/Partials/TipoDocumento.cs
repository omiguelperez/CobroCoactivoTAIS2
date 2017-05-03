using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class TipoDocumento
    {
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static TipoDocumento MapeoDTOToDAL(TipoDocumentoDTO DTO)
        {
            try
            {
                TipoDocumento c = new TipoDocumento();
                c.CreatedAt = DTO.CreatedAt;
                c.Nombre = DTO.Nombre;
                c.UpdateAt = DTO.UpdateAt;
                c.TipoDocumentoId = DTO.TipoDocumentoId;
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
        public static TipoDocumentoDTO MapeoDALToDTO(TipoDocumento DAL)
        {
            try
            {

                TipoDocumentoDTO c = new TipoDocumentoDTO();
                c.CreatedAt = DAL.CreatedAt;
                c.Nombre = DAL.Nombre;
                c.UpdateAt = DAL.UpdateAt;
                c.TipoDocumentoId = DAL.TipoDocumentoId;
                return c;
            }
            catch (Exception e)
            {
                return null;
            }
        }


    }
}
