using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class Municipio{
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static Municipio MapeoDTOToDAL(MunicipioDTO DTO)
        {
            try
            {
                Municipio c = new Municipio();
                c.Nombre = DTO.Nombre;
                c.MunicipioId = DTO.MunicipioId;
                if (DTO.Departamento != null)
                {
                    c.Departamento = Departamento.MapeoDTOToDAL(DTO.Departamento);
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
        public static MunicipioDTO MapeoDALToDTO(Municipio DAL)
        {
            try
            {
                MunicipioDTO c = new MunicipioDTO();
                c.Nombre = DAL.Nombre;
                c.MunicipioId = DAL.MunicipioId;
                if (DAL.Departamento != null)
                {
                    c.Departamento = Departamento.MapeoDALToDTO(DAL.Departamento);
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
