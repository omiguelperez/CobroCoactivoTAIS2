using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class Departamento{
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static Departamento MapeoDTOToDAL(DepartamentoDTO DTO)
        {
            try
            {
                Departamento c = new Departamento();
                c.Nombre = DTO.Nombre;
                c.DepartamentoId = DTO.DepartamentoId;
                if (DTO.Pais != null)
                {
                    c.Pais = Pais.MapeoDTOToDAL(DTO.Pais);
                }
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
        public static DepartamentoDTO MapeoDALToDTO(Departamento DAL)
        {
            try
            {
                DepartamentoDTO c = new DepartamentoDTO();
                c.Nombre = DAL.Nombre;
                c.DepartamentoId = DAL.DepartamentoId;
                if (DAL.Pais != null)
                {
                    c.Pais = Pais.MapeoDALToDTO(DAL.Pais);
                }
                return c;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
