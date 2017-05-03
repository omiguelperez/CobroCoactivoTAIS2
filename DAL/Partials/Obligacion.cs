using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL.Infrastructure;

namespace DAL
{
    public partial class Obligacion
    {
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static Obligacion MapeoDTOToDAL(ObligacionDTO DTO)
        {
            try
            {
            Obligacion obligacion = new Obligacion();
            obligacion.ObligacionId = DTO.ObligacionId;
            obligacion.UpdateAt = DTO.UpdateAt;
            obligacion.CreatedAt = DTO.CreatedAt;
            obligacion.Cuantia = DTO.Cuantia;
            obligacion.Dueda = DTO.Dueda;
            obligacion.Estado = DTO.Estado;
            if (DTO.Expediente != null)
            {
                obligacion.Expediente = Expediente.MapeoDTOToDAL(DTO.Expediente);
            }
            if (DTO.Persona != null)
            {
                obligacion.Persona = Persona.MapeoDTOToDAL(DTO.Persona);
            }
            if (DTO.TipoObligacion != null)
            {
                obligacion.TipoObligacion = TipoObligacion.MapeoDTOToDAL(DTO.TipoObligacion);
            }
            obligacion.FechaPreinscripcion = DTO.FechaPreinscripcion;
            obligacion.PersonaId = DTO.PersonaId;
            obligacion.ExpedienteId = DTO.ExpedienteId;
            obligacion.TipoObligacionId = DTO.TipoObligacionId;
            return obligacion;

            }catch(Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DAL">Parametro DAL</param>
        /// <returns>Objeto tipo DAL</returns>
        public static ObligacionDTO MapeoDALToDTO(Obligacion DAL)
        {
            try
            {
                ObligacionDTO obligacion = new ObligacionDTO();
                obligacion.ObligacionId = DAL.ObligacionId;
                obligacion.UpdateAt = DAL.UpdateAt;
                obligacion.CreatedAt = DAL.CreatedAt;
                obligacion.Cuantia = DAL.Cuantia;
                obligacion.Dueda = DAL.Dueda;
                obligacion.Estado = DAL.Estado;
                if (DAL.Expediente != null)
                {
                    obligacion.Expediente = Expediente.MapeoDALToDTO(DAL.Expediente);
                }
                if (DAL.Persona != null)
                {
                    obligacion.Persona = Persona.MapeoDALToDTO(DAL.Persona);
                }
                if (DAL.TipoObligacion!=null)
                {
                    obligacion.TipoObligacion = TipoObligacion.MapeoDALToDTO(DAL.TipoObligacion);
                }
                obligacion.FechaPreinscripcion = DAL.FechaPreinscripcion;
                obligacion.PersonaId = DAL.PersonaId;
                obligacion.ExpedienteId = DAL.ExpedienteId;
                obligacion.TipoObligacionId = DAL.TipoObligacionId;
                return obligacion;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Este metodo Convierte una Lista DTO de Cobros a DAL, Recuerde que Para Mapear Una SubLista desde el controlador lo puede hacer
        /// </summary>
        /// <param name="ListaDTO">Lista De tipo DTO</param>
        /// <returns>Lista de Tipo DAL</returns>
        public static List<Obligacion> ConvertList(List<ObligacionDTO> ListaDTO)
        {
            try
            {
                List<Obligacion> Obligaciones = new List<Obligacion>();
                foreach (ObligacionDTO item in ListaDTO)
                {
                    Obligaciones.Add(MapeoDTOToDAL(item));
                }
                return Obligaciones;

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
