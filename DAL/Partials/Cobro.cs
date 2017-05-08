using DAL.Infrastructure;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class Cobro
    {
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static Cobro Mapeo(CobroDTO item)
        {
            try
            {

                Cobro cobro = new Cobro();
                cobro.CobroId = item.CobroId;
                cobro.CreatedAt = item.CreatedAt;
                cobro.Nombre = item.Nombre;
                if (item.TipoCobro != null)
                {
                    cobro.TipoCobro = TipoCobro.MapeoDTOToDAL(item.TipoCobro);
                }
                cobro.UpdateAt = item.UpdateAt;
                cobro.UsuarioId = item.UsuarioId;
                if (item.Usuario != null)
                {
                    cobro.Usuario = ApplicationUser.Mapeo(item.Usuario);
                }
                cobro.TipoCobroId = item.TipoCobroId;
                return cobro;
            }catch(Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Este metodo Convierte una Lista DTO de Cobros a DAL, Recuerde que Para Mapear Una SubLista desde el controlador lo puede hacer
        /// </summary>
        /// <param name="ListaDTO">Lista De tipo DTO</param>
        /// <returns>Lista de Tipo DAL</returns>
        public static List<Cobro> ConvertList(List<CobroDTO> ListaDTO)
        {
            try
            {
                List<Cobro> Cobros = new List<Cobro>();
                foreach (CobroDTO item in ListaDTO)
                {
                    Cobros.Add(Mapeo(item));
                }
                return Cobros;

            }catch(Exception)
            {
                return null;
            }
        }
    }
}
