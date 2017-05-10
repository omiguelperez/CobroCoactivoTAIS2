using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class Pais{
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static Pais MapeoDTOToDAL(PaisDTO DTO)
        {
            try
            {
                Pais c = new Pais();
                c.Nombre = DTO.Nombre;
                c.PaisId = DTO.PaisId;
                return c;

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Este metodo convierte un DAL a DTO
        /// </summary>
        /// <param name="DAL">Parametro DAL</param>
        /// <returns>Objeto tipo DTO</returns>
        public static PaisDTO MapeoDALToDTO(Pais DAL)
        {
            try
            {
                PaisDTO c = new PaisDTO();
                c.Nombre = DAL.Nombre;
                c.PaisId = DAL.PaisId;
                return c;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
