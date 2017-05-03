using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class TipoCobro
    {
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static TipoCobro MapeoDTOToDAL(TipoCobroDTO DTO)
        {
            try
            {
                TipoCobro c = new TipoCobro();
                c.CreatedAt = DTO.CreatedAt;
                c.Nombre = DTO.Nombre;
                c.TipoCobroId = DTO.TipoCobroId;
                c.UpdateAt = DTO.UpdateAt;

                //No mapeo los cobros porque despues Habria un Bucle
                return c;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
