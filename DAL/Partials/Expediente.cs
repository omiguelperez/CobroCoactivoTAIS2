using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class Expediente
    {
        /// <summary>
        /// Este metodo convierte un DTO a DAL
        /// </summary>
        /// <param name="DTO">Parametro DTO</param>
        /// <returns>Objeto tipo DAL</returns>
        public static Expediente MapeoDTOToDAL(ExpedienteDTO DTO)
        {
            try
            {
                Expediente expediente = new Expediente();
                expediente.ExpedienteId = DTO.ExpedienteId;
                expediente.UpdateAt = DTO.UpdateAt;
                expediente.CreatedAt = DTO.CreatedAt;
                expediente.Cuantia = DTO.Cuantia;
                expediente.Descripcion = DTO.Descripcion;
                expediente.DireccionEjecutado = DTO.DireccionEjecutado;
                expediente.DireccionTituloEjecutivo = DTO.DireccionTituloEjecutivo;
                expediente.EntidadEncargada = DTO.EntidadEncargada;
                expediente.FechaRadicacion = DTO.FechaRadicacion;
                expediente.Identificacion = DTO.Identificacion;
                expediente.NaturalezaObligacion = DTO.NaturalezaObligacion;
                expediente.Nombre = DTO.Nombre;

                expediente.UbicacionExpediente = DTO.UbicacionExpediente;
                //expediente.ObligacionId = DTO.ObligacionId;
                return expediente;

            }catch(Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DAL"></param>
        /// <returns></returns>
        public static ExpedienteDTO MapeoDALToDTO(Expediente DAL)
        {
            try
            {
                ExpedienteDTO expediente = new ExpedienteDTO();
                expediente.ExpedienteId = DAL.ExpedienteId;
                expediente.UpdateAt = DAL.UpdateAt;
                expediente.CreatedAt = DAL.CreatedAt;
                expediente.Cuantia = DAL.Cuantia;
                expediente.Descripcion = DAL.Descripcion;
                expediente.DireccionEjecutado = DAL.DireccionEjecutado;
                expediente.DireccionTituloEjecutivo = DAL.DireccionTituloEjecutivo;
                expediente.EntidadEncargada = DAL.EntidadEncargada;
                expediente.FechaRadicacion = DAL.FechaRadicacion;
                expediente.Identificacion = DAL.Identificacion;
                expediente.NaturalezaObligacion = DAL.NaturalezaObligacion;
                expediente.Nombre = DAL.Nombre;
                //expediente.Obligacion = Obligacion.MapeoDALToDTO(DAL.Obligacion);
                expediente.UbicacionExpediente = DAL.UbicacionExpediente;
                // expediente.ObligacionId = DAL.ObligacionId;
                return expediente;

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
