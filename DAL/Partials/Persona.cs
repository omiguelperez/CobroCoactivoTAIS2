using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class Persona
    {
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static Persona MapeoDTOToDAL(PersonaDTO DTO)
        {
            try
            {
                Persona c = new Persona();
                c.Apellidos = DTO.Apellidos;
                c.Direccion = DTO.Direccion;
                c.Identificacion = DTO.Identificacion;
                c.Nombres = DTO.Nombres;
                c.PersonaId = DTO.PersonaId;
                c.Sexo = DTO.Sexo;
                c.Telefono = DTO.Telefono;
                c.UpdateAt = DTO.UpdateAt;
                c.CreatedAt = DTO.CreatedAt;
                c.TipoPersonaId = DTO.TipoPersonaId;
                if (c.TipoPersona != null)
                {
                    c.TipoPersona = TipoPersona.MapeoDTOToDAL(DTO.TipoPersona);
                }
                c.Nacionalidad = DTO.Nacionalidad;
                c.PaisNacimiento = DTO.PaisNacimiento;
                c.PaisCorrespondencia = DTO.PaisCorrespondencia;
                c.Departamento = DTO.Departamento;
                if (DTO.Municipio!=null)
                {
                    c.Municipio = Municipio.MapeoDTOToDAL(DTO.Municipio);
                }
                if (DTO.Pais != null)
                {
                    c.Pais = Pais.MapeoDTOToDAL(DTO.Pais);
                }
                c.MunicipioId = DTO.MunicipioId;
                c.PaisId = DTO.PaisId;
                c.Email = DTO.Email;
                c.FechaNacimiento = DTO.FechaNacimiento;
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
        /// <param name="DAL">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static PersonaDTO MapeoDALToDTO(Persona DAL)
        {
            try
            {

                PersonaDTO c = new PersonaDTO();
                c.Apellidos = DAL.Apellidos;
                c.Direccion = DAL.Direccion;
                c.Identificacion = DAL.Identificacion;
                c.Nombres = DAL.Nombres;
                c.PersonaId = DAL.PersonaId;
                c.Sexo = DAL.Sexo;
                c.Telefono = DAL.Telefono;
                c.UpdateAt = DAL.UpdateAt;
                c.CreatedAt = DAL.CreatedAt;
                c.TipoPersonaId = DAL.TipoPersonaId;
                if (c.TipoPersona != null)
                {
                    c.TipoPersona = TipoPersona.MapeoDALToDTO(DAL.TipoPersona);
                }
                c.Nacionalidad = DAL.Nacionalidad;
                c.PaisNacimiento = DAL.PaisNacimiento;
                c.PaisCorrespondencia = DAL.PaisCorrespondencia;
                c.Departamento = DAL.Departamento;
                if (DAL.Municipio != null)
                {
                    c.Municipio = Municipio.MapeoDALToDTO(DAL.Municipio);
                }
                if (DAL.Pais != null)
                {
                    c.Pais = Pais.MapeoDALToDTO(DAL.Pais);
                }
                c.MunicipioId = DAL.MunicipioId;
                c.PaisId = DAL.PaisId;
                c.Email = DAL.Email;
                c.FechaNacimiento = DAL.FechaNacimiento;
                return c;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
